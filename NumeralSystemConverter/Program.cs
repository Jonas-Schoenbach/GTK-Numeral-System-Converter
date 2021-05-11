using System;
using System.Runtime.InteropServices;
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
			
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				Settings.Default.ThemeName = "win";
			}

			var numeralSystemConverter = new Application(Constants.App.Id, GLib.ApplicationFlags.None);
			numeralSystemConverter.Register(GLib.Cancellable.Current);
			var mainWindow = new MainWindow {Title = Constants.App.Name, Screen = Screen.Default};

			numeralSystemConverter.AddWindow(mainWindow);
			
			mainWindow.ShowAll();
			
			Application.Run();
		}
	}
}