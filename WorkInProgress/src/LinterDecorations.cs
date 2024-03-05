using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace WorkInProgress
{
	public static class LinterColors
	{
		public static Color NSpaceClr { get; set; } = Color.RoyalBlue;
		public static Color ClassNameClr { get; set; } = Color.DeepSkyBlue;
		public static Color MethodClr { get; set; } = Color.Aqua;
		public static Color TypeClr { get; set; } = Color.LimeGreen;
		public static Color StdClr { get; set; } = Color.Gray;
		public static Color FileClr { get; set; } = Color.DeepSkyBlue;
		public static Color LNClr { get; set; } = Color.Violet;
		public static Color ArgsClr { get; set; } = Color.DimGray;
		public static Color FuncDelimClr { get; set; } = Color.White;
		public static Color ArgsScopeDelimClr { get; set; } = Color.MediumVioletRed;
		public static Color ArsDelimClr { get; set; } = Color.MediumVioletRed;
		public static Color FolderDelimClr { get; set; } = Color.MediumVioletRed;
		public static Color Reset { get; set; } = Color.White;
	}

	public class DEFAULT_SEPARATOR
	{
		public char LeftArgsSeparator { get; set; }
		public char LeftGenericArgsSeparator { get; set; }

		public char RightArgsSeparator { get; set; }
		public char RightGenericArgsSeparator { get; set; }

	}
	public class DEFAULT_DELIMITERS
	{
		public const char LeftNamespace = char.MinValue;
		public const char LeftClassName = char.MinValue;
		public const char LeftMethodName = char.MinValue;
		public const char LeftMethodScope = '(';
		public const char LeftArgsSeparator = char.MinValue;
		public const char LeftGenericArgs = '<';
		public const char LeftGenericArgsSeparator = char.MinValue;

		public const char RightNamespace = '.';
		public const char RightClassName = '.';
		public const char RightMethodName = char.MinValue;
		public const char RightMethodScope = '(';
		public const char RightArsSeparator = ',';
		public const char RightGenericArgs = '>';
		public const char RightGenericArgsSeparator = ',';

		//static void InvokeMethodWithParams(MyClass instance, int param1, string param2)
		//{
		//	// Appel de la méthode de l'autre fichier avec les paramètres
		//	instance.MyMethod(param1, param2);
		//}

	}
	public class Delimiters
	{
		public static char Namespace { get; set; }
		public static char ClassName { get; set; }
		public static char MethodName { get; set; }
		public static char MethodScope { get; set; }
		public static char Arguments { get; set; }
		public Delimiters(char nspace, char classname, char methodname, char methodscope, char arguments)
		{
			Namespace = nspace;
			ClassName = classname;
			MethodName = methodname;
			MethodScope = methodscope;
			Arguments = arguments;
		}
	}
	public static class LinterDelimiters
	{
		//public static Delimiters Left {  get; set; } = new Delimiters();
		//public static Delimiters Right {  get; set; } = new Delimiters();

	}

	public class DEFAULT_PADDING
	{
		public const int LeftNamespace = 12;
		public const int LetfFilePath = 16;
	}


}
