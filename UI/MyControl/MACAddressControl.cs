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
        private List<Tuple<string,string,bool>> netItems;
        private int netCount;
        private MyWaitCircleBar[] myWaitCircleBars;
        public List<Tuple<string, string,bool>> NetItems
        {
            get
            {
                return this.netItems;
            }
            set
            {
                this.netItems = value;
                myWaitCircleBars = new MyWaitCircleBar[netItems.Count];
                netCount = netItems.Count;
                for(int i=0;i< netCount; i++)
                {
                    myWaitCircleBars[i] = new MyWaitCircleBar
                    {
                        ShowText = false,
                        FilledThickness = 4,
                        Size = new(25, 25),
                        Parent = this,
                        //Location = new(this.Width / 2 + (int)sizeF.Width / 2, y + h / 2 + (int)sizeF.Height / 3),
                        Location = new(this.Width/2+50, 95*i+115),
                        Percentage = 100 * (netItems[i].Item3 ? 100 : 0)
                    };
                    myWaitCircleBars[i].Show();
                    if (!netItems[i].Item3) Warning(i + 1);
                }
                
                Invalidate();
            }
        }
        public MACAddressControl()
        {
            InitializeComponent();
        }
        private void Warning(int index)
        {
            MessageBox.Show("网卡" + index + "MAC地址不符合IEEE802.1规范！", "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height / 6);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            SizeF sizeF;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("宋体", 20, FontStyle.Regular);
                g.DrawString("MAC地址测试", font, brush, rectangle, stringFormat);
                int index = 0;

                foreach(var net in netItems)
                {
                    int x = 0, y = this.Height / 6 + index * (this.Height ) / (netCount + 1);
                    int w = this.Width, h = (this.Height ) / (netCount + 1);
                    rectangle = new Rectangle(x, y, w, h);
                    rectangle.Inflate(-10, -10);
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Near;
                    font = new Font("宋体", 15, FontStyle.Regular);
                    g.DrawString("网卡"+(index + 1) , font, brush, rectangle, stringFormat);
                    font.Dispose();
                    font = new Font("宋体", 12, FontStyle.Regular);
                    g.DrawString( "\n型号 " + net.Item1, font, brush, rectangle, stringFormat);
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    g.DrawString("MAC地址 " + net.Item2, font, brush, rectangle, stringFormat);
                    sizeF = g.MeasureString(net.Item2, font);
                    
                    
                    font.Dispose();
                    font = new Font("宋体", 10, FontStyle.Regular);
                    y -= 7;
                    g.DrawString("高24位", font, brush, this.Width * 5 / 11+10 , y + h+7);
                    g.DrawString("低24位", font, brush, this.Width * 5 / 11 + sizeF.Width / 2+10 , y + h+7);
                    font.Dispose();
                    using (Pen pen = new Pen(Color.Black, 2f))
                    {
                        g.DrawLine(pen, this.Width * 5 / 11- 8, y + h, this.Width * 5 / 11- 7 + sizeF.Width / 2 - 10, y + h);
                        g.DrawLine(pen, this.Width * 5 / 11- 15 + sizeF.Width / 2 + 6, y + h, this.Width * 5 / 11- 15 + sizeF.Width, y + h);
                        g.DrawLine(pen, this.Width * 5 / 11- 7, y + h, this.Width * 5 / 11- 7, y + h - sizeF.Height / 3);
                        g.DrawLine(pen, this.Width * 5 / 11- 7 + sizeF.Width / 2 - 10, y + h, this.Width * 5 / 11 - 7 + sizeF.Width / 2 - 10, y + h - sizeF.Height / 3);
                        g.DrawLine(pen, this.Width * 5 / 11- 15 + sizeF.Width / 2 + 6, y + h, this.Width * 5 / 11 - 15 + sizeF.Width / 2 + 6, y + h - sizeF.Height / 3);
                        g.DrawLine(pen, this.Width * 5 / 11- 15 + sizeF.Width, y + h, this.Width * 5 / 11- 15 + sizeF.Width, y + h - sizeF.Height / 3);
                    }
                    index++;
                }

            }
            
        }
    }
}
