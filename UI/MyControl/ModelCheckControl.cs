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
    public partial class ModelCheckControl : UserControl
    {
        private string terminalModel;
        private string configurationModel;
        private string text;
        
        public string TerminalModel
        {
            get
            {
                return terminalModel;
            }
            set
            {
                terminalModel = value;
                Invalidate();
            }
        }
        public string ConfigurationModel
        {
            get
            {
                return configurationModel;
            }
            set
            {
                configurationModel = value;
                Invalidate();
            }
        }

        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                this.text = value;
                Invalidate();
            }
        }
        public ModelCheckControl()
        {
            InitializeComponent();
            this.progressBar.Location = new(this.Width / 5 + 45, 10);
            this.progressBar.percentage = 100;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
            rectangle.Inflate(-5, -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("Segoe Print", 18, FontStyle.Regular);
                g.DrawString(text+"配置校验", font, brush, rectangle, stringFormat);
                font.Dispose();
                font = new Font("Segoe Print", 12, FontStyle.Regular);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("本机"+text+"型号 " + terminalModel, font, brush, rectangle, stringFormat);
                stringFormat.LineAlignment = StringAlignment.Far;
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString("配置文件"+text+"型号 " + configurationModel, font, brush, rectangle, stringFormat);

            }
        }
    }
}
