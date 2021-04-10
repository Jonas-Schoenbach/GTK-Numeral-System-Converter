using System;
using Gdk;
using Gtk;

namespace NumeralSystemConverter
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.Init();
            
            //var cssProvider = new CssProvider();
            //cssProvider.LoadFromPath(Path.Combine("theme", "gtk.css"));
            //StyleContext.AddProviderForScreen(Screen.Default, cssProvider, 600);

            var numeralSystemConverter = new Application(Constants.App.Id, GLib.ApplicationFlags.None);
            numeralSystemConverter.Register(GLib.Cancellable.Current);
            var mainWindow = new MainWindow {Title = Constants.App.Name, Screen = Screen.Default};

            numeralSystemConverter.AddWindow(mainWindow);
            
            mainWindow.ShowAll();
            
            Console.Clear();
            Console.WriteLine("Don't mind me...");
            Console.WriteLine("I'm very stubborn and will exist no matter what!");
            Console.WriteLine("Consoles matter!");
            Application.Run();
        }
    }
}