using System;
using System.Text.RegularExpressions;
using Gtk;

namespace NumeralSystemConverter
{
	internal class MainWindow : Window
	{
		[Builder.Object]
		private readonly Button btnCalc;
		
		[Builder.Object]
		private readonly Entry eInput;
		
		[Builder.Object]
		private readonly Entry eDecimal;
		
		[Builder.Object]
		private readonly Entry eBinary;
		
		[Builder.Object]
		private readonly Entry eTernary;
		
		[Builder.Object]
		private readonly Entry eOctal;
		
		[Builder.Object]
		private readonly Entry eHex;
		
		[Builder.Object]
		private readonly RadioButton rbDecimal;
		
		[Builder.Object]
		private readonly RadioButton rbBinary;
		
		[Builder.Object]
		private readonly RadioButton rbTernary;
		
		[Builder.Object]
		private readonly RadioButton rbOctal;

		public MainWindow() : this(new Builder(Constants.WindowResources.MainWindow))
		{
			
		}

		private MainWindow(Builder builder) : base(builder.GetObject(Constants.WindowIds.MainWindow).Handle)
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
			try
			{
				if (!Regex.IsMatch(eInput.Text, @"[^a-fA-F0-9\s]"))
				{
					int input;
					if (rbDecimal.Active.Equals(true))
					{
						input = Convert.ToInt32(eInput.Text);
						eDecimal.Text = eInput.Text;
						eBinary.Text = Converter.ToBinary(input);
						eTernary.Text = Converter.ToTernary(input);
						eOctal.Text = Converter.ToOctal(input);
						eHex.Text = Converter.ToHexadecimal(input);
					}
					else
					{
						int inputDecimal;
						if (rbBinary.Active.Equals(true))
						{
							inputDecimal = Convert.ToInt32(eInput.Text, 2);
							eDecimal.Text = inputDecimal.ToString();
							eBinary.Text = eInput.Text;
							eTernary.Text = Converter.ToTernary(inputDecimal);
							eOctal.Text = Converter.ToOctal(inputDecimal);
							eHex.Text = Converter.ToHexadecimal(inputDecimal);
						}
						else if (rbTernary.Active.Equals(true))
						{
							input = Convert.ToInt32(eInput.Text);
							inputDecimal = Converter.TernaryToDecimal(input);
							eDecimal.Text = inputDecimal.ToString();
							eBinary.Text = Converter.ToBinary(inputDecimal);
							eTernary.Text = eInput.Text;
							eOctal.Text = Converter.ToOctal(inputDecimal);
							eHex.Text = Converter.ToHexadecimal(inputDecimal);
						}
						else if (rbOctal.Active.Equals(true))
						{
							inputDecimal = Convert.ToInt32(eInput.Text, 8);
							eDecimal.Text = inputDecimal.ToString();
							eBinary.Text = Converter.ToBinary(inputDecimal);
							eTernary.Text = Converter.ToTernary(inputDecimal);
							eOctal.Text = eInput.Text;
							eHex.Text = Converter.ToHexadecimal(inputDecimal);
						}
						else
						{
							var inputHex = eInput.Text;
							inputDecimal = Convert.ToInt32(inputHex, 16);
							eDecimal.Text = inputDecimal.ToString();
							eBinary.Text = Converter.ToBinary(inputDecimal);
							eTernary.Text = Converter.ToTernary(inputDecimal);
							eOctal.Text = Converter.ToOctal(inputDecimal);
							eHex.Text = inputHex.ToUpper();
						}
					}
				}
				else
				{
					MessageBoxHelper.ErrorMessageBox(Constants.Error.InvalidNumberTitle,
						Constants.Error.InvalidNumberMessage);
				}
			}
			catch
			{
				MessageBoxHelper.ErrorMessageBox(Constants.Error.InvalidNumberTitle,
					Constants.Error.InvalidNumberMessage);
			}
		}
	}
}