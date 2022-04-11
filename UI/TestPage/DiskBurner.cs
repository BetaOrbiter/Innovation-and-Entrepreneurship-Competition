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
        private int durationTime;
        private int TotalDuration { get; set; }
        private int diskCount;
        private System.Threading.Timer timer;
        private DateTime timeStart;
        private TimeSpan timeSpan;

        
        public int DurationTime
        {
            get
            {
                return durationTime;
            }
            set
            {
                durationTime = value;
                timeSpan = DateTime.Now - timeStart;
                this.progressBar.Value = durationTime * 100 / TotalDuration;
                this.progressLabel.Text = $"测试进度 {durationTime * 100 / TotalDuration} %" +
                    $"(已经运行时间 {timeSpan.Hours}:{timeSpan.Minutes}:{timeSpan.Seconds}) ";
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
                    diskControls[i].DiskNumber = i;
                    diskControls[i].Parent = this.diskPanel;
                    diskControls[i].Show();
                }
                Refresh();
            }
        }

        
        public DiskBurner()
        {
            InitializeComponent();
            
           

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
                DurationTime = 0;
                timeStart = DateTime.Now;
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
            if (DurationTime >= TotalDuration)
            {
                Stop();
            }
            else
            {
                List<float> useRate=new ();
                List<float> readSpeed=new ();
                List<float> writeSpeed=new ();
                foreach (var diskMonitor in ComputerMonitor.DriveMonitorList)
                {
                    diskMonitor.Update();
                    useRate.Add((float)diskMonitor.Usage!.Value!);
                    readSpeed.Add((float)diskMonitor.ReadRate!.Value! / 1024f);
                    writeSpeed.Add((float)diskMonitor.WriteRate!.Value! / 1024f);
                }

                Update(useRate, readSpeed, writeSpeed);
            }

        }
        private void Stop()
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


        private void Update(List<float> useRate, List<float> readSpeed, List<float> writeSpeed)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<float>, List<float>, List<float>>(Update), useRate, readSpeed, writeSpeed);
            }
            else
            {
                DurationTime = durationTime + 1;
                for(int i = 0; i < diskCount; i++)
                {
                    diskControls[i].DiskActRate = (int)useRate[i];
                    diskControls[i].ReadSpeed = readSpeed[i];
                    diskControls[i].WriteSpeed = writeSpeed[i];
                }
            }
        }

    }
}
