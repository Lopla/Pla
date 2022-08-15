using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public abstract class BaseTextWidget : Widget
    {
        private readonly TextPainterActiveElement _painter = new TextPainterActiveElement();

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    Parent?.RequestResize();
                }
            }
        }

        public override SKPoint CalculateRequestedSize(IDesign style)
        {
            var textSize = _painter.GetTextTotalSize(TextLines());
            var ornamentedElement =
                style.Ornaments.GetSize(textSize);

            var size = new SKPoint(ornamentedElement.Bounds.Width, ornamentedElement.Bounds.Height);

            return size;
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            var textSize = _painter.GetTextTotalSize(TextLines());
            var ornamentedElement = style.Ornaments.GetSize(textSize);

            style.Ornaments.Draw(new PaintContext(Bounds, canvas));
            _painter.Draw(new PaintContext(ornamentedElement.OffsetForInternalBounds(Bounds), canvas),
                TextLines(),
                style.Palette.Color(Styling.Alert));
        }

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }
    }
}