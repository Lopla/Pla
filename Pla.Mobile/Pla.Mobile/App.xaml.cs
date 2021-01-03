using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pla.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PlaGUI(new Pla.App.MainContext());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
