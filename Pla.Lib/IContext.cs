using System;
using SkiaSharp;

namespace Pla.Lib
{
    public interface IContext
    {
        void Init(IEngine engine);

        IPainter GetPainter();

        IControl GetControl();
    }
}
