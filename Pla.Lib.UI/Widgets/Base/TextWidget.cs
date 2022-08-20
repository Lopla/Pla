using Pla.Lib.UI.DrawingStyles.LCars.ActiveElements;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets.Base
{
    public abstract class TextWidget : OrnamentedWidget
    {
        private readonly Ornament _ornamentType;

        private IActiveElementPainter TextOrnamentPainter
        {
            get { return new TextActiveElement(this, _ornamentType); }
        }
        private string _text;

        public TextWidget(Ornament ornamentType = Ornament.Visible)
            :base(ornamentType, new TextActiveElement(ornamentType ))
        {
            _ornamentType = ornamentType;
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
            var textSize = TextOrnamentPainter.GetSize();

            var ornamentedElement =
                style.Ornaments.GetSizeAroundElement(TextOrnamentPainter, _ornamentType);

            var size = new SKPoint(ornamentedElement.Bounds.Width, ornamentedElement.Bounds.Height);

            return size;
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            var ornamentedElement = style.Ornaments.GetSizeAroundElement(TextOrnamentPainter);

            style
                .Ornaments
                .Draw(new PaintContext(Bounds, canvas), _ornamentType);

            var newTextBounds = ornamentedElement.OffsetForInternalBounds(Bounds);
            TextOrnamentPainter.Draw(new PaintContext(newTextBounds, canvas));
        }

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }
    }
}