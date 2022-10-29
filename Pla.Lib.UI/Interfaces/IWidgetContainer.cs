using System.Collections.Generic;
using Pla.Lib.UI.Widgets.Base;
using Pla.Lib.UI.Widgets.Enums;

namespace Pla.Lib.UI.Interfaces
{
    public interface IWidgetContainer
    {
        IEnumerable<Widget> Widgets { get; }

        /// <summary>
        /// Specify in which direction this element is growing.
        /// </summary>
        FrameStyle Orientation { get; }

        /// <summary>
        /// Add a widget to this container
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        Widget Add(Widget widget);

        /// <summary>
        /// Request for all kids within this widget container, and the widget container itself.
        /// </summary>
        void Invalidate();

        /// <summary>
        /// Call to request resize action on this frame, usually it's called during <see cref="Add"/> method.
        /// </summary>
        void RequestResize();

        /// <summary>
        ///     Provide first element that can be selected. Which in reality is not a <see cref="IWidgetContainer" />
        /// </summary>
        /// <returns></returns>
        Widget FindFirstSelectableWidget();
    }
}