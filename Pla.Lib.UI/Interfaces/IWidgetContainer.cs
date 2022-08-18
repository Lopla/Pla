using System.Collections.Generic;
using Pla.Lib.UI.Widgets;

namespace Pla.Lib.UI.Interfaces
{
    public interface IWidgetContainer
    {
        IEnumerable<Widget> Widgets { get; }
        IWidgetContainer Parent { get; set; }
        Widget Add(Widget widget);
        void Invalidate();
        void RequestResize();
        FrameStyle Orientation { get; }
    }
}