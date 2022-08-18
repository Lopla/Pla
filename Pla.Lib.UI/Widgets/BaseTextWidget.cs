using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.DrawingStyles.LCars;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public abstract class BaseTextWidget : Widget
    {
        private readonly Ornament _ornamentType;

        public IActiveElementPainter ActiveElementPainter { get; set; }

        public BaseTextWidget(Ornament ornamentType = Ornament.Visible)
        {
            _ornamentType = ornamentType;
            ActiveElementPainter = new LCarsTextPainterActiveElement(this);
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
            var textSize = this.ActiveElementPainter.GetSize();

            var ornamentedElement =
                style.Ornaments.GetSizeAroundElement(textSize, _ornamentType);

            var size = new SKPoint(ornamentedElement.Bounds.Width, ornamentedElement.Bounds.Height);

            return size;
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            var textSize = this.ActiveElementPainter.GetSize();

            var ornamentedElement = style.Ornaments.GetSizeAroundElement(textSize);

            style
                .Ornaments
                .Draw(new PaintContext(Bounds, canvas), _ornamentType);

            var newTextBounds = ornamentedElement.OffsetForInternalBounds(this.Bounds);
            this.ActiveElementPainter.Draw(new PaintContext(newTextBounds, canvas));
        }

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }
    }
}