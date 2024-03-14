using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

	public class DEFAULT_PADDING
	{
		public const int LeftNamespace = 12;
		public const int LetfFilePath = 16;
	}

	public class DEFAULT_DELIMITERS
	{
		
		public DecorationManager NAMESPACE = new DecorationManager(1, char.MinValue, '.' );
		public DecorationManager CLASSNAME = new DecorationManager(2, char.MinValue, '.');
		public DecorationManager METHODNAME = new DecorationManager(3, char.MinValue, char.MinValue);
		public DecorationManager METHOD_SCOPE = new DecorationManager(4, '(', ')');
		public DecorationManager ARGS_SEPARATOR = new DecorationManager(5, char.MinValue, ',');
		public DecorationManager GENERIC_ARGS_SCOPE = new DecorationManager(6, '<', '>');
		public DecorationManager GENERIC_ARGS_SEPARATOR = new DecorationManager(7, char.MinValue, '.');
	}

	//public class DECORATION_CONSTANTS
	//{
	//	public int Id { get; set; }
	//	public char Left {  get; set; }
	//	public char Right { get; set; }

	//	public int PadLeft { get; set; }
	//	public int PadRight {  get; set; }

	//	public Color Color { get; set; }


	//	public DECORATION_CONSTANTS(int id, char left, char right, Color color, int padLeft=0, int padRight=0)
	//	{
	//		this.Id = id;
	//		this.Left = left;
	//		this.Right = right;
	//		this.Color = color;
	//		this.PadLeft = padLeft;
	//		this.PadRight = padRight;
	//	}
	//}

	public interface IDecorationStructure
	{
		public char Separator { get; set; }
		public Color SeparatorColor { get; set; }
		public int Pad {  get; set; }

	}
	public class DecorationStructure :IDecorationStructure
	{
		public char Separator { get; set; }
		public Color SeparatorColor { get; set; }
		public int Pad { get; set; }
		public DecorationStructure(char separator, Color separatorColor, int pad)
		{
			this.Separator = separator;
			this.SeparatorColor = separatorColor;
			this.Pad = pad;
		}
	}

	public interface ILeft<T>
	{
		public T left { get; set; }
		//void SetLeft(T obj);
	}
	public interface IRight<T>
	{
		public T right { get; set; }
		//void SetRight(T obj);
	}
	public class Left<T> : ILeft<T>
	{
		public T left { get; set; }
		public Left(T value)
		{
			this.left = value;
		}
		//public void SetLeft(T obj)
		//{
		//	this.Left = obj;
		//}
	}
	public class Right<T> : IRight<T>
	{
		public T right { get; set; }
		public Right(T value)
		{
			this.right = value;
		}
		//public void SetRight(T obj)
		//{
		//	this.Right = obj;
		//}
	}
	public interface ISided<T> 
	{
		public Left<T> left { get; set; }
		public Right<T> right { get; set; }
		void SetBoth(T both);
		void SetBoth(T left, T right);
		void SetSide(T obj, bool isLeft);
	}
	public  abstract class Sided<T> : ISided<T>
	{
		public Left<T> left { get; set; }
		public Right<T> right { get; set; }

		public void SetLeft(T left)
		{
			this.left = new Left<T>(left);
		}
		public void SetRight(T right)
		{
			this.right = new Right<T>(right);
		}
		public void SetBoth(T both)
		{
			this.left = new Left<T>(both);
			this.right = new Right<T>(both);
		}
		public void SetBoth(T left, T right)
		{
			this.left = new Left<T>(left);
			this.right = new Right<T>(right);
		}

		public void SetSide(T obj, bool isRight)
		{
			if (!isRight)
			{
				this.left = new Left<T>(obj);
			}
			else
			{
				this.right = new Right<T>(obj);
			}
		}
	}

	public class DecorationManager<DecorationStructure>: Sided<DecorationStructure>
	{
		public Color color { get; set; }
		public Sided<DecorationStructure> sided { get; set; }


		public DecorationManager(Color color)
		{
			this.color = color;
		}
		public DecorationManager(DecorationStructure bothSides)
		{
			this.sided.SetBoth(bothSides);
		}
		public DecorationManager(Color color, DecorationStructure bothSides)
		{
			this.color = color;
			this.sided.SetBoth(bothSides);
		}
		public DecorationManager(Color color, ILeft<DecorationStructure> left)
		{
			this.color = color;
			this.SetLeft(left)
		}

		public void SetDecoration(DecorationStructure left, DecorationStructure right)
		{
			this.SetLeft(left);
			this.SetRight(right);
		}
		public void SetSidedDecoration(Color separatorColor, char separator = char.MinValue, int pad = 0)
		{
			this.left = new DecorationStructure(separator, separatorColor, pad);
			this.right= new DecorationStructure()
		}

	}




	//public static class DEFAULT_DELIMITERS
	//{
	//	public const char LeftNamespace = char.MinValue;
	//	public const char LeftClassName = char.MinValue;
	//	public const char LeftMethodName = char.MinValue;
	//	public const char LeftMethodScope = '(';
	//	public const char LeftArgsSeparator = char.MinValue;
	//	public const char LeftGenericArgs = '<';
	//	public const char LeftGenericArgsSeparator = char.MinValue;

	//	public const char RightNamespace = '.';
	//	public const char RightClassName = '.';
	//	public const char RightMethodName = char.MinValue;
	//	public const char RightMethodScope = '(';
	//	public const char RightArsSeparator = ',';
	//	public const char RightGenericArgs = '>';
	//	public const char RightGenericArgsSeparator = ',';

	//}





}
