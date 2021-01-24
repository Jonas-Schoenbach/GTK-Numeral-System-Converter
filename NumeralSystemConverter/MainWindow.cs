using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace NumeralSystemConverter
{
	internal class MainWindow : Window
	{
		#region ApplicationElements
		[UI] private readonly Button btnCalc = null;
		[UI] private readonly Entry eInput = null;
		[UI] private readonly Entry eDecimal = null;
		[UI] private readonly Entry eBinary = null;
		[UI] private readonly Entry eTernary = null;
		[UI] private readonly Entry eOctal = null;
		[UI] private readonly Entry eHex = null;
		[UI] private readonly RadioButton rbDecimal = null;
		[UI] private readonly RadioButton rbBinary = null;
		[UI] private readonly RadioButton rbTernary = null;
		[UI] private readonly RadioButton rbOctal = null;
		#endregion

		#region Constants
		private const string ErrorNumberTitle = "Error: Invalid number";
		private const string ErrorNumberMsg = "Please put in a valid number!";
		#endregion

		public MainWindow() : this(new Builder("MainWindow.glade")){}

		private MainWindow(Builder builder) : base(builder.GetObject("Converter").Handle)
		{
			builder.Autoconnect(this);
			DeleteEvent += Window_DeleteEvent;
			btnCalc.Clicked += BtnCalc_Clicked;
		}

		private static void Window_DeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
		}
		
		private void BtnCalc_Clicked(object sender, EventArgs a)
		{
			int input;
			int inputDecimal;

			try
			{
				if (!Regex.IsMatch(eInput.Text, @"[^a-fA-F0-9\s]"))
				{
					if (rbDecimal.Active.Equals(true))
					{
						input = Convert.ToInt32(eInput.Text);
						eDecimal.Text = eInput.Text;
						eBinary.Text = ToBinary(input);
						eTernary.Text = ToTernary(input);
						eOctal.Text = ToOctal(input);
						eHex.Text = ToHexadecimal(input);
					}

					else if (rbBinary.Active.Equals(true))
					{
					    inputDecimal = Convert.ToInt32(eInput.Text, 2);
					    eDecimal.Text = inputDecimal.ToString();
					    eBinary.Text = eInput.Text;
					    eTernary.Text = ToTernary(inputDecimal);
					    eOctal.Text = ToOctal(inputDecimal);
					    eHex.Text = ToHexadecimal(inputDecimal);
					}
					else if (rbTernary.Active.Equals(true))
					{
					    input = Convert.ToInt32(eInput.Text);
					    inputDecimal = TernaryToDecimal(input);
					    eDecimal.Text = inputDecimal.ToString();
					    eBinary.Text = ToBinary(inputDecimal);
					    eTernary.Text = eInput.Text;
					    eOctal.Text = ToOctal(inputDecimal);
					    eHex.Text = ToHexadecimal(inputDecimal);
					}
					else if (rbOctal.Active.Equals(true))
					{
					    inputDecimal = Convert.ToInt32(eInput.Text, 8);
					    eDecimal.Text = inputDecimal.ToString();
					    eBinary.Text = ToBinary(inputDecimal);
					    eTernary.Text = ToTernary(inputDecimal);
					    eOctal.Text = eInput.Text;
					    eHex.Text = ToHexadecimal(inputDecimal);
					}
					else
					{
					    var inputHex = eInput.Text;
					    inputDecimal = Convert.ToInt32(inputHex, 16);
					    eDecimal.Text = inputDecimal.ToString();
					    eBinary.Text = ToBinary(inputDecimal);
					    eTernary.Text = ToTernary(inputDecimal);
					    eOctal.Text = ToOctal(inputDecimal);
					    eHex.Text = inputHex.ToUpper();
					}
				}
				else
				{
					Error(ErrorNumberTitle, ErrorNumberMsg);
				}
			}
			catch
			{
				Error(ErrorNumberTitle, ErrorNumberMsg);
			}

		}


		private static void Error(string title, string msg)
		{
			var dialog = new Dialog(title, null, DialogFlags.DestroyWithParent | DialogFlags.Modal,
				ResponseType.Ok);
			dialog.Resize(250, 100);
			dialog.AddButton(Stock.Ok, ResponseType.Ok);
			dialog.ContentArea.Add(new Label(msg));
			dialog.ShowAll();
			if (dialog.Run() == (int) ResponseType.Ok)
			{
				dialog.Dispose();
			}
		}

		private static string ToHexadecimal(int input)
		{
			var hexLetters = new Dictionary<int, string>
			{
				{10, "A"},
				{11, "B"},
				{12, "C"},
				{13, "D"},
				{14, "E"},
				{15, "F"}
			};
			
			var numbers = new List<string>();
			var rest = 0;
			string output;
			
			while (input != 0)
			{
				rest = input % 16;
				input /= 16;
				if (rest > 9 && rest <= 15)
				{
					output = hexLetters[rest];
					numbers.Add(output);
				}
				else
				{
					numbers.Add(rest.ToString());
				}
			}
			return string.Join(string.Empty, numbers.ToArray().Reverse());
		}

		private static int TernaryToDecimal(int input)
		{
			var inputString = input.ToString();
			var output = 0;
			var pot = 1;
			for (var i = 0; i < inputString.Length; i++)
			{
				output += Convert.ToInt32(inputString[inputString.Length - 1 - i].ToString()) * pot;
				pot *= 3;
			}
			return output;
		}

		private static string ToBinary(int input)
		{
			var output = new List<int>();
			var rest = 0;

			while (input != 0)
			{
				rest = input % 2;
				input /= 2;

				output.Add(rest > 0 ? rest : 0);
			}
			return string.Join(string.Empty, output.ToArray().Reverse());
		}

		private static string ToTernary(int input)
		{
			var output = new List<int>();
			var rest = 0;

			while (input != 0)
			{
				rest = input % 3;
				input /= 3;

				output.Add(rest > 0 ? rest : 0);
			}
			return string.Join(string.Empty, output.ToArray().Reverse());
		}

		private static string ToOctal(int input)
		{
			var output = new List<int>();
			var rest = 0;

			while (input != 0)
			{
				rest = input % 8;
				input /= 8;

				output.Add(rest > 0 ? rest : 0);
			}
			return string.Join(string.Empty, output.ToArray().Reverse());
		}
	}
}