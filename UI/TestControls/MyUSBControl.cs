namespace UI.MyControl
{
    public partial class MyUSBControl : UserControl
    {
        private string usbModel;
        private ulong usbSize;
        private int usbIndex;
        private int status;
        private string task;
        private int testModel;
        private Image image = Properties.Resources.USB;
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

        public ulong USBSize
        {
            get
            {
                return usbSize;
            }
            set
            {
                usbSize = value;
                Invalidate();
            }
        }
        public int USBIndex
        {
            get
            {
                return this.usbIndex;
            }
            set
            {
                this.usbIndex = value;
                Invalidate();
            }
        }
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                if (status == 0)
                {
                    this.BackColor = Color.DarkGray;
                    this.task = "等待";
                }
                else if (status == 1)
                {
                    this.BackColor = Color.LightGray;
                    this.task = "检测中";
                }
                else if (status == 2)
                {
                    this.BackColor = ColorTranslator.FromHtml("#67c23a");
                    this.task = "检测完成";
                }
                else if (status == 3)
                {
                    this.BackColor = Color.IndianRed;
                    this.task = (TestModel == 0 ? "USB接口错误" : "串口错误");
                }
                Invalidate();
                Refresh();
            }
        }
        public int TestModel
        {
            get
            {
                return testModel;
            }
            set
            {
                testModel = value;
                if (testModel == 0)
                {
                    image = Properties.Resources.USB;
                }
                else
                {
                    image = Properties.Resources.SerialPort;
                }
            }
        }
        public MyUSBControl()
        {
            InitializeComponent();
            this.BackColor = Color.DarkGray;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(0, this.Height * 1 / 5, this.Width * 2 / 5, this.Height * 4 / 5);
            rectangle.Inflate(-5, -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Rectangle dstRect = AfImageUtil.FitInside(rectangle, image.Size);
            g.DrawImage(image, dstRect);
            rectangle = new Rectangle(0, 0, this.Width, this.Height / 5);
            using (Brush brush = new SolidBrush(Color.Black))
            {

                rectangle.Inflate(-5, -5);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                using (Font font = new Font("宋体", 20, FontStyle.Regular))
                {
                    g.DrawString($"{(TestModel == 0 ? "U盘" : "串口")} {usbIndex}", font, brush, rectangle, stringFormat);

                }
                stringFormat.Alignment = StringAlignment.Far;
                stringFormat.LineAlignment = StringAlignment.Far;
                using (Font font = new Font("宋体", 12, FontStyle.Regular))
                {
                    if (TestModel == 0)
                        g.DrawString(usbModel, font, brush, rectangle, stringFormat);
                }
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                rectangle = new Rectangle(this.Width * 2 / 5, 0, this.Width * 3 / 5, this.Height);

                using (Font font = new Font("宋体", 12, FontStyle.Regular))
                {

                    g.DrawString(TestModel == 0 ? "容量:" + usbSize + "GB" : "名称:" + usbModel, font, brush, rectangle, stringFormat);
                    g.DrawString("\n\n\n测试状态:" + task, font, brush, rectangle, stringFormat);
                }
            }
            //画分割线
            //using (Pen pen=new Pen(Color.Black))
            //{
            //    g.DrawLine(pen, new Point(0, 0), new Point(this.Width, this.Height));
            //}
            //using (Pen pen=new Pen(Color.Black))
            //{
            //    g.DrawLine(pen, 0, 5, this.Width, 5);
            //    g.DrawLine(pen, this.Width-1, 5, this.Width-1, this.Height);
            //}
        }
    }
}
