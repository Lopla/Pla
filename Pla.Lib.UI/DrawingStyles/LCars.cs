using SkiaSharp;

namespace Pla.Lib.UI
{
    /// <summary>
    ///     Warp 10
    /// </summary>
    public class LCars : IDrawingStyle
    {
        private readonly bool transparent = false;

        private string[] colourMap =
        {
            "#000000",
            "#ff7700", // orange - normal text
            "#ff2200", // red
            "#33cc99", // green
            "#666688" // gray
        };

        private SKColor colours = SKColor.Parse("#f5f6fa");

        public void Modifyable(PaintContext context)
        {
        }

        public void Pointable(PaintContext context)
        {
            using (var painterBorder = new SKPaint())
            using (var painterBack = new SKPaint())
            {
                if (!transparent)
                    context.canvas.DrawRect(context.widgetSize, painterBack);
                context.canvas.DrawRect(context.widgetSize, painterBorder);
            }
        }

        public void Readable(PaintContext context)
        {
        }

        public void Border()
        {
        }
    }
}