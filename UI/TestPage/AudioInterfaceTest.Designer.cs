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
            this.myDockLayout1 = new UI.MyDockLayout();
            this.bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.audioPicture = new System.Windows.Forms.PictureBox();
            this.microphonePicture = new System.Windows.Forms.PictureBox();
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
            this.audioPictureBox.Location = new System.Drawing.Point(134, 29);
            this.audioPictureBox.Name = "audioPictureBox";
            this.audioPictureBox.Size = new System.Drawing.Size(469, 225);
            this.audioPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.audioPictureBox.TabIndex = 0;
            this.audioPictureBox.TabStop = false;
            this.audioPictureBox.Click += new System.EventHandler(this.audioPictureBox_Click);
            // 
            // microphonePictureBox
            // 
            this.microphonePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.microphonePictureBox.Location = new System.Drawing.Point(3, 290);
            this.microphonePictureBox.Name = "microphonePictureBox";
            this.microphonePictureBox.Size = new System.Drawing.Size(481, 225);
            this.microphonePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.microphonePictureBox.TabIndex = 1;
            this.microphonePictureBox.TabStop = false;
            // 
            // myDockLayout
            // 
            this.myDockLayout.Controls.Add(this.myDockLayout1);
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
            // myDockLayout1
            // 
            this.myDockLayout1.Controls.Add(this.bigLabel2);
            this.myDockLayout1.Controls.Add(this.bigLabel1);
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
            this.myDockLayout1.Location = new System.Drawing.Point(3, 3);
            this.myDockLayout1.Name = "myDockLayout1";
            this.myDockLayout1.Size = new System.Drawing.Size(606, 516);
            this.myDockLayout1.TabIndex = 6;
            // 
            // bigLabel2
            // 
            this.bigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel2.Location = new System.Drawing.Point(134, 3);
            this.bigLabel2.Name = "bigLabel2";
            this.bigLabel2.Size = new System.Drawing.Size(472, 23);
            this.bigLabel2.TabIndex = 5;
            this.bigLabel2.Text = "扬声器音频波形";
            this.bigLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bigLabel1
            // 
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(3, 262);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(472, 23);
            this.bigLabel1.TabIndex = 4;
            this.bigLabel1.Text = "麦克风音频波形";
            this.bigLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // audioPicture
            // 
            this.audioPicture.BackgroundImage = global::UI.Properties.Resources.Speakers;
            this.audioPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.audioPicture.Location = new System.Drawing.Point(3, 3);
            this.audioPicture.Name = "audioPicture";
            this.audioPicture.Size = new System.Drawing.Size(125, 256);
            this.audioPicture.TabIndex = 2;
            this.audioPicture.TabStop = false;
            // 
            // microphonePicture
            // 
            this.microphonePicture.BackgroundImage = global::UI.Properties.Resources.Microphone;
            this.microphonePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.microphonePicture.Location = new System.Drawing.Point(484, 262);
            this.microphonePicture.Name = "microphonePicture";
            this.microphonePicture.Size = new System.Drawing.Size(125, 256);
            this.microphonePicture.TabIndex = 3;
            this.microphonePicture.TabStop = false;
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
        private MyDockLayout myDockLayout1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
    }
}
