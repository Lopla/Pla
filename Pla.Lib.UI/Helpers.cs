using Pla.Lib.UI.Interfaces;

namespace Pla.Lib.UI
{
    public static class Helpers
    {
        public static T AddWidget<T>(this IWidgetContainer frame, T newWidget)
            where T: Widget
        {
            frame.Add(newWidget);
            return newWidget;
        }
        
    }
}