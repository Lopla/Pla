namespace Pla.Maui.App;

public class MainPlaPage : ContentPage
{
	public MainPlaPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				},
				new PlaControl()
                {
					VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center
                }
			},

		};
	}
}