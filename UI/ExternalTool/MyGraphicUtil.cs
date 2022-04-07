using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class MyGraphicUtil
    {
        public MyGraphicUtil()
        {

        }
        // 描绘一个圆角矩形
        // rect 所在的矩形 r 圆角的大小
        public static GraphicsPath RoundRectangle(Rectangle rect, int r)
        {
            int x = rect.X, y = rect.Y;
            int w = rect.Width;
            int h = rect.Height;
            if (r > w/2) r = w/2;
            if (r > h/2) r = h/2;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(x, y, r, r), 180, 90);
            path.AddArc(new Rectangle(x+w-r, y, r, r), 270, 90);
            path.AddArc(new Rectangle(x+w-r, y+h-r, r, r), 0, 90);
            path.AddArc(new Rectangle(x, y+h-r, r, r), 90, 90);
            path.CloseFigure();

            return path;
        }

        public static void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rect, int r)
        {
            GraphicsPath path = RoundRectangle(rect, r);
            g.DrawPath(pen, path);
        }

        public static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int r)
        {
            GraphicsPath path = RoundRectangle(rect, r);
            g.FillPath(brush, path);
        }

        public class Rect
        {

        }
        // 矩形的一些常用操作
        public static Rectangle Copy(Rectangle r)
        {
            return new Rectangle(r.X, r.Y, r.Width, r.Height);
        }
        public static Point Center(Rectangle r)
        {
            return new Point(r.X + r.Width / 2, r.Y + r.Height / 2);
        }
        public static void Center(Rectangle r, Point ct)
        {
            r.X = ct.X - r.Width / 2;
            r.Y = ct.Y - r.Height / 2;
        }
        public static void Center(Rectangle r, int cx, int cy)
        {
            r.X = cx - r.Width / 2;
            r.Y = cy - r.Height / 2;
        }

        // 颜色相关操作
        public static Color RGB(int color)
        {
            Color c = Color.FromArgb(color);
            return Color.FromArgb(255, c); // 设置alpha = 255
        }
        public static Color RGBA(int color, int alpha)
        {
            Color c = Color.FromArgb(color);
            return Color.FromArgb(alpha, c); // 设置alpha
        }

        /// <summary>
        /// 图片相关操作
        /// </summary>
        
        /// <param name="rect"></param>
        /// <param name="imgSize"></param>
        /// <returns></returns>

        // 缩放显示: rect:目标区域 , imgSize: 图片大小
        // 如果图片太少，则拉伸图片；如果图片太大，但缩小图片
        public static Rectangle FitInside(Rectangle rect, Size imgSize)
        {
            int imgW = imgSize.Width;
            int imgH = imgSize.Height;

            // 先尝试以窗口之宽度作为图片宽度，按比例绘制图片
            int w = rect.Width;
            int h = w * imgH / imgW;
            if (h > rect.Height)
            {
                // 若图片高度fitH超出宽度高度，就以窗口高度为图片高度，按比例绘制图片
                h = rect.Height;
                w = h * imgW / imgH;
            }

            int x = rect.X + (rect.Width - w) / 2;
            int y = rect.Y + (rect.Height - h) / 2;
            return new Rectangle(x, y, w, h);
        }

        // 如果图像较小，则居中显示
        // 如果图像较大，则按比例缩放显示
        public static Rectangle CenterInside(Rectangle rect, Size imgSize)
        {
            int w = imgSize.Width;
            int h = imgSize.Height;

            if (w < rect.Width && h < rect.Height)
            {
                int x = rect.X + (rect.Width - w) / 2;
                int y = rect.Y + (rect.Height - h) / 2;
                return new Rectangle(x, y, w, h);
            }
            else
            {
                return FitInside(rect, imgSize);
            }
        }
    }
}
