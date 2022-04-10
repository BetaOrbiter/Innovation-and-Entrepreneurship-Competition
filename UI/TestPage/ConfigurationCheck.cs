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
                gpuCheckControl.Size = new(this.Width, 100);
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
                diskCheckControl.Size = new(this.Width, 50 * terminalMemoryModels.Count + 50);
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
                memoryCheckControl.Size = new(this.Width, 50 * terminalMemoryModels.Count + 50);
                memoryCheckControl.Parent = this;
                memoryCheckControl.Show();
                Invalidate();
            }
        }

        
        public ConfigurationCheck()
        {
            InitializeComponent();
            
        }
        public void Work(int step,List<string> actualInfos, List<string> expectedInfos,bool flag)
        {
            if (InvokeRequired)
            {
                this.Invoke(Work, step, actualInfos, expectedInfos, flag);
            }
            else
            {
                SetControlInit(actualInfos, expectedInfos, step);
                if (!flag) Warning(step);
                else Access(step);
            }
        }
        private void SetControlInit(List<string> actualInfos, List<string> expectedInfos, int step)
        {
            switch (step)
            {
                case 1:
                    TerminalCPUModel = actualInfos;
                    ConfigurationCPUModel = expectedInfos;
                    break;
                case 2:
                    TerminalMemoryModels = actualInfos;
                    ConfigurationMemoryModels = expectedInfos;
                    break;
                case 3:
                    TerminalGPUModel = actualInfos;
                    ConfigurationGPUModel = expectedInfos;
                    break;
                case 4:
                    TerminalDiskModels = actualInfos;
                    ConfigurationDiskModels = expectedInfos;
                    break;
            }
        }
        private void Warning(int step)
        {
            string testName="硬件";
            switch (step)
            {
                case 1:
                    cpuCheckControl.Flag = false;
                    testName = "CPU";
                    break;
                case 2:
                    memoryCheckControl.Flag = false;
                    testName = "内存";
                    break;
                case 3:
                    gpuCheckControl.Flag = false;
                    testName = "显卡";
                    break;
                case 4:
                    diskCheckControl.Flag = false;
                    testName = "硬盘";
                    break;
            }
            MessageBox.Show("本机"+testName+"与配置文件不符！", "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }
        private void Access(int step)
        {
            switch (step)
            {
                case 1:
                    cpuCheckControl.Flag = true;
                    break;
                case 2:
                    memoryCheckControl.Flag = true;
                    break;
                case 3:
                    gpuCheckControl.Flag = true;
                    break;
                case 4:
                    diskCheckControl.Flag = true;
                    break;
            }
        }
    }
}
