using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.TestPage
{
    public partial class AudioInterfaceTest : UserControl
    {
        
        private int status;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                if (status == 0)
                {
                    this.titleLabel.Text = "测试进度:0%";
                    this.microphonePictureBox.Image = Properties.Resources.AudioWait;
                    this.audioPictureBox.Image = Properties.Resources.AudioStart;
                }
                else 
                {
                    this.titleLabel.Text = "测试进度:50%";
                    this.progressBar.Value = 50;
                    this.audioPictureBox.Image = Properties.Resources.AudioWait;
                    this.microphonePictureBox.Image = Properties.Resources.AudioStart;
                }
                this.audioPicture.Width = myDockLayout1.Width / 5;
                this.microphonePicture.Width = myDockLayout1.Width / 5;
                this.audioPictureBox.Height = myDockLayout1.Height / 2;
                this.microphonePictureBox.Height = myDockLayout1.Height / 2;

                Refresh();
            }
        }
        public AudioInterfaceTest()
        {
            InitializeComponent();
            this.microphonePictureBox.Image = Properties.Resources.AudioWait;
            this.audioPictureBox.Image = Properties.Resources.AudioWait;
        }

        private void audioPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
