using SkiaSharp;

namespace Pla.Lib
{
    public interface IControl
    {
        void Click(SKPoint argsLocation);
        void KeyDown(uint key);
    }
}