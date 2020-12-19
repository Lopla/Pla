# Jak zacząć
- Zainstaluj vs code
- Command line
```
dotnet new classlib --name Example
dotnet new console --name Example.Console
cd Example.Console
dotnet add reference ..\Example
dotnet add package Pla.Gtk
cd ..
cd Example
dotnet add package Pla.Lib
cd ..
code .
```
- Dodaj wszystkie sugerowane dodatki dla C# i .net
- Podmień zawartość pliku ``Example\Class1.cs`` jak niżej
```cs
using System;
using Pla.Lib;
using SkiaSharp;

namespace Example
{
    public class Class1 : IPainter, IControl, IContext
    {

        public IControl GetControl()
        {
            return this;
        }

        public IPainter GetPainter()
        {
            return this;
        }

        public void Init(IEngine engine)
        {
        }

        public void KeyDown(uint key)
        {
        }

        public void Click(SKPoint argsLocation)
        {
        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            using(var painter = new SKPaint(){
                Color = new SKColor(255,255,255)
            })
            {
                surface.Canvas.DrawText("Hello PLA", 10,10, painter);
            }
        }
    }
}


```
- Podmień zawartość pliku ``Example.Console\Program.cs`` na wskazaną poniżej

```cs
using System;

namespace Example.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Pla.Gtk.App.PlaMain(new Example.Class1());
        }
    }
}

```