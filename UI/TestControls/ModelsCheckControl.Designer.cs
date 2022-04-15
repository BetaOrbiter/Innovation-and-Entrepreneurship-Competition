namespace UI.MyControl
{
    partial class ModelsCheckControl
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
            this.progressBar = new UI.MyControl.MyWaitCircleBar();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.AnimationSpeed = 5;
            this.progressBar.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.progressBar.FilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.progressBar.FilledColorAlpha = 130;
            this.progressBar.FilledThickness = 4;
            this.progressBar.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.progressBar.IsAnimated = true;
            this.progressBar.Location = new System.Drawing.Point(363, 156);
            this.progressBar.Name = "progressBar";
            this.progressBar.Percentage = 50;
            this.progressBar.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.progressBar.ShowText = false;
            this.progressBar.Size = new System.Drawing.Size(20, 20);
            this.progressBar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.progressBar.TabIndex = 0;
            this.progressBar.TextColor = System.Drawing.Color.Gray;
            this.progressBar.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.progressBar.TextSize = 25;
            this.progressBar.UnFilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.progressBar.UnfilledThickness = 24;
            // 
            // MemoryCheckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Name = "MemoryCheckControl";
            this.Size = new System.Drawing.Size(688, 525);
            this.ResumeLayout(false);

        }

        #endregion

        private MyWaitCircleBar progressBar;
    }
}
