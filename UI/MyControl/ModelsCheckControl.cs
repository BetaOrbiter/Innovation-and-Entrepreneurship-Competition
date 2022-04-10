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
    public partial class ModelsCheckControl : UserControl
    {
        private List<string> terminalModels;
        private List<string> configurationModels;
        private string text;
        private bool flag;
        public bool Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
                if (flag == false) this.progressBar.percentage = 0;
                else this.progressBar.percentage = 100;
            }
        }
        public override string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                Invalidate();
            }
        }
        public List<string> TerminalModels
        {
            get
            {
                return terminalModels;
            }
            set
            {
                terminalModels = value;
                Invalidate();
            }
        }

        public List<string> ConfigurationModels
        {
            get
            {
                return configurationModels;
            }
            set
            {
                configurationModels = value;
                Invalidate();
            }
        }
        public ModelsCheckControl()
        {
            InitializeComponent();
            terminalModels = new List<string>();
            configurationModels = new List<string>();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            float h = 1f * this.Height / (terminalModels.Count + 1);
            RectangleF rectangle = new RectangleF(0, 0, this.Width, h);
            rectangle.Inflate(-2, -2);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("宋体", 20, FontStyle.Regular);
                g.DrawString(text+"配置校验", font, brush, rectangle, stringFormat);
                SizeF sizeF = g.MeasureString(text + "配置校验", font);
                this.progressBar.Location = new((int)sizeF.Width, (int)sizeF.Height/5);
                font.Dispose();
                font = new Font("宋体", 12, FontStyle.Regular);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Far;
                g.DrawString("\n本机"+text+"数量 "+terminalModels.Count, font, brush, rectangle, stringFormat);
                stringFormat.Alignment = StringAlignment.Center;
                g.DrawString("\n配置文件"+ text + "数量 " + configurationModels.Count, font, brush, rectangle, stringFormat);
                int count = 0;
                foreach (string model in terminalModels)
                {
                    count++;
                    rectangle = new RectangleF(0, h*count, this.Width, h);
                    rectangle.Inflate(-2, -2);
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    g.DrawString("本机"+text+count +"型号 " +model, font, brush, rectangle, stringFormat);
                }
                count = 0;
                foreach (string model in configurationModels)
                {
                    count++;
                    rectangle = new RectangleF(0, h * count, this.Width, h);
                    rectangle.Inflate(-2, -2);
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Near;
                    g.DrawString("\n配置文件" + text + count + "型号 " + model, font, brush, rectangle, stringFormat);
                }
                font.Dispose();
            }
        }
    }
}
