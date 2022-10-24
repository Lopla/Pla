using Pla.Lib;
using SkiaSharp;

namespace Pla.Win;

public class PlaSimpleContext : IContext, IPainter, IControl
{
    private IEngine engine = null!;

    public void Init(IEngine engine)
    {
        this.engine = engine;
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
        
    }

    public void Click(SKPoint argsLocation)
    {
        
    }

    public void KeyDown(uint key)
    {
        
    }
}
