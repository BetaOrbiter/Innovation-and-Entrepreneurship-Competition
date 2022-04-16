namespace UI.MyControl
{
    public partial class BadDiskControl : UserControl
    {
        private int diskIndex;
        private string diskModel;
        private ulong diskCapacity;
        private int status;
        private string task;
        private Image image = Properties.Resources.disk;
        public int DiskIndex
        {
            get
            {
                return diskIndex;
            }
            set
            {
                diskIndex = value;
                Invalidate();
            }
        }
        public string DiskModel
        {
            get
            {
                return diskModel;
            }
            set
            {
                diskModel = value;
                Invalidate();
            }
        }
        public ulong DiskCapacity
        {
            get
            {
                return diskCapacity;
            }
            set
            {
                diskCapacity = value;
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
                    this.task = "发现坏道";
                }
                else if (status == 4) 
                {
                    this.BackColor = Color.LemonChiffon;
                    this.task = "坏道修复";
                }
                Invalidate();
                Refresh();
            }
        }
        public BadDiskControl()
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
            Rectangle rectangle = new Rectangle(0, this.Height*1/5, this.Width * 2 / 5, this.Height*4/5);
            rectangle.Inflate(-5, -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Rectangle dstRect = AfImageUtil.FitInside(rectangle, image.Size);
            g.DrawImage(image, dstRect);
            using (Brush brush = new SolidBrush(Color.Black))
            {
                rectangle = new Rectangle(0, 0, this.Width, this.Height * 1 / 5);
                rectangle.Inflate(-5, -5);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                using(Font font=new Font("宋体",20,FontStyle.Regular))
                {
                    g.DrawString("硬盘 "+diskIndex, font, brush, rectangle, stringFormat);
                    
                }
                stringFormat.LineAlignment = StringAlignment.Far;
                stringFormat.Alignment = StringAlignment.Far;
                using (Font font=new Font("宋体", 12, FontStyle.Regular))
                {
                    g.DrawString(diskModel, font, brush, rectangle, stringFormat);
                }
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                rectangle = new Rectangle(this.Width * 2 / 5, 0, this.Width * 3 / 5, this.Height);
                
                using (Font font = new Font("宋体", 12, FontStyle.Regular))
                {
                    
                    g.DrawString("容量:" + diskCapacity+"GB", font, brush, rectangle, stringFormat);
                    g.DrawString("\n\n\n测试状态:" + task, font, brush, rectangle, stringFormat);
                }
            }

        }
    }
}
