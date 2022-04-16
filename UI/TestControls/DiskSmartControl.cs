namespace UI.MyControl
{
    public partial class DiskSmartControl : UserControl
    {
        private List<Tuple<string, int, int, int, int, bool>> disks;

        private MyWaitCircleBar[] progressBar;
        public List<Tuple<string, int, int, int, int, bool>> Disks
        {
            get
            {
                return disks;
            }
            set
            {
                this.disks = value;
                progressBar = new MyWaitCircleBar[disks.Count];
                for(int i = 0; i < progressBar.Length; i++)
                {
                    progressBar[i] = new();
                    progressBar[i].showText = false;
                    progressBar[i].FilledThickness = 4;
                    progressBar[i].UnfilledThickness = 24;
                    progressBar[i].Size = new(15, 15);
                    progressBar[i].isAnimated = true;
                    progressBar[i].percentage = 50;
                    progressBar[i].Parent = this;
                    progressBar[i].Hide();
                }
                Invalidate();
            }
        }
        public DiskSmartControl()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            float h = 1f * this.Height / (disks.Count + 1);
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
                g.DrawString("硬盘Smart信息检查", font, brush, rectangle, stringFormat);
                int count = 0;
                font.Dispose();
               
                foreach (var disk in Disks)
                {
                    count++;
                    rectangle = new RectangleF(0, h * count-30, this.Width, h);
                    rectangle.Inflate(-2, -2);
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    font = new Font("宋体", 15, FontStyle.Regular);
                    g.DrawString($"硬盘{count}", font, brush, rectangle, stringFormat);
                    SizeF sizeF = g.MeasureString($"硬盘{count}", font);
                    progressBar[count - 1].Location = new((int)sizeF.Width+2, (int)h * count+(int)sizeF.Height / 5 - 35);
                    stringFormat.Alignment = StringAlignment.Far;
                    g.DrawString($"型号 {disk.Item1}", font, brush, rectangle, stringFormat);
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Near;
                    font.Dispose();
                    font = new Font("宋体", 12, FontStyle.Regular);
                    g.DrawString($"通电次数 {disk.Item2}", font, brush, rectangle, stringFormat);
                    stringFormat.Alignment = StringAlignment.Far;
                    g.DrawString($"通电时间 {disk.Item3}h", font, brush, rectangle, stringFormat);
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Near;
                    g.DrawString($"读写次数数据 {disk.Item4}GB", font, brush, rectangle, stringFormat);
                    stringFormat.Alignment = StringAlignment.Far;
                    g.DrawString($"致命错误次数 {disk.Item5}", font, brush, rectangle, stringFormat);
                    progressBar[count - 1].percentage = (disk.Item6 == true ? 100 : 0);
                    progressBar[count - 1].Show();
                    if (disk.Item6 == false)
                        Warning(count);
                    font.Dispose();
                }
            }
        }
        private void Warning(int index)
        {
            MessageBox.Show($"硬盘{index}Smart传感器信息报错！", "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }
    }
}
