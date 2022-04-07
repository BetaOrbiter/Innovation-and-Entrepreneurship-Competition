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
        private int diskCount;
        public int DiskCount
        {
            get
            {
                return this.diskCount;
            }
            set
            {
                this.diskCount = value;
               
                diskControls = new MyDiskControl[diskCount];
                for (int i = 0; i < diskCount; i++)
                {
                    diskControls[i] = new MyDiskControl();
                    diskControls[i].Dock = DockStyle.Top;
                    diskControls[i].Text = "硬盘";
                    diskControls[i].Size = new(this.Width-30, 250);
                    diskControls[i].DiskNumber = i;
                    diskControls[i].Parent = this;
                    diskControls[i].Show();
                }
                Refresh();
            }
        }
        public DiskBurner()
        {
            InitializeComponent();
            
           

        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            
        }
    }
}
