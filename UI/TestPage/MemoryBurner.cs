using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using MyTool.Monitor;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.TestPage
{
    public partial class MemoryBurner : UserControl
    {
        private List<string> memoryModels;
        private float memoryUseage;
        private float memoryUse;
        private float memoryRest;
        private ulong MemorySize { get; set; }
        private LineSeries<int> lineSeries { get; set; }
        private int TotalDuration { get; set; }
        private System.Threading.Timer timer;
        private TimeSpan durationTime;
        private DateTime timeStart;
        //记录图标更新次数
        private int count;
        public float MemoryUseage
        {
            get
            {
                return this.memoryUseage;
            }
            set
            {
                this.memoryUseage = value;
                this.memoryUseBar.Value = (long)memoryUseage;
            }
        }
        public float MemoryUse
        {
            get
            {
                return this.memoryUse;
            }
            set
            {
                this.memoryUse = value;
                this.Invalidate();
            }
        }
        public float MemoryRest
        {
            get
            {
                return this.memoryRest;
            }
            set
            {
                this.memoryRest = value;
                Invalidate();
            }
        }
        public List<string> MemoryModels
        {
            get
            {
                return this.memoryModels;
            }
            set
            {
                this.memoryModels = value;
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
                durationTime = value;
                this.progressBar.Value = (int)durationTime.TotalSeconds * 100 / TotalDuration;
                this.progressLabel.Text = $"测试进度 {Math.Min(100, (int)durationTime.TotalSeconds * 100 / TotalDuration)} %" +
                    $"(已经运行时间 {durationTime.Hours}:{durationTime.Minutes}:{durationTime.Seconds}) ";
            }
        }

        public MemoryBurner()
        {
            InitializeComponent();
            //内存使用率图表初始化
            this.memoryUseRateChart.Size = new(this.Width - 160, this.Height * 1 / 3);
            this.memoryUseRateChart.Location = new(0, this.Height / 6);
            this.bigLabel1.Location = new(10, this.Height / 6 - 5);
            memoryModels = new List<string>();
            lineSeries = new LineSeries<int>
            {
                Values = new int[1],
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 2 },
                LineSmoothness = 0,
                GeometryFill = null, // mark
                GeometryStroke = null // mark
            };


            memoryUseRateChart.Series = new ISeries[]
            {
                lineSeries,
            };

            memoryUseRateChart.XAxes = new List<Axis>{
                new Axis{
                  MaxLimit = 60,
                  MinLimit = 0,

                }
            };
            memoryUseRateChart.YAxes = new List<Axis>{
                new Axis{
                  MaxLimit = 105,
                  MinLimit = 0
                }
            };
            this.memoryUseBar.Size = new(this.Width / 5, this.Width / 5);
            this.memoryUseBar.Location = new(this.Width / 20, this.Height * 1 / 2+25);
            this.memoryUseBar.Value = 0;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void Work(List<string> _memoryModels,ulong memorySize, int _totalDuration)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Work, _memoryModels, memorySize, _totalDuration);
            }
            else
            {
                TotalDuration = _totalDuration;
                timeStart = DateTime.Now;
                DurationTime = DateTime.Now - DateTime.Now;
                MemoryModels = _memoryModels;
                MemorySize = memorySize;
                count = 0;
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
                ComputerMonitor.MemoryMonitor.Update();
               
                Update((float)ComputerMonitor.MemoryMonitor.Usage!.Value!);
            }
        }

        private void Update(float usage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<float>(Update), usage);
            }
            else
            {
                count++;
                MemoryUseage= usage;
                MemoryUse = usage / 100f * (float)MemorySize;
                MemoryRest = (1f - usage / 100f) * (float)MemorySize;
                lineSeries.Values = lineSeries.Values!.Append((int)usage).ToList();
                DurationTime = DateTime.Now - timeStart;
                if (count > 60)
                {
                    var Xaxes = memoryUseRateChart.XAxes.ToList();
                    Xaxes[0].MaxLimit += 1;
                    Xaxes[0].MinLimit += 1;
                    memoryUseRateChart.XAxes = Xaxes;
                }
                memoryUseRateChart.Update();
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


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            RectangleF rectangle = new RectangleF(0, this.Height / 10, this.Width, this.Height / 6);
            using (Brush brush=new SolidBrush(Color.Black))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                Font font = new Font("宋体", 25, FontStyle.Regular);
                g.DrawString("内存", font, brush, rectangle, stringFormat);
                font.Dispose();
                font = new Font("宋体", 15, FontStyle.Regular);
                for(int i=0;i<memoryModels.Count;i++)
                {
                    g.DrawString($"内存 {i + 1}: " + memoryModels[i]+" ", font, brush, this.Width / 2, this.Height / 12 + 40 * i);
                }
                rectangle.Size = new(this.Width / 2, this.Height / 3);
                rectangle.Location = new(this.Width / 2, this.Height * 5 / 9);
                font.Dispose();
                font = new Font("宋体", 20, FontStyle.Regular);
                stringFormat.LineAlignment = StringAlignment.Near;
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString("\n内存组合", font, brush, rectangle, stringFormat);
                font.Dispose();
                font = new Font("宋体", 15, FontStyle.Regular);
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString("使用中 "+memoryUse.ToString("f2") + "GB", font, brush, rectangle, stringFormat);
                stringFormat.LineAlignment = StringAlignment.Far;
                g.DrawString("可用 " + memoryRest.ToString("f2") + "GB", font, brush, rectangle, stringFormat);
                font.Dispose();
            }
        }

        private void MemoryBurner_Load(object sender, EventArgs e)
        {

        }
    }
}
