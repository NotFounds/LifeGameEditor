namespace LifeGameEditor
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLifeGameOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLifeGameSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patternPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPattern = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.playPToolStripMenuItem,
            this.settingsSToolStripMenuItem,
            this.helpHToolStripMenuItem,
            this.versionVToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openLifeGameOToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveLifeGameSToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitXToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fileFToolStripMenuItem.Text = "File (&F)";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.newToolStripMenuItem.Text = "New LifeGame (&N)";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openLifeGameOToolStripMenuItem
            // 
            this.openLifeGameOToolStripMenuItem.Name = "openLifeGameOToolStripMenuItem";
            this.openLifeGameOToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.openLifeGameOToolStripMenuItem.Text = "Open LifeGame (&O)";
            this.openLifeGameOToolStripMenuItem.Click += new System.EventHandler(this.openLifeGameOToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // saveLifeGameSToolStripMenuItem
            // 
            this.saveLifeGameSToolStripMenuItem.Name = "saveLifeGameSToolStripMenuItem";
            this.saveLifeGameSToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveLifeGameSToolStripMenuItem.Text = "Save LifeGame (&S)";
            this.saveLifeGameSToolStripMenuItem.Click += new System.EventHandler(this.saveLifeGameSToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // exitXToolStripMenuItem
            // 
            this.exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
            this.exitXToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitXToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exitXToolStripMenuItem.Text = "Exit (&X)";
            this.exitXToolStripMenuItem.Click += new System.EventHandler(this.exitXToolStripMenuItem_Click);
            // 
            // settingsSToolStripMenuItem
            // 
            this.settingsSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patternPToolStripMenuItem,
            this.resetRToolStripMenuItem});
            this.settingsSToolStripMenuItem.Name = "settingsSToolStripMenuItem";
            this.settingsSToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.settingsSToolStripMenuItem.Text = "Settings (&S)";
            // 
            // patternPToolStripMenuItem
            // 
            this.patternPToolStripMenuItem.Name = "patternPToolStripMenuItem";
            this.patternPToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.patternPToolStripMenuItem.Text = "Pattern (&P)";
            this.patternPToolStripMenuItem.Click += new System.EventHandler(this.patternPToolStripMenuItem_Click);
            // 
            // resetRToolStripMenuItem
            // 
            this.resetRToolStripMenuItem.Name = "resetRToolStripMenuItem";
            this.resetRToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.resetRToolStripMenuItem.Text = "Reset (&R)";
            this.resetRToolStripMenuItem.Click += new System.EventHandler(this.resetRToolStripMenuItem_Click);
            // 
            // helpHToolStripMenuItem
            // 
            this.helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
            this.helpHToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.helpHToolStripMenuItem.Text = "Help (&H)";
            this.helpHToolStripMenuItem.Click += new System.EventHandler(this.helpHToolStripMenuItem_Click);
            // 
            // versionVToolStripMenuItem
            // 
            this.versionVToolStripMenuItem.Name = "versionVToolStripMenuItem";
            this.versionVToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.versionVToolStripMenuItem.Text = "Version (&V)";
            this.versionVToolStripMenuItem.Click += new System.EventHandler(this.versionVToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelPoint,
            this.toolStripStatusLabelPattern});
            this.statusStrip.Location = new System.Drawing.Point(0, 824);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelPoint
            // 
            this.toolStripStatusLabelPoint.Name = "toolStripStatusLabelPoint";
            this.toolStripStatusLabelPoint.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabelPoint.Text = "(000, 000)";
            // 
            // toolStripStatusLabelPattern
            // 
            this.toolStripStatusLabelPattern.Name = "toolStripStatusLabelPattern";
            this.toolStripStatusLabelPattern.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.toolStripStatusLabelPattern.Size = new System.Drawing.Size(142, 17);
            this.toolStripStatusLabelPattern.Text = "cell[#X][#Y] = 1;";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 800);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // playPToolStripMenuItem
            // 
            this.playPToolStripMenuItem.Name = "playPToolStripMenuItem";
            this.playPToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.playPToolStripMenuItem.Text = "Play (&P)";
            this.playPToolStripMenuItem.Click += new System.EventHandler(this.playPToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveAsToolStripMenuItem.Text = "Save As (&A)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 846);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "LifeGameEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLifeGameOToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveLifeGameSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpHToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPoint;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPattern;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem patternPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}

