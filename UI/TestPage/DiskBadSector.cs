using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using UI.MyControl;

namespace UI.TestPage
{
    public partial class DiskBadSector : UserControl
    {
        private List<Tuple<string,ulong>> disks;
        private int diskCount;
        private int nowDiskIndex;
        private int status = 0;
        private string nowTask;
        private BadDiskControl[] badDiskControls;
        private TimeSpan durationTime;
        private DateTime timeStart;
        private System.Threading.Timer timer;
        public List<Tuple<string, ulong>> Disks
        {
            get
            {
                return disks;
            }
            set
            {
                disks = value;
                Status = 1;
                diskCount = disks.Count;
                disksPanel.AutoScroll = true;
                disksPanel.Dock = DockStyle.Bottom;
                disksPanel.Size = new(this.Width, this.Height * 3 / 7 + 35);
                badDiskControls = new BadDiskControl [diskCount];
                for(int i=0;i< diskCount; i++)
                {
                    badDiskControls[i] = new BadDiskControl();
                    badDiskControls[i].DiskModel = disks[i].Item1;
                    badDiskControls[i].Parent = this.disksPanel;
                    badDiskControls[i].Size = new(disksPanel.Width / 2, this.disksPanel.Height - 22);
                    
                    badDiskControls[i].DiskCapacity = disks[i].Item2;
                    badDiskControls[i].DiskIndex = i+1;
                    badDiskControls[i].Hide();
                    badDiskControls[i].Status = 0;
                }
                Refresh();
            }
        }
        public int NowDiskIndex
        {
            get
            {
                return nowDiskIndex;
            }
            set
            {
                nowDiskIndex = value;
                SetPosition();
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
                    case 3:
                        nowTask = "坏道修复中";
                        break;
                   
                }
                Invalidate();
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
                this.progressLabel.Text = $"测试进度 {(NowDiskIndex * 100f / diskCount).ToString("f1")} %"+
                     $"(已运行时间 {durationTime.Hours}:{durationTime.Minutes}:{durationTime.Seconds}) ";
                this.progressBar.Value = (NowDiskIndex) * 100 / diskCount;
            }
        }
        public DiskBadSector()
        {
            InitializeComponent();
            this.progressBar.Value = 0;
            Status = 0;
            nowDiskIndex = -1;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public void Work(List<Tuple<string, ulong>> _disks)
        {
            if (InvokeRequired)
            {
                this.Invoke(Work, _disks);
            }
            else
            {
                this.Disks = _disks;
                NowDiskIndex = 0;
                timeStart = DateTime.Now;
                DurationTime = DateTime.Now - DateTime.Now;
                timer = new System.Threading.Timer(
                new TimerCallback(OnTimer)
                , null
                , 1000
                , 1000
              );
            }
            
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
                    badDiskControls[nowDiskIndex].Status = 2;
                }
                else
                {
                    MessageBox.Show($"硬盘{nowDiskIndex+1}出现坏道！", "错误", 
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    badDiskControls[nowDiskIndex].Status = 3;
                }
                if (nowDiskIndex >= diskCount - 1) 
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
                NowDiskIndex = nowDiskIndex + 1;
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(this.Width / 2, this.Height * 1 / 16, this.Width / 2, this.Height * 1 / 2 );
            rectangle.Inflate(-5, -5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Rectangle dstRect = AfImageUtil.FitInside(rectangle, Properties.Resources.diskCheck.Size);
            g.DrawImage(Properties.Resources.diskCheck, dstRect);
            //using (Pen pen=new Pen(Color.Black))
            //{
            //    g.DrawLine(pen,0, 0, this.Width / 2, this.Height * 4 / 7);
            //}
            rectangle.Location =new(0, 0);
            using (Brush brush = new SolidBrush(Color.Black))
            {

                rectangle.Height = this.Height / 2;
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                using (Font font = new Font("宋体", 20, FontStyle.Regular))
                {
                    g.DrawString($"\n当前检测硬盘:硬盘{Math.Min(diskCount, NowDiskIndex + 1)}", font, brush, rectangle, stringFormat);
                    g.DrawString("\n\n\n当前执行任务:" + nowTask, font, brush, rectangle, stringFormat);
                }
            }
        }
        private void SetPosition()
        {
            for (int i = 0; i < diskCount; i++)
            {
                badDiskControls[i].Location = new(
                    (diskCount + badDiskControls[i].DiskIndex-1 - NowDiskIndex) % diskCount
                    * this.Width / 2,
                    0
                    );
                if (badDiskControls[i].DiskIndex-1 == NowDiskIndex)
                    badDiskControls[i].Status = 1;
                badDiskControls[i].Show();
            }
        }
        private void progressBar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
