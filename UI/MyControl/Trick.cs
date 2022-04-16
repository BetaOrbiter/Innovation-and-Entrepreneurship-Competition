using System.Drawing.Drawing2D;

namespace UI.MyControl
{
    public class Trick:Control
    {
        private readonly Pen BaseColor = new Pen(Color.DarkGray,4f);

        private readonly Pen AnimationColor = new Pen(Color.DimGray,4f);

        private readonly System.Windows.Forms.Timer AnimationSpeed = new System.Windows.Forms.Timer();

        private PointF[] FloatPoint;

        private BufferedGraphics BuffGraphics;

        private int IndicatorIndex;

        private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

        private double Rise;

        private double Run;

        private PointF _StartingFloatPoint;

        private bool stop = false;

        private bool rightToLeft = false;
        public bool LineRightToLeft
        {
            get 
            {
                return rightToLeft;
            }
            set
            {
                rightToLeft = value;
                Invalidate();
            }
        }

        public bool Stop
        {
            get
            {
                return stop;
            }
            set
            {
                stop = value;
                Invalidate();
            }
        }

        public Color P_BaseColor
        {
            get
            {
                return BaseColor.Color;
            }
            set
            {
                BaseColor.Color = value;
            }
        }

        public Color P_AnimationColor
        {
            get
            {
                return AnimationColor.Color;
            }
            set
            {
                AnimationColor.Color = value;
            }
        }

        public int P_AnimationSpeed
        {
            get
            {
                return AnimationSpeed.Interval;
            }
            set
            {
                AnimationSpeed.Interval = value;
            }
        }

        private PointF EndPoint
        {
            get
            {
                float y = Convert.ToSingle((double)_StartingFloatPoint.Y + Rise);
                return new PointF(Convert.ToSingle((double)_StartingFloatPoint.X + Run), y);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
            UpdateGraphics();
            SetPoints();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            AnimationSpeed.Enabled = base.Enabled;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationSpeed.Tick += AnimationSpeed_Tick;
            AnimationSpeed.Start();
        }

        private void AnimationSpeed_Tick(object sender, EventArgs e)
        {
            if (LineRightToLeft == false)
            {
                if (IndicatorIndex.Equals(0))
                {
                    IndicatorIndex = FloatPoint.Length - 1;
                }
                else
                {
                    IndicatorIndex--;
                }
            }
            else
            {
                if (IndicatorIndex.Equals(FloatPoint.Length - 1))
                {
                    IndicatorIndex = 0;
                }
                else
                {
                    IndicatorIndex++;
                }
            }

            Invalidate(invalidateChildren: false);
        }

        public Trick()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            base.Size = new Size(80, 80);
            Text = string.Empty;
            MinimumSize = new Size(0, 0);
            SetPoints();
            AnimationSpeed.Interval = 100;
        }

        private void SetStandardSize()
        {
            //int num = Math.Max(base.Width, base.Height);
            //base.Size = new Size(num, num);
        }

        private void SetPoints()
        {
            Stack<PointF> stack = new Stack<PointF>();
            PointF startingFloatPoint = new PointF((float)base.Width / 2f, (float)base.Height / 2f);
            for(int num = 0; num < 6; num++)
            {
                PointF pointF = new(this.Width * num / 5f, this.Height / 2);
                stack.Push(pointF);
            }
            //for (float num = 0f; num < 360f; num += 45f)
            //{
            //    //SetValue(startingFloatPoint,)
            //    SetValue(startingFloatPoint, (int)Math.Round((double)base.Width / 2.0 - 15.0), num);
            //    PointF endPoint = EndPoint;
            //    endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
            //    stack.Push(endPoint);
            //}

            FloatPoint = stack.ToArray();
        }

        private void UpdateGraphics()
        {
            if (base.Width > 0 && base.Height > 0)
            {
                Size maximumBuffer = new Size(base.Width + 1, base.Height + 1);
                GraphicsContext.MaximumBuffer = maximumBuffer;
                BuffGraphics = GraphicsContext.Allocate(CreateGraphics(), base.ClientRectangle);
                BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            BuffGraphics.Graphics.Clear(BackColor);
            int num = FloatPoint.Length - 1;
            for (int i = 0; i < num; i++)
            {
                if (IndicatorIndex == i&& stop == false)
                {
                    //BuffGraphics.Graphics.FillPie
                    
                    BuffGraphics.Graphics.DrawLine(AnimationColor, FloatPoint[i].X, FloatPoint[i].Y, FloatPoint[i+1].X, FloatPoint[i + 1].Y);
                    //BuffGraphics.Graphics.FillEllipse(AnimationColor, FloatPoint[i].X, FloatPoint[i].Y, 15f, 15f);
                }
                else
                {
                    BuffGraphics.Graphics.DrawLine(BaseColor, FloatPoint[i].X, FloatPoint[i].Y, FloatPoint[i + 1].X , FloatPoint[i + 1].Y);

                }
            }

            BuffGraphics.Render(e.Graphics);
        }

        private X AssignValues<X>(ref X Run, X Length)
        {
            Run = Length;
            return Length;
        }

        private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
        {
            double num = Math.PI * Angle / 180.0;
            _StartingFloatPoint = StartingFloatPoint;

            Rise = AssignValues(ref Run, Length);
            Rise = Math.Sin(num) * Rise;
            Run = Math.Cos(num) * Run;
        }
    }
}
