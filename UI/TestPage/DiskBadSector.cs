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
        private int diskCount;
        private int nowDiskIndex;
        private int status;
        private string nowTask;
        private BadDiskControl[] badDiskControls;

        public int DiskCount
        {
            get
            {
                return diskCount;
            }
            set
            {
                diskCount = value;
                disksPanel.Dock = DockStyle.Bottom;
                disksPanel.Size = new(this.Width, this.Height * 3 / 7);
                badDiskControls = new BadDiskControl [DiskCount];
                for(int i=0;i<diskCount;i++)
                {
                    badDiskControls[i] = new BadDiskControl();
                    badDiskControls[i].DiskModel = "diskModel";
                    badDiskControls[i].Parent = this.disksPanel;
                    badDiskControls[i].Size = new(298, this.Height);
                    badDiskControls[i].Dock = DockStyle.Right;
                    badDiskControls[i].DiskCapactiy = 500;
                    badDiskControls[i].DiskIndex = i;
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
                
                this.progressLabel.Text = "测试进度" + (nowDiskIndex + 1)*100f / diskCount+"%";
                if (nowDiskIndex != diskCount-1)
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
                    g.DrawString("\n\n当前检测硬盘:硬盘"+ NowDiskIndex, font, brush, rectangle, stringFormat);
                    g.DrawString("\n\n\n\n当前执行任务:" + nowTask, font, brush, rectangle, stringFormat);
                }
            }
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
