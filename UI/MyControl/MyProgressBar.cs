using ReaLTaiizor.Colors;
using ReaLTaiizor.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class MyProgressBar:Control
    {
        private int W;

        private int H;

        private int _Value;

        private int _Maximum = 100;

        private bool _Pattern = true;

        private bool _ShowBalloon = true;

        private bool _PercentSign;

        private Color _BaseColor = Color.FromArgb(45, 47, 49);

        private Color _ProgressColor = ForeverLibrary.ForeverColor;

        private Color _DarkerProgress = Color.FromArgb(23, 148, 92);

        [Category("Control")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < _Value)
                {
                    _Value = value;
                }

                _Maximum = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                    Invalidate();
                }

                _Value = value;
                Invalidate();
            }
        }

        public bool Pattern
        {
            get
            {
                return _Pattern;
            }
            set
            {
                _Pattern = value;
            }
        }

        public bool ShowBalloon
        {
            get
            {
                return _ShowBalloon;
            }
            set
            {
                _ShowBalloon = value;
            }
        }

        public bool PercentSign
        {
            get
            {
                return _PercentSign;
            }
            set
            {
                _PercentSign = value;
            }
        }

        [Category("Colors")]
        public Color ProgressColor
        {
            get
            {
                return _ProgressColor;
            }
            set
            {
                _ProgressColor = value;
            }
        }

        [Category("Colors")]
        public Color DarkerProgress
        {
            get
            {
                return _DarkerProgress;
            }
            set
            {
                _DarkerProgress = value;
            }
        }

        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return _BaseColor;
            }
            set
            {
                _BaseColor = value;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Height = 50;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            base.Height = 42;
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }

        public MyProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);
            ForeColor = _ProgressColor;
            base.Height = 50;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            W = base.Width - 1;
            H = base.Height - 1;
            Rectangle rect = new Rectangle(0, 24, W, H);
            GraphicsPath graphicsPath = new GraphicsPath();
            GraphicsPath graphicsPath2 = new GraphicsPath();
            GraphicsPath graphicsPath3 = new GraphicsPath();
            Graphics graphics2 = graphics;
            graphics2.SmoothingMode = SmoothingMode.HighQuality;
            graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics2.Clear(BackColor);
            int num = (int)((float)_Value / (float)_Maximum * (float)base.Width);
            switch (Value)
            {
                case 0:
                    graphics2.FillRectangle(new SolidBrush(_BaseColor), rect);
                    graphics2.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 24, num - 1, H - 1));
                    break;
                case 100:
                    graphics2.FillRectangle(new SolidBrush(_BaseColor), rect);
                    graphics2.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 24, num - 1, H - 1));
                    break;
                default:
                    graphics2.FillRectangle(new SolidBrush(_BaseColor), rect);
                    graphicsPath.AddRectangle(new Rectangle(0, 24, num - 1, H - 1));
                    graphics2.FillPath(new SolidBrush(_ProgressColor), graphicsPath);
                    if (_Pattern)
                    {
                        HatchBrush brush = new HatchBrush(HatchStyle.Plaid, _DarkerProgress, _ProgressColor);
                        graphics2.FillRectangle(brush, new Rectangle(0, 24, num - 1, H - 1));
                    }

                    if (_ShowBalloon)
                    {
                        graphicsPath2 = ForeverLibrary.RoundRec(new Rectangle(num - 18, 0, 34, 16), 4);
                        graphics2.FillPath(new SolidBrush(_BaseColor), graphicsPath2);
                        graphicsPath3 = ForeverLibrary.DrawArrow(num - 9, 16, flip: true);
                        graphics2.FillPath(new SolidBrush(_BaseColor), graphicsPath3);
                        string s = _PercentSign ? (Value + "%") : Value.ToString();
                        int x = _PercentSign ? (num - 15) : (num - 11);
                        graphics2.DrawString(s, new Font("Segoe UI", 10f), new SolidBrush(ForeColor), new Rectangle(x, -2, W, H), ForeverLibrary.NearSF);
                    }

                    break;
            }

            base.OnPaint(e);
            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            bitmap.Dispose();
        }

        private void UpdateColors()
        {
            ForeverColors colors = ForeverLibrary.GetColors(this);
            _ProgressColor = colors.Forever;
        }
    }
}
