using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.DrawingStyles.LCars;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public abstract class BaseTextWidget : Widget
    {
        private readonly Ornament _ornamentType;

        public BaseTextWidget(Ornament ornamentType = Ornament.Visible)
        {
            _ornamentType = ornamentType;
        }

        
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
            var textSize = style.TextPainter.GetTextTotalSize(TextLines());
            var ornamentedElement =
                style.Ornaments.GetSize(textSize, _ornamentType);

            var size = new SKPoint(ornamentedElement.Bounds.Width, ornamentedElement.Bounds.Height);

            return size;
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            var textSize = style.TextPainter.GetTextTotalSize(TextLines());
            var ornamentedElement = style.Ornaments.GetSize(textSize);

            style
                .Ornaments
                .Draw(new PaintContext(Bounds, canvas), _ornamentType);

            style.TextPainter.Draw(new PaintContext(ornamentedElement.OffsetForInternalBounds(Bounds), canvas),
                TextLines(), 
                _ornamentType);
        }

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }
    }
}