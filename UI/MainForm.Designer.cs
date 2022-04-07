namespace UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BaseForm = new UI.MyForm();
            this.MainLayout = new UI.MyDockLayout();
            this.testStep = new UI.MyStep();
            this.TitlePanel = new ReaLTaiizor.Controls.NightPanel();
            this.myClock1 = new UI.MyClock();
            this.progressLabel = new ReaLTaiizor.Controls.BigLabel();
            this.StopButton = new ReaLTaiizor.Controls.RoyalEllipseButton();
            this.NowTestItem = new ReaLTaiizor.Controls.BigLabel();
            this.testProgressBar = new UI.MyProgressBar();
            this.testPageCard = new UI.MyCardLayout();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.floatBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.BaseForm.SuspendLayout();
            this.MainLayout.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.floatBoxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.BaseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.BaseForm.Controls.Add(this.MainLayout);
            this.BaseForm.Controls.Add(this.nightControlBox1);
            this.BaseForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseForm.DrawIcon = true;
            this.BaseForm.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BaseForm.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(110)))), ((int)(((byte)(147)))));
            this.BaseForm.Location = new System.Drawing.Point(0, 0);
            this.BaseForm.MinimumSize = new System.Drawing.Size(100, 42);
            this.BaseForm.Name = "BaseForm";
            this.BaseForm.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.BaseForm.Size = new System.Drawing.Size(1050, 900);
            this.BaseForm.TabIndex = 0;
            this.BaseForm.Text = "AutoMaticx86";
            this.BaseForm.TextAlignment = UI.MyForm.Alignment.Left;
            this.BaseForm.TitleBarTextColor = System.Drawing.Color.Gainsboro;
            // 
            // MainLayout
            // 
            this.MainLayout.Controls.Add(this.testStep);
            this.MainLayout.Controls.Add(this.TitlePanel);
            this.MainLayout.Controls.Add(this.testPageCard);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.DockFlags = new int[] {
        0,
        0,
        1,
        0,
        0,
        0,
        0,
        0};
            this.MainLayout.Location = new System.Drawing.Point(0, 31);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Size = new System.Drawing.Size(1050, 869);
            this.MainLayout.TabIndex = 1;
            // 
            // testStep
            // 
            this.testStep.BackColor = System.Drawing.Color.Transparent;
            this.testStep.Dock = System.Windows.Forms.DockStyle.Left;
            this.testStep.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.testStep.ImgCompleted = null;
            this.testStep.LineWidth = 2;
            this.testStep.Location = new System.Drawing.Point(0, 130);
            this.testStep.Margin = new System.Windows.Forms.Padding(0);
            this.testStep.Name = "testStep";
            this.testStep.Size = new System.Drawing.Size(256, 739);
            this.testStep.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.testStep.StepFontColor = System.Drawing.Color.White;
            this.testStep.StepForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.testStep.StepIndex = 0;
            this.testStep.Steps = new string[] {
        "配置校验和信息检查",
        "硬盘坏道测试",
        "音频接口测试",
        "USB及串口测试",
        "网口测试及MAC检查",
        "硬盘压力测试",
        "CPU压力测试",
        "内存压力测试"};
            this.testStep.StepWidth = 25;
            this.testStep.TabIndex = 3;
            this.testStep.IndexChecked += new System.EventHandler(this.myStep2_IndexChecked);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.myClock1);
            this.TitlePanel.Controls.Add(this.progressLabel);
            this.TitlePanel.Controls.Add(this.StopButton);
            this.TitlePanel.Controls.Add(this.NowTestItem);
            this.TitlePanel.Controls.Add(this.testProgressBar);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TitlePanel.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.TitlePanel.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.TitlePanel.Size = new System.Drawing.Size(1050, 130);
            this.TitlePanel.TabIndex = 2;
            // 
            // myClock1
            // 
            this.myClock1.Dock = System.Windows.Forms.DockStyle.Left;
            this.myClock1.Location = new System.Drawing.Point(0, 0);
            this.myClock1.Margin = new System.Windows.Forms.Padding(0);
            this.myClock1.Name = "myClock1";
            this.myClock1.Size = new System.Drawing.Size(256, 130);
            this.myClock1.TabIndex = 6;
            this.myClock1.Text = "myClock1";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.progressLabel.Location = new System.Drawing.Point(259, 20);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(148, 30);
            this.progressLabel.TabIndex = 5;
            this.progressLabel.Text = "bigLabel1";
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.StopButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.StopButton.BorderThickness = 3;
            this.StopButton.DrawBorder = true;
            this.StopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.StopButton.HotTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.StopButton.Image = null;
            this.StopButton.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            this.StopButton.Location = new System.Drawing.Point(1000, 80);
            this.StopButton.Name = "StopButton";
            this.StopButton.PressedColor = System.Drawing.Color.IndianRed;
            this.StopButton.PressedForeColor = System.Drawing.Color.Black;
            this.StopButton.Size = new System.Drawing.Size(50, 50);
            this.StopButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "停止";
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // NowTestItem
            // 
            this.NowTestItem.BackColor = System.Drawing.Color.Transparent;
            this.NowTestItem.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NowTestItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.NowTestItem.Location = new System.Drawing.Point(256, 95);
            this.NowTestItem.Margin = new System.Windows.Forms.Padding(0);
            this.NowTestItem.Name = "NowTestItem";
            this.NowTestItem.Size = new System.Drawing.Size(741, 35);
            this.NowTestItem.TabIndex = 4;
            this.NowTestItem.Text = "bigLabel1";
            this.NowTestItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // testProgressBar
            // 
            this.testProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.testProgressBar.BaseColor = System.Drawing.Color.LightGray;
            this.testProgressBar.DarkerProgress = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            this.testProgressBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.testProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.testProgressBar.Location = new System.Drawing.Point(432, 0);
            this.testProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.testProgressBar.Maximum = 100;
            this.testProgressBar.Name = "testProgressBar";
            this.testProgressBar.Pattern = true;
            this.testProgressBar.PercentSign = false;
            this.testProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.testProgressBar.ShowBalloon = true;
            this.testProgressBar.Size = new System.Drawing.Size(618, 50);
            this.testProgressBar.TabIndex = 0;
            this.testProgressBar.Text = "testProgressBar";
            this.testProgressBar.Value = 0;
            // 
            // testPageCard
            // 
            this.testPageCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testPageCard.Location = new System.Drawing.Point(256, 130);
            this.testPageCard.Margin = new System.Windows.Forms.Padding(0);
            this.testPageCard.Name = "testPageCard";
            this.testPageCard.Size = new System.Drawing.Size(794, 739);
            this.testPageCard.TabIndex = 1;
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.DefaultLocation = false;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = false;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(911, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 0;
            // 
            // floatBoxMenu
            // 
            this.floatBoxMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.floatBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暂停ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.floatBoxMenu.Name = "floatBoxMenu";
            this.floatBoxMenu.Size = new System.Drawing.Size(109, 58);
            this.floatBoxMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.floatBoxMenu_MouseUp);
            // 
            // 暂停ToolStripMenuItem
            // 
            this.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem";
            this.暂停ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.暂停ToolStripMenuItem.Text = "暂停";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.floatBoxMenu;
            this.notifyIcon.Text = "AutoMaticx86";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            this.notifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.floatBoxMenu_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1050, 900);
            this.Controls.Add(this.BaseForm);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1030);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoMaticx86";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.BaseForm.ResumeLayout(false);
            this.MainLayout.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.floatBoxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyForm BaseForm;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private MyDockLayout MainLayout;
        private ReaLTaiizor.Controls.NightPanel TitlePanel;
        private MyCardLayout testPageCard;
        private MyProgressBar testProgressBar;
        private ReaLTaiizor.Controls.RoyalEllipseButton StopButton;
        private MyStep testStep;
        private ReaLTaiizor.Controls.BigLabel NowTestItem;
        private ContextMenuStrip floatBoxMenu;
        private ToolStripMenuItem 暂停ToolStripMenuItem;
        private NotifyIcon notifyIcon;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ReaLTaiizor.Controls.BigLabel progressLabel;
        private MyClock myClock1;
    }
}