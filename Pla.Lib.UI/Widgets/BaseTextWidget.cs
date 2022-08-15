using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public abstract class BaseTextWidget : Widget
    {
        private SKPoint _size = SKPoint.Empty;
        private string _text;

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

        public override SKPoint RequestedSize => _size;
        

        /// <summary>
        ///     calls <see cref="OnDraw" /> and foreach line calls <see cref="OnDrawTextLine" />
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="style"></param>
        public override void Draw(SKCanvas canvas, IDesign style)
        {
            if (_size == SKPoint.Empty)
            {
                _size = style.GetTextTotalSize(this.TextLines());
                Parent?.RequestResize();
            }

            OnDraw(new PaintContext(this, canvas), style);
            OnDrawAllText(canvas, style);
        }

        /// <summary>
        ///     Paints all underlaying lines and calls <see cref="OnDrawTextLine" /> when need to render one text line
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="style"></param>
        protected virtual void OnDrawAllText(SKCanvas canvas, IDesign style)
        {
            var currentBounds = Bounds;

            style.DrawAllText(new PaintContext(currentBounds, canvas), this.TextLines());
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