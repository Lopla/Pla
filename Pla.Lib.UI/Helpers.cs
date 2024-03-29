using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Base;

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