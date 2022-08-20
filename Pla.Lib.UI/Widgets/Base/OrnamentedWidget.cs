using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets.Base
{
    public abstract class OrnamentedWidget : Widget
    {
        private readonly IActiveElementPainter _painter;
        private readonly Ornament _ornamentStyle;

        public OrnamentedWidget(Ornament ornamentStyle)
        {
            _ornamentStyle = ornamentStyle;
            _painter = GetPainter();
        }

        protected abstract IActiveElementPainter GetPainter();
        
        public override SKPoint CalculateRequestedSize(IDesign style)
        {
            var ornamentedElement =
                style.Ornaments.GetSizeAroundElement(_painter, _ornamentStyle);

            var size = new SKPoint(ornamentedElement.Bounds.Width, ornamentedElement.Bounds.Height);

            return size;
        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            style.Ornaments.Draw(new PaintContext(this, canvas), _ornamentStyle);
        }
    }
}