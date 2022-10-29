using Pla.Lib;
using Pla.Lib.UI;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets;
using Pla.Lib.UI.Widgets.Enums;

namespace Pla.App.Pilot
{
    public class PilotContext : IContext
    {
        private IEngine _engine = null!;
        private Manager _manager = null!;

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
            this._manager = new Manager(engine, new Pla.Lib.UI.DrawingStyles.Ami.AmiMagic());

            var container =
                    this._manager
                    //.AddWidget(new Frame())
                ;

            ShowLabelAndSelectedWidgetEvent(container);
            Editor(container);
            AddButton(container);

            container.AddWidget(new Button()
            {
                Text = "Add lot's of strange frames",
            }).ClickedHandler += point =>
            {
                LotsOfFrames(container);
            };

            container.AddWidget(new Button()
            {
                Text = "Request transparency",
            }).ClickedHandler += point =>
            {
                this._engine.SwitchTransparentWindow(true);
            };

            container.AddWidget(new Button()
            {
                Text = "Disable transparency",
            }).ClickedHandler += point =>
            {
                this._engine.SwitchTransparentWindow(false);
            };
        }

        private void AddButton(IWidgetContainer container)
        {
            var b = container.AddWidget(new Button()
            {
                Text = "Close",
            });

            b.ClickedHandler += point =>
            {
                this._manager.RequestClose();
            };
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
