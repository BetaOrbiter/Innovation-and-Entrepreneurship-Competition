using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.MyControl
{
    public partial class NetworkPortControl : UserControl
    {
        private Image computerImage;
        private Image routerImage;
        private Image serverImage;
        private System.Threading.Timer timer;
        private float uploadSpeed;
        private float downloadSpeed;
        private bool flag = false;
        private bool accessed;
        private int count = 0;
        public bool AC
        {
            get
            {
                return accessed;
            }
            set
            {
                this.accessed = value;
                if (accessed)
                {
                    this.progressBar.percentage = 100;
                }
                else
                {
                    this.progressBar.percentage = 0;
                    Warning();
                }
            }
        }
        public float UploadSpeed
        {
            get
            {
                return this.uploadSpeed;
            }
            set
            {
                this.uploadSpeed = value;
                Invalidate();
            }
        }

        public float DownloadSpeed
        {
            get
            {
                return this.downloadSpeed;
            }
            set
            {
                this.downloadSpeed = value;
                if (timer == null)
                {
                    timer = new System.Threading.Timer(
                       new TimerCallback(OnTimer)
                       , null
                       , 300
                       , 300
                     );
                }
               
                if (!flag)
                {
                    this.compuertToRouter.Location = new(this.Width * 1 / 4 - 11, this.Height / 8);
                    this.compuertToRouter.Size = new(this.Width / 5 + 5, this.Height / 100);
                    this.routerToComputer.Location = new(this.Width * 1 / 4 - 11, this.Height / 5);
                    this.routerToComputer.Size = new(this.Width / 5 + 5, this.Height / 100);
                    this.routerToServer.Location = new(this.Width * 3 / 5 - 30, this.Height / 8);
                    this.routerToServer.Size = new(this.Width / 4, this.Height / 100);
                    this.serverToRouter.Location = new(this.Width * 3 / 5 - 30, this.Height / 5);
                    this.serverToRouter.Size = new(this.Width / 4, this.Height / 100);
                    this.compuertToRouter.Stop = true;
                    this.routerToComputer.Stop = true;
                    this.routerToServer.Stop = true;
                    this.serverToRouter.Stop = true;
                    flag = true;
                }
                Invalidate();
            }
        }

        
        public NetworkPortControl()
        {
            InitializeComponent();
            computerImage = Properties.Resources.NetworkComputer;
            routerImage = Properties.Resources.NetworkRouter;
            serverImage = Properties.Resources.NetworkServer;
            
        }
        public void OnTimer(object state)
        {
            Change(count);
            if (count >= 20)
            {
                timer.Change(-1, -1);
                return;
            }
            count++;
            
        }
        public void Change(int index)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Change, index);
            }
            else
            {
                if (count == 20)
                {
                    this.compuertToRouter.Stop = true;
                    this.routerToComputer.Stop = true;
                    this.routerToServer.Stop = true;
                    this.serverToRouter.Stop = true;
                    return;
                }
                switch (index % 4)
                {
                    case 0:
                        routerToComputer.Stop = true;
                        compuertToRouter.Stop = false;
                        break;
                    case 1:
                        compuertToRouter.Stop = true;
                        routerToServer.Stop = false;
                        break;
                    case 2:
                        routerToServer.Stop = true;
                        serverToRouter.Stop = false;
                        break;
                    case 3:
                        serverToRouter.Stop = true;
                        routerToComputer.Stop = false;
                        break;
                }
            }
        }
        private void Warning()
        {
            MessageBox.Show("网口数据流异常！", "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(0, this.Height / 6, this.Width / 3, this.Height / 3);
            rectangle.Inflate(-5, -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Rectangle dstRect = AfImageUtil.CenterInside(rectangle, computerImage.Size);
            rectangle.Y = this.Height / 2;
            using(Brush brush =new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("宋体", 10, FontStyle.Regular);
                g.DrawString("主机", font, brush, rectangle, stringFormat);
                rectangle.Location = new(this.Width * 4 / 11, this.Height * 3 / 7+10);
                g.DrawString("路由器", font, brush, rectangle, stringFormat);
                rectangle.Location = new(this.Width / 20 + this.Width * 4 / 6+8, this.Height / 2+5);
                g.DrawString("服务器", font, brush, rectangle, stringFormat);

            }
            g.DrawImage(this.computerImage, dstRect);
            rectangle = new Rectangle( this.Width * 2 / 5, this.Height / 5, this.Width / 4, this.Height / 4);
            rectangle.Inflate(-5, -5);
            dstRect = AfImageUtil.CenterInside(rectangle, routerImage.Size);
            g.DrawImage(this.routerImage, dstRect);
            rectangle = new Rectangle(this.Width / 20 + this.Width * 4 / 6, this.Height / 6, this.Width / 3 , this.Height / 3);
            dstRect = AfImageUtil.CenterInside(rectangle, serverImage.Size);
            g.DrawImage(this.serverImage, dstRect);
            rectangle = new Rectangle(0, 0, this.Width, this.Height / 7);
            using (Brush brush = new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("宋体", 20, FontStyle.Regular);
                g.DrawString("网口数据测试", font, brush, rectangle, stringFormat);
                rectangle = new Rectangle(this.Width/5, this.Height * 3 / 5, this.Width*3/5, this.Height / 2);
                rectangle.Inflate(-10, -10);
                font = new Font("宋体", 16, FontStyle.Regular);
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString("上行"+uploadSpeed.ToString("f2") +"KB/s", font, brush, rectangle, stringFormat);
                stringFormat.Alignment = StringAlignment.Far;
                g.DrawString("下行" + downloadSpeed.ToString("f2") + "KB/s", font, brush, rectangle, stringFormat);
            }
        }
        
    }
}
