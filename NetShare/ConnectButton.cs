﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

/*
 * name: Manuel Lind
 * class: 5AHIF
 * number: i16022
*/

namespace NetShare
{
    public class ConnectButton : Button
    {
        private Color _buttonColor = Color.Blue;
        private Color _textColor = Color.White;
        private bool _isOpen = false;
        private bool _isConnecting = false;
        private bool _isConnected = false;

        // Getter and Setter
        public ListBox List { get; set; }

        public Color ButtonColor
        {
            get => _buttonColor;
            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }

        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                Invalidate();
            }
        }

        public bool IsConnecting
        {
            get => _isConnecting;
            set
            {
                _isConnecting = value;
                Invalidate();
            }
        }

        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                Invalidate();
            }
        }

        // Creating a Figure with rounded Corners
        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            graphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            graphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            graphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            graphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            graphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            graphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            graphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            graphPath.CloseFigure();
            return graphPath;
        }

        protected override void OnPaint(PaintEventArgs paintEvent)
        {
            base.OnPaint(paintEvent);

            Graphics g = paintEvent.Graphics;
            g.Clear(Color.White);

            // Set Drawing to highest Quality
            paintEvent.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            paintEvent.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            paintEvent.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            paintEvent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create Brushes for Button- and Text-Color
            Brush buttonBrush = new SolidBrush(_buttonColor);
            Brush textBrush = new SolidBrush(_textColor);

            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            SizeF textSize = g.MeasureString(Text, Font);

            // Draw Button and Text
            using (GraphicsPath graphPath = GetRoundPath(Rect, 15))
            {
                paintEvent.Graphics.FillPath(buttonBrush, graphPath);
                if (!_isConnecting)
                {
                    paintEvent.Graphics.DrawString(Text, Font, textBrush, (Width - textSize.Width) / 2, (Height - textSize.Height) / 2);
                } 
                else
                {
                    paintEvent.Graphics.DrawString(Text, Font, textBrush, (Width - textSize.Width) / 2 + 1, (Height - textSize.Height) / 2);
                }
            }

            // Draw Arrow in Button
            if (List != null)
            {
                Icon arrowLeft = null;
                int arrowX = 0;
                int arrowY = 0;
                if (!_isConnecting && !_isConnected)
                {
                    if (!_isOpen)
                    {
                        arrowLeft = new Icon("../../Resources/arrowLeft.ico");
                        arrowX = ClientRectangle.Width - 23;
                        arrowY = ClientRectangle.Height / 2 - 7;
                    }
                    else
                    {
                        arrowLeft = new Icon("../../Resources/arrowUp.ico");
                        arrowX = ClientRectangle.Width - 25;
                        arrowY = ClientRectangle.Height / 2 - 4;
                    }
                    paintEvent.Graphics.DrawIcon(arrowLeft, arrowX, arrowY);
                }
            }
        }
    }
}