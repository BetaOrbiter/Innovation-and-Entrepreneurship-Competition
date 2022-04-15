namespace UI
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BaseForm = new UI.MyForm();
            this.programsLabel = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.smallLabel = new ReaLTaiizor.Controls.LostLabel();
            this.exitButton = new ReaLTaiizor.Controls.BigLabel();
            this.startButton = new ReaLTaiizor.Controls.BigLabel();
            this.TitleLabel = new ReaLTaiizor.Controls.BigLabel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.BaseForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.BaseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.BaseForm.Controls.Add(this.programsLabel);
            this.BaseForm.Controls.Add(this.bigLabel1);
            this.BaseForm.Controls.Add(this.smallLabel);
            this.BaseForm.Controls.Add(this.exitButton);
            this.BaseForm.Controls.Add(this.startButton);
            this.BaseForm.Controls.Add(this.TitleLabel);
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
            this.BaseForm.Text = "AutoMaticX86";
            this.BaseForm.TextAlignment = UI.MyForm.Alignment.Left;
            this.BaseForm.TitleBarTextColor = System.Drawing.Color.Gainsboro;
            // 
            // programsLabel
            // 
            this.programsLabel.BackColor = System.Drawing.Color.Transparent;
            this.programsLabel.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.programsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.programsLabel.Location = new System.Drawing.Point(345, 835);
            this.programsLabel.Name = "programsLabel";
            this.programsLabel.Size = new System.Drawing.Size(360, 56);
            this.programsLabel.TabIndex = 7;
            this.programsLabel.Text = "Programed by 卷不动了\r\n\r\n";
            this.programsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bigLabel1.Font = new System.Drawing.Font("方正粗黑宋简体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(947, 52);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(71, 34);
            this.bigLabel1.TabIndex = 6;
            this.bigLabel1.Text = "帮助";
            // 
            // smallLabel
            // 
            this.smallLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.smallLabel.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.smallLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.smallLabel.Location = new System.Drawing.Point(414, 297);
            this.smallLabel.Name = "smallLabel";
            this.smallLabel.Size = new System.Drawing.Size(222, 43);
            this.smallLabel.TabIndex = 5;
            this.smallLabel.Text = "AcutoMaticX86";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(10)))), ((int)(((byte)(100)))));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("方正粗黑宋简体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(240)))), ((int)(((byte)(171)))));
            this.exitButton.Location = new System.Drawing.Point(647, 598);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(258, 71);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "退出";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitButton.Click += new System.EventHandler(this.bigLabel2_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(10)))), ((int)(((byte)(100)))));
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.Font = new System.Drawing.Font("方正粗黑宋简体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(240)))), ((int)(((byte)(171)))));
            this.startButton.Location = new System.Drawing.Point(145, 598);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(258, 71);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "开始测试";
            this.startButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("方正粗黑宋简体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.TitleLabel.Location = new System.Drawing.Point(145, 201);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(760, 93);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "X86计算机自动测试软件";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.nightControlBox1.Location = new System.Drawing.Point(911, 1);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 1;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 900);
            this.Controls.Add(this.BaseForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1030);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.BaseForm.ResumeLayout(false);
            this.BaseForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyForm BaseForm;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private ReaLTaiizor.Controls.BigLabel TitleLabel;
        private ReaLTaiizor.Controls.LostLabel smallLabel;
        private ReaLTaiizor.Controls.BigLabel exitButton;
        private ReaLTaiizor.Controls.BigLabel startButton;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigLabel programsLabel;
    }
}