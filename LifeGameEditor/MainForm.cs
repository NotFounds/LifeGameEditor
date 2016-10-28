using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace LifeGameEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const int SizeWidth = 40;
        private const int SizeHeight = 40;
        private bool[,] Cell;
        private bool isEditted = false;
        private bool isPutCell = false;
        private bool isSelect  = false;
        private bool drawFocus = false;
        private bool isClipped = false;
        private Point mousePos;
        private Rectangle select;
        private string pattern;
        private string fileName;
        private bool[,] clipBoard;

        private void Form1_Load(object sender, EventArgs e)
        {
            pattern = "cell[#X][#Y] = 1;";
            Initialize();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePos = ConvertPixelToPoint(e.Location);
            if (!CheckAlign(mousePos)) return;

            // paste
            if (isClipped)
            {
                for (var y = 0; y < select.Height; ++y)
                {
                    for (var x = 0; x < select.Width; ++x)
                    {
                        if (clipBoard[y, x])
                        {
                            var nx = x + mousePos.X;
                            var ny = y + mousePos.Y;
                            if (!CheckAlign(new Point(nx, ny))) continue;
                            Cell[ny, nx] = clipBoard[y, x];
                        }
                    }
                }
                isClipped = false;
                return;
            }
            
            isEditted = true;
            isPutCell = !Cell[mousePos.Y, mousePos.X];

            // reverse cell
            if (e.Button == MouseButtons.Left) Cell[mousePos.Y, mousePos.X] = !Cell[mousePos.Y, mousePos.X];

            if (e.Button == MouseButtons.Right)
            {
                select = new Rectangle(mousePos.X, mousePos.Y, 1, 1);
                isSelect = true;
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = ConvertPixelToPoint(e.Location);
            if (!CheckAlign(mousePos)) return;
            drawFocus = false;
            switch (e.Button)
            {
                case MouseButtons.None:
                    // Focus
                    drawFocus = true;
                    break;
                case MouseButtons.Left:
                    // Draw
                    Cell[mousePos.Y, mousePos.X] = isPutCell;
                    break;
                case MouseButtons.Right:
                    // Select
                    var diffX = Math.Abs(select.X - mousePos.X) + 1;
                    var diffY = Math.Abs(select.Y - mousePos.Y) + 1;
                    select.Width = diffX;
                    select.Height = diffY;
                    break;
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousePos = ConvertPixelToPoint(e.Location);
            if (!CheckAlign(mousePos)) return;
            isPutCell = false;
            isSelect  = false;
            if (e.Button == MouseButtons.Right)
            {
                var diffX = Math.Abs(select.X - mousePos.X) + 1;
                var diffY = Math.Abs(select.Y - mousePos.Y) + 1;
                select.X = Math.Max(Math.Min(select.X, mousePos.X), 0);
                select.Y = Math.Max(Math.Min(select.Y, mousePos.Y), 0);
                select.Width  = diffX;
                select.Height = diffY;

                clipBoard = new bool[diffY, diffX];
                for (var y = 0; y < diffY; ++y)
                {
                    for (var x = 0; x < diffX; ++x)
                    {
                        clipBoard[y, x] = Cell[y + select.Y, x + select.X];
                    }
                }
                isClipped = true;
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var pen = new Pen(Brushes.Black, 1);
            var width  = pictureBox1.Size.Width;
            var height = pictureBox1.Size.Height;

            // Draw cells
            for (var y = 0; y < SizeHeight; ++y)
            {
                for (var x = 0; x < SizeWidth; ++x)
                {
                    Brush brush;
                    if (Cell[y, x])
                    {
                        brush = Brushes.DarkGray;
                    }
                    else
                    {
                        brush = Brushes.White;
                    }
                    g.FillRectangle(brush, x * width / SizeWidth + 1, y * height / SizeHeight + 1, width / SizeWidth, height / SizeHeight);
                }
            }

            // Focus
            if (drawFocus && !isClipped) g.FillRectangle(Brushes.LightGreen, mousePos.X * width / SizeWidth + 1, mousePos.Y * height / SizeHeight + 1, width / SizeWidth, height / SizeHeight);

            // Draw clipboard
            if (isClipped)
            {
                for (var y = 0; y < select.Height; ++y)
                {
                    for (var x = 0; x < select.Width; ++x)
                    {
                        if (clipBoard[y, x])
                        {
                            var nx = x + mousePos.X;
                            var ny = y + mousePos.Y;
                            if (!CheckAlign(new Point(nx, ny))) continue;
                            g.FillRectangle(Brushes.LightCyan, nx * width / SizeWidth + 1, ny * height / SizeHeight + 1, width / SizeWidth, height / SizeHeight);
                        }
                    }
                }
            }
            
            // Draw grid lines
            for (var x = 0; x < SizeWidth; ++x)
                g.DrawLine(pen, x * width / SizeWidth, 0, x * width / SizeWidth, height);
            for (var y = 0; y < SizeHeight; ++y)
                g.DrawLine(pen, 0, y * height / SizeHeight, width, y * height / SizeHeight);

            g.DrawLine(pen, width - 1, 0, width - 1, height);
            g.DrawLine(pen, 0, height - 1, width, height - 1);

            // Draw selection
            var sx = Math.Max(Math.Min(select.X, mousePos.X), 0);
            var sy = Math.Max(Math.Min(select.Y, mousePos.Y), 0);
            if (isSelect) g.DrawRectangle(Pens.Red, sx * width / SizeWidth, sy * height / SizeHeight, select.Width * width / SizeWidth,  select.Height * height / SizeHeight);

            SetLabels();
        }

        private void Initialize()
        {
            Cell = new bool[SizeHeight, SizeWidth];
            isPutCell = false;
            isEditted = false;
            isSelect  = false;
            isClipped = false;
            drawFocus = false;
            mousePos = new Point(0, 0);
            fileName = "";
            SetLabels();
        }

        private void SetLabels()
        {
            this.Text = $"{(fileName != "" ? fileName : "*New file")} - LifeGameEditor";
            toolStripStatusLabelPoint.Text = $"({mousePos.X:d3}, {mousePos.Y:d3})";
            toolStripStatusLabelPattern.Text = $"{pattern}";
        }

        private void Open(string file)
        {
            Initialize();
            using (var sr = new StreamReader(file))
            {
                var p = sr.ReadLine();
                if (AnalysisPattern(p))
                {
                    pattern = p;

                    var expression = Regex.Escape(pattern);
                    Debug.WriteLine(expression);
                    expression = expression.Replace(@"\#X", @"(?<X>\d+)").Replace(@"\#x", @"(?<X>\d+)");
                    expression = expression.Replace(@"\#Y", @"(?<Y>\d+)").Replace(@"\#y", @"(?<Y>\d+)");
                    Debug.WriteLine(expression);
                    var reg = new Regex(expression);
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var match = reg.Match(line);
                        if (match.Success)
                        {
                            Debug.WriteLine(match.Length);
                            Debug.WriteLine(match.Groups["X"].Value);
                            int x, y;
                            if (!int.TryParse(match.Groups["X"].Value, out x)) continue;
                            if (!int.TryParse(match.Groups["Y"].Value, out y)) continue;
                            if (!CheckAlign(new Point(x, y))) continue;
                            Cell[y, x] = true;
                        }
                    }
                }
            }
            pictureBox1.Invalidate();
        }

        private void Save(string file)
        {
            using (var sw = new StreamWriter(fileName, false))
            {
                // write pattern
                sw.WriteLine(pattern);

                // write cells
                for (var y = 0; y < SizeHeight; ++y)
                {
                    for (var x = 0; x < SizeWidth; ++x)
                    {
                        if (Cell[y, x])
                        {
                            var line = pattern;
                            line = line.Replace("#X", x.ToString()).Replace("#x", x.ToString());
                            line = line.Replace("#Y", y.ToString()).Replace("#y", y.ToString());
                            sw.WriteLine(line);
                        }
                    }
                }
            }
        }

        private void ResetSettings()
        {
            pattern = "cell[#X][#Y] = 1;";
        }
        
        private bool Confirm()
        {
            return MessageBox.Show("Are you sure you want to delete the work that has not been saved.", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK;
        }

        private string GetFileName()
        {
            var ret = "LifeGame";
            if (!File.Exists(ret + ".life")) return ret + ".life";

            var i = 1;
            while (File.Exists(ret + i.ToString() + ".life")) ++i;
            return ret + i.ToString() + ".life";
        }

        private bool AnalysisPattern(string pattern)
        {
            if (pattern.Length == 0) return false;
            if (pattern.Where(c => c == '$').Count() % 2 != 0) return false;

            int pos = 0, cnt = 0;
            while ((pos = pattern.IndexOf('#', pos + 1)) != -1)
            {
                if (pos == pattern.Length - 1) return false;
                switch (pattern[pos + 1])
                {
                    case 'x':
                    case 'X':
                        cnt++;
                        break;
                    case 'y':
                    case 'Y':
                        cnt++;
                        break;
                    default:
                        return false;
                }
            }

            return cnt > 1;
        }

        private Point ConvertPixelToPoint(Point pos)
        {
            return new Point(pos.X * SizeWidth / pictureBox1.Width, pos.Y * SizeHeight / pictureBox1.Height);
        }

        private bool CheckAlign(Point pos)
        {
            if (pos.X < 0 || pos.X >= Width) return false;
            if (pos.Y < 0 || pos.Y >= Height) return false;
            return true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isEditted && !Confirm()) return;
            Initialize();
        }

        private void openLifeGameOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isEditted && !Confirm()) return;

            using (var ofs = new OpenFileDialog())
            {
                ofs.CheckFileExists = true;
                ofs.CheckPathExists = true;
                ofs.DefaultExt = ".life";
                if (ofs.ShowDialog() != DialogResult.OK) return;
                if (File.Exists(ofs.FileName))
                {
                    fileName = ofs.FileName;
                }
                else
                {
                    MessageBox.Show("The file does not exist.", "Warning", MessageBoxButtons.OK);
                    return;
                }
            }
            Open(fileName);
            SetLabels();
        }

        private void saveLifeGameSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AnalysisPattern(pattern)) return;
            if (fileName == null || fileName == "") fileName = GetFileName();
            if (File.Exists(fileName) && MessageBox.Show($"{fileName} already exists. Do you want to overwrite the file?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            Save(fileName);
            MessageBox.Show($"Saved! ({fileName})", "LifeGameEditor");
            isEditted = false;
            SetLabels();
        }
        
        private void patternPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var p = Interaction.InputBox("Input pattern", "Edit Pattern", "cell[#X][#Y] = 1;");
            if (AnalysisPattern(p)) pattern = p;
            else MessageBox.Show("The pattern is invalid.", "Warning");
            SetLabels();
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isEditted && !Confirm()) return;
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isEditted && !Confirm()) e.Cancel = true;
        }

        private void helpHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Left Click and Drag  : Edit Cell\n" 
                          + "Right Click and Drag : Select Cells and Paste by next Left Click\n"
                          + "Pattern :\n"
                          + "#x or #X are replaced the X position\n"
                          + "#y or #Y are replaced the Y position.", "Help");
        }

        private void versionVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 2.0\n"
                          + "Last Release: 10/27/2016\n"
                          + "Copyright © 2016 NotFounds", "Version");
        }

        private void resetRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetSettings();
        }

        private void playPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var lifegame = new LifeGame())
            {
                lifegame.SetBoard(Cell);
                lifegame.ShowDialog();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AnalysisPattern(pattern)) return;
            if (fileName == null || fileName == "") fileName = GetFileName();

            using (var sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.DefaultExt = ".life";
                sfd.FileName = fileName;
                if (sfd.ShowDialog() != DialogResult.OK) return;
                fileName = sfd.FileName;
            }

            if (File.Exists(fileName) && MessageBox.Show($"{fileName} already exists. Do you want to overwrite the file?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            Save(fileName);
            MessageBox.Show($"Saved! ({fileName})", "LifeGameEditor");
            isEditted = false;
            SetLabels();
        }
    }
}
