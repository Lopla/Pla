using Pla.Lib.UI.DrawingStyles.LCars.ActiveElements;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets.Base
{
    public class TextWidget : Widget
    {
        private readonly OrnamentType _ornamentType;
        
        private string _text;
        private readonly TextActiveElement _painter;

        public TextWidget(OrnamentType ornamentType)
        {
            _ornamentType = ornamentType;
            _painter = new TextActiveElement(ornamentType, this);
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
            var ornamentedElement = style.Ornaments.GetSizeAroundElement(_painter, this._ornamentType);
            return ornamentedElement.RequestedSize();
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            var ornamentedElement = 
                style.Ornaments.GetSizeAroundElement(_painter);

            style
                .Ornaments
                .Draw(new PaintContext(Bounds, canvas), _ornamentType);

            var newTextBounds = ornamentedElement.OffsetForInternalBounds(Bounds);
            _painter.Draw(new PaintContext(newTextBounds, canvas));
        }

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }
    }
}