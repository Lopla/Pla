using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Edit : Widget
    {
        public string Text = "";

        public override void Draw(SKCanvas canvas, DrawingStyle style)
        {
            base.Draw(canvas, style);
            using (var painterb = new SKPaint()
            {
                Color = style.Front.Color
            })
            {
                canvas.DrawText(Text, Bounds.Left, Bounds.MidY, painterb);
            }
        }

        public override void OnKeyDow(uint key)
        {
            this.Text = this.Text + (char)key;

            this.Parent.Invalidate();
        }

        public override SKPoint RequestedSize => new SKPoint(100,30);
    }
}