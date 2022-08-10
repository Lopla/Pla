using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Manager : IControl, IPainter, IWidgetContainer
    {
        public Manager(IEngine painter) : base()
        {
            this.painter = painter;
        }

        Frame rootFrame = new Frame();

        public Widget Add(Widget widget)
        {
            rootFrame.Add(widget);
            return widget;
        }

        private readonly IEngine painter;

        public void KeyDown(uint key)
        {

        }

        public void Click(SKPoint argsLocation)
        {
            rootFrame.Click(argsLocation);
        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            // var c = surface.Canvas;
            // var painter  = new SKColor(255,0,0,32);
            // c.Clear(painter);

            var style = new DrawingStyle();
            using (style.Front = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = new SKColor(0, 0, 0),
            })
            {
                rootFrame.Draw(surface.Canvas, style);
            }
            surface.Canvas.Flush();
        }
    }
}