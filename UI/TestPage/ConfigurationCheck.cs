using Hardware.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.MyControl;

namespace UI.TestPage
{
    public partial class ConfigurationCheck : UserControl
    {
        private DateTime terminalTime;
        private DateTime configurationTime;
        private List<string> terminalCPUModel;
        private List<string> configurationCPUModel;
        private List<string> terminalMemoryModels;
        private List<string> configurationMemoryModels;
        private List<string> terminalGPUModel;
        private List<string> configurationGPUModel;
        private List<string> terminalDiskModels;
        private List<string> configurationDiskModels;
        private RTCTestControl rtcTextControl;
        private ModelsCheckControl cpuCheckControl;
        private ModelsCheckControl memoryCheckControl;
        private ModelsCheckControl gpuCheckControl;
        private ModelsCheckControl diskCheckControl;
        private DiskSmartControl diskSmartControl;
        private List<Tuple<string, int, int, int, int, bool>> diskSmarts;

        public DateTime TerminalTime
        {
            get
            {
                return this.terminalTime;
            }
            set
            {
                this.terminalTime = value;
                
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
                rtcTextControl = new RTCTestControl();
                rtcTextControl.TerminalTime = this.terminalTime;
                rtcTextControl.ConfigurationTime = this.configurationTime;
                rtcTextControl.Dock = DockStyle.Top;
                rtcTextControl.Size = new(this.Width, 100);
                rtcTextControl.Parent = this;
                rtcTextControl.Show();
                Refresh();
            }
        }
        public List<string> TerminalCPUModel
        {
            get
            {
                return terminalCPUModel;
            }
            set
            {
                terminalCPUModel = value;
            }
        }
        public List<string> ConfigurationCPUModel
        {
            get
            {
                return configurationCPUModel;
            }
            set
            {
                configurationCPUModel = value;
                cpuCheckControl = new ModelsCheckControl();
                cpuCheckControl.Text = "CPU";
                cpuCheckControl.TerminalModels = this.terminalCPUModel;
                cpuCheckControl.ConfigurationModels = this.configurationCPUModel;
                cpuCheckControl.Dock = DockStyle.Top;
                cpuCheckControl.Size = new(this.Width, 100);
                cpuCheckControl.Parent = this;
                cpuCheckControl.Show();
                Refresh();
            }
        }
        public List<string> TerminalGPUModel
        {
            get
            {
                return terminalGPUModel;
            }
            set
            {
                terminalGPUModel = value;
               
            }
        }
        public List<string> ConfigurationGPUModel
        {
            get
            {
                return configurationGPUModel;
            }
            set
            {
                configurationGPUModel = value;

                gpuCheckControl = new ModelsCheckControl();
                gpuCheckControl.Text = "显卡";
                gpuCheckControl.TerminalModels = this.terminalGPUModel;
                gpuCheckControl.ConfigurationModels = this.configurationGPUModel;
                gpuCheckControl.Dock = DockStyle.Top;
                gpuCheckControl.Size = new(this.Width, 50 + 55 * Math.Max(terminalGPUModel.Count, configurationCPUModel.Count));
                gpuCheckControl.Parent = this;
                gpuCheckControl.Show();
                Refresh();
            }
        }
        public List<string> TerminalDiskModels
        {
            get
            {
                return terminalDiskModels;
            }
            set
            {
                terminalDiskModels = value;
            }
        }

        public List<string> ConfigurationDiskModels
        {
            get
            {
                return configurationDiskModels;
            }
            set
            {
                configurationDiskModels = value;
                diskCheckControl = new ModelsCheckControl();
                diskCheckControl.Text = "硬盘";
                diskCheckControl.TerminalModels = terminalDiskModels;
                diskCheckControl.ConfigurationModels = configurationDiskModels;
                diskCheckControl.Dock = DockStyle.Top;
                diskCheckControl.Size = new(this.Width, 55 * Math.Max(terminalMemoryModels.Count,configurationDiskModels.Count) + 50);
                diskCheckControl.Parent = this;
                diskCheckControl.Show();

                Refresh();
            }
        }
        public List<string> TerminalMemoryModels
        {
            get
            {
                return terminalMemoryModels;
            }
            set
            {
                terminalMemoryModels = value;
                Invalidate();
            }
        }

        public List<string> ConfigurationMemoryModels
        {
            get
            {
                return configurationMemoryModels;
            }
            set
            {
                configurationMemoryModels = value;
                memoryCheckControl = new ModelsCheckControl();
                memoryCheckControl.Text = "内存";
                memoryCheckControl.TerminalModels = terminalMemoryModels;
                memoryCheckControl.ConfigurationModels = configurationMemoryModels;
                memoryCheckControl.Dock = DockStyle.Top;
                memoryCheckControl.Size = new(this.Width, 55 * Math.Max(terminalMemoryModels.Count, configurationMemoryModels.Count) + 50);
                memoryCheckControl.Parent = this;
                memoryCheckControl.Show();
                Invalidate();
            }
        }

        private List<Tuple<string, int, int, int, int, bool>> DiskSmarts
        {
            get
            {
                return diskSmarts;
            }
            set
            {
                diskSmarts = value;
                diskSmartControl = new();
                diskSmartControl.Dock = DockStyle.Top;
                diskSmartControl.Disks = diskSmarts;
                diskSmartControl.Size = new(this.Width, 55 * diskSmarts.Count+50 );
                diskSmartControl.Parent = this;
                diskSmartControl.Show();
            }
        }
        public ConfigurationCheck()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public void RTCWork(DateTime _serverTime,DateTime _terminalTime,bool flag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(RTCWork, _serverTime, _terminalTime,flag);
            }
            else
            {
                TerminalTime = _terminalTime;
                ConfigurationTime = _serverTime;
                if (!flag) Warning(0);
                else Access(0);
            }
        }
        public void Work(Controller.TestType testType, List<string> actualInfos, List<string> expectedInfos,bool flag)
        {
            if (InvokeRequired)
            {
                this.Invoke(Work, testType, actualInfos, expectedInfos, flag);
            }
            else
            {
                SetControlInit(testType,actualInfos, expectedInfos);
                if (!flag) Warning(testType);
                else Access(testType);
            }
        }
        public void DiskSmartWork(List<Tuple<string, int, int, int, int, bool>> _diskSmarts)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(DiskSmartWork, _diskSmarts);
            }
            else
            {
                DiskSmarts = _diskSmarts;
            }
        }
        private void SetControlInit(Controller.TestType testType,List<string> actualInfos, List<string> expectedInfos)
        {
            switch (testType)
            {
                case Controller.TestType.CPUConfigCheck:
                    TerminalCPUModel = actualInfos;
                    ConfigurationCPUModel = expectedInfos;
                    break;
                case Controller.TestType.MemoryConfigCheck:
                    TerminalMemoryModels = actualInfos;
                    ConfigurationMemoryModels = expectedInfos;
                    break;
                case Controller.TestType.GPUConfigCheck:
                    TerminalGPUModel = actualInfos;
                    ConfigurationGPUModel = expectedInfos;
                    break;
                case Controller.TestType.DiskConfigCheck:
                    TerminalDiskModels = actualInfos;
                    ConfigurationDiskModels = expectedInfos;
                    break;
            }
        }
        private void Warning(Controller.TestType testType)
        {
            string testName="";
            switch (testType)
            {
                case Controller.TestType.RTCTest:
                    rtcTextControl.Flag = false;
                     break;
                case Controller.TestType.CPUConfigCheck:
                    cpuCheckControl.Flag = false;
                    testName = "CPU";
                    break;
                case Controller.TestType.MemoryConfigCheck:
                    memoryCheckControl.Flag = false;
                    testName = "内存";
                    break;
                case Controller.TestType.GPUConfigCheck:
                    gpuCheckControl.Flag = false;
                    testName = "显卡";
                    break;
                case Controller.TestType.DiskConfigCheck:
                    diskCheckControl.Flag = false;
                    testName = "硬盘";
                    break;
            }
            if (Controller.TestType.RTCTest == testType)
            {
                MessageBox.Show("终端时间与服务端不一致！", "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("本机" + testName + "与配置文件不符！", "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
        private void Access(Controller.TestType testType)
        {
            switch (testType)
            {
                case Controller.TestType.RTCTest:
                    rtcTextControl.Flag = true;
                    break;
                case Controller.TestType.CPUConfigCheck:
                    cpuCheckControl.Flag = true;
                    break;
                case Controller.TestType.MemoryConfigCheck:
                    memoryCheckControl.Flag = true;
                    break;
                case Controller.TestType.GPUConfigCheck:
                    gpuCheckControl.Flag = true;
                    break;
                case Controller.TestType.DiskConfigCheck:
                    diskCheckControl.Flag = true;
                    break;
            }
        }
    }
}
