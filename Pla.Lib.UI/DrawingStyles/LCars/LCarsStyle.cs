using Pla.Lib.UI.Interfaces;

namespace Pla.Lib.UI.DrawingStyles.LCars
{
    /// <summary>
    ///     Warp 10
    /// </summary>
    public class LCarsStyle : IDesign
    {
        public LCarsStyle()
        {
            Ornaments = new LCarsOrnaments();
            Palette = new LCarsPalette();
        }
        
        public IPalette Palette { get; }

        public IOrnamentsPainter Ornaments { get; }
    }
}