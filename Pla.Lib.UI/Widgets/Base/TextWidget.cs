using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets.Base
{
    public class TextWidget : Widget
    {
        private readonly OrnamentType _ornamentType;
        
        private string _text;

        public TextWidget(OrnamentType ornamentType)
        {
            _ornamentType = ornamentType;
        }

        TextPainter GetPainterElement(IDesign style)
        {
            return new TextPainter(
                this, 
                style.Palette, 
                style.Palette.Color(_ornamentType));
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
            var ornamentedElement = style.Ornaments.GetSizeAroundElement(GetPainterElement(style), this._ornamentType);
            return ornamentedElement.RequestedSize();
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            var ornamentedElement = 
                style.Ornaments.GetSizeAroundElement(GetPainterElement(style), _ornamentType);

            style
                .Ornaments
                .Draw(new PaintContext(Bounds, canvas), _ornamentType);

            var newTextBounds = ornamentedElement.OffsetForInternalBounds(Bounds);
            GetPainterElement(style).Draw(new PaintContext(newTextBounds, canvas));
        }

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }


        public override void GotFocus()
        {

        }

        public override void LostFocus()
        {

        }
    }
}