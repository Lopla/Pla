using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Edit : Widget
    {
        public string Text = "";

        public override void Draw(SKCanvas canvas)
        {
            using (var painterb = new SKPaint()
            {
                Color = new SKColor(0, 0, 0)
            })
            {
                canvas.DrawText(Text, Bounds.Left, Bounds.MidY, painterb);
            }
        }

        
    }
}