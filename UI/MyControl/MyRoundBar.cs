using ReaLTaiizor.Colors;
using ReaLTaiizor.Util;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class MyRoundBar:Control
    {
        private readonly int tempValue;

        private int _valueNumber;

        private readonly float _roundWidth = 4f;

        private bool _isError;

        private string _PercentText = "%";

        private Color _BorderColor = HopeColors.OneLevelBorder;

        private Color _DangerColor = HopeColors.Danger;

        private Color _DangerTextColorA = HopeColors.Danger;

        private Color _DangerTextColorB = HopeColors.Danger;

        private Color _FullTextColorA = HopeColors.Success;

        private Color _FullTextColorB = HopeColors.Success;

        private Color _BarColor = HopeColors.PrimaryColor;

        private Color _FullBarColor = HopeColors.Success;

        public int ValueNumber
        {
            get
            {
                return _valueNumber;
            }
            set
            {
                _valueNumber = ((value > 100) ? 100 : ((value >= 0) ? value : 0));
                Invalidate();
            }
        }

        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                _isError = value;
                Invalidate();
            }
        }

        public string PercentText
        {
            get
            {
                return _PercentText;
            }
            set
            {
                _PercentText = value;
            }
        }

        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
            }
        }

        public Color DangerColor
        {
            get
            {
                return _DangerColor;
            }
            set
            {
                _DangerColor = value;
            }
        }

        public Color DangerTextColorA
        {
            get
            {
                return _DangerTextColorA;
            }
            set
            {
                _DangerTextColorA = value;
            }
        }

        public Color DangerTextColorB
        {
            get
            {
                return _DangerTextColorB;
            }
            set
            {
                _DangerTextColorB = value;
            }
        }

        public Color FullTextColorA
        {
            get
            {
                return _FullTextColorA;
            }
            set
            {
                _FullTextColorA = value;
            }
        }

        public Color FullTextColorB
        {
            get
            {
                return _FullTextColorB;
            }
            set
            {
                _FullTextColorB = value;
            }
        }

        public Color BarColor
        {
            get
            {
                return _BarColor;
            }
            set
            {
                _BarColor = value;
            }
        }

        public Color FullBarColor
        {
            get
            {
                return _FullBarColor;
            }
            set
            {
                _FullBarColor = value;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Width = base.Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            //graphics.Clear(base.Parent.BackColor);
            graphics.FillEllipse(new SolidBrush(_BorderColor), new Rectangle(0, 0, base.Width, base.Height));
            if (_isError)
            {
                graphics.FillPie(new SolidBrush(_DangerColor), new Rectangle(0, 0, base.Width, base.Width), 0f, (float)_valueNumber * 3.6f);
                graphics.FillEllipse(new SolidBrush(BackColor), new RectangleF(_roundWidth, _roundWidth, (float)base.Width - _roundWidth * 2f, (float)base.Width - _roundWidth * 2f));
                graphics.DrawLine(new Pen(_DangerTextColorA, 2f), base.Width / 2 - 6, base.Height / 2 - 6, base.Width / 2 + 6, base.Height / 2 + 6);
                graphics.DrawLine(new Pen(_DangerTextColorB, 2f), base.Width / 2 - 6, base.Height / 2 + 6, base.Width / 2 + 6, base.Height / 2 - 6);
            }
            else if (_valueNumber == 100)
            {
                graphics.FillPie(new SolidBrush(_FullBarColor), new Rectangle(0, 0, base.Width, base.Width), 270f, (float)_valueNumber * 3.6f);
                graphics.FillEllipse(new SolidBrush(BackColor), new RectangleF(_roundWidth, _roundWidth, (float)base.Width - _roundWidth * 2f, (float)base.Width - _roundWidth * 2f));
                graphics.DrawLine(new Pen(_FullTextColorA, 2f), base.Width / 2 - 6, base.Height / 2, base.Width / 2 - 3, base.Height / 2 + 6);
                graphics.DrawLine(new Pen(_FullTextColorB, 2f), base.Width / 2 + 6, base.Height / 2 - 6, base.Width / 2 - 3, base.Height / 2 + 6);
            }
            else
            {
                graphics.FillPie(new SolidBrush(_BarColor), new Rectangle(0, 0, base.Width, base.Width), 270f, (float)_valueNumber * 3.6f);
                graphics.FillEllipse(new SolidBrush(BackColor), new RectangleF(_roundWidth, _roundWidth, (float)base.Width - _roundWidth * 2f, (float)base.Width - _roundWidth * 2f));
                graphics.DrawString(_valueNumber.ToString(), Font, new SolidBrush(ForeColor), new RectangleF(_roundWidth, _roundWidth, (float)base.Width - _roundWidth * 2f, (float)base.Width - _roundWidth * 2f), HopeStringAlign.Center);
            }
        }

        public MyRoundBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            DoubleBuffered = true;
            Font = new Font("宋体", 12f);
            BackColor = Color.White;
            ForeColor = HopeColors.PrimaryColor;
            
        }
    }
}
