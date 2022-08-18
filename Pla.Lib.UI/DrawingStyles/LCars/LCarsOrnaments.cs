using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars
{
    public class LCarsOrnaments : IOrnamentsPainter
    {
        private readonly IDesign _style;

        public LCarsOrnaments(IDesign style)
        {
            _style = style;
            BorderWidth = 20;
        }

        public int BorderWidth { get; set; }

        public void Draw(PaintContext context,
            Ornament ornamentType)
        {
            this.DrawFrameLRTB(context, ornamentType);
        }

        private void DrawFrameLRTB(PaintContext context, Ornament ornamentType)
        {
            using (var painterBack = new SKPaint
                   {
                       Color = _style.Palette.BackColor(ornamentType),
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderWidth, BorderWidth, painterBack);
            }
        }

        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <returns></returns>
        public OrnamentBounds GetSizeAroundElement(SKPoint internalElementSize,
            Ornament ornamentType)
        {
            return this.GetSizeAroundElemenFrameLRTB(internalElementSize);
        }

        private OrnamentBounds GetSizeAroundElemenFrameLRTB(SKPoint internalElementSize)
        {
            //// minimal frame size
            var ornamentSize = new SKRect(0, 0, 
                BorderWidth * 2 + internalElementSize.X, 
                BorderWidth * 2 + internalElementSize.Y);
            
            return new OrnamentBounds
            {
                Bounds = ornamentSize,
                InternalBounds = new SKRect(BorderWidth, BorderWidth, internalElementSize.X, internalElementSize.Y)
            };
        }
    }
}