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
            this.SuspendLayout();
            // 
            // memoryUseRateChart
            // 
            this.memoryUseRateChart.Location = new System.Drawing.Point(140, 111);
            this.memoryUseRateChart.Name = "memoryUseRateChart";
            this.memoryUseRateChart.Size = new System.Drawing.Size(384, 188);
            this.memoryUseRateChart.TabIndex = 0;
            // 
            // memoryUseBar
            // 
            this.memoryUseBar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.memoryUseBar.Font = new System.Drawing.Font("Segoe Print", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            // MemoryBurner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.memoryUseBar);
            this.Controls.Add(this.memoryUseRateChart);
            this.Name = "MemoryBurner";
            this.Size = new System.Drawing.Size(723, 562);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart memoryUseRateChart;
        private UseRateBar memoryUseBar;
    }
}
