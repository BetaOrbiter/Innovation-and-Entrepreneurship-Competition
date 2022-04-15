namespace UI
{
    partial class MyDiskControl
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
            this.diskActRateBar = new UI.UseRateBar();
            this.SuspendLayout();
            // 
            // diskActRateBar
            // 
            this.diskActRateBar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.diskActRateBar.Font = new System.Drawing.Font("宋体", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.diskActRateBar.Location = new System.Drawing.Point(100, 69);
            this.diskActRateBar.Maximum = ((long)(100));
            this.diskActRateBar.MinimumSize = new System.Drawing.Size(100, 100);
            this.diskActRateBar.Name = "diskActRateBar";
            this.diskActRateBar.PercentColor = System.Drawing.Color.Black;
            this.diskActRateBar.ProgressColor1 = System.Drawing.Color.Brown;
            this.diskActRateBar.ProgressColor2 = System.Drawing.Color.Purple;
            this.diskActRateBar.ProgressShape = UI.UseRateBar._ProgressShape.Round;
            this.diskActRateBar.Size = new System.Drawing.Size(190, 190);
            this.diskActRateBar.TabIndex = 1;
            this.diskActRateBar.Text = "硬盘活动时间";
            this.diskActRateBar.Value = ((long)(0));
            // 
            // MyDiskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.diskActRateBar);
            this.Name = "MyDiskControl";
            this.Size = new System.Drawing.Size(955, 473);
            this.ResumeLayout(false);

        }

        #endregion
        private UseRateBar diskActRateBar;
    }
}
