namespace UI.TestPage
{
    partial class MemoryBurner
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
            this.memoryUseRateChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.memoryUseBar = new UI.UseRateBar();
            this.progressBar = new ReaLTaiizor.Controls.AloneProgressBar();
            this.progressLabel = new ReaLTaiizor.Controls.BigLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoryUseRateChart
            // 
            this.memoryUseRateChart.Location = new System.Drawing.Point(155, 128);
            this.memoryUseRateChart.Name = "memoryUseRateChart";
            this.memoryUseRateChart.Size = new System.Drawing.Size(384, 188);
            this.memoryUseRateChart.TabIndex = 0;
            // 
            // memoryUseBar
            // 
            this.memoryUseBar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.memoryUseBar.Font = new System.Drawing.Font("宋体", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.memoryUseBar.ForeColor = System.Drawing.Color.Black;
            this.memoryUseBar.Location = new System.Drawing.Point(20, 322);
            this.memoryUseBar.Maximum = ((long)(100));
            this.memoryUseBar.MinimumSize = new System.Drawing.Size(100, 100);
            this.memoryUseBar.Name = "memoryUseBar";
            this.memoryUseBar.PercentColor = System.Drawing.Color.Black;
            this.memoryUseBar.ProgressColor1 = System.Drawing.Color.Brown;
            this.memoryUseBar.ProgressColor2 = System.Drawing.Color.Purple;
            this.memoryUseBar.ProgressShape = UI.UseRateBar._ProgressShape.Round;
            this.memoryUseBar.Size = new System.Drawing.Size(198, 198);
            this.memoryUseBar.TabIndex = 1;
            this.memoryUseBar.Text = "内存使用率";
            this.memoryUseBar.Value = ((long)(0));
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar.BackgroundColor = System.Drawing.Color.Green;
            this.progressBar.BorderColor = System.Drawing.Color.DodgerBlue;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(17, 20);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(689, 10);
            this.progressBar.Stripes = System.Drawing.Color.DarkGreen;
            this.progressBar.TabIndex = 8;
            this.progressBar.Text = "aloneProgressBar1";
            this.progressBar.Value = 0;
            // 
            // progressLabel
            // 
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.progressLabel.Location = new System.Drawing.Point(17, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(689, 20);
            this.progressLabel.TabIndex = 9;
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.progressLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.panel1.Size = new System.Drawing.Size(723, 33);
            this.panel1.TabIndex = 10;
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(17, 76);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(143, 18);
            this.bigLabel1.TabIndex = 11;
            this.bigLabel1.Text = "60s内内存利用率";
            // 
            // MemoryBurner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.bigLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.memoryUseBar);
            this.Controls.Add(this.memoryUseRateChart);
            this.Name = "MemoryBurner";
            this.Size = new System.Drawing.Size(723, 562);
            this.Load += new System.EventHandler(this.MemoryBurner_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart memoryUseRateChart;
        private UseRateBar memoryUseBar;
        private ReaLTaiizor.Controls.AloneProgressBar progressBar;
        private ReaLTaiizor.Controls.BigLabel progressLabel;
        private Panel panel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
    }
}
