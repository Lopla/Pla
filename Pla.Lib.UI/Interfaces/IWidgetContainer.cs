namespace Pla.Lib.UI.Interfaces
{
    public interface IWidgetContainer
    {
        Widget Add(Widget widget);
        void Invalidate();
        void RequestResize();
    }
}