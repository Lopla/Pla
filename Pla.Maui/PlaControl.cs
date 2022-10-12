using SkiaSharp;
using SkiaSharp.Views.Maui.Controls;

namespace Pla.Maui;

public class PlaControl : ContentView
{
    public PlaControl()
    {
        this.Canvas = new SKCanvasView()
        {
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill,
            Background = Brush.Azure,
            HeightRequest = 100,
            WidthRequest = 100
        };

        this.Canvas.PaintSurface += (sender, args) =>
        {
            var p = new SKPaint()
            {
                Color = SKColor.Parse("aaa"),
                StrokeWidth = 1
            };
            args.Surface.Canvas.DrawLine(0, 0, 100, 100, p);
        };
        
        Content = new VerticalStackLayout
        {
            Children =
            {
                new Label
                {
                    HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "pla..."
                },
                Canvas
            }
        };
    }

    public SKCanvasView Canvas { get; set; }
}