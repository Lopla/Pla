using SkiaSharp;

namespace Example.GUI
{
    public class Button : Widget
    {
        public string Label = "";

        public override void Draw(SKCanvas canvas)
        {
            base.Draw(canvas);

            using(var painterb = new SKPaint(){
                Color = new SKColor(0,0,0),
                TextAlign = SKTextAlign.Center,
                })
            {
                canvas.DrawText(Label, Bounds.MidX, Bounds.MidY, painterb);
            }
        }
    }
}