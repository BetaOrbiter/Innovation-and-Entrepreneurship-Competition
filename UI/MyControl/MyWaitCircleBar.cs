using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.MyControl
{
    public class MyWaitCircleBar:Control
    {
        private SmoothingMode _SmoothingType = SmoothingMode.AntiAlias;

        private PixelOffsetMode _PixelOffsetType = PixelOffsetMode.HighQuality;

        private CompositingQuality _CompositingQualityType = CompositingQuality.HighQuality;

        private TextRenderingHint _TextRenderingType = TextRenderingHint.ClearTypeGridFit;

        private InterpolationMode _InterpolationType = InterpolationMode.HighQualityBilinear;

        private BufferedGraphics bufferedGraphics;

        private readonly System.Windows.Forms.Timer UpdateUI = new System.Windows.Forms.Timer();

        private int StartPoint = 270;

        private Color unFilledColor = Color.FromArgb(114, 114, 114);

        private Color filledColor = Color.FromArgb(60, 220, 210);

        private int filledColorAlpha = 130;

        private int unfilledThickness = 24;

        private int filledThickness = 40;

        public int percentage = 50;

        public int animationSpeed = 5;

        public bool isAnimated;

        public int textSize = 25;

        public Color textColor = Color.Gray;

        public bool showText = true;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor
        {
            get;
            set;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string Text
        {
            get;
            set;
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("Unfilled circle color")]
        public Color UnFilledColor
        {
            get
            {
                return unFilledColor;
            }
            set
            {
                unFilledColor = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("Filled circle color")]
        public Color FilledColor
        {
            get
            {
                return filledColor;
            }
            set
            {
                filledColor = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("Filled colors alpha value")]
        public int FilledColorAlpha
        {
            get
            {
                return filledColorAlpha;
            }
            set
            {
                filledColorAlpha = value;
                if (value > 255)
                {
                    filledColorAlpha = 255;
                }

                if (value < 1)
                {
                    filledColorAlpha = 1;
                }

                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("Unfilled circle thickness")]
        public int UnfilledThickness
        {
            get
            {
                return unfilledThickness;
            }
            set
            {
                unfilledThickness = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("Unfilled circle thickness")]
        public int FilledThickness
        {
            get
            {
                return filledThickness;
            }
            set
            {
                filledThickness = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("The progress circle percentage")]
        public int Percentage
        {
            get
            {
                return percentage;
            }
            set
            {
                percentage = value;
                if (value < 0)
                {
                    percentage = 0;
                }

                if (value > 100)
                {
                    percentage = 100;
                }

                OnPercentageChanged();
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("The animation speed")]
        public int AnimationSpeed
        {
            get
            {
                return animationSpeed;
            }
            set
            {
                animationSpeed = value;
                if (value < 1)
                {
                    animationSpeed = 1;
                }

                if (animationSpeed > 10)
                {
                    animationSpeed = 10;
                }

                UpdateUI.Interval = 200 / animationSpeed;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("Is the control animated")]
        public bool IsAnimated
        {
            get
            {
                return isAnimated;
            }
            set
            {
                isAnimated = value;
                if (value)
                {
                    UpdateUI.Enabled = true;
                }
                else
                {
                    UpdateUI.Enabled = false;
                }

                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("The text size")]
        public int TextSize
        {
            get
            {
                return textSize;
            }
            set
            {
                textSize = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("Text color")]
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        [Description("Show text")]
        public bool ShowText
        {
            get
            {
                return showText;
            }
            set
            {
                showText = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        public SmoothingMode SmoothingType
        {
            get
            {
                return _SmoothingType;
            }
            set
            {
                _SmoothingType = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        public PixelOffsetMode PixelOffsetType
        {
            get
            {
                return _PixelOffsetType;
            }
            set
            {
                _PixelOffsetType = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        public CompositingQuality CompositingQualityType
        {
            get
            {
                return _CompositingQualityType;
            }
            set
            {
                _CompositingQualityType = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        public TextRenderingHint TextRenderingType
        {
            get
            {
                return _TextRenderingType;
            }
            set
            {
                _TextRenderingType = value;
                Invalidate();
            }
        }

        [Category("Parrot")]
        [Browsable(true)]
        public InterpolationMode InterpolationType
        {
            get
            {
                return _InterpolationType;
            }
            set
            {
                _InterpolationType = value;
                Invalidate();
            }
        }

        public event EventHandler PercentageChanged;

        public MyWaitCircleBar()
        {
            base.Size = new Size(200, 200);
          
            UpdateUI.Tick += Animate;
            UpdateUI.Interval = 200 / animationSpeed;
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        }

        private void Animate(object sender, EventArgs e)
        {
            if (StartPoint == 360)
            {
                StartPoint = 0;
            }

            StartPoint += animationSpeed;
            Refresh();
        }

        protected virtual void OnPercentageChanged()
        {
            this.PercentageChanged?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            BufferedGraphicsContext current = BufferedGraphicsManager.Current;
            current.MaximumBuffer = new Size(base.Width + 1, base.Height + 1);
            bufferedGraphics = current.Allocate(CreateGraphics(), new Rectangle(0, 0, 1, 1));
            bufferedGraphics = current.Allocate(CreateGraphics(), base.ClientRectangle);
            bufferedGraphics.Graphics.SmoothingMode = SmoothingType;
            bufferedGraphics.Graphics.InterpolationMode = InterpolationType;
            bufferedGraphics.Graphics.CompositingQuality = CompositingQualityType;
            bufferedGraphics.Graphics.PixelOffsetMode = PixelOffsetType;
            bufferedGraphics.Graphics.TextRenderingHint = TextRenderingType;
            if (BackgroundImage == null)
            {
                bufferedGraphics.Graphics.Clear(BackColor);
            }
            else
            {
                bufferedGraphics.Graphics.DrawImage(BackgroundImage, 0, 0);
            }

            Rectangle rect = new Rectangle(filledThickness / 2 + 1, filledThickness / 2 + 1, base.Width - filledThickness - 2, base.Height - filledThickness - 2);
            //bufferedGraphics.Graphics.DrawArc(new Pen(unFilledColor, unfilledThickness), rect, StartPoint, 360f);
            //bufferedGraphics.Graphics.DrawArc(new Pen(Color.FromArgb(filledColorAlpha, filledColor.R, filledColor.G, filledColor.B), filledThickness), rect, StartPoint, (int)((double)Percentage * 3.6));
            if (percentage == 100)
            {
                UpdateUI.Enabled = false;
                bufferedGraphics.Graphics.DrawLine(new Pen(ColorTranslator.FromHtml("#67c23a"), 2.5f), base.Width / 2 - 10, base.Height / 2, base.Width / 2 - 5, base.Height / 2 + 10);
                bufferedGraphics.Graphics.DrawLine(new Pen(ColorTranslator.FromHtml("#67c23a"), 2.5f), base.Width / 2 + 10, base.Height / 2 - 10, base.Width / 2 - 5, base.Height / 2 + 10);
            }
            else if (percentage == 0)
            {
                UpdateUI.Enabled = false;
                bufferedGraphics.Graphics.DrawLine(new Pen(ColorTranslator.FromHtml("#f56c6c"), 2f), base.Width / 2 - 10, base.Height / 2 - 10, base.Width / 2 + 10, base.Height / 2 + 10);
                bufferedGraphics.Graphics.DrawLine(new Pen(ColorTranslator.FromHtml("#f56c6c"), 2f), base.Width / 2 - 10, base.Height / 2 + 10, base.Width / 2 + 10, base.Height / 2 - 10);
            }
            else
            {
                bufferedGraphics.Graphics.DrawArc(new Pen(Color.FromArgb(filledColorAlpha, filledColor.R, filledColor.G, filledColor.B), filledThickness), rect, StartPoint, (int)((double)Percentage * 3.6));
            }
            if (ShowText)
            {
                Rectangle r = new Rectangle(0, 0, base.Width, base.Height);
                StringFormat format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                bufferedGraphics.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                bufferedGraphics.Graphics.DrawString(Percentage + "%", new Font("Ariel", textSize), new SolidBrush(textColor), r, format);
            }

            bufferedGraphics.Render(e.Graphics);
            bufferedGraphics.Dispose();
            base.OnPaint(e);
        }
    }
}
