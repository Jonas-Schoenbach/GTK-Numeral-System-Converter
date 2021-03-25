using System;
using Gtk;

namespace NumeralSystemConverter
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.Init();

            var numeralSystemConverter = new Application(Constants.App.Id, GLib.ApplicationFlags.None);
            numeralSystemConverter.Register(GLib.Cancellable.Current);
            
            var mainWindow = new MainWindow();
            numeralSystemConverter.AddWindow(mainWindow);
            mainWindow.Show();
            
            Application.Run();
        }
    }
}