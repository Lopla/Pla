# Jak zacząć
- Zainstaluj vs code
- Command line
```
dotnet new classlib --name Example
dotnet new exe --name Example.Console
cd Example.Console
dotnet add reference ..\Example
dotnet add package Pla.Gtk
cd ..
cd Example
dotnet add package Pla.Lib
code .
```
