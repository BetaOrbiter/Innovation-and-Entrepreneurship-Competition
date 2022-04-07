namespace UI.MyControl
{
    partial class MACAddressControl
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
            this.ProgressBar = new UI.MyControl.MyWaitCircleBar();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.AnimationSpeed = 5;
            this.ProgressBar.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.ProgressBar.FilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.ProgressBar.FilledColorAlpha = 130;
            this.ProgressBar.FilledThickness = 4;
            this.ProgressBar.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.ProgressBar.IsAnimated = true;
            this.ProgressBar.Location = new System.Drawing.Point(185, 12);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Percentage = 50;
            this.ProgressBar.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.ProgressBar.ShowText = false;
            this.ProgressBar.Size = new System.Drawing.Size(20, 20);
            this.ProgressBar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.ProgressBar.TabIndex = 5;
            this.ProgressBar.TextColor = System.Drawing.Color.Gray;
            this.ProgressBar.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ProgressBar.TextSize = 25;
            this.ProgressBar.UnFilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.ProgressBar.UnfilledThickness = 24;
            // 
            // MACAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProgressBar);
            this.Name = "MACAddressControl";
            this.Size = new System.Drawing.Size(737, 572);
            this.ResumeLayout(false);

        }

        #endregion

        private MyWaitCircleBar ProgressBar;
    }
}
