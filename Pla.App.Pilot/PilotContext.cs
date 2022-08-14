using Pla.Lib;
using Pla.Lib.UI;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets;

namespace Pla.App.Pilot
{
    public class PilotContext : IContext
    {
        private IEngine _engine;
        private Manager _manager;

        public IControl GetControl()
        {
            return this._manager;
        }

        public IPainter GetPainter()
        {
            return this._manager;
        }

        public void Init(IEngine engine)
        {
            this._engine = engine;
            this._manager = new Manager(engine);

            var container = this._manager
                    .AddWidget(new Frame())
                ;

            //ShowLabelAndSelectedWidgetEvent(container);
            Editor(container);
            //AddButton(container);
            //LotsOfFrames(container);

            //this._engine.RequestTransparentWindow();
        }

        private void AddButton(IWidgetContainer container)
        {
            var b = container.AddWidget(new Button()
            {
                Text = "Close",
            });

            b.ClickedHandler += point => { throw new Exception("How to close it?"); };
        }

        private void Editor(IWidgetContainer container)
        {
            container.Add(new Edit()
            {
                Text ="Zażółć gęślą jaźń. yyygggIIWWllLLTTT"
            });
        }

        private void ShowLabelAndSelectedWidgetEvent(IWidgetContainer container)
        {
            var labal = container.AddWidget(new Label() { Text = "Label" });
            this._manager.OnWidgetSelected += (widget) =>
            {
                labal.Text = widget?.ToString() ?? "none";
                
                this._engine.RequestRefresh();
            };
        }

        private void LotsOfFrames(IWidgetContainer container)
        {

            container.AddWidget(new Button() { Text = "No Frame" });
            container.AddWidget(new Button() { Text = "No Frame" });
            container.AddWidget(new Button() { Text = "No Frame" });

            var horizontalFrame = container.AddWidget(new Frame(
                FrameStyle.Horizontal));
            horizontalFrame.AddWidget(new Button() { Text = "Frame1/1" });
            var inhorizontal = horizontalFrame.AddWidget(new Frame());
            inhorizontal.AddWidget(new Button() { Text = "Frame1/2/1" });
            inhorizontal.AddWidget(new Edit() { Text = "Editor/2/2" });
            inhorizontal.AddWidget(new Button() { Text = "Frame1/2/2" });


            horizontalFrame.AddWidget(new Button() { Text = "Frame1/1" });

            var f2 = container.AddWidget(new Frame());
            f2.AddWidget(new Button() { Text = "Frame2/1" });
            f2.AddWidget(new Button() { Text = "Frame2/2" });
            f2.AddWidget(new Button() { Text = "Frame2/3" });

            container.AddWidget(new Button() { Text = "No Frame" });
        }
    }
}
