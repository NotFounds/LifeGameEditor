using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGameEditor
{
    public partial class LifeGame : Form
    {
        public LifeGame()
        {
            InitializeComponent();
        }

        private bool[,] tmp;
        private bool[,] Cell;
        private bool[,] playCell;
        private int SizeWidth;
        private int SizeHeight;
        public void SetBoard(bool[,] cell)
        {
            SizeWidth = cell.GetLength(1);
            SizeHeight = cell.GetLength(0);
            tmp = new bool[SizeHeight, SizeWidth];
            Cell = new bool[SizeHeight, SizeWidth];
            playCell = new bool[SizeHeight, SizeWidth];
            for (var y = 0; y < SizeHeight; ++y)
            {
                for (var x = 0; x < SizeWidth; ++x)
                {
                    Cell[y, x] = cell[y, x];
                    playCell[y, x] = cell[y, x];
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var dx = new int[] { -1, 0, 1, 1, 1, 0, -1, -1};
            var dy = new int[] { -1, -1, -1, 0, 1, 1, 1, 0};

            var flag = false;
            for (var y = 0; y < SizeHeight; ++y)
            {
                for (var x = 0; x < SizeWidth; ++x)
                {
                    var cnt = 0;
                    for (var i = 0; i < 8; ++i)
                    {
                        var nx = x + dx[i];
                        var ny = y + dy[i];
                        if (nx < 0 || nx >= SizeWidth) continue;
                        if (ny < 0 || ny >= SizeHeight) continue;
                        if (playCell[ny, nx])
                        {
                            flag = true;
                            ++cnt;
                        }
                    }

                    if (cnt == 3) tmp[y, x] = true;
                    else if (cnt == 2) tmp[y, x] = playCell[y, x];
                    else tmp[y, x] = false;
                }
            }

            for (var y = 0; y < SizeHeight; ++y)
            {
                for (var x = 0; x < SizeWidth; ++x)
                {
                    playCell[y, x] = tmp[y, x];
                }
            }

            if (!flag)
            {
                timer.Stop();
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var pen = new Pen(Brushes.Black, 1);
            var width = pictureBox1.Size.Width;
            var height = pictureBox1.Size.Height;

            // Draw cells
            for (var y = 0; y < SizeHeight; ++y)
            {
                for (var x = 0; x < SizeWidth; ++x)
                {
                    Brush brush;
                    if (playCell[y, x])
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

            // Draw grid lines
            for (var x = 0; x < SizeWidth; ++x)
                g.DrawLine(pen, x * width / SizeWidth, 0, x * width / SizeWidth, height);
            for (var y = 0; y < SizeHeight; ++y)
                g.DrawLine(pen, 0, y * height / SizeHeight, width, y * height / SizeHeight);

            g.DrawLine(pen, width - 1, 0, width - 1, height);
            g.DrawLine(pen, 0, height - 1, width, height - 1);
        }

        private void startSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (var y = 0; y < SizeHeight; ++y)
            {
                for (var x = 0; x < SizeWidth; ++x)
                {
                    playCell[y, x] = Cell[y, x];
                }
            }
            timer.Start();
        }
    }
}
