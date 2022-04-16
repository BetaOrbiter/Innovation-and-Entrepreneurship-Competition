using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace UI
{
    class MyClock : Control
    {
        System.Windows.Forms.Timer timer;
        private TimeSpan timeSpan;
        private DateTime dateTimeStart;
        private DateTime dataTimeNow;

        public MyClock()
        {
            this.Size = new Size(200, 200);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            //
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += this.OnTimer; // 简写
            timer.Start();
            dateTimeStart = DateTime.Now;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            dataTimeNow = DateTime.Now;
            timeSpan = dataTimeNow - dateTimeStart;
            this.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            // 随着控件的销毁而销毁
            timer.Dispose();

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;

            // 计算中间的正方形区域
            int size = w;
            if (size > h) size = h;
            Rectangle rect = new Rectangle(0, (h - size) / 2, size, size);
            
            // 平滑绘制，反锯齿
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            using (Brush brush=new SolidBrush(Color.Black))
            {
                Rectangle rectangle = new Rectangle(size, 0, this.Width - size, this.Height);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                using (Font font =new Font("宋体",10,FontStyle.Regular))
                {
                    g.DrawString("\n当前时间:\n" + dataTimeNow.Hour+ ":" + dataTimeNow.Minute + ":" + dataTimeNow.Second, font, brush, rectangle, stringFormat);
                    stringFormat.LineAlignment = StringAlignment.Center;
                    g.DrawString("\n\n\n已运行时间:\n" + timeSpan.Hours+":"+timeSpan.Minutes+":"+timeSpan.Seconds, font, brush, rectangle, stringFormat);
                }
            }

            // 绘制表盘
            if (true)
            {
                rect.Inflate(-2, -2);

                // 表盘背景：白色
                Brush brush = new SolidBrush(Color.White);
                g.FillEllipse(brush, rect);
                brush.Dispose();

                // 表框
                Pen pen = new Pen(Color.Gray);
                pen.Width = 2;
                g.DrawEllipse(pen, rect);
                pen.Dispose();
            }

            // 刻度
            using (Pen pen = new Pen(Color.Gray))
            {
                pen.Width = 2;
                int cx = rect.X + rect.Width / 2;
                int cy = rect.Y + rect.Height / 2;
                int R1 = rect.Width / 2;
                int R2 = R1 - 5;

                //
                for (int i = 0; i < 12; i++)
                {
                    double angle = Math.PI * (360 / 12) * i / 180;
                    double x1 = cx + R1 * Math.Cos(angle);
                    double y1 = cy + R1 * Math.Sin(angle);
                    double x2 = cx + R2 * Math.Cos(angle);
                    double y2 = cy + R2 * Math.Sin(angle);
                    g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
                }
            }

            // 时针、分针、秒针
            if (true)
            {
                rect.Inflate(-8,-8);
                int cx = rect.X + rect.Width / 2;
                int cy = rect.Y + rect.Height / 2;
                double R1 = rect.Width / 2;

                DateTime now = DateTime.Now;
                int hour = now.Hour;
                int minute = now.Minute;
                int second = now.Second;

                // 时针 
                using (Pen pen = new Pen(Color.Gray, 4.0f))
                {
                    // 角度计算时，需考虑分钟带来的影响
                    double angle = (hour+minute/60.0) / 12.0 * 360;
                    DrawTickHandle(g, pen, cx, cy, angle, R1 * 0.4);
                }
                //分针
                using (Pen pen = new Pen(Color.Gray, 2.0f))
                {
                    double angle = (minute/60.0) * 360 ;
                    DrawTickHandle(g, pen, cx, cy, angle, R1 * 0.6);
                }
                //秒针
                using (Pen pen = new Pen(Color.Red, 1.0f))
                {
                    double angle = (second / 60.0) * 360;
                    DrawTickHandle(g, pen, cx, cy, angle, R1 * 0.8);
                }
            }
        }
        public void Stop()
        {
            timer.Stop();
        }
        private void DrawTickHandle(Graphics g,
            Pen pen,
            int cx, int cy,
            double angle,
            double radius)
        {
            angle -= 90; // 时针的起点位于-90度位置(12点位置)

            // 转成弧度值
            double aaa = angle * Math.PI / 180;
            double x2 = cx + radius * Math.Cos(aaa);
            double y2 = cy + radius * Math.Sin(aaa);
            g.DrawLine(pen, cx, cy, (int)x2, (int)y2);
        }

        

    }
}
