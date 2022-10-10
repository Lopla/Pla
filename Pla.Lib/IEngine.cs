using System;
using SkiaSharp;

namespace Pla.Lib
{
    public interface IEngine
    {
        bool RequestTransparentWindow();

        void RequestRefresh();

        void RequestQuit();

        DeviceInfo GetDeviceInfo();
    }
}
