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
        private float uploadSpeed;
        private float downloadSpeed;

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
            
                
                this.compuertToRouter.Location = new(this.Width * 1 / 4 - 11 , this.Height / 8);
                this.compuertToRouter.Size = new(this.Width / 5 + 5, this.Height / 100);
                this.routerToComputer.Location = new(this.Width * 1 / 4 - 11, this.Height / 5);
                this.routerToComputer.Size = new(this.Width / 5+5, this.Height / 100);
                this.routerToServer.Location = new(this.Width * 3 / 5 - 30, this.Height / 8);
                this.routerToServer.Size = new(this.Width / 4 , this.Height / 100);
                this.serverToRouter.Location = new(this.Width * 3 / 5 - 30, this.Height / 5);
                this.serverToRouter.Size = new(this.Width / 4, this.Height / 100);

                Invalidate();
            }
        }

        public NetworkPortControl()
        {
            InitializeComponent();
            computerImage = Properties.Resources.NetworkComputer;
            routerImage = Properties.Resources.NetworkRouter;
            serverImage = Properties.Resources.NetworkServer;
            //this.compuertToRouter.Size=new()
            
            //this.CompuertToRouter
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
                Font font = new Font("Segoe Print", 10, FontStyle.Regular);
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
                Font font = new Font("Segoe Print", 20, FontStyle.Regular);
                g.DrawString("网口数据测试", font, brush, rectangle, stringFormat);
                rectangle = new Rectangle(this.Width/5, this.Height * 3 / 5, this.Width*3/5, this.Height / 2);
                rectangle.Inflate(-10, -10);
                font = new Font("Segoe Print", 18, FontStyle.Regular);
                g.DrawString("上行"+uploadSpeed+"MB/s", font, brush, rectangle, stringFormat);
                stringFormat.Alignment = StringAlignment.Far;
                g.DrawString("下行" + downloadSpeed + "MB/s", font, brush, rectangle, stringFormat);
            }
        }
    }
}
