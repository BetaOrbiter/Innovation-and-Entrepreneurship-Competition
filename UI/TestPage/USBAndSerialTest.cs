using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.MyControl;

namespace UI.TestPage
{
    public partial class USBAndSerialTest : UserControl
    {
        private MyUSBControl[] usbControls;
        private MyUSBControl[] serialPortControls;
        private int serialPortCount;
        private int usbCount;
        private Image image;
        private bool testModel = false;
        
        public int USBCount
        {
            get
            {
                return this.usbCount;
            }
            set
            {
                this.usbCount = value;
                if (testModel == false)
                {
                    if (usbCount == 0) image = Properties.Resources.Computer_USB0;
                    else if (usbCount == 1) image = Properties.Resources.Computer_USB1;
                    else if (usbCount == 2) image = Properties.Resources.Computer_USB2;
                    else if (usbCount == 3) image = Properties.Resources.Computer_USB3;
                }    
                else image = Properties.Resources.Computer_USB0;
                this.usbPanel.Size = new(this.Width, this.Height * 4 / 7);
                usbControls = new MyUSBControl[usbCount];
                for (int i = 0; i < usbCount; i++)
                {
                   usbControls[i] = new MyUSBControl();
                   usbControls[i].Dock = DockStyle.Left;
                   usbControls[i].Size = new(298, this.usbPanel.Height);
                   usbControls[i].USBNumber = i;
                   usbControls[i].Parent = this.usbPanel;
                    if (testModel == false)
                        usbControls[i].Show();
                    else
                        usbControls[i].Hide();
                }
                Invalidate();
                Refresh();
            }
        }
        public int SerialPortCount
        {
            get
            {
                return this.serialPortCount;
            }
            set
            {
                serialPortCount = value;
                if (testModel == true)
                {
                    image = Properties.Resources.Computer_USB0;
                }
                this.usbPanel.Size = new(this.Width, this.Height * 4 / 7);
                serialPortControls = new MyUSBControl[serialPortCount];
                for (int i = 0; i < serialPortCount; i++)
                {
                    serialPortControls[i] = new MyUSBControl();
                    serialPortControls[i].Dock = DockStyle.Left;
                    serialPortControls[i].Size = new(298, this.usbPanel.Height);
                    serialPortControls[i].USBNumber = i;
                    serialPortControls[i].Parent = this.usbPanel;
                    if (testModel == true)
                        serialPortControls[i].Show();
                    else
                        serialPortControls[i].Hide();
                }
                Invalidate();
                Refresh();
            }
        }
        public bool TestModel
        {
            get
            {
                return testModel;
            }
            set
            {
                testModel = value;
                if (testModel == false)
                {
                    image = Properties.Resources.Computer_USB0;
                    for (int i = 0; i < serialPortCount; i++)
                    {
                        serialPortControls[i].Hide();
                        serialPortControls[i].Dispose();
                    }
                    
                }
                else
                {

                    for (int i = 0; i < usbCount; i++)
                    {
                        usbControls[i].Hide();
                        usbControls[i].Dispose();
                    }
                    
                }
                Invalidate();
                Refresh();
            }
        }

        public USBAndSerialTest()
        {
            InitializeComponent();
           
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(this.Width/3, 0, this.Width / 2, this.Height * 3 / 7);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            if (image != null)
            {
                Rectangle dstRect = AfImageUtil.CenterInside(rectangle, image.Size);
                g.DrawImage(this.image, dstRect);
            }
            using (Brush brush=new SolidBrush(Color.Black))
            {
                rectangle = new(0, 0, this.Width / 3, this.Height * 2 / 5);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                Font font = new Font("Segoe Print", 25, FontStyle.Regular);
                if(testModel==false)
                    g.DrawString("U盘数量\n     " + usbCount, font, brush, rectangle, stringFormat);
                else
                    g.DrawString("串口数量\n     " + serialPortCount, font, brush, rectangle, stringFormat);
            }
        }
    }
}
