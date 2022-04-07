namespace UI.TestPage
{
    partial class AudioInterfaceTest
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
            this.audioPictureBox = new System.Windows.Forms.PictureBox();
            this.microphonePictureBox = new System.Windows.Forms.PictureBox();
            this.myDockLayout = new UI.MyDockLayout();
            this.progressBar = new ReaLTaiizor.Controls.AloneProgressBar();
            this.myDockLayout1 = new UI.MyDockLayout();
            this.audioPicture = new System.Windows.Forms.PictureBox();
            this.microphonePicture = new System.Windows.Forms.PictureBox();
            this.titleLabel = new ReaLTaiizor.Controls.BigLabel();
            ((System.ComponentModel.ISupportInitialize)(this.audioPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.microphonePictureBox)).BeginInit();
            this.myDockLayout.SuspendLayout();
            this.myDockLayout1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audioPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.microphonePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // audioPictureBox
            // 
            this.audioPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.audioPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.audioPictureBox.Location = new System.Drawing.Point(134, 3);
            this.audioPictureBox.Name = "audioPictureBox";
            this.audioPictureBox.Size = new System.Drawing.Size(469, 248);
            this.audioPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.audioPictureBox.TabIndex = 0;
            this.audioPictureBox.TabStop = false;
            this.audioPictureBox.Click += new System.EventHandler(this.audioPictureBox_Click);
            // 
            // microphonePictureBox
            // 
            this.microphonePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.microphonePictureBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.microphonePictureBox.Location = new System.Drawing.Point(3, 236);
            this.microphonePictureBox.Name = "microphonePictureBox";
            this.microphonePictureBox.Size = new System.Drawing.Size(469, 257);
            this.microphonePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.microphonePictureBox.TabIndex = 1;
            this.microphonePictureBox.TabStop = false;
            // 
            // myDockLayout
            // 
            this.myDockLayout.Controls.Add(this.progressBar);
            this.myDockLayout.Controls.Add(this.myDockLayout1);
            this.myDockLayout.Controls.Add(this.titleLabel);
            this.myDockLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDockLayout.DockFlags = new int[] {
        0,
        0,
        1,
        1,
        0,
        1,
        1,
        0};
            this.myDockLayout.Location = new System.Drawing.Point(0, 0);
            this.myDockLayout.Name = "myDockLayout";
            this.myDockLayout.Size = new System.Drawing.Size(612, 522);
            this.myDockLayout.TabIndex = 2;
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
            this.progressBar.Size = new System.Drawing.Size(612, 10);
            this.progressBar.Stripes = System.Drawing.Color.DarkGreen;
            this.progressBar.TabIndex = 7;
            this.progressBar.Text = "aloneProgressBar1";
            this.progressBar.Value = 50;
            // 
            // myDockLayout1
            // 
            this.myDockLayout1.Controls.Add(this.audioPictureBox);
            this.myDockLayout1.Controls.Add(this.audioPicture);
            this.myDockLayout1.Controls.Add(this.microphonePicture);
            this.myDockLayout1.Controls.Add(this.microphonePictureBox);
            this.myDockLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDockLayout1.DockFlags = new int[] {
        1,
        0,
        0,
        1,
        0,
        1,
        1,
        0};
            this.myDockLayout1.Location = new System.Drawing.Point(3, 23);
            this.myDockLayout1.Name = "myDockLayout1";
            this.myDockLayout1.Size = new System.Drawing.Size(606, 496);
            this.myDockLayout1.TabIndex = 6;
            // 
            // audioPicture
            // 
            this.audioPicture.BackgroundImage = global::UI.Properties.Resources.Speakers;
            this.audioPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.audioPicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.audioPicture.Location = new System.Drawing.Point(3, 3);
            this.audioPicture.Name = "audioPicture";
            this.audioPicture.Size = new System.Drawing.Size(125, 227);
            this.audioPicture.TabIndex = 2;
            this.audioPicture.TabStop = false;
            // 
            // microphonePicture
            // 
            this.microphonePicture.BackgroundImage = global::UI.Properties.Resources.Microphone;
            this.microphonePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.microphonePicture.Dock = System.Windows.Forms.DockStyle.Right;
            this.microphonePicture.Location = new System.Drawing.Point(478, 257);
            this.microphonePicture.Name = "microphonePicture";
            this.microphonePicture.Size = new System.Drawing.Size(125, 236);
            this.microphonePicture.TabIndex = 3;
            this.microphonePicture.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(606, 20);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "bigLabel1";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AudioInterfaceTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myDockLayout);
            this.Name = "AudioInterfaceTest";
            this.Size = new System.Drawing.Size(612, 522);
            ((System.ComponentModel.ISupportInitialize)(this.audioPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.microphonePictureBox)).EndInit();
            this.myDockLayout.ResumeLayout(false);
            this.myDockLayout1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.audioPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.microphonePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox audioPictureBox;
        private PictureBox microphonePictureBox;
        private MyDockLayout myDockLayout;
        private PictureBox microphonePicture;
        private PictureBox audioPicture;
        private ReaLTaiizor.Controls.BigLabel titleLabel;
        private MyDockLayout myDockLayout1;
        private ReaLTaiizor.Controls.AloneProgressBar progressBar;
    }
}
