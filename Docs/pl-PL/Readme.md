# Jak zacząć
## Aplikacja na komputer (linux i windows)
- Zainstaluj vs code
- Z linii komend, w katalogu gdzie chcesz tworzyć swoje rozwiązanie utwórz projeky .net
```
dotnet new classlib --name Example
dotnet new console --name Example.Console
```
- dodatkowo dodaj referencje z projektu Console do biblioteki

```
cd Example.Console
dotnet add reference ..\Example
```
 -  w projekcie konsolowym dodaj nuget ``Pla.Gtk``
```
dotnet add package Pla.Gtk
```
 - w biblitece, gdzie będzie się znajdował nasz kod dodaj referencje ``Pla.Lib``
```
cd ..
cd Example
dotnet add package Pla.Lib
cd ..
```
 - uruchom visual studio code, aby móc pracować nad naszą aplikacją
```
code .
```
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