namespace Pla.Lib.UI.Interfaces
{
    public interface IDesign
    {
        IOrnamentsPainter Ornaments { get; }
        IPalette Palette { get; }
        IActiveElementPainter TextPainter { get; }
    }
}