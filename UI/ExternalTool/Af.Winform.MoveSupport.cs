/**
 * 窗口移动支持
 * 
 */

namespace UI
{
    class AfMoveSupport
    {
        public Control target; // 目标 Form 或 Control

        private bool pressed = false; // 鼠标左键按下
        private Point startMousePos; // 鼠标按下时、鼠标的初始位置
        private Point startWinPos;// 鼠标按下时、窗口的初始位置

        public AfMoveSupport(Control target)
        {
            this.target = target;

            target.MouseDown += this.OnMouseDown;
            target.MouseMove += this.OnMouseMove;
            target.MouseUp   += this.OnMouseUp;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pressed = true;

                // 获取鼠标的初始位置和大小
                startMousePos = target.PointToScreen(e.Location);

                // 获取窗口的初始位置和大小
                Form form = target.FindForm();
                startWinPos = form.Location;
            }

        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (pressed) // pressed为true，表示当前鼠标左键被按下
            {
                // 根据鼠标位置，计算鼠标的位移
                Point pos = target.PointToScreen(e.Location);
                int dx = pos.X - startMousePos.X;
                int dy = pos.Y - startMousePos.Y;

                // 移动窗口位置
                Form form = target.FindForm();
                form.Location = new Point(startWinPos.X + dx, startWinPos.Y + dy);
            }

        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            pressed = false;
        }

    }
}
