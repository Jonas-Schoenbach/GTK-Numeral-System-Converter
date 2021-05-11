using Gtk;

namespace NumeralSystemConverter
{
	public static class MessageBoxHelper
	{
		internal static void ErrorMessageBox(string title, string msg)
		{
			var dialog = new Dialog(title, null, DialogFlags.DestroyWithParent | DialogFlags.Modal, ResponseType.Ok);
			dialog.Resize(250, 100);
			dialog.AddButton(Stock.Ok, ResponseType.Ok);
			dialog.ContentArea.Add(new Label(msg));
			dialog.ShowAll();
			if (dialog.Run() == (int) ResponseType.Ok)
			{
				dialog.Dispose();
			}
		}
	}
}