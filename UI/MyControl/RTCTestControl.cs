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
    public partial class RTCTestControl : UserControl
    {
        private DateTime terminalTime;
        private DateTime configurationTime;
        public DateTime TerminalTime
        {
            get
            {
                return this.terminalTime;
            }
            set
            {
                this.terminalTime = value;
                Invalidate();
            }
        }

        public DateTime ConfigurationTime
        {
            get
            {
                return configurationTime;
            }
            set
            {
                configurationTime = value;
                Invalidate();
            }
        }

        public RTCTestControl()
        {
            InitializeComponent();
            this.progressBar.Location = new(this.Width / 5, 10);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height );
            rectangle.Inflate(-5, -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("Segoe Print", 18, FontStyle.Regular);
                g.DrawString("RTC测试", font, brush, rectangle, stringFormat);
                font.Dispose();
                font= new Font("Segoe Print", 12, FontStyle.Regular);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("终端时间 "+terminalTime.ToString(), font, brush, rectangle, stringFormat);
                stringFormat.LineAlignment = StringAlignment.Far;
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString("服务器时间 " + configurationTime.ToString(), font, brush, rectangle, stringFormat);

            }
        }
    }
}
