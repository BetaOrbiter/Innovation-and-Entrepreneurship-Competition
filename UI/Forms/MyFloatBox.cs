using HZH_Controls.Controls;
using System.Drawing.Drawing2D;

namespace UI.Forms
{
    public partial class MyFloatBox : Form
    {
        public UCProcessWave processWave;
        private int percent = 0;
        private string text;
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
        public int Percent
        {
            get
            {
                return this.percent;
            }
            set
            {
                this.percent = value;
                this.processWave.Value = this.percent;
                Refresh();
            }
        }
        public MyFloatBox()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;//无边框
            this.StartPosition = FormStartPosition.Manual;//手工指定位置
            this.ShowInTaskbar = false;//在任务栏不显示图标
            //this.TopMost = true;//置顶显示
            this.BackColor = Color.White;//背景色
            this.TransparencyKey = Color.White;//指定透明区域的颜色
            processWave = new UCProcessWave();
            processWave.Dock = DockStyle.Left;
            processWave.Parent = this;
            processWave.Font = new Font("微软雅黑", 10, FontStyle.Regular);
            processWave.ForeColor = Color.Black;
            //processWave.BackColor = Color.DarkSeaGreen;
            processWave.BackColor = Color.FromArgb(243, 244, 246);
            processWave.ValueColor = Color.LightSkyBlue;
            processWave.RectColor = Color.DarkSeaGreen;
            processWave.RectWidth = 4;
            processWave.Show();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            float w = this.Width, h = this.Height;
            
            
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            GraphicsPath path = new GraphicsPath();
            float radius = this.Height / 2f;
            float x = radius;
            float y = h / 2f - radius;
            path.AddArc(new RectangleF(x, y, radius * 2, radius * 2), 120, 120);
            //path.AddArc(new Rectangle(x, y, radius * 2, radius * 2));
            //path.AddLine(this.Width, y, this.Width, y + radius);
            float nowR = radius * (float)Math.Sqrt(3.0) / 2;
            path.AddArc(new RectangleF(w - nowR * 2f, radius - nowR, nowR * 2f, nowR * 2f), -90, 180);
            path.CloseFigure();

            
            using (Brush brush = new SolidBrush(Color.FromArgb(243, 244, 246)))
            {
                g.FillPath(brush, path);
            }
            using (Pen pen = new Pen(Color.Black, 2f))
            {
                g.DrawPath(pen, path);
            }
            using (Brush brush=new SolidBrush(Color.Black))
            {
                RectangleF rect = new RectangleF(radius * 2, radius - nowR, w - radius * 2, nowR * 2);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("宋体", 9, FontStyle.Regular);
                g.DrawString("\n  测试项目", font, brush, rect, stringFormat);
                stringFormat.LineAlignment = StringAlignment.Center;
                font.Dispose();
                font = new Font("宋体", 10, FontStyle.Bold);
                g.DrawString("\n"+Text, font, brush, rect, stringFormat);
                font.Dispose();
            }
        
        }
        private void FrmLocation_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            //this.Anchor = AnchorStyles.Right;
            System.Windows.Forms.Timer checkDockTimer = new System.Windows.Forms.Timer();
            checkDockTimer.Tick += new EventHandler(StopRectTimer_Tick);
            checkDockTimer.Interval = 100;
            checkDockTimer.Enabled = true;
        }


        private void StopRectTimer_Tick(object sender, EventArgs e)
        {
            //如果鼠标在窗体上，则根据停靠位置显示整个窗体
            if (this.Bounds.Contains(Cursor.Position))
            {
                switch (this.Anchor)
                {
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, 0);
                        break;
                    case AnchorStyles.Bottom:
                        this.Location = new Point(this.Location.X, Screen.PrimaryScreen.Bounds.Height - this.Height);
                        break;
                    case AnchorStyles.Left:
                        this.Location = new Point(0, this.Location.Y);
                        break;
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y);
                        break;
                }
            }
            else  //如果鼠标离开窗体，则根据停靠位置隐藏窗体，但须留出部分窗体边缘以便鼠标选中窗体
            {
                switch (this.Anchor)
                {
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, (this.Height - 3) * (-1));
                        break;
                    case AnchorStyles.Bottom:
                        this.Location = new Point(this.Location.X, Screen.PrimaryScreen.Bounds.Height - 5);
                        break;
                    case AnchorStyles.Left:
                        this.Location = new Point((-1) * (this.Width - 3), this.Location.Y);
                        break;
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, this.Location.Y);
                        break;
                }
            }
        }

        /// <summary>
        /// 更改窗体的位置时，根据和各个窗体边缘的距离赋值停靠的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLocation_LocationChanged(object sender, EventArgs e)
        {
            if (this.Top <= 0)
            {
                this.Anchor = AnchorStyles.Top;
            }
            else if (this.Bottom >= Screen.PrimaryScreen.Bounds.Height)
            {
                this.Anchor = AnchorStyles.Bottom;
            }
            else if (this.Left <= 0)
            {
                this.Anchor = AnchorStyles.Left;
            }
            else if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)
            {
                this.Anchor = AnchorStyles.Right;
            }
            else
            {
                this.Anchor = AnchorStyles.None;
            }
        }
    }
}
