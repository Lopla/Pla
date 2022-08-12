using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public class Edit : Widget
    {
        private int _cursorLocation = 0;
        private bool _hasFocus;
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
                    var tmpSize = CaulculateRequestedSize();
                    if (tmpSize != _size)
                    {
                        _size = tmpSize;
                        Parent?.RequestResize();
                    }
                }
            }
        }

        public override SKPoint RequestedSize
        {
            get
            {
                if (_size == SKPoint.Empty) _size = CaulculateRequestedSize();

                return _size;
            }
        }

        private SKPoint CaulculateRequestedSize()
        {
            var newSize = SKPoint.Empty;
            foreach (var t in TextLines())
            {
                var textSize = new LCars().CalculateTextSize(t);
                newSize.Offset(0, textSize.Y);
                if (newSize.X < textSize.X) newSize.X = textSize.X;
            }

            return newSize;
        }

        public override void Draw(SKCanvas canvas, LCars style)
        {
            style.ModifyAble(new PaintContext(this, canvas, _hasFocus));

            float yOffset = 0;
            foreach (var t in TextLines())
            {
                var currentBounds = Bounds;
                currentBounds.Offset(0, yOffset);
                var textSize = new LCars().CalculateTextSize(t);
                currentBounds.Bottom = currentBounds.Top + textSize.Y;
                style.ModifyAbleText(new PaintContext(currentBounds, canvas, _hasFocus), t, SKTextAlign.Left);
                yOffset += textSize.Y;
            }
        }

        public override void OnKeyDow(uint key)
        {
            switch (key)
            {
                case 8: //backspace
                    if (Text.Length > 0)
                        Text = Text.Remove(_cursorLocation, 1);
                    break;
                default:
                    Text = (Text ?? "") + (char)key;
                    break;
            }

            Parent.Invalidate();
        }

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }

        public override void GotFocus()
        {
            _hasFocus = true;
            Parent.Invalidate();
        }

        public override void LostFocus()
        {
            _hasFocus = false;
            Parent.Invalidate();
        }
    }
}