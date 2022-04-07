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
            this.CPUMessageChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.CPUThermometer = new UI.MyThermometer();
            this.fanPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fanPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CPUMessageChart
            // 
            this.CPUMessageChart.Location = new System.Drawing.Point(0, 89);
            this.CPUMessageChart.Name = "CPUMessageChart";
            this.CPUMessageChart.Size = new System.Drawing.Size(407, 239);
            this.CPUMessageChart.TabIndex = 1;
            // 
            // CPUThermometer
            // 
            this.CPUThermometer.BackColor = System.Drawing.SystemColors.Control;
            this.CPUThermometer.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CPUThermometer.GlassTubeColor = System.Drawing.Color.LightGray;
            this.CPUThermometer.LeftTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.CPUThermometer.Location = new System.Drawing.Point(38, 433);
            this.CPUThermometer.MaxValue = new decimal(new int[] {
            90,
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
            this.fanPictureBox.Location = new System.Drawing.Point(480, 402);
            this.fanPictureBox.Name = "fanPictureBox";
            this.fanPictureBox.Size = new System.Drawing.Size(125, 85);
            this.fanPictureBox.TabIndex = 5;
            this.fanPictureBox.TabStop = false;
            // 
            // CPUBurner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.fanPictureBox);
            this.Controls.Add(this.CPUThermometer);
            this.Controls.Add(this.CPUMessageChart);
            this.Name = "CPUBurner";
            this.Size = new System.Drawing.Size(743, 586);
            ((System.ComponentModel.ISupportInitialize)(this.fanPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart CPUMessageChart;
        private MyThermometer CPUThermometer;
        private PictureBox fanPictureBox;
    }
}
