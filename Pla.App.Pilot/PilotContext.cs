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

            ShowSelectedWidget();
            LotsOfFrames();

            //this.engine.RequestTransparentWindow();
        }

        private void ShowSelectedWidget()
        {
            var labale = this.manager.AddWidget(new Label() { Text = "Label" });
            this.manager.OnWidgetSelected += (widget) =>
            {
                labale.Text = widget?.ToString() ?? "none";
                
                this.engine.RequestRefresh();
            };
        }

        private void LotsOfFrames()
        {

            this.manager.AddWidget(new Button() { Label = "No Frame" });
            this.manager.AddWidget(new Button() { Label = "No Frame" });
            this.manager.AddWidget(new Button() { Label = "No Frame" });

            var horizontalFrame = this.manager.AddWidget(new Frame(
                FrameStyle.Horizontal,
                drawingStyle: new DrawingStyle()
                {
                    Front = new SKPaint()
                    {
                        Color = new SKColor(230, 200, 200)
                    }
                }));
            horizontalFrame.AddWidget(new Button() { Label = "Frame1/1" });
            var inhorizontal = horizontalFrame.AddWidget(new Frame());
            inhorizontal.AddWidget(new Button() { Label = "Frame1/2/1" });
            inhorizontal.AddWidget(new Button() { Label = "Frame1/2/2" });

            horizontalFrame.AddWidget(new Button() { Label = "Frame1/1" });

            var f2 = this.manager.AddWidget(new Frame(drawingStyle: new DrawingStyle()
            {
                Front = new SKPaint()
                {
                    Color = new SKColor(200, 230, 200)
                }
            }));
            f2.AddWidget(new Button() { Label = "Frame2/1" });
            f2.AddWidget(new Button() { Label = "Frame2/2" });
            f2.AddWidget(new Button() { Label = "Frame2/3" });

            this.manager.AddWidget(new Button() { Label = "No Frame" });
        }
    }
}
