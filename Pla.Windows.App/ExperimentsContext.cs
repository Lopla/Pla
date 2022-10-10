using Pla.Lib;
using SkiaSharp;

namespace Pla.Windows.App;

internal class ExperimentsContext : IContext, IPainter, IControl
{
    private List<SKPoint> points = new List<SKPoint>();
    private IEngine e = null;

    public void Init(IEngine engine)
    {
        this.e = engine;
    }

    public IPainter GetPainter()
    {
        return this;
    }

    public IControl GetControl()
    {
        return this;
    }

    public void Paint(SKImageInfo info, SKSurface surface)
    {
        foreach (var p in points)
        {
            surface.Canvas.DrawPoint(p, SKColor.Parse("000"));
        }            
    }

    public void Click(SKPoint argsLocation)
    {
        this.points.Add(argsLocation);
        this.e.RequestRefresh();
    }

    public void KeyDown(uint key)
    {
            
    }
}