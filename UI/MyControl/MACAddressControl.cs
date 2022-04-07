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
    public partial class MACAddressControl : UserControl
    {
        private string macAddress;
        
        
        public string MACAddress
        {
            get
            {
                return this.macAddress;
            }
            set
            {
                this.macAddress = value;
                
                Invalidate();
            }
        }
        public MACAddressControl()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height / 5);
            rectangle.Inflate(-5, -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            SizeF sizeF;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("Segoe Print", 20, FontStyle.Regular);
                g.DrawString("MAC地址测试", font, brush, rectangle, stringFormat);
                rectangle = new Rectangle(0, this.Height * 1 / 3, this.Width , this.Height / 2);
                rectangle.Inflate(-10, -10);
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Near;
                font = new Font("Segoe Print", 18, FontStyle.Regular);
                g.DrawString("MAC地址 " + macAddress, font, brush, rectangle, stringFormat);
                sizeF = g.MeasureString(macAddress, font);
                font = new Font("Segoe Print", 11, FontStyle.Regular);
                g.DrawString("高24位", font, brush, this.Width * 4 / 11 + sizeF.Width / 6, this.Height * 6 / 11 + 6);
                g.DrawString("低24位", font, brush, this.Width * 4 / 11 + sizeF.Width / 2 + sizeF.Width / 6, this.Height * 6 / 11 + 6);

            }
            using (Pen pen = new Pen(Color.Black , 2f))
            {
                g.DrawLine(pen, this.Width * 4 / 11, this.Height * 6 / 11, this.Width * 4 / 11 + sizeF.Width / 2 - 10, this.Height * 6 / 11);
                g.DrawLine(pen, this.Width * 4 / 11 + sizeF.Width / 2 + 6, this.Height * 6 / 11, this.Width * 4 / 11 + sizeF.Width, this.Height * 6 / 11);
                g.DrawLine(pen, this.Width * 4 / 11, this.Height * 6 / 11, this.Width * 4 / 11, this.Height * 6 / 11-sizeF.Height/5);
                g.DrawLine(pen, this.Width * 4 / 11 + sizeF.Width/2-10, this.Height * 6 / 11, this.Width * 4 / 11 + sizeF.Width/2-10, this.Height * 6 / 11 - sizeF.Height/5);
                g.DrawLine(pen, this.Width * 4 / 11 + sizeF.Width / 2+6, this.Height * 6 / 11, this.Width * 4 / 11 + sizeF.Width / 2+6, this.Height * 6 / 11 - sizeF.Height / 5);
                g.DrawLine(pen, this.Width * 4 / 11 + sizeF.Width, this.Height * 6 / 11, this.Width * 4 / 11 + sizeF.Width, this.Height * 6 / 11 - sizeF.Height/5);
            }
        }
    }
}
