﻿namespace UI.TestPage
{
    partial class DiskBadSector
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.disksPanel = new System.Windows.Forms.Panel();
            this.progressBar = new ReaLTaiizor.Controls.AloneProgressBar();
            this.progressLabel = new ReaLTaiizor.Controls.BigLabel();
            this.SuspendLayout();
            // 
            // disksPanel
            // 
            this.disksPanel.Location = new System.Drawing.Point(215, 280);
            this.disksPanel.Name = "disksPanel";
            this.disksPanel.Size = new System.Drawing.Size(250, 125);
            this.disksPanel.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar.BackgroundColor = System.Drawing.Color.Green;
            this.progressBar.BorderColor = System.Drawing.Color.DodgerBlue;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(0, 20);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(663, 10);
            this.progressBar.Stripes = System.Drawing.Color.DarkGreen;
            this.progressBar.TabIndex = 1;
            this.progressBar.Text = "aloneProgressBar1";
            this.progressBar.Value = 50;
            // 
            // progressLabel
            // 
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.progressLabel.Location = new System.Drawing.Point(0, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(663, 20);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "bigLabel1";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DiskBadSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.disksPanel);
            this.Name = "DiskBadSector";
            this.Size = new System.Drawing.Size(663, 536);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel disksPanel;
        private ReaLTaiizor.Controls.AloneProgressBar progressBar;
        private ReaLTaiizor.Controls.BigLabel progressLabel;
    }
}