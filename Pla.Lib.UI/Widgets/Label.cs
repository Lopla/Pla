using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public class Label : Widget
    {
        private string _text;
        private SKPoint _size;

        private readonly TextPainterActiveElement _painter = new TextPainterActiveElement();
        private readonly LCarsOrnaments _ornaments = new LCarsOrnaments();

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            if (_size == SKPoint.Empty)
            {
                _size = _painter.GetTextTotalSize(this.TextLines());
                Parent?.RequestResize();
            }

            _ornaments.Draw(new PaintContext(this, canvas));
            _painter.Draw(new PaintContext(this, canvas), TextLines(), _ornaments.palette.Colour(Styling.Alert));
        }

        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    _size = SKPoint.Empty;
                }
            }
        }
        
        public override SKPoint RequestedSize => _size;

        public string[] TextLines()
        {
            return Text?.Split('\r', '\n');
        }
    }
}