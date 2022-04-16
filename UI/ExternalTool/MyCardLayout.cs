namespace UI
{
    class MyCardLayout : Panel
    {
        public MyCardLayout()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);

            // 仅在设计器中绘制，高亮显示当前的卡片布局
            if (this.DesignMode)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(50, 255, 255, 0)))
                {
                    g.FillRectangle(brush, rect);
                }

                using (Brush brush = new SolidBrush(Color.Orange))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString("卡片布局", this.Font, brush, rect, sf);
                }
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            // 去掉 Padding
            Padding p = this.Padding;
            Rectangle rect = new Rectangle(p.Left,
                p.Top,
                this.Width - p.Left - p.Right,
                this.Height - p.Top - p.Bottom);

            // 将可见的卡片显示出来
            foreach (Control c in this.Controls)
            {
                if (c.Visible)
                {
                    c.Bounds = rect;
                }
            }
        }

        // 添加一张卡片
        public void AddCard(Control c, string name)
        {
            c.Name = name;
            c.Visible = false;
            this.Controls.Add(c);
        }

        // 获取一张卡片
        public Control GetCard(string name)
        {
            foreach(Control c in this.Controls)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        // 移除一张卡片
        public void RemoveCard(string name)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name.Equals(name))
                {
                    this.Controls.Remove(c);
                    c.Dispose(); // 需要手工销毁
                    break;
                }                   
            }
        }

        // 显示一张卡片
        public void ShowCard(string name)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name.Equals(name))
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
            this.PerformLayout();
        }

        public void ShowCard(Control ctrl)
        {
            foreach (Control c in this.Controls)
            {
                if (c == ctrl)
                    c.Visible = true;
                else
                    c.Visible = false;
            }
            this.PerformLayout();
        }

        public void ShowCard(int index)
        {
            if (index < 0 || index >= this.Controls.Count)
                return;

            for(int i=0; i<this.Controls.Count; i++)
            {
                Control c = this.Controls[i];
                if (i == index)
                    c.Visible = true;
                else
                    c.Visible = false;
            }
                        
            this.PerformLayout();
        }

        // 当前卡片
        public Control CurrentCard()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Visible)
                    return c;                
            }
            return null;
        }


    }
}
