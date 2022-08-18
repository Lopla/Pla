using Pla.Lib.UI.DrawingStyles.LCars.ActiveElements;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public abstract class BaseTextWidget : Widget
    {
        private readonly Ornament _ornamentType;
        private readonly IActiveElementPainter _textOrnamentPainter;
        private string _text;

        public BaseTextWidget(Ornament ornamentType = Ornament.Visible)
        {
            _ornamentType = ornamentType;
            _textOrnamentPainter = new TextActiveElement(this);
        }

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
            var textSize = _textOrnamentPainter.GetSize();

            var ornamentedElement =
                style.Ornaments.GetSizeAroundElement(_textOrnamentPainter, _ornamentType);

            var size = new SKPoint(ornamentedElement.Bounds.Width, ornamentedElement.Bounds.Height);

            return size;
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            var textSize = _textOrnamentPainter.GetSize();

            var ornamentedElement = style.Ornaments.GetSizeAroundElement(_textOrnamentPainter);

            style
                .Ornaments
                .Draw(new PaintContext(Bounds, canvas), _ornamentType);

            var newTextBounds = ornamentedElement.OffsetForInternalBounds(Bounds);
            _textOrnamentPainter.Draw(new PaintContext(newTextBounds, canvas));
        }

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }
    }
}