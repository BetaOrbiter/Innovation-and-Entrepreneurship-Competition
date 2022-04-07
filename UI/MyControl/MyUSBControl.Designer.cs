namespace UI.MyControl
{
    partial class MyUSBControl
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
            this.usbActRateBar = new UI.UseRateBar();
            this.SuspendLayout();
            // 
            // usbActRateBar
            // 
            this.usbActRateBar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.usbActRateBar.Font = new System.Drawing.Font("Segoe Print", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usbActRateBar.Location = new System.Drawing.Point(155, 45);
            this.usbActRateBar.Maximum = ((long)(100));
            this.usbActRateBar.MinimumSize = new System.Drawing.Size(100, 100);
            this.usbActRateBar.Name = "usbActRateBar";
            this.usbActRateBar.PercentColor = System.Drawing.Color.Black;
            this.usbActRateBar.ProgressColor1 = System.Drawing.Color.Brown;
            this.usbActRateBar.ProgressColor2 = System.Drawing.Color.Purple;
            this.usbActRateBar.ProgressShape = UI.UseRateBar._ProgressShape.Round;
            this.usbActRateBar.Size = new System.Drawing.Size(100, 100);
            this.usbActRateBar.TabIndex = 2;
            this.usbActRateBar.Text = "U盘活动时间";
            this.usbActRateBar.Value = ((long)(50));
            // 
            // MyUSBControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usbActRateBar);
            this.Name = "MyUSBControl";
            this.Size = new System.Drawing.Size(522, 455);
            this.ResumeLayout(false);

        }

        #endregion

        private UseRateBar usbActRateBar;
    }
}
