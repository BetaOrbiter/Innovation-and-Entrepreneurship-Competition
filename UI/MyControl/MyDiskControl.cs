using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MyDiskControl : UserControl
    {
        private int diskActRate;
        private string diskModel = "Samsung SSD 870 EVO 500GB";
        private int readSpeed;
        private int writeSpeed;
        private int diskNumber;
        private string text;
        public override string Text {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                this.diskActRateBar.Text = this.text+"使用率";
                Invalidate();
            }
        }

        public int DiskActRate
        {
            get
            {
                return this.diskActRate;
            }
            set
            {
                this.diskActRate = value;
                this.diskActRateBar.Value = this.diskActRate;
            }
        }

        public string DiskModel
        {
            get
            {
                return this.diskModel;
            }
            set
            {
                this.diskModel = value;
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

        public int DiskNumber
        {
            get
            {
                return this.diskNumber;
            }
            set
            {
                this.diskNumber = value;
                Invalidate();
            }
        }
        public MyDiskControl()
        {
            InitializeComponent();
            this.diskActRateBar.Value = 50;
            this.diskActRateBar.Location = new(this.Width/10, this.Height/9);
            text = "硬盘";
            this.diskActRateBar.Text = this.text + "使用率";

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height/4);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
           
            //using (Pen pen = new Pen(Color.Black))
            //{
            //    g.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);
            //}
            using (Brush brush = new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("宋体", 25, FontStyle.Regular);
                g.DrawString(text+" "+ diskNumber, font, brush, rectangle, stringFormat);
                font.Dispose();
                font = new Font("宋体", 15, FontStyle.Regular);
                stringFormat.LineAlignment = StringAlignment.Far;
                stringFormat.Alignment = StringAlignment.Far;
                g.DrawString("型号 "+diskModel, font, brush, rectangle, stringFormat);
                rectangle.Location = new(this.Width * 1 / 2, this.Height / 3);
                rectangle.Size = new(this.Width * 1 / 3, this.Height * 4 / 5);
                stringFormat.LineAlignment = StringAlignment.Near;
                stringFormat.Alignment = StringAlignment.Center;
                g.DrawString("读取速度 "+readSpeed+"KB/s", font, brush, rectangle, stringFormat);
                stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("写入速度 " + writeSpeed + "KB/s", font, brush, rectangle, stringFormat);
                font.Dispose();
            }
        }
    }
}
