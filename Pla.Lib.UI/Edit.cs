using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Edit : Widget
    {
        public string Text = "";

        public override void Draw(SKCanvas canvas, DrawingStyle style)
        {
            using (var painterb = new SKPaint()
            {
                Color = style.Front.Color
            })
            {
                canvas.DrawText(Text, Bounds.Left, Bounds.MidY, painterb);
            }

            
        }        
    }
}