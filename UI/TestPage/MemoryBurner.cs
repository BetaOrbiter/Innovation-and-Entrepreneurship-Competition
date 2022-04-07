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
    public partial class MemoryBurner : UserControl
    {
        private string memoryModel= "Kingston HyperX KHX2666C15S4/8G";
        private float memoryUse;
        private float memoryRest;

        public float MemoryUse
        {
            get
            {
                return this.memoryUse;
            }
            set
            {
                this.memoryUse = value;
                this.Invalidate();
            }
        }

        public float MemoryRest
        {
            get
            {
                return this.memoryRest;
            }
            set
            {
                this.memoryRest = value;
                Invalidate();
            }
        }
        public string MemoryModel
        {
            get
            {
                return this.memoryModel;
            }
            set
            {
                this.memoryModel = value;
                this.Invalidate();
            }
        }
        public MemoryBurner()
        {
            InitializeComponent();
            this.memoryUseRateChart.Size = new(this.Width * 7 / 10, this.Height * 1 / 3);
            this.memoryUseRateChart.Location = new(this.Width / 20, this.Height / 8);
            this.memoryUseBar.Size = new(this.Width / 5, this.Width / 5);
            this.memoryUseBar.Location = new(this.Width / 20, this.Height * 1 / 2);
            this.memoryUseBar.Value = 100;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            RectangleF rectangle = new RectangleF(0, 0, this.Width, this.Height / 8);
            using (Brush brush=new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("Segoe Print", 25, FontStyle.Regular);
                g.DrawString("内存", font, brush, rectangle, stringFormat);
                font = new Font("Segoe Print", 15, FontStyle.Regular);
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Far;
                g.DrawString(memoryModel, font, brush, rectangle, stringFormat);
                rectangle.Size = new(this.Width / 2, this.Height / 2);
                rectangle.Location = new(this.Width / 2, this.Height * 4 / 9);
                font = new Font("Segoe Print", 15, FontStyle.Regular);
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString("使用中", font, brush, rectangle, stringFormat);
                stringFormat.Alignment = StringAlignment.Center;
                g.DrawString("可用", font, brush, rectangle, stringFormat);
                font = new Font("Segoe Print", 20, FontStyle.Regular);
                g.DrawString("\n\n  "+memoryRest.ToString() +"GB", font, brush, rectangle, stringFormat);
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString("\n\n  " + memoryUse.ToString() + "GB", font, brush, rectangle, stringFormat);
            }
        }
    }
}
