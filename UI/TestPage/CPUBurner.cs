using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using MyTool.Monitor;
using LiveChartsCore.Kernel.Sketches;

namespace UI.TestPage
{
    public partial class CPUBurner : UserControl
    {
        private string CpuModel;
        private float CpuUseRate, CpuClock;
        private float CpuTemperature, fanSpeed;
        private int TotalDuration { get; set; }
        private LineSeries<int> lineSeries { get; set; }
        private System.Threading.Timer timer;
        private TimeSpan durationTime;
        private DateTime timeStart;
        private int tmpExceedCount;
        //记录图表更新次数
        private int count;
        public string CPUModel
        {
            get
            {
                return this.CpuModel;
            }
            set
            {
                CpuModel = value;
                Invalidate();
                Refresh();
            }
        }
        public float CPUUseRate
        {
            get
            {
                return this.CpuUseRate;
            }
            set
            {
                CpuUseRate = value;
                this.Invalidate();
            }
        }
        public float CPUClock
        {
            get
            {
                return this.CpuClock;
            }
            set
            {
                CpuClock = value;
                this.Invalidate();
            }
        }
        public float CPUTemperature
        {
            get
            {
                return this.CpuTemperature;
            }
            set
            {
                CpuTemperature = value;
                this.CPUThermometer.Value = (int)CpuTemperature;
                this.Invalidate();
            }
        }
        public float FanSpeed
        {
            get
            {
                return this.fanSpeed;
            }
            set
            {
                fanSpeed = value;
                if (fanSpeed > 0) this.fanPictureBox.Image = Properties.Resources.fanStart;
                else this.fanPictureBox.Image = Properties.Resources.fanStop;
                this.Invalidate();
            }
        }

        public TimeSpan DurationTime
        {
            get
            {
                return this.durationTime;
            }
            set
            {
                durationTime =value;
                this.progressBar.Value = (int)durationTime.TotalSeconds * 100 / TotalDuration;
                this.progressLabel.Text = $"测试进度 {Math.Min(100, (int)durationTime.TotalSeconds * 100 / TotalDuration)} %" +
                    $"(已运行时间 {durationTime.Hours}:{durationTime.Minutes}:{durationTime.Seconds}) ";
            }
        }

        
        private CpuMonitor CpuMonitor { get; init; }

        public CPUBurner()
        {
            
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            CpuMonitor = ComputerMonitor.CpuMonitorList[0];
            this.bigLabel1.Location = new(10, this.Height / 8);
            CPUUseRateChart.Size = new Size(this.Width - 160, this.Height / 3);
            CPUUseRateChart.Location = new Point(0, this.Height / 8+5);
            lineSeries = new LineSeries<int>
            {
                Values = new int[1],
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 2 },
                LineSmoothness = 0,
                GeometryFill = null, // mark
                GeometryStroke = null, // mark
                Name="60s内CPU利用率",
                //LegendShapeSize=100f
            };
            
            CPUUseRateChart.Series = new ISeries[]
            {
                lineSeries,
            };


            CPUUseRateChart.XAxes = new List<Axis>{
                new Axis{
                  MaxLimit = 60,
                  MinLimit = 0,
                  
                }
            };
            CPUUseRateChart.YAxes = new List<Axis>{
                new Axis{
                  MaxLimit = 105,
                  MinLimit = 0
                }
            };
            //CPUUseRateChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
            ////CPUUseRateChart.LegendOrientation = LiveChartsCore.Measure.LegendOrientation.Vertical;
            //CPUUseRateChart.LegendFont = new System.Drawing.Font("宋体", 6);
            //CPUUseRateChart.LegendTextColor = System.Drawing.Color.FromArgb(255, 80, 80, 80);
            //CPUUseRateChart.LegendBackColor = System.Drawing.Color.FromArgb(255, 243, 244, 246);


            CPUThermometer.Location = new Point(250, 550);
            CPUThermometer.Size = new Size(70, 180);
          
            this.fanPictureBox.Size = new(100, 100);
            this.fanPictureBox.Location = new(310, 360);
            this.fanPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

        }
        public void Work(string _CpuModel,int _totalDuration)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Work, _CpuModel, _totalDuration);
            }
            else
            {
                TotalDuration = _totalDuration;
                timeStart = DateTime.Now;
                DurationTime = DateTime.Now - DateTime.Now;
                CPUModel = _CpuModel;
                count = 0;
                tmpExceedCount = 0;
                timer = new System.Threading.Timer(
                 new TimerCallback(OnTimer)
                 , null
                 , 1000
                 , 1000
               );
                
            }
        }
        private void OnTimer(object state)
        {
            if ((int)DurationTime.TotalSeconds >= TotalDuration)
            {
                Stop();
            }
            else
            {
                ComputerMonitor.CpuMonitorList[0].Update();
                ComputerMonitor.FanMonitorList[0].Update();
                float maxColock = 0;
                foreach(var cpuClocks in CpuMonitor.Clocks)
                {
                    maxColock = MathF.Max(maxColock, (float)cpuClocks!.Value!);
                }
                float temperature = (float)CpuMonitor.MaxTemperature!.Value!;
                if (temperature > 90) tmpExceedCount++;
                else tmpExceedCount = 0;
                if (tmpExceedCount >= 60) Warning();
                Update(
                    (float)CpuMonitor.Usage!.Value!,
                    maxColock / 1000f,
                    (float)CpuMonitor.MaxTemperature!.Value!,
                    MathF.Ceiling((float)ComputerMonitor.FanMonitorList[0]!.Speed!)
                    );
            }

        }
        public void Stop()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Stop);
            }
            else
            {
                timer.Change(-1, -1);
            }
        }
        
        private void Update(float _CpuUseRate, float _CpuClock, 
            float _temperature,float _fanSpeed)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<float,float,float,float>(Update), _CpuUseRate, _CpuClock, _temperature, _fanSpeed);
            }
            else
            {
                count++;
                DurationTime = DateTime.Now - timeStart;
                FanSpeed = _fanSpeed;
                CPUUseRate = _CpuUseRate;
                CPUClock = _CpuClock;
                CPUTemperature = _temperature;
                lineSeries.Values = lineSeries.Values!.Append((int)_CpuUseRate).ToList();
                if (count > 60)
                {
                    var Xaxes  = CPUUseRateChart.XAxes.ToList();
                    Xaxes[0].MaxLimit += 1;
                    Xaxes[0].MinLimit += 1;
                    CPUUseRateChart.XAxes = Xaxes;
                }
                
                CPUUseRateChart.Update();
            }
        }

        private void Warning()
        {
            var dr = MessageBox.Show($"CPU温度连续60s超过90℃！是否中止并排查故障", "错误",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
                System.Environment.Exit(0);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            
            Rectangle rectangle = new(0, 0, this.Width, 120);
            rectangle.Inflate(-2, -2);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                //绘制CPU型号
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Far;
                Font font = new Font("宋体", 25, FontStyle.Regular);
                g.DrawString("CPU型号", font, brush, rectangle, stringFormat);
                stringFormat.Alignment = StringAlignment.Far;
                font.Dispose();
                font = new Font("宋体", 15, FontStyle.Regular);

                stringFormat.LineAlignment = StringAlignment.Far;
                g.DrawString("  " + CpuModel+" ", font, brush, rectangle, stringFormat);
                //绘制CPU利用率
                rectangle.Size = new Size(this.Width/2, 150);
                rectangle.Location = new(0, this.Height - 310);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                font.Dispose();
                font = new Font("宋体", 18, FontStyle.Regular);
                g.DrawString("           CPU利用率", font, brush, rectangle, stringFormat);
                font.Dispose();
                font = new Font("宋体", 18, FontStyle.Regular);
                g.DrawString("\n            " + CpuUseRate.ToString("f2") + " %", font, brush, rectangle, stringFormat);
                //绘制CPU速度
                
                rectangle.Location = new(this.Width / 2, this.Height - 310);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                font.Dispose();
                font = new Font("宋体", 18, FontStyle.Regular);
                g.DrawString("           CPU速度", font, brush, rectangle, stringFormat);
                font.Dispose();
                font = new Font("宋体", 18, FontStyle.Regular);
                g.DrawString("\n           " + CpuClock.ToString("f2") + " GHZ", font, brush, rectangle, stringFormat);
 
                //绘制CPU温度
                rectangle.Location = new Point(50, 590);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                g.DrawString("CPU温度", font, brush, rectangle, stringFormat);
                font.Dispose();
                font = new Font("宋体", 18, FontStyle.Regular);
                g.DrawString("\n " + CpuTemperature.ToString() + " ℃", font, brush, rectangle, stringFormat);

                //绘制风扇转速
                rectangle.Location = new Point(560, 590);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                font.Dispose();
                font = new Font("宋体", 18, FontStyle.Regular);
                g.DrawString("风扇转速 ", font, brush, rectangle, stringFormat);
                font.Dispose();
                font = new Font("宋体", 18, FontStyle.Regular);
                g.DrawString("\n" + fanSpeed.ToString() + " r/min", font, brush, rectangle, stringFormat);

            }
            //绘制分界线
            using (Pen pen=new Pen(Color.Black, 2f))
            {
                g.DrawLine(pen, new Point(0, 540), new Point(this.Width, 540));
                g.DrawLine(pen, new Point(752 / 2, 540), new Point(752 / 2, this.Height));
            }
        }
    }
}
