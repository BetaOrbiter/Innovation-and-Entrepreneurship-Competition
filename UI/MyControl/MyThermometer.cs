using HZH_Controls;
using HZH_Controls.Controls;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace UI
{
    public partial class MyThermometer : UserControl
    {
        private Color glassTubeColor = Color.FromArgb(211, 211, 211);

        private Color mercuryColor = Color.FromArgb(255, 77, 59);

        private decimal minValue = 0m;

        private decimal maxValue = 100m;

        private decimal m_value = 10m;

        private int splitCount = 1;

        private TemperatureUnit leftTemperatureUnit = TemperatureUnit.C;

        private TemperatureUnit rightTemperatureUnit = TemperatureUnit.C;

        private Rectangle m_rectWorking;

        private Rectangle m_rectLeft;

        private Rectangle m_rectRight;

        [Description("玻璃管颜色")]
        [Category("自定义")]
        public Color GlassTubeColor
        {
            get
            {
                return glassTubeColor;
            }
            set
            {
                glassTubeColor = value;
                Refresh();
            }
        }

        [Category("自定义")]
        [Description("水印颜色")]
        public Color MercuryColor
        {
            get
            {
                return mercuryColor;
            }
            set
            {
                mercuryColor = value;
                Refresh();
            }
        }

        [Description("左侧刻度最小值")]
        [Category("自定义")]
        public decimal MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
                Refresh();
            }
        }

        [Category("自定义")]
        [Description("左侧刻度最大值")]
        public decimal MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                Refresh();
            }
        }

        [Description("左侧刻度值")]
        [Category("自定义")]
        public decimal Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
                Refresh();
            }
        }

        [Description("刻度分隔份数")]
        [Category("自定义")]
        public int SplitCount
        {
            get
            {
                return splitCount;
            }
            set
            {
                if (value > 0)
                {
                    splitCount = value;
                    Refresh();
                }
            }
        }

        [Category("自定义")]
        [Description("获取或设置控件显示的文字的字体")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Refresh();
            }
        }

        [Category("自定义")]
        [Description("获取或设置控件的文字及刻度颜色")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                Refresh();
            }
        }

        [Category("自定义")]
        [Description("左侧刻度单位，不可为none")]
        public TemperatureUnit LeftTemperatureUnit
        {
            get
            {
                return leftTemperatureUnit;
            }
            set
            {
                if (value != 0)
                {
                    leftTemperatureUnit = value;
                    Refresh();
                }
            }
        }

        [Category("自定义")]
        [Description("右侧刻度单位，当为none时，不显示")]
        public TemperatureUnit RightTemperatureUnit
        {
            get
            {
                return rightTemperatureUnit;
            }
            set
            {
                rightTemperatureUnit = value;
                Refresh();
            }
        }

        public MyThermometer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
            SetStyle(ControlStyles.DoubleBuffer, value: true);
            SetStyle(ControlStyles.ResizeRedraw, value: true);
            SetStyle(ControlStyles.Selectable, value: true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
            SetStyle(ControlStyles.UserPaint, value: true);
            base.AutoScaleMode = AutoScaleMode.None;
            base.SizeChanged += UCThermometer_SizeChanged;
            base.Size = new Size(70, 200);
        }

        private void UCThermometer_SizeChanged(object sender, EventArgs e)
        {
            m_rectWorking = new Rectangle(base.Width / 2 - base.Width / 8, base.Width / 4, base.Width / 4, base.Height - base.Width / 2);
            m_rectLeft = new Rectangle(0, m_rectWorking.Top + m_rectWorking.Width / 2, (base.Width - base.Width / 4) / 2 - 2, m_rectWorking.Height - m_rectWorking.Width * 2);
            m_rectRight = new Rectangle(base.Width - (base.Width - base.Width / 4) / 2 + 2, m_rectWorking.Top + m_rectWorking.Width / 2, (base.Width - base.Width / 4) / 2 - 2, m_rectWorking.Height - m_rectWorking.Width * 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SetGDIHigh();
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(m_rectWorking.Left, m_rectWorking.Bottom, m_rectWorking.Left, m_rectWorking.Top + m_rectWorking.Width / 2);
            graphicsPath.AddArc(new Rectangle(m_rectWorking.Left, m_rectWorking.Top, m_rectWorking.Width, m_rectWorking.Width), 180f, 180f);
            graphicsPath.AddLine(m_rectWorking.Right, m_rectWorking.Top + m_rectWorking.Width / 2, m_rectWorking.Right, m_rectWorking.Bottom);
            graphicsPath.CloseAllFigures();
            graphics.FillPath(new SolidBrush(glassTubeColor), graphicsPath);
            Rectangle rect = new Rectangle(base.Width / 2 - m_rectWorking.Width, m_rectWorking.Bottom - m_rectWorking.Width - 2, m_rectWorking.Width * 2, m_rectWorking.Width * 2);
            graphics.FillEllipse(new SolidBrush(glassTubeColor), rect);
            graphics.FillEllipse(new SolidBrush(mercuryColor), new Rectangle(rect.Left + 4, rect.Top + 4, rect.Width - 8, rect.Height - 8));
            decimal d = (maxValue - minValue) / (decimal)splitCount;
            decimal num = m_rectLeft.Height / splitCount;
            for (int i = 0; i <= splitCount; i++)
            {
                graphics.DrawLine(new Pen(new SolidBrush(ForeColor), 1f), new PointF(m_rectLeft.Left + 2, (float)((decimal)m_rectLeft.Bottom - num * (decimal)i)), new PointF(m_rectLeft.Right, (float)((decimal)m_rectLeft.Bottom - num * (decimal)i)));
                string text = (minValue + d * (decimal)i).ToString("0.##");
                SizeF sizeF = graphics.MeasureString(text, Font);
                graphics.DrawString(text, Font, new SolidBrush(ForeColor), new PointF(m_rectLeft.Left, (float)m_rectLeft.Bottom - (float)num * (float)i - sizeF.Height - 1f));
                if (rightTemperatureUnit != 0)
                {
                    graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1f), new PointF(m_rectRight.Left + 2, (float)((decimal)m_rectRight.Bottom - num * (decimal)i)), new PointF(m_rectRight.Right, (float)((decimal)m_rectRight.Bottom - num * (decimal)i)));
                    string text2 = GetRightValue(minValue + d * (decimal)i).ToString("0.##");
                    SizeF sizeF2 = graphics.MeasureString(text2, Font);
                    graphics.DrawString(text2, Font, new SolidBrush(ForeColor), new PointF((float)m_rectRight.Right - sizeF2.Width - 1f, (float)m_rectRight.Bottom - (float)num * (float)i - sizeF2.Height - 1f));
                }

                if (i == splitCount)
                {
                    continue;
                }

                if (num > 40m)
                {
                    decimal value = num / 10m;
                    for (int j = 1; j < 10; j++)
                    {
                        if (j == 5)
                        {
                            graphics.DrawLine(new Pen(new SolidBrush(ForeColor), 1f), new PointF(m_rectLeft.Right - 10, (float)m_rectLeft.Bottom - (float)num * (float)i - (float)value * (float)j), new PointF(m_rectLeft.Right, (float)m_rectLeft.Bottom - (float)num * (float)i - (float)value * (float)j));
                            if (rightTemperatureUnit != 0)
                            {
                                graphics.DrawLine(new Pen(new SolidBrush(ForeColor), 1f), new PointF(m_rectRight.Left + 10, (float)m_rectRight.Bottom - (float)num * (float)i - (float)value * (float)j), new PointF(m_rectRight.Left, (float)m_rectRight.Bottom - (float)num * (float)i - (float)value * (float)j));
                            }
                        }
                        else
                        {
                            graphics.DrawLine(new Pen(new SolidBrush(ForeColor), 1f), new PointF(m_rectLeft.Right - 5, (float)m_rectLeft.Bottom - (float)num * (float)i - (float)value * (float)j), new PointF(m_rectLeft.Right, (float)m_rectLeft.Bottom - (float)num * (float)i - (float)value * (float)j));
                            if (rightTemperatureUnit != 0)
                            {
                                graphics.DrawLine(new Pen(new SolidBrush(ForeColor), 1f), new PointF(m_rectRight.Left + 5, (float)m_rectRight.Bottom - (float)num * (float)i - (float)value * (float)j), new PointF(m_rectRight.Left, (float)m_rectRight.Bottom - (float)num * (float)i - (float)value * (float)j));
                            }
                        }
                    }
                }
                else if (num > 10m)
                {
                    graphics.DrawLine(new Pen(new SolidBrush(ForeColor), 1f), new PointF(m_rectLeft.Right - 5, (float)m_rectLeft.Bottom - (float)num * (float)i - (float)num / 2f), new PointF(m_rectLeft.Right, (float)m_rectLeft.Bottom - (float)num * (float)i - (float)num / 2f));
                    if (rightTemperatureUnit != 0)
                    {
                        graphics.DrawLine(new Pen(new SolidBrush(ForeColor), 1f), new PointF(m_rectRight.Left + 5, (float)m_rectRight.Bottom - (float)num * (float)i - (float)num / 2f), new PointF(m_rectRight.Left, (float)m_rectRight.Bottom - (float)num * (float)i - (float)num / 2f));
                    }
                }
            }

            string unitChar = GetUnitChar(leftTemperatureUnit);
            SizeF sizeF3 = graphics.MeasureString(unitChar, Font);
            graphics.DrawString(unitChar, Font, new SolidBrush(ForeColor), new PointF((float)(m_rectRight.Right - 2) - sizeF3.Width, 2f));
            //if (rightTemperatureUnit != 0)
            //{
            //    string unitChar2 = GetUnitChar(rightTemperatureUnit);
            //    SizeF sizeF3 = graphics.MeasureString(unitChar2, Font);
            //    graphics.DrawString(unitChar2, Font, new SolidBrush(ForeColor), new PointF((float)(m_rectRight.Right - 2) - sizeF3.Width, 2f));
            //}

            float num2 = (float)(Value / (maxValue - minValue) * (decimal)m_rectLeft.Height);
            graphics.FillRectangle(rect: new RectangleF(m_rectWorking.Left + 4, (float)m_rectLeft.Top + ((float)m_rectLeft.Height - num2), m_rectWorking.Width - 8, num2 + (float)(m_rectWorking.Height - m_rectWorking.Width / 2 - m_rectLeft.Height)), brush: new SolidBrush(mercuryColor));
            SizeF sizeF4 = graphics.MeasureString(m_value.ToString("0.##"), Font);
            graphics.DrawString(m_value.ToString("0.##"), Font, new SolidBrush(Color.White), new PointF((float)rect.Left + ((float)rect.Width - sizeF4.Width) / 2f, (float)rect.Top + ((float)rect.Height - sizeF4.Height) / 2f + 1f));
        }

        private string GetUnitChar(TemperatureUnit unit)
        {
            string result = "℃";
            switch (unit)
            {
                case TemperatureUnit.C:
                    result = "℃";
                    break;
                case TemperatureUnit.F:
                    result = "℉";
                    break;
                case TemperatureUnit.K:
                    result = "K";
                    break;
                case TemperatureUnit.R:
                    result = "°R";
                    break;
                case TemperatureUnit.Re:
                    result = "°Re";
                    break;
            }

            return result;
        }

        private decimal GetRightValue(decimal decValue)
        {
            decimal num = decValue;
            switch (leftTemperatureUnit)
            {
                case TemperatureUnit.F:
                    num = (decValue - 32m) / 1.8m;
                    break;
                case TemperatureUnit.K:
                    num = decValue - 273m;
                    break;
                case TemperatureUnit.R:
                    num = decValue / 0.5555555555555555555555555556m - 273.15m;
                    break;
                case TemperatureUnit.Re:
                    num = decValue / 1.25m;
                    break;
            }

            switch (rightTemperatureUnit)
            {
                case TemperatureUnit.C:
                    return num;
                case TemperatureUnit.F:
                    return 1.8m * num + 32m;
                case TemperatureUnit.K:
                    return num + 273m;
                case TemperatureUnit.R:
                    return (num + 273.15m) * 0.5555555555555555555555555556m;
                case TemperatureUnit.Re:
                    return num * 1.25m;
                default:
                    return decValue;
            }
        }
    }
}
