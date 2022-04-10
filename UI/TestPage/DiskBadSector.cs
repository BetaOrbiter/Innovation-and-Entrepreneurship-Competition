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

        public List<Tuple<string, ulong>> Disks
        {
            get
            {
                return disks;
            }
            set
            {
                disks = value;
                this.status = 0;
                diskCount = disks.Count;
                disksPanel.AutoScroll = true;
                disksPanel.Dock = DockStyle.Bottom;
                disksPanel.Size = new(this.Width, this.Height * 3 / 7);
                badDiskControls = new BadDiskControl [diskCount];
                for(int i=0;i< diskCount; i++)
                {
                    badDiskControls[i] = new BadDiskControl();
                    badDiskControls[i].DiskModel = disks[i].Item1;
                    badDiskControls[i].Parent = this.disksPanel;
                    badDiskControls[i].Size = new(disksPanel.Width/2, this.Height);
                    badDiskControls[i].Dock = DockStyle.Right;
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
                status = 1;
                this.progressLabel.Text = "测试进度" + (nowDiskIndex)*100f / diskCount+"%";
                this.progressBar.Value = (nowDiskIndex) * 100 / diskCount;
                if (nowDiskIndex < diskCount-1)
                {
                    badDiskControls[nowDiskIndex].Show();
                    badDiskControls[nowDiskIndex].Status = 1;
                    badDiskControls[nowDiskIndex+1].Show();
                    badDiskControls[nowDiskIndex+1].Status = 0;
                }
                else
                {
                    badDiskControls[nowDiskIndex].Show();
                    badDiskControls[nowDiskIndex].Status = 1;
                }
                Invalidate();
                Refresh();
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
                        break;
                    case 3:
                        nowTask = "坏道修复中";
                        break;
                   
                }
                Invalidate();
                Refresh();
            }
        }
        public DiskBadSector()
        {
            InitializeComponent();
            this.progressBar.Value = 0;
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
                    badDiskControls[nowDiskIndex].Dock = DockStyle.Left;
                }
                else
                {
                    MessageBox.Show("硬盘" + nowDiskIndex + "出现坏道！", "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    badDiskControls[nowDiskIndex].Status = 3;
                }
                if (nowDiskIndex == diskCount - 1) 
                {
                    this.progressLabel.Text = "测试进度100%";
                    this.progressBar.Value = 100;
                    Status = 2; 
                }
                else
                {
                    Status = 1;
                    NowDiskIndex = nowDiskIndex + 1;
                }
            
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
                    g.DrawString("已运行时间:",font, brush, rectangle, stringFormat);
                    g.DrawString("\n\n当前检测硬盘:硬盘"+ (NowDiskIndex+1), font, brush, rectangle, stringFormat);
                    g.DrawString("\n\n\n\n当前执行任务:" + nowTask, font, brush, rectangle, stringFormat);
                }
            }
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
