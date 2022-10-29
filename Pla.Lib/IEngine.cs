namespace Pla.Lib
{
    public interface IEngine
    {
        void SwitchTransparentWindow(bool transparent = true);

        void RequestRefresh();

        void RequestQuit();

        DeviceInfo GetDeviceInfo();
    }
}
