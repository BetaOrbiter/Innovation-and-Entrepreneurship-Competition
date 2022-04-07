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
        private string terminalCPUModel;
        private string configurationCPUModel;
        private List<string> terminalMemoryModels;
        private List<string> configurationMemoryModels;
        private string terminalGPUModel;
        private string configurationGPUModel;
        private List<string> terminalDiskModels;
        private List<string> configurationDiskModels;
        RTCTestControl rtcTextControl;
        ModelCheckControl cpuCheckControl;
        ModelsCheckControl memoryCheckControl;
        ModelCheckControl gpuCheckControl;
        ModelsCheckControl diskCheckControl;
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
        public string TerminalCPUModel
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
        public string ConfigurationCPUModel
        {
            get
            {
                return configurationCPUModel;
            }
            set
            {
                configurationCPUModel = value;
                cpuCheckControl = new ModelCheckControl();
                cpuCheckControl.Text = "CPU";
                cpuCheckControl.TerminalModel = this.terminalCPUModel;
                cpuCheckControl.ConfigurationModel = this.configurationCPUModel;
                cpuCheckControl.Dock = DockStyle.Top;
                cpuCheckControl.Size = new(this.Width, 100);
                cpuCheckControl.Parent = this;
                cpuCheckControl.Show();
                Refresh();
            }
        }
        public string TerminalGPUModel
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
        public string ConfigurationGPUModel
        {
            get
            {
                return configurationGPUModel;
            }
            set
            {
                configurationGPUModel = value;

                gpuCheckControl = new ModelCheckControl();
                gpuCheckControl.Text = "显卡";
                gpuCheckControl.TerminalModel = this.terminalGPUModel;
                gpuCheckControl.ConfigurationModel = this.configurationGPUModel;
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }
        
    }
}
