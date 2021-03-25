using System;
using System.Collections.Generic;
using System.Linq;

namespace NumeralSystemConverter
{
    public static class Converter
    {
	    internal static string ToHexadecimal(int input)
        {
        	var hexLetters = new Dictionary<int, char>
        	{
        		{10, 'A'},
        		{11, 'B'},
        		{12, 'C'},
        		{13, 'D'},
        		{14, 'E'},
        		{15, 'F'}
        	};
        	
        	var numbers = new List<char>();

        	while (input != 0)
        	{
        		var rest = input % 16;
        		input /= 16;
        		if (rest > 9 && rest <= 15)
        		{
        			var output = hexLetters[rest];
        			numbers.Add(output);
        		}
        		else
        		{
        			numbers.Add(rest.ToString()[0]);
        		}
        	}
        	return string.Join(string.Empty, numbers.ToArray().Reverse());
        }

        internal static int TernaryToDecimal(int input)
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

        internal static string ToBinary(int input)
        {
        	var output = new List<int>();

        	while (input != 0)
        	{
        		var rest = input % 2;
        		input /= 2;

        		output.Add(rest > 0 ? rest : 0);
        	}
        	return string.Join(string.Empty, output.ToArray().Reverse());
        }

        internal static string ToTernary(int input)
        {
        	var output = new List<int>();

        	while (input != 0)
        	{
        		var rest = input % 3;
        		input /= 3;

        		output.Add(rest > 0 ? rest : 0);
        	}
        	return string.Join(string.Empty, output.ToArray().Reverse());
        }

        internal static string ToOctal(int input)
        {
        	var output = new List<int>();

        	while (input != 0)
        	{
        		var rest = input % 8;
        		input /= 8;

        		output.Add(rest > 0 ? rest : 0);
        	}
        	return string.Join(string.Empty, output.ToArray().Reverse());
        }
    }
}