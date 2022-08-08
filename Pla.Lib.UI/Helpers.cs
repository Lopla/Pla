namespace Pla.Lib.UI
{
    public static class Helpers
    {
        public static T AddWidget<T>(this Frame frame, T newWidget)
            where T: Widget
        {
            frame.Add(newWidget);
            return newWidget;
        }

        public static T AddWidget<T>(this Manager frame, T newWidget)
            where T: Widget
        {
            frame.Add(newWidget);
            return newWidget;
        }
    }
}