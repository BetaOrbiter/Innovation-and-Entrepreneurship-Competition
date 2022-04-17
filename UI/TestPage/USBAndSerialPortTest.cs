using Controller;
using UI.MyControl;

namespace UI.TestPage
{
    public partial class USBAndSerialPortTest : UserControl
    {
        private MyUSBControl[] usbControls;
        private List<Tuple<string, ulong>> usbs;
        private List<string> serialPorts;
        private int nowUSBIndex;
        private int usbCount;
        private int status = 0;
        private string nowTask;
        private TimeSpan durationTime;
        private DateTime timeStart;
        private System.Threading.Timer timer;
        private Image image ;
        private int testModel;

        public List<Tuple<string, ulong>> USBS
        {
            get
            {
                return this.usbs;
            }
            set
            {
                this.usbs = value;
                
                Status = 1;
                TestModel = 0;
                usbCount = usbs.Count;

                Init();
                Invalidate();
                Refresh();
            }
        }
        public List<string> SerialPorts
        {
            get
            {
                return this.serialPorts;
            }
            set
            {
                serialPorts = value;
                TestModel = 1;
                Status = 1;
                usbCount = serialPorts.Count;
                Init();
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
                if (testModel != value)
                {
                    for (int i = 0; i < usbCount; i++)
                    {
                        usbControls[i].Hide();
                        usbControls[i].Dispose();
                    }
                }
                testModel = value;
                Invalidate();
                Refresh();
            }
        }
        public int NowUSBIndex
        {
            get
            {
                return nowUSBIndex;
            }
            set
            {
                nowUSBIndex = value;
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
                switch (status)
                {
                    case 0:
                        nowTask = "等待";
                        break;
                    case 1:
                        nowTask = "正在检测";
                        break;
                    case 2:
                        nowTask = "检测完毕";
                        timer.Change(-1, -1);
                        break;
                }
                Invalidate();
                Refresh();
            }
        }
        public TimeSpan DurationTime
        {
            get
            {
                return durationTime;
            }
            set
            {
                durationTime = value;
                if (usbCount != 0)
                {
                    this.progressLabel.Text = $"测试进度 {(NowUSBIndex * 100f / usbCount).ToString("f1")} %" +
                     $"(已运行时间 {durationTime.Hours}:{durationTime.Minutes}:{durationTime.Seconds}) ";
                    this.progressBar.Value = (NowUSBIndex) * 100 / usbCount;
                }
            }
        }
        public USBAndSerialPortTest()
        {
            InitializeComponent();
            image = Properties.Resources.Computer_USB0;
            Status = 0;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }
        public void USBTestWork(List<Tuple<string, ulong>> usbs,bool flag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(USBTestWork, usbs,flag);
            }
            else
            {
                if(!flag)
                    Warning(TestType.USBTest);
                this.USBS = usbs;
                timeStart = DateTime.Now;
                DurationTime = DateTime.Now - DateTime.Now;
                timer = new System.Threading.Timer(
                new TimerCallback(OnTimer)
                , null
                , 1000
                , 1000
              );
              if (usbs.Count <= 0)
                  timer.Change(-1, -1);
            }
        }
        public void SerialPortTestWork(List<string> _serialPorts,bool flag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(SerialPortTestWork, _serialPorts,flag);
            }
            else
            {
                if (!flag)
                    Warning(TestType.SerialPortTest);
                this.SerialPorts = _serialPorts;
                timeStart = DateTime.Now;
                DurationTime = DateTime.Now - DateTime.Now;
                timer = new System.Threading.Timer(
                    new TimerCallback(OnTimer)
                    , null
                    , 1000
                    , 1000
                );
                if (_serialPorts.Count <= 0)
                    timer.Change(-1, -1);

            }
        }
        private void Init()
        {
            usbPanel.AutoScroll = true;
            usbPanel.Dock = DockStyle.Bottom;
            usbPanel.Size = new(this.Width, this.Height * 3 / 7 + 35);
            usbControls = new MyUSBControl[usbCount];
            if (TestModel == 0)
            {
                if (usbCount == 0) image = Properties.Resources.Computer_USB0;
                else if (usbCount == 1) image = Properties.Resources.Computer_USB1;
                else if (usbCount == 2) image = Properties.Resources.Computer_USB2;
                else if (usbCount == 3) image = Properties.Resources.Computer_USB3;
            }
            else
            {
                image = Properties.Resources.Computer_USB0;
            }
            for (int i = 0; i < usbCount; i++)
            {
                usbControls[i] = new MyUSBControl();
                usbControls[i].USBModel = testModel == 0 ? usbs[i].Item1 : serialPorts[i];
                usbControls[i].Parent = this.usbPanel;
                usbControls[i].Size = new(usbPanel.Width / 2, this.usbPanel.Height - 22);
                usbControls[i].USBSize = testModel == 0 ? usbs[i].Item2 : 0;
                usbControls[i].USBIndex = i + 1;
                usbControls[i].TestModel = TestModel;
                usbControls[i].Show();
                usbControls[i].Status = 0;
            }
            NowUSBIndex = 0;
        }
        public void Change(bool noError)
        {
            if (InvokeRequired)
            {
                this.Invoke(Change, noError);
            }
            else
            {
                if (noError)
                {
                    usbControls[nowUSBIndex].Status = 2;
                }
                else
                {
                    var dr= MessageBox.Show($"{(TestModel == 0 ? "USB接口" : "串口")} { (NowUSBIndex + 1)}发生错误！是否中止并排查错误", 
                        "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    usbControls[nowUSBIndex].Status = 3;
                    if (dr == DialogResult.Yes)
                        System.Environment.Exit(0);
                }
                if (nowUSBIndex >= usbCount - 1)
                {
                    this.progressLabel.Text = $"测试进度 100 %" +
                     $"(已运行时间 {durationTime.Hours}:{durationTime.Minutes}:{durationTime.Seconds}) ";
                    this.progressBar.Value = 100;
                    timer.Change(-1, -1);
                    Status = 2;
                }
                else
                {
                    Status = 1;
                }
                NowUSBIndex = nowUSBIndex + 1;
                SetPosition();
                Refresh();
            }
        }
        private void OnTimer(object state)
        {
            UpdateTime();
        }
        private void UpdateTime()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(UpdateTime);
            }
            else
            {
                DurationTime = DateTime.Now - timeStart;
            }
        }
        private void SetPosition()
        {
            for(int i = 0; i < usbCount; i++)
            {
                usbControls[i].Location = new(
                    (usbCount+ usbControls[i].USBIndex-1-NowUSBIndex )%usbCount 
                    * this.Width/2 , 
                    0
                    );
                if (usbControls[i].USBIndex-1 == NowUSBIndex)
                    usbControls[i].Status = 1;
                usbControls[i].Show();
            }
        }
        private void Warning(TestType testType)
        {
            string test = (testType == TestType.USBTest ? "USB数量检测未通过！": "串口数量检测未通过！");
            var dr = MessageBox.Show(test + "是否中止并排查故障", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
                System.Environment.Exit(0);


        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(this.Width / 2, this.Height * 1 / 16, this.Width / 2, this.Height * 1 / 2);
            rectangle.Inflate(-5, -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Rectangle dstRect = AfImageUtil.FitInside(rectangle, image.Size);
            g.DrawImage(image, dstRect);
            //using (Pen pen=new Pen(Color.Black))
            //{
            //    g.DrawLine(pen,0, 0, this.Width / 2, this.Height * 4 / 7);
            //}
            rectangle.Location = new(0, 0);
            using (Brush brush = new SolidBrush(Color.Black))
            {

                rectangle.Height = this.Height / 2;
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                using (Font font = new Font("宋体", 20, FontStyle.Regular))
                {
                    g.DrawString($"\n当前检测{(TestModel==0?"USB接口:接口":"串口:串口")}{Math.Min(usbCount, NowUSBIndex + 1)}"  , font, brush, rectangle, stringFormat);
                    g.DrawString("\n\n\n当前执行任务:" + nowTask, font, brush, rectangle, stringFormat);
                }
            }
        }
    }
}
