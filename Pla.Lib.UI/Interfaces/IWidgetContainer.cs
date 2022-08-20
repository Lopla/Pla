using System.Collections.Generic;
using Pla.Lib.UI.Widgets;
using Pla.Lib.UI.Widgets.Base;
using Pla.Lib.UI.Widgets.Enums;

namespace Pla.Lib.UI.Interfaces
{
    public interface IWidgetContainer
    {
        IEnumerable<Widget> Widgets { get; }
        Widget Add(Widget widget);
        void Invalidate();
        void RequestResize();
        FrameStyle Orientation { get; }
    }
}