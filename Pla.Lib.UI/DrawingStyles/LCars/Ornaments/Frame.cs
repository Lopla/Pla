using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars.Ornaments
{
    public class Frame : IOrnamentPainter
    {
        private readonly IDesign _lCarsStyle;
        private float Border { get; set; } = 20;

        public Frame(IDesign lCarsStyle)
        {
            _lCarsStyle = lCarsStyle;
        }

        public void Draw(PaintContext context)
        {


            using (var painterBack = new SKPaint
                   {
                       Color = new SKColor(0, 0, 0),
                       Style = SKPaintStyle.Stroke
                   })
            {
                context.Canvas.DrawRect(context.Bounds, painterBack);
            }
            

            // top header
            using (var painterBack = new SKPaint
                   {
                       Color = _lCarsStyle.Palette.FrontColor(OrnamentType.WidgetContainer),
                       Style = SKPaintStyle.StrokeAndFill
                   })
            {

                ///   top
                context.Canvas.DrawCircle(
                    context.Bounds.Left +  Border / 2, 
                    context.Bounds.Top + Border / 2, Border/2,  painterBack);

                context.Canvas.DrawRect(
                    new SKRect(context.Bounds.Left+ Border/2, 
                        context.Bounds.Top, 
                        context.Bounds.Right, 
                        context.Bounds.Top + Border), painterBack);

                /// left
                context.Canvas.DrawRect(
                    new SKRect(context.Bounds.Left,
                        context.Bounds.Top+ Border /2,
                        context.Bounds.Left + Border,
                        context.Bounds.Bottom - Border/2), painterBack);

                /// bottom
                context.Canvas.DrawCircle(
                    context.Bounds.Left  + Border / 2, 
                    context.Bounds.Bottom - Border / 2, 
                    Border / 2, painterBack);

                context.Canvas.DrawRect(
                    new SKRect(context.Bounds.Left + Border / 2,
                        context.Bounds.Bottom - Border,
                        context.Bounds.Right,
                        context.Bounds.Bottom), painterBack);


            }
        }

        public OrnamentBounds GetSizeAroundElement(SKPoint internalElementSize)
        {
            //// minimal frame size
            var ornamentSize = new SKRect(0, 0,
                Border * 2 + internalElementSize.X,
                Border * 2 + internalElementSize.Y);

            return new OrnamentBounds
            {
                Bounds = ornamentSize,
                InternalBounds = new SKRect(Border, Border , internalElementSize.X, internalElementSize.Y)
            };
        }

    }
}
