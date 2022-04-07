using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class MyForm : ContainerControl
    {
        public enum Alignment
        {
            Left,
            Center
        }

        private readonly int draggableHeight;

        private bool isBeingDragged;

        private Point mouseLocation;

        private Rectangle titleBarRect;

        private int titleBarStringLeft;

        private bool _ControlMode;

        private Alignment _TextAlignment;

        private bool _DrawIcon;

        private Color _TitleBarTextColor = Color.Gainsboro;

        private Color _HeadColor = ColorTranslator.FromHtml("#323A3D");

        protected bool ControlMode
        {
            get
            {
                return _ControlMode;
            }
            set
            {
                _ControlMode = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Description("Indicates how the window title should be aligned.")]
        public Alignment TextAlignment
        {
            get
            {
                return _TextAlignment;
            }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Description("Determines whether the icon specified in the parent form should be drawn.")]
        public bool DrawIcon
        {
            get
            {
                return _DrawIcon;
            }
            set
            {
                _DrawIcon = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Description("Sets the title bar title color.")]
        public Color TitleBarTextColor
        {
            get
            {
                return _TitleBarTextColor;
            }
            set
            {
                _TitleBarTextColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Description("Sets the title bar color.")]
        public Color HeadColor
        {
            get
            {
                return _HeadColor;
            }
            set
            {
                _HeadColor = value;
                Invalidate();
            }
        }

        [Bindable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout
        {
            get;
            set;
        }

        [Bindable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image BackgroundImage
        {
            get;
            set;
        }

        //
        // 摘要:
        //     Returns true if the mouse is over the title bar icon.
        private static bool IsOverTitleBarIcon(MouseEventArgs e)
        {
            if (e.X > 8 && e.X < 26)
            {
                if (e.Y > 6)
                {
                    return e.Y < 22;
                }

                return false;
            }

            return false;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!ControlMode)
            {
                titleBarRect = new Rectangle(9, 2, base.Width, draggableHeight);
            }

            base.OnSizeChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (titleBarRect.Contains(e.Location))
                {
                    isBeingDragged = true;
                    mouseLocation = e.Location;
                }

                base.OnMouseDown(e);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_DrawIcon && IsOverTitleBarIcon(e))
                {
                    Application.Exit();
                }

                base.OnMouseDoubleClick(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isBeingDragged)
            {
                base.Parent.Location = Point.Subtract(Control.MousePosition, (Size)mouseLocation);
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isBeingDragged)
            {
                isBeingDragged = false;
            }

            base.OnMouseUp(e);
        }

        public MyForm()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, value: true);
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            base.Padding = new Padding(0, 30, 0, 0);
            MinimumSize = new Size(100, 42);
            BackColor = Color.FromArgb(40, 48, 51);
            Font = new Font("Segoe UI", 9f);
            draggableHeight = 28;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            base.ParentForm.FormBorderStyle = FormBorderStyle.None;
            base.ParentForm.TransparencyKey = Color.Fuchsia;
            base.ParentForm.BackColor = SystemColors.ControlDarkDark;
            base.ParentForm.MaximumSize = Screen.FromRectangle(base.ParentForm.Bounds).WorkingArea.Size;
            base.ParentForm.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DrawTitleBar(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(HeadColor))
            {
                g.FillRectangle(brush, new Rectangle(0, 0, base.Width, 42));
            }
        }

        private void DrawTitleBarIcon(Graphics g)
        {
            if (_DrawIcon)
            {
                titleBarStringLeft = ((_TextAlignment == Alignment.Left) ? 33 : 5);
                g.DrawIcon(targetRect: new Rectangle(10, 8, 20, 20), icon: FindForm().Icon);
            }
            else
            {
                titleBarStringLeft = 5;
            }
        }

        private void DrawTitleBarText(Graphics g)
        {
            Rectangle r = new Rectangle(titleBarStringLeft, 3, base.Width - 13, base.Height);
            switch (_TextAlignment)
            {
                case Alignment.Left:
                    {
                        using (SolidBrush brush2 = new SolidBrush(_TitleBarTextColor))
                        {
                            using (StringFormat format2 = new StringFormat
                            {
                                Alignment = StringAlignment.Near,
                                LineAlignment = StringAlignment.Near
                            })
                            {
                                g.DrawString(Text, Font, brush2, r, format2);
                            }
                        }

                        break;
                    }
                case Alignment.Center:
                    {
                        using (SolidBrush brush = new SolidBrush(_TitleBarTextColor))
                        {
                            using (StringFormat format = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Near
                            })
                            {
                                g.DrawString(Text, Font, brush, r, format);
                            }
                        }

                        break;
                    }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(BackColor);
            DrawTitleBar(graphics);
            DrawTitleBarIcon(graphics);
            DrawTitleBarText(graphics);
            base.OnPaint(e);
        }
    }
}
