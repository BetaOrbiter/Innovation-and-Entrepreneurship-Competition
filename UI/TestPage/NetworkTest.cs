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
using UI.MyControl;

namespace UI.TestPage
{
    public partial class NetworkTest : UserControl
    {
        private NetworkPortControl networkPortControl;
        private MACAddressControl macAddressControl;
        private float uploadSpeed;
        private float downloadSpeed; 
        private List<Tuple<string,string,bool>> netItems;
        private int count = 0;
        public List<Tuple<string, string, bool>> NetItems
        {
            get
            {
                return this.netItems;
            }
            set
            {
                this.netItems = value;
                macAddressControl.Parent = this;
                macAddressControl.NetItems = netItems;
                macAddressControl.Dock = DockStyle.Top;
                macAddressControl.Size = new(this.Width, this.Height * netItems.Count / 5);
                Refresh();
            }
        }
        public float UploadSpeed
        {
            get
            {
                return this.uploadSpeed;
            }
            set
            {
                this.uploadSpeed = value;
                Refresh();
            }
        }

        public float DownloadSpeed
        {
            get
            {
                return this.downloadSpeed;
            }
            set
            {
                this.downloadSpeed = value;
                networkPortControl.Parent = this;
                networkPortControl.DownloadSpeed = downloadSpeed;
                networkPortControl.UploadSpeed = uploadSpeed;
                networkPortControl.Dock = DockStyle.Top;
                networkPortControl.Size = new(this.Width, this.Height * 1 / 2);
                networkPortControl.Show();
                Refresh();
            }
        }
        public NetworkTest()
        {
            InitializeComponent();
            this.AutoScroll = true;
            networkPortControl = new NetworkPortControl();
            macAddressControl = new MACAddressControl();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public void NetPortTestWork()
        {

            NetAdapterMonitor net = ComputerMonitor.NetAdapterMonitorList[ComputerMonitor.NetAdapterMonitorList.Count - 1];
            net.Update();
            UpdateLoadSpeed((float) net.UploadSpeed!.Value!,(float) net.DownloadSpeed!.Value!);
        }
        public void UpdateLoadSpeed(float _uploadSpeed,float _downloadSpeed)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(UpdateLoadSpeed, _uploadSpeed, _downloadSpeed);
            }
            else
            {
                count++;
                if (count == 5) networkPortControl.AC = true;
                this.UploadSpeed = _uploadSpeed/(1024);
                this.DownloadSpeed = _downloadSpeed/(1024);
            }
        }
        public void MacCheckWork(List<Tuple<string, string, bool>> _netItems)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(MacCheckWork, _netItems);
            }
            else
            {
                NetItems = _netItems;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }
    }
}
