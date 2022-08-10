using SkiaSharp;
using System.Collections.Generic;

namespace Pla.Lib.UI
{
    public class DrawingStyle
    {
        /// <summary>
        /// Used to write text and draw lines
        /// </summary>
        public SKPaint Front;

        /// <summary>
        /// Used to paint backgrounds
        /// </summary>
        public SKPaint Back;

        public DrawingStyle()
        {
            this.SetStyle(amigaWB);
        }

        public void SetStyle(List<SKColor> style)
        {
            this.Front = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = style[1],
            };

            this.Back = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = style[0],
            };
        }

        public List<SKColor> amigaWB = new List<SKColor>()
        {
            new SKColor(149, 149, 149),
            new SKColor(000, 000, 000),
            new SKColor(255, 255, 255),
            new SKColor( 59, 103, 162),
            new SKColor(123, 123, 123),
            new SKColor(175, 175, 175),
            new SKColor(170, 144, 124),
            new SKColor(255, 169, 151),
        };
    }
}