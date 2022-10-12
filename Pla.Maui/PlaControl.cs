using SkiaSharp.Views.Maui.Controls;

namespace Pla.Maui;

public class PlaControl : ContentView
{
    public PlaControl()
    {
        
        Content = new VerticalStackLayout
        {
            Children =
            {
                new Label
                {
                    HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "pla..."
                },
                new SKCanvasView()
            }
        };
    }
}