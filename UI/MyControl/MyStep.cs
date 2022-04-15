using HZH_Controls;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class MyStep:UserControl
    {
        private Color m_stepBackColor = Color.FromArgb(189, 189, 189);

        private Color m_stepForeColor = Color.FromArgb(255, 77, 59);

        private Color m_stepFontColor = Color.White;

        private int m_stepWidth = 35;

        private string[] m_steps = new string[3]
        {
            "step1",
            "step2",
            "step3"
        };

        private int m_stepIndex = 0;

        private int m_lineWidth = 2;

        private Image m_imgCompleted = null;

        private List<Rectangle> m_lstCacheRect = new List<Rectangle>();
        private List<RectangleF> m_listStringRect = new List<RectangleF>();

        private IContainer components = null;

        [Category("自定义")]
        [Description("步骤背景色")]
        public Color StepBackColor
        {
            get
            {
                return m_stepBackColor;
            }
            set
            {
                m_stepBackColor = value;
                Refresh();
            }
        }

        [Description("步骤前景色")]
        [Category("自定义")]
        public Color StepForeColor
        {
            get
            {
                return m_stepForeColor;
            }
            set
            {
                m_stepForeColor = value;
                Refresh();
            }
        }

        [Description("步骤文字景色")]
        [Category("自定义")]
        public Color StepFontColor
        {
            get
            {
                return m_stepFontColor;
            }
            set
            {
                m_stepFontColor = value;
                Refresh();
            }
        }

        [Category("自定义")]
        [Description("步骤宽度景色")]
        public int StepWidth
        {
            get
            {
                return m_stepWidth;
            }
            set
            {
                m_stepWidth = value;
                Refresh();
            }
        }

        [Category("自定义")]
        [Description("步骤")]
        public string[] Steps
        {
            get
            {
                return m_steps;
            }
            set
            {
                if (m_steps != null && m_steps.Length > 1)
                {
                    m_steps = value;
                    Refresh();
                }
            }
        }

        [Description("步骤位置")]
        [Category("自定义")]
        public int StepIndex
        {
            get
            {
                return m_stepIndex;
            }
            set
            {
                if (value <= Steps.Length)
                {
                    m_stepIndex = value;
                    Refresh();
                    if (this.IndexChecked != null)
                    {
                        this.IndexChecked(this, null);
                    }
                }
            }
        }

        [Description("连接线宽度,最小2")]
        [Category("自定义")]
        public int LineWidth
        {
            get
            {
                return m_lineWidth;
            }
            set
            {
                if (value >= 2)
                {
                    m_lineWidth = value;
                    Refresh();
                }
            }
        }

        [Category("自定义")]
        [Description("已完成步骤图片，当不为空时，已完成步骤将不再显示数字,建议24*24大小")]
        public Image ImgCompleted
        {
            get
            {
                return m_imgCompleted;
            }
            set
            {
                m_imgCompleted = value;
                Refresh();
            }
        }

        [Description("步骤更改事件")]
        [Category("自定义")]
        public event EventHandler IndexChecked;
        private MyRoundBar [] hopeRoundProgressBars;

        

        private int[] nowProgress;
        public MyStep()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
            SetStyle(ControlStyles.DoubleBuffer, value: true);
            SetStyle(ControlStyles.ResizeRedraw, value: true);
            SetStyle(ControlStyles.Selectable, value: true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
            SetStyle(ControlStyles.UserPaint, value: true);
            base.MouseDown += UCStep_MouseDown;
            hopeRoundProgressBars = new MyRoundBar [15];
            nowProgress = new int[15];

           

            for (int i = 0; i < 15; i++)
            {
                hopeRoundProgressBars[i] = new MyRoundBar();
                hopeRoundProgressBars[i].Size = new Size(m_stepWidth - 4, m_stepWidth - 4);
                hopeRoundProgressBars[i].Font = new Font("宋体", 7, FontStyle.Regular);
                hopeRoundProgressBars[i].Parent = this;
                hopeRoundProgressBars[i].ValueNumber = 25;
                hopeRoundProgressBars[i].BackColor = Color.FromArgb(243, 244, 246);
                hopeRoundProgressBars[i].ValueNumber = 0;
                hopeRoundProgressBars[i].Hide();
            }
            
        }

        private void UCStep_MouseDown(object sender, MouseEventArgs e)
        {
            //List<MyRoundBar> k=new List<MyRoundBar>();
            
            //int num = m_lstCacheRect.FindIndex((Rectangle p) => p.Contains(e.Location));
            //int num2 = m_listStringRect.FindIndex((RectangleF p) => p.Contains(e.Location));
            
            //if (num >= 0)
            //{
            //    StepIndex = num + 1;
                
            //}
            //if (num2 >= 0)
            //{
            //    StepIndex = num2 + 1;
            //}
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Graphics graphics = e.Graphics;
            graphics.SetGDIHigh();
            if (m_steps == null || m_steps.Length <= 0)
            {
                return;
            }

            SizeF sizeF = graphics.MeasureString(m_steps[0], Font);
            int num = (base.Width - m_stepWidth - 180 - (int)sizeF.Height) / 2;
            //int num = (base.Height - m_stepWidth - 10 - (int)sizeF.Height) / 2;
            if (num < 0)
            {
                num = 0;
            }

            int y = num + m_stepWidth + 10;
            int num2 = 0;
            if (sizeF.Width > (float)m_stepWidth)
            {
                num2 = (int)(sizeF.Height - (float)m_stepWidth +50) / 2 + 1;
            }

            int num3 = 0;
            SizeF sizeF2 = graphics.MeasureString(m_steps[m_steps.Length - 1], Font);
            if (sizeF2.Width > (float)m_stepWidth)
            {
                num3 = (int)(sizeF2.Height - (float)m_stepWidth+10) / 2 + 1;
            }

            int num4 = 20;
            num4 = (base.Height - m_steps.Length - m_steps.Length * m_stepWidth - num3 - num2) / (m_steps.Length);
            if (num4 < 20)
            {
                num4 = 20;
            }

            m_lstCacheRect = new List<Rectangle>();
            m_listStringRect = new List<RectangleF>();
            for (int i = 0; i < m_steps.Length; i++)
            {
                Rectangle rectangle = new Rectangle(new Point(num, num2 + i * (m_stepWidth + num4)), new Size(m_stepWidth, m_stepWidth));
                m_lstCacheRect.Add(rectangle);
              
                if (m_stepIndex > i)
                {
                    //graphics.FillEllipse(new SolidBrush(m_stepForeColor), new Rectangle(new Point(num + 2, num2 + i * (m_stepWidth + num4) + 2), new Size(m_stepWidth - 4, m_stepWidth - 4)));
                    hopeRoundProgressBars[i].Location = new Point(num, num2 + i * (m_stepWidth + num4));
                    hopeRoundProgressBars[i].ValueNumber = 100;
                    hopeRoundProgressBars[i].Show();
                }
                else if (m_stepIndex == i)
                {
                    //MessageBox.Show(m_stepIndex.ToString());
                    hopeRoundProgressBars[i].Location = new Point(num, num2 + i * (m_stepWidth + num4));
                    hopeRoundProgressBars[i].ValueNumber = nowProgress[i];
                    hopeRoundProgressBars[i].Show();
                }
                else
                {
                    hopeRoundProgressBars[i].Hide();
                    //hoperoundprogressbars[0].location = new point(num, num2 + i * (m_stepwidth + num4));
                    graphics.FillEllipse(new SolidBrush(m_stepBackColor), rectangle);
                }
                if (m_stepIndex > i && m_imgCompleted != null)
                {
                    graphics.DrawImage(m_imgCompleted, new Rectangle(new Point(num + (m_stepWidth - 24) / 2, num2 + i * (m_stepWidth + num4) + (m_stepWidth - 24) / 2), new Size(24, 24)), 0, 0, m_imgCompleted.Width, m_imgCompleted.Height, GraphicsUnit.Pixel, null);
                }
                else
                {
                    
                    SizeF sizeF3 = graphics.MeasureString((i + 1).ToString(), Font);
                    graphics.DrawString((i + 1).ToString(), Font, new SolidBrush(m_stepFontColor), new Point(num + (m_stepWidth - (int)sizeF3.Width) / 2 + 1, num2 + i * (m_stepWidth + num4) + (m_stepWidth - (int)sizeF3.Height) / 2 + 1));
                }

                SizeF sizeF4 = graphics.MeasureString(m_steps[i], Font);
                
                System.Diagnostics.Debug.WriteLine(sizeF4);
                //Console.WriteLine(sizeF4);
                graphics.DrawString(m_steps[i], Font, new SolidBrush((m_stepIndex > i) ? m_stepForeColor : m_stepBackColor), new Point(y, num2 + i * (m_stepWidth + num4) + (m_stepWidth - (int)sizeF4.Height) / 2 + 1));
                m_listStringRect.Add(new RectangleF(new Point(y, num2 + i * (m_stepWidth + num4) + (m_stepWidth - (int)sizeF4.Height) / 2 + 1), sizeF4)); 
            }

            for (int i = 0; i < m_steps.Length; i++)
            {
                if (m_stepIndex > i)
                {
                    if (i != m_steps.Length - 1)
                    {
                        if (m_stepIndex == i + 1)
                        {
                            graphics.DrawLine(new Pen(m_stepForeColor, m_lineWidth), new Point(num + m_stepWidth / 2, num2 + i * (m_stepWidth + num4) + m_stepWidth - 3), new Point(num + m_stepWidth / 2, num2 + i * (m_stepWidth + num4) + m_stepWidth + num4 / 2));
                            graphics.DrawLine(new Pen(m_stepBackColor, m_lineWidth), new Point(num + m_stepWidth / 2, num2 + i * (m_stepWidth + num4) + m_stepWidth + num4 / 2), new Point(num + m_stepWidth / 2, num2 + (i + 1) * (m_stepWidth + num4) + 10));
                        }
                        else
                        {
                            graphics.DrawLine(new Pen(m_stepForeColor, m_lineWidth), new Point(num + m_stepWidth / 2, num2 + i * (m_stepWidth + num4) + m_stepWidth - 3), new Point(num + m_stepWidth / 2, num2 + (i + 1) * (m_stepWidth + num4) + 10));
                        }
                    }
                }
                else if (i != m_steps.Length - 1)
                {
                    graphics.DrawLine(new Pen(m_stepBackColor, m_lineWidth), new Point(num + m_stepWidth / 2, num2 + i * (m_stepWidth + num4) + m_stepWidth - 3), new Point(num + m_stepWidth / 2, num2 + (i + 1) * (m_stepWidth + num4) + 10));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Transparent;
            Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            base.Name = "UCStep";
            base.Size = new System.Drawing.Size(239, 80);
            ResumeLayout(false);
        }
        public void ChangeNowProgress(int index, int value)
        {
            hopeRoundProgressBars[index].ValueNumber = value;
        }

    }
}
