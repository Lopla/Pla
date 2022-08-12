namespace Pla.Win
{
    public class App 
    {
        public static void PlaMain(Pla.Lib.IContext ctx)
        {
            var window = new PlaWindow();
            window.Init(ctx);
            Application.Run(window);
        }
    }
}
