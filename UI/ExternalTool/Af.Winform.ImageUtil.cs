namespace UI
{
    class AfImageUtil
    {
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

            if(w < rect.Width && h < rect.Height)
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
