using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets.Base
{
    public abstract class OrnamentedWidget : Widget
    {
        private readonly Ornament _ornamentStyle;
        private readonly IActiveElementPainter _elementPainter;

        public OrnamentedWidget(Ornament ornamentStyle, IActiveElementPainter elementPainter)
        {
            _ornamentStyle = ornamentStyle;
            _elementPainter = elementPainter;
        }
        
        public override SKPoint CalculateRequestedSize(IDesign style)
        {
            var ornamentedElement = style.Ornaments.GetSizeAroundElement(_elementPainter, _ornamentStyle);

            return ornamentedElement.RequestedSize();
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            style.Ornaments.Draw(new PaintContext(this, canvas), _ornamentStyle);
        }
    }
}