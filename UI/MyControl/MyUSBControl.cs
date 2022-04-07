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
    public partial class MyUSBControl : UserControl
    {
        private int usbActRate;
        private string usbModel = "Samsung SSD 870 EVO 500GB";
        private int readSpeed;
        private int writeSpeed;
        private int usbNumber;
        public int USBActRate
        {
            get
            {
                return this.usbActRate;
            }
            set
            {
                this.usbActRate = value;
                this.usbActRateBar.Value = this.usbActRate;
            }
        }

        public string USBModel
        {
            get
            {
                return this.usbModel;
            }
            set
            {
                this.usbModel = value;
                this.Invalidate();
            }
        }

        public int ReadSpeed
        {
            get
            {
                return this.readSpeed;
            }
            set
            {
                this.readSpeed = value;
                this.Invalidate();
            }
        }

        public int WriteSpeed
        {
            get
            {
                return this.writeSpeed;
            }
            set
            {
                this.writeSpeed = value;
                this.Invalidate();
            }
        }

        public int USBNumber
        {
            get
            {
                return this.usbNumber;
            }
            set
            {
                this.usbNumber = value;
                Invalidate();
            }
        }
        public MyUSBControl()
        {
            InitializeComponent();
            this.usbActRateBar.Value = 50;
            this.usbActRateBar.Size = new(150, 150);
            this.usbActRateBar.Location = new(this.Width/8, this.Height / 10);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            //this.diskActRateBar.Location = new(0, 0);
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height / 4);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            //using (Pen pen=new Pen(Color.Black))
            //{
            //    g.DrawLine(pen, new Point(0, 0), new Point(this.Width, this.Height));
            //}
            using (Pen pen=new Pen(Color.Black))
            {
                g.DrawLine(pen, 0, 5, this.Width, 5);
                g.DrawLine(pen, this.Width-1, 5, this.Width-1, this.Height);
            }
            using (Brush brush = new SolidBrush(Color.Black))
            {
                
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("Segoe Print", 18, FontStyle.Regular);
                g.DrawString("U盘 " + usbNumber, font, brush, rectangle, stringFormat);
                font = new Font("Segoe Print", 12, FontStyle.Regular);
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString(usbModel, font, brush, rectangle, stringFormat);
                font = new Font("Segoe Print", 14, FontStyle.Regular);
                rectangle.Location = new(this.Width/6, this.Height * 3 / 4);
                rectangle.Size = new(this.Width, this.Height * 1 / 4);
                stringFormat.LineAlignment = StringAlignment.Near;
                stringFormat.Alignment = StringAlignment.Near;
                rectangle.Inflate(-5, -5);
                g.DrawString("读取速度\n " + readSpeed + "KB/s", font, brush, rectangle, stringFormat);
                stringFormat.Alignment = StringAlignment.Center;
                g.DrawString("写入速度\n" + writeSpeed + "KB/s", font, brush, rectangle, stringFormat);

            }
        }
    }
}
