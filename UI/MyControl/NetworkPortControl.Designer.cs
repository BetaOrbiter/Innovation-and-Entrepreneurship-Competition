namespace UI.MyControl
{
    partial class NetworkPortControl
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
            this.compuertToRouter = new UI.MyControl.Trick();
            this.routerToServer = new UI.MyControl.Trick();
            this.routerToComputer = new UI.MyControl.Trick();
            this.serverToRouter = new UI.MyControl.Trick();
            this.ProgressBar = new UI.MyControl.MyWaitCircleBar();
            this.SuspendLayout();
            // 
            // compuertToRouter
            // 
            this.compuertToRouter.LineRightToLeft = false;
            this.compuertToRouter.Location = new System.Drawing.Point(88, 49);
            this.compuertToRouter.Name = "compuertToRouter";
            this.compuertToRouter.P_AnimationColor = System.Drawing.Color.LimeGreen;
            this.compuertToRouter.P_AnimationSpeed = 100;
            this.compuertToRouter.P_BaseColor = System.Drawing.Color.RoyalBlue;
            this.compuertToRouter.Size = new System.Drawing.Size(142, 78);
            this.compuertToRouter.Stop = false;
            this.compuertToRouter.TabIndex = 0;
            this.compuertToRouter.Text = "trick1";
            // 
            // routerToServer
            // 
            this.routerToServer.LineRightToLeft = false;
            this.routerToServer.Location = new System.Drawing.Point(368, 69);
            this.routerToServer.Name = "routerToServer";
            this.routerToServer.P_AnimationColor = System.Drawing.Color.LimeGreen;
            this.routerToServer.P_AnimationSpeed = 100;
            this.routerToServer.P_BaseColor = System.Drawing.Color.RoyalBlue;
            this.routerToServer.Size = new System.Drawing.Size(100, 100);
            this.routerToServer.Stop = false;
            this.routerToServer.TabIndex = 1;
            this.routerToServer.Text = "trick1";
            // 
            // routerToComputer
            // 
            this.routerToComputer.LineRightToLeft = true;
            this.routerToComputer.Location = new System.Drawing.Point(97, 255);
            this.routerToComputer.Name = "routerToComputer";
            this.routerToComputer.P_AnimationColor = System.Drawing.Color.LimeGreen;
            this.routerToComputer.P_AnimationSpeed = 100;
            this.routerToComputer.P_BaseColor = System.Drawing.Color.RoyalBlue;
            this.routerToComputer.Size = new System.Drawing.Size(100, 100);
            this.routerToComputer.Stop = false;
            this.routerToComputer.TabIndex = 2;
            this.routerToComputer.Text = "trick1";
            // 
            // serverToRouter
            // 
            this.serverToRouter.LineRightToLeft = true;
            this.serverToRouter.Location = new System.Drawing.Point(368, 255);
            this.serverToRouter.Name = "serverToRouter";
            this.serverToRouter.P_AnimationColor = System.Drawing.Color.LimeGreen;
            this.serverToRouter.P_AnimationSpeed = 100;
            this.serverToRouter.P_BaseColor = System.Drawing.Color.RoyalBlue;
            this.serverToRouter.Size = new System.Drawing.Size(100, 100);
            this.serverToRouter.Stop = false;
            this.serverToRouter.TabIndex = 3;
            this.serverToRouter.Text = "trick1";
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
            this.ProgressBar.Location = new System.Drawing.Point(177, 10);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Percentage = 50;
            this.ProgressBar.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.ProgressBar.ShowText = false;
            this.ProgressBar.Size = new System.Drawing.Size(20, 20);
            this.ProgressBar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.ProgressBar.TabIndex = 4;
            this.ProgressBar.TextColor = System.Drawing.Color.Gray;
            this.ProgressBar.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ProgressBar.TextSize = 25;
            this.ProgressBar.UnFilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.ProgressBar.UnfilledThickness = 24;
            // 
            // NetworkPortControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.serverToRouter);
            this.Controls.Add(this.routerToComputer);
            this.Controls.Add(this.routerToServer);
            this.Controls.Add(this.compuertToRouter);
            this.Name = "NetworkPortControl";
            this.Size = new System.Drawing.Size(625, 525);
            this.ResumeLayout(false);

        }

        #endregion

        private Trick compuertToRouter;
        private Trick routerToServer;
        private Trick routerToComputer;
        private Trick serverToRouter;
        private MyWaitCircleBar ProgressBar;
    }
}
