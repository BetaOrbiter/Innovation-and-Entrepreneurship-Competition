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
        private string macAddress;

        public string MACAddress
        {
            get
            {
                return this.macAddress;
            }
            set
            {
                this.macAddress = value;
                this.macAddressControl = new MACAddressControl();
                macAddressControl.Parent = this;
                macAddressControl.MACAddress = macAddress;
                macAddressControl.Dock = DockStyle.Top;
                macAddressControl.Size = new(this.Width, this.Height / 3);
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
                networkPortControl = new NetworkPortControl();
                networkPortControl.Parent = this;
                networkPortControl.DownloadSpeed = downloadSpeed;
                networkPortControl.UploadSpeed = uploadSpeed;
                networkPortControl.Dock = DockStyle.Top;
                networkPortControl.Size = new(this.Width, this.Height / 2);
                networkPortControl.Show();
                Refresh();
            }
        }
        public NetworkTest()
        {
            InitializeComponent();
            


        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }
    }
}
