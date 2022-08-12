using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public abstract class BaseTextWidget : Widget
    {
        private string _text;

        private SKPoint _size = SKPoint.Empty;

        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    _size = SKPoint.Empty;
                }
            }
        }

        public override SKPoint RequestedSize
        {
            get
            {
                return _size;
            }
        }

        private SKPoint CaulculateRequestedSize(IDesign style)
        {
            var newSize = SKPoint.Empty;
            foreach (var t in TextLines())
            {
                var textSize = style.CalculateTextSize(t);
                newSize.Offset(0, textSize.Y);
                if (newSize.X < textSize.X) newSize.X = textSize.X;
            }

            return newSize;
        }

        /// <summary>
        /// calls <see cref="OnDraw"/> and foreach line calls <see cref="OnDrawTextLine"/>
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="style"></param>
        public override void Draw(SKCanvas canvas, IDesign style)
        {
            if (this._size == SKPoint.Empty)
            {
                this._size = CaulculateRequestedSize(style);
                this.Parent?.RequestResize();
            }

            this.OnDraw(new PaintContext(this, canvas), style);

            OnDrawAllText(canvas, style);
        }

        /// <summary>
        /// Paints all underlaying lines and calls <see cref="OnDrawTextLine"/> when need to render one text line
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="style"></param>
        protected virtual void OnDrawAllText(SKCanvas canvas, IDesign style)
        {
            float yOffset = 0;
            foreach (var t in TextLines())
            {
                var currentBounds = Bounds;
                currentBounds.Offset(0, yOffset);
                var textSize = style.CalculateTextSize(t);
                currentBounds.Bottom = currentBounds.Top + textSize.Y;

                this.OnDrawTextLine(new PaintContext(currentBounds, canvas), style, t);

                yOffset += textSize.Y;
            }
        }

        protected virtual void OnDrawTextLine(PaintContext paintContext, IDesign style, string lineOfText)
        {
            style.VisibleText(paintContext, lineOfText, SKTextAlign.Left);
        }

        protected virtual void OnDraw(PaintContext paintContext, IDesign style)
        {
            style.Visible(paintContext);
        }
        
        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }
    }
}