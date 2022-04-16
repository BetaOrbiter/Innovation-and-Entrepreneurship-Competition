namespace UI.MyControl
{
    public partial class RTCTestControl : UserControl
    {
        private DateTime terminalTime;
        private DateTime configurationTime;
        private bool flag;

        public bool Flag
        {
            get
            {
                return flag;
            }
            set
            {
                this.flag = value;
                if (flag == false) this.progressBar.percentage = 0;
                else this.progressBar.percentage = 100;
            }
        }
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
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
                Font font = new Font("宋体", 20, FontStyle.Regular);
                g.DrawString("RTC测试", font, brush, rectangle, stringFormat);
                SizeF sizeF = g.MeasureString("RTC测试", font);
                this.progressBar.Location = new((int)sizeF.Width, (int)sizeF.Height / 5);
                font.Dispose();
                font= new Font("宋体", 12, FontStyle.Regular);
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
