using Pla.Lib;
using Pla.Lib.UI;
using SkiaSharp;

namespace Pla.App.Pilot
{
    public class PilotContext : IContext
    {
        private IEngine engine;
        private Manager manager;

        public IControl GetControl()
        {
            return this.manager;
        }

        public IPainter GetPainter()
        {
            return this.manager;
        }

        public void Init(IEngine engine)
        {
            this.engine = engine;
            this.manager = new Manager(engine);

            var container = this.manager
                    .AddWidget(new Frame())
                ;

            ShowLabelAndSelectedWidgetEvent(container);
            Editor(container);
            AddButton(container);
            LotsOfFrames(container);

            this.engine.RequestTransparentWindow();
        }

        private void AddButton(IWidgetContainer container)
        {
            container.Add(new Button()
            {
                Label = "Action action!"
            });
        }

        private void Editor(IWidgetContainer container)
        {
            container.Add(new Edit()
            {
                Text ="a"
            });
        }

        private void ShowLabelAndSelectedWidgetEvent(IWidgetContainer container)
        {
            var labal = container.AddWidget(new Label() { Text = "Label" });
            this.manager.OnWidgetSelected += (widget) =>
            {
                labal.Text = widget?.ToString() ?? "none";
                
                this.engine.RequestRefresh();
            };
        }

        private void LotsOfFrames(IWidgetContainer container)
        {

            container.AddWidget(new Button() { Label = "No Frame" });
            container.AddWidget(new Button() { Label = "No Frame" });
            container.AddWidget(new Button() { Label = "No Frame" });

            var horizontalFrame = container.AddWidget(new Frame(
                FrameStyle.Horizontal));
            horizontalFrame.AddWidget(new Button() { Label = "Frame1/1" });
            var inhorizontal = horizontalFrame.AddWidget(new Frame());
            inhorizontal.AddWidget(new Button() { Label = "Frame1/2/1" });
            inhorizontal.AddWidget(new Edit() { Text = "Editor/2/2" });
            inhorizontal.AddWidget(new Button() { Label = "Frame1/2/2" });


            horizontalFrame.AddWidget(new Button() { Label = "Frame1/1" });

            var f2 = container.AddWidget(new Frame());
            f2.AddWidget(new Button() { Label = "Frame2/1" });
            f2.AddWidget(new Button() { Label = "Frame2/2" });
            f2.AddWidget(new Button() { Label = "Frame2/3" });

            container.AddWidget(new Button() { Label = "No Frame" });
        }
    }
}
