namespace Pla.Lib.UI
{
    public interface IWidgetContainer
    {
        Widget Add(Widget widget);
        void Invalidate();
        void RequestResize();
    }
}