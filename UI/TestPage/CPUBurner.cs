using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.Geo;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.SKCharts;
using SkiaSharp;

namespace UI.TestPage
{
    public partial class CPUBurner : UserControl
    {
        private string CpuKind = "Intel(R) Core(TM) i7 - 9750H CPU @ 2.60GHz";
        private double CpuUseRate, CpuSpeed;
        private int CpuTemperature, fanSpeed;
        private DateTime durationTime;
        private LineSeries<int> lineSeries;
        private System.Threading.Timer timer;
        int tmp=0;
        public LineSeries<int> LineSerise
        {
            get
            {
                return this.lineSeries;
            }
            set
            {
                this.lineSeries = value;
                PaintChart();
            }
        }
        private string CPUKind
        {
            get
            {
                return this.CpuKind;
            }
            set
            {
                CpuKind = value;
            }
        }
        private double CPUUseRate
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
        private double CPUSpeed
        {
            get
            {
                return this.CpuSpeed;
            }
            set
            {
                CpuSpeed = value;
                this.Invalidate();
            }
        }
        public int CPUTemperature
        {
            get
            {
                return this.CpuTemperature;
            }
            set
            {
                CpuTemperature = value;
                this.CPUThermometer.Value = CpuTemperature;
                this.Invalidate();
            }
        }
        public int FanSpeed
        {
            get
            {
                return this.fanSpeed;
            }
            set
            {
                fanSpeed = value;
                if (fanSpeed > 0) this.fanPictureBox.Image = Properties.Resources.fanStart;
                this.Invalidate();
            }
        }

        public DateTime DurationTime
        {
            get
            {
                return this.durationTime;
            }
            set
            {
                durationTime = value;
                
                this.Invalidate();
            }
        }


        public CPUBurner()
        {
            InitializeComponent();

            CPUMessageChart.Size = new Size(this.Width - 160, this.Height / 3);
            CPUMessageChart.Location = new Point(0, this.Height / 8);
            lineSeries = new LineSeries<int>
            {
                Values = new int[] {1,2,3,4},
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },

            };
            
            lineSeries.Values=lineSeries.Values.Append(5);
            
            //lineSeries.Values.Append<int>(5);
            
            CPUMessageChart.Series = new ISeries[]
            {
                lineSeries
            };
            
            CPUThermometer.Location = new Point(250, 550);
            CPUThermometer.Size = new Size(70, 180);
            CPUThermometer.Value = 50;
            CpuTemperature = 50;
          
            CpuSpeed = 3.45;
            CpuUseRate = 90.2;
            durationTime = new DateTime();
            
            //Point(560, 590);
            
            this.fanPictureBox.Size = new(100, 100);
            this.fanPictureBox.Location = new(310, 360);
            this.fanPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            fanSpeed = 5000;
            timer = new System.Threading.Timer(
                new TimerCallback(OnTimer)
                , null
                , 1000
                , 1000
             );
            
            if (fanSpeed > 0) this.fanPictureBox.Image = Properties.Resources.fanStart;
            else this.fanPictureBox.Image = Properties.Resources.fanStop;

        }
        public void OnTimer(object state)
        {
            tmp++;
            lineSeries.Values=lineSeries.Values.Append(tmp);
            PaintChart();
            if (tmp >= 20)
            {
                timer.Change(-1, -1);
                return;
            }

        }
        //private void ChartWork()
        //{
            
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        lineSeries = new LineSeries<int> { Values=new int[]{ i,i+1,i+2} };
        //        //Console.WriteLine(this.lineSeries.Values);
        //        Thread.Sleep(1000);
        //        CPUMessageChart.Update();
        //        //PaintChart();
        //    }
        //}
       

        

        private void PaintChart()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.PaintChart));
            }
            else
            {
                CPUMessageChart.Update();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            
            Rectangle rectangle = new(0, 0, this.Width, 100);
            rectangle.Inflate(-2, -2);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                //绘制CPU型号
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                Font font = new Font("Ink Free", 25, FontStyle.Regular);
                g.DrawString("CPU", font, brush, rectangle, stringFormat);
                font = new Font("方正舒体", 25, FontStyle.Regular);
                stringFormat.Alignment = StringAlignment.Near;
                g.DrawString("       型号:", font, brush, rectangle, stringFormat);
                stringFormat.Alignment = StringAlignment.Far;

                font = new Font("Ink Free", 15, FontStyle.Regular);

                stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("  " + CPUKind, font, brush, rectangle, stringFormat);
                //绘制CPU利用率
                rectangle.Size = new Size(this.Width/2, 150);
                rectangle.Location = new(0, this.Height - 310);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                font = new Font("Ink Free", 20, FontStyle.Regular);
                g.DrawString("           CPU",font, brush, rectangle, stringFormat);
                font = new Font("方正舒体", 20, FontStyle.Regular);
                g.DrawString("                    利用率" , font, brush, rectangle, stringFormat);
                font = new Font("Ink Free", 20, FontStyle.Regular);
                g.DrawString("\n               " + CpuUseRate.ToString() + " %", font, brush, rectangle, stringFormat);
                //绘制CPU速度
                
                rectangle.Location = new(this.Width / 2, this.Height - 310);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                font = new Font("Ink Free", 20, FontStyle.Regular);
                g.DrawString("           CPU", font, brush, rectangle, stringFormat);
                font = new Font("方正舒体", 20, FontStyle.Regular);
                g.DrawString("                    速度", font, brush, rectangle, stringFormat);
                font = new Font("Ink Free", 20, FontStyle.Regular);
                g.DrawString("\n           " + CpuSpeed.ToString() + " GHZ", font, brush, rectangle, stringFormat);
 
                //绘制CPU温度
                rectangle.Location = new Point(50, 590);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                g.DrawString("CPU" , font, brush, rectangle, stringFormat);
                font = new Font("方正舒体", 20, FontStyle.Regular);
                g.DrawString("        温度 ", font, brush, rectangle, stringFormat);
                font = new Font("Ink Free", 20, FontStyle.Regular);
                g.DrawString("\n   " + CpuTemperature.ToString() + " ℃", font, brush, rectangle, stringFormat);

                //绘制风扇转速
                rectangle.Location = new Point(560, 590);
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                font = new Font("方正舒体", 20, FontStyle.Regular);
                g.DrawString("风扇转速 ", font, brush, rectangle, stringFormat);
                font = new Font("Ink Free", 20, FontStyle.Regular);
                g.DrawString("\n" + fanSpeed.ToString() + " r/min", font, brush, rectangle, stringFormat);

            }
            //绘制分界线
            using (Pen pen=new Pen(Color.Black))
            {
                g.DrawLine(pen, new Point(0, 540), new Point(this.Width, 540));
                g.DrawLine(pen, new Point(752 / 2, 540), new Point(752 / 2, this.Height));
            }
        }
    }
}
