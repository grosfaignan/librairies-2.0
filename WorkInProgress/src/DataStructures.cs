using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Pastel;

namespace WorkInProgress
{

	public class Decoration
	{
		public char Delimiter { get; set; }
		public int Pad {  get; set; }
		public Color DelimiterColor { get; set; }

		public Decoration() { }

		public Decoration(char delimiter, int pad, Color delimiterColor)
		{
			Delimiter = delimiter;
			Pad = pad;
			DelimiterColor = delimiterColor;
		}
		public override string ToString()
		{
			if (!char.IsPunctuation(this.Delimiter))
				return string.Empty;
			return this.Delimiter.ToString().Pastel(DelimiterColor);
		}

		public bool SetDelimiter(char delimiter)
		{
			if (char.IsSeparator(delimiter))
			{
				this.Delimiter = delimiter;
				return true;
			}
			else
				return false;
		}
		public void SetPad(int pad)
		{
			this.Pad = pad;
		}
		public void SetColor(Color color)
		{
			this.DelimiterColor = color;
		}
	}
	public class Left  
	{ 
		public Decoration Decoration { get; set; }
		public Left()
		{
			this.Decoration = new Decoration();
		}
		public Left(char delimiter, int pad, Color delimiterColor)
		{
			this.Decoration = new Decoration(delimiter, pad, delimiterColor);
		}
		public override string ToString()
		{
			return this.Decoration.ToString().PadLeft(this.Decoration.Pad);
		}
	}
	public class Right 
	{
		public Decoration Decoration { get; set; }
		public Right()
		{
			this.Decoration = new Decoration();
		}
		public Right(char delimiter, int pad, Color delimiterColor) 
		{
			this.Decoration = new Decoration(delimiter, pad, delimiterColor);
		}
		public override string ToString()
		{
			return this.Decoration.ToString().PadRight(this.Decoration.Pad);
		}
	}

	public class FrameElement
	{
		public string Name { get; set; }
		public Color Color { set; get; }
		public Left Left { get; set; }
		public Right Right { get; set; }

		public FrameElement() 
		{
			this.Name = string.Empty;
			this.Color = new Color();
			this.Left = new Left();
			this.Right = new Right();
		}
		public FrameElement(string name) 
		{
			this.Name = name;
			this.Color = new Color();
			this.Left = new Left();
			this.Right = new Right();
		}
		public override string ToString()
		{
			return new StringBuilder()
				.Append(this.Left.ToString())
				.Append(this.Name.Pastel(this.Color))
				.Append(this.Right.ToString())
				.ToString();
		}
		public void SetColor(Color color)
		{
			this.Color = color;
		}
	}

	public class MethodArgs
	{
		public FrameElement Type { get; set; }
		public FrameElement Name { get; set; }
		public FrameElement DefaultValue { get; set; }

		public MethodArgs(ParameterInfo param)
		{
			this.Type = new FrameElement(param?.ParameterType.Name??string.Empty);
			this.Name = new FrameElement(param?.Name??string.Empty);
			this.DefaultValue = new FrameElement(param?.DefaultValue?.ToString() ?? string.Empty);
		}
		public override string ToString()
		{
			return new StringBuilder()
				.Append(this.Type.ToString())
				.Append(this.Name.ToString())
				.Append(this.DefaultValue.ToString())
				.ToString();
		}
	}

	public class MethodArgsList
	{
		public List<MethodArgs> List { get; set; }
		public MethodArgsList(MethodInfo method)
		{
			ParameterInfo[] parameters = method.GetParameters();
			this.List = new List<MethodArgs>();

			foreach (ParameterInfo parameter in parameters)
			{
				this.List.Add(new MethodArgs(parameter));
			}
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
            foreach (var item in List)
            {
				sb.Append(List.ToString());
            }
			return sb.ToString();
        }
	}
	public class GenericArgsList
	{
		public List<FrameElement> List { get; set; }
		public GenericArgsList(Type[] ArgArray)
		{
			this.List = new List<FrameElement>();
			foreach (Type type in ArgArray)
			{
				this.List.Append(new FrameElement(type.Name));
			}
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
            foreach (var arg in List)
            {
                sb.Append(arg.ToString());
            }
			return sb.ToString();
        }
	}
	public class Frame
	{
		public FrameElement? Space { get; set; }
		public FrameElement? Class { get; set; }
		public FrameElement MethodeType { get; set; }
		public FrameElement Methode { get; set; }
		public GenericArgsList? GenericArgs { get; set; }
		public MethodArgsList? Arguments { get; set; }
		public FrameElement? Path { get; set; }
		public FrameElement? File { get; set; }
		public FrameElement? Line { get; set; }
		public FrameElement? Column { get; set; }



		public Frame(StackFrame frame)
		{

			MethodInfo? methodInfo = frame.GetMethod() as MethodInfo;
			
			if(methodInfo != null)
			{
				this.Space = new FrameElement(methodInfo.DeclaringType.Namespace);
				this.Class = new FrameElement(name: methodInfo.DeclaringType.Name);
				this.Methode = new FrameElement(name: methodInfo.Name);
				this.MethodeType = new FrameElement(methodInfo.ReturnType.Name);
				this.GenericArgs = new GenericArgsList(methodInfo.GetGenericArguments());
				this.Arguments = new MethodArgsList(methodInfo);
				this.Path = new FrameElement(System.IO.Path.GetDirectoryName(frame.GetFileName()));
				this.File = new FrameElement(System.IO.Path.GetFileName(frame.GetFileName()));
				this.Line = new FrameElement(frame.GetFileLineNumber().ToString());
				this.Column = new FrameElement(frame.GetFileColumnNumber().ToString());

			}
		}
		public Frame(FrameElement? space, FrameElement? @class, FrameElement methode, FrameElement? path, FrameElement? file, FrameElement? line, FrameElement? column)
		{
			Space = space;
			Class = @class;
			Methode = methode;
			Path = path;
			File = file;
			Line = line;
			Column = column;
		}

		public override string ToString()
		{
			return new StringBuilder()
				.Append(this.Space.ToString())
				.Append(this.Class.ToString())
				.Append(this.Methode.ToString())
				.Append(this.GenericArgs.ToString())
				.Append(this.Arguments.ToString())
				.Append(Environment.NewLine)
				.Append(this.Path.ToString())
				.Append(this.File.ToString())
				.Append(this.Line.ToString())
				.Append(this.Column.ToString())
				.ToString();
		}
	}

	public class FramesList
	{
		public StackTrace StackTrace { get; set; }
		public List<Frame> List { get; set;}

		public FramesList(Exception ex)
		{
			this.StackTrace = new StackTrace(ex, true);
			StackFrame[] stackFrames = this.StackTrace.GetFrames();
			this.List = new List<Frame>();
            foreach (StackFrame frame in stackFrames)
            {
				this.List.Add(new Frame(frame));
            }
        }
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
            foreach (var frame in List)
            {
				sb.Append(frame.ToString());
            }
			return sb.ToString();

        }

	}
	
}
