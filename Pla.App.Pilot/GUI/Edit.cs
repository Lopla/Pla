using SkiaSharp;

namespace Example.GUI
{
    public class Edit:Widget{
        public string Text = "";

        public override void Draw(SKCanvas canvas)
        {
            using( var paintera = new SKPaint(){
                Color = new SKColor(255,255,255)
                })
            using(var painterb = new SKPaint(){
                Color = new SKColor(0,0,0)
                })
            {
                canvas.DrawRect(Bounds, paintera);
                canvas.DrawText(Text, Bounds.Left, Bounds.MidY, painterb);
            }
        }
    }
}