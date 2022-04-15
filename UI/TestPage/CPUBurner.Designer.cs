namespace UI.TestPage
{
    partial class CPUBurner
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
            this.CPUUseRateChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.CPUThermometer = new UI.MyThermometer();
            this.fanPictureBox = new System.Windows.Forms.PictureBox();
            this.progressBar = new ReaLTaiizor.Controls.AloneProgressBar();
            this.progressLabel = new ReaLTaiizor.Controls.BigLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fanPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CPUUseRateChart
            // 
            this.CPUUseRateChart.Location = new System.Drawing.Point(133, 197);
            this.CPUUseRateChart.Name = "CPUUseRateChart";
            this.CPUUseRateChart.Size = new System.Drawing.Size(407, 239);
            this.CPUUseRateChart.TabIndex = 1;
            // 
            // CPUThermometer
            // 
            this.CPUThermometer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.CPUThermometer.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CPUThermometer.GlassTubeColor = System.Drawing.Color.LightGray;
            this.CPUThermometer.LeftTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.CPUThermometer.Location = new System.Drawing.Point(70, 449);
            this.CPUThermometer.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CPUThermometer.MercuryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.CPUThermometer.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CPUThermometer.Name = "CPUThermometer";
            this.CPUThermometer.RightTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.None;
            this.CPUThermometer.Size = new System.Drawing.Size(50, 118);
            this.CPUThermometer.SplitCount = 1;
            this.CPUThermometer.TabIndex = 2;
            this.CPUThermometer.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // fanPictureBox
            // 
            this.fanPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fanPictureBox.Location = new System.Drawing.Point(464, 461);
            this.fanPictureBox.Name = "fanPictureBox";
            this.fanPictureBox.Size = new System.Drawing.Size(125, 85);
            this.fanPictureBox.TabIndex = 5;
            this.fanPictureBox.TabStop = false;
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
            this.progressBar.Size = new System.Drawing.Size(709, 10);
            this.progressBar.Stripes = System.Drawing.Color.DarkGreen;
            this.progressBar.TabIndex = 6;
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
            this.progressLabel.Size = new System.Drawing.Size(709, 20);
            this.progressLabel.TabIndex = 7;
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
            this.panel1.Size = new System.Drawing.Size(743, 33);
            this.panel1.TabIndex = 8;
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(0, 95);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(134, 18);
            this.bigLabel1.TabIndex = 9;
            this.bigLabel1.Text = "60s内CPU利用率";
            // 
            // CPUBurner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.bigLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fanPictureBox);
            this.Controls.Add(this.CPUThermometer);
            this.Controls.Add(this.CPUUseRateChart);
            this.Name = "CPUBurner";
            this.Size = new System.Drawing.Size(743, 586);
            ((System.ComponentModel.ISupportInitialize)(this.fanPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart CPUUseRateChart;
        private MyThermometer CPUThermometer;
        private PictureBox fanPictureBox;
        private ReaLTaiizor.Controls.AloneProgressBar progressBar;
        private ReaLTaiizor.Controls.BigLabel progressLabel;
        private Panel panel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
    }
}
