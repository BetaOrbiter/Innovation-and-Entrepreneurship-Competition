using MyTool.Monitor;
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
    public partial class DiskBurner : UserControl
    {

        private MyDiskControl[] diskControls;
        private List<string> disks;
        private int TotalDuration { get; set; }
        private int diskCount;
        private System.Threading.Timer timer;
        private DateTime timeStart;
        private TimeSpan durationTime;

        
        public TimeSpan DurationTime
        {
            get
            {
                return durationTime;
            }
            set
            {
                durationTime = value;
                this.progressBar.Value =(int)durationTime.TotalSeconds * 100 / TotalDuration;
                this.progressLabel.Text = $"测试进度 {Math.Min(100, (int)durationTime.TotalSeconds * 100 / TotalDuration)} %" +
                    $"(已运行时间 {durationTime.Hours}:{durationTime.Minutes}:{durationTime.Seconds}) ";
            }
        }

        public List<string> Disks
        {
            get
            {
                return disks;
            }
            set
            {
                disks = value;
                diskCount = disks.Count;
                diskControls = new MyDiskControl[diskCount];
                for (int i = 0; i < diskCount; i++)
                {
                    diskControls[i] = new MyDiskControl();
                    diskControls[i].Dock = DockStyle.Top;
                    diskControls[i].DiskModel = disks[i];
                    diskControls[i].Text = "硬盘";
                    diskControls[i].Size = new(this.Width - 30, 250);
                    diskControls[i].DiskNumber = i + 1;
                    diskControls[i].Parent = this.diskPanel;
                    diskControls[i].Show();
                }
                Refresh();
            }
        }

        
        public DiskBurner()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


        }
        public void Work(List<string> _disks, int totalDuration )
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Work, _disks, totalDuration);
            }
            else
            {
                Disks = _disks;
                TotalDuration = totalDuration;
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
        private void OnTimer(object state)
        {
            if ((int) DurationTime.TotalSeconds >= TotalDuration)
            {
                Stop();
            }
            else
            {
                List<float> activityRate=new ();
                List<float> readSpeed=new ();
                List<float> writeSpeed=new ();
                foreach (var diskMonitor in ComputerMonitor.DriveMonitorList)
                {
                    diskMonitor.Update();
                    activityRate.Add((float)diskMonitor.TotalActivity!.Value!);
                    readSpeed.Add((float)diskMonitor.ReadRate!.Value! / (1024f * 1024f));
                    writeSpeed.Add((float)diskMonitor.WriteRate!.Value! / (1024f * 1024f));
                }

                Update(activityRate, readSpeed, writeSpeed);
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
        private void Update(List<float> activityRate, List<float> readSpeed, List<float> writeSpeed)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<float>, List<float>, List<float>>(Update), activityRate, readSpeed, writeSpeed);
            }
            else
            {
                DurationTime = DateTime.Now - timeStart;
                for(int i = 0; i < diskCount; i++)
                {
                    diskControls[i].DiskActRate = (int)activityRate[i];
                    diskControls[i].ReadSpeed = readSpeed[i];
                    diskControls[i].WriteSpeed = writeSpeed[i];
                }
            }
        }

    }
}
