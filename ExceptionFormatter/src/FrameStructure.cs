using System.Reflection;
using System.Text;
using System.Diagnostics;
using Pastel;
using System.Drawing;
using Microsoft.Diagnostics.Runtime;
using Microsoft.Diagnostics.Runtime.Interfaces;

namespace ExceptionLinter
{
	/// <summary>
	/// parsed stack frame structure
	/// </summary>
	public class StackFrameInfo
	{
		public FrameElements NSpace { get; set; }
		public FrameElements Class { get; set; }
		public FrameElements Method { get; set; }
		public FrameElements Path { get; set; }
		public FrameElements File { get; set; }
		public FrameElements Line { get; set; }
		public Dictionary<FrameElements, FrameElements>? Arguments { get; set; }

		/// <summary>
		/// instanciate StackFrameInfo Element and set StackFrameInfo properties Id 
		/// </summary>
		/// <param name="stackFrame"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public StackFrameInfo(StackFrame stackFrame) 
		{
			if (stackFrame == null)
				throw new ArgumentNullException(nameof(stackFrame));
			MethodBase? method = stackFrame.GetMethod();
			this.NSpace = new FrameElements((method?.DeclaringType?.Namespace ?? string.Empty).Trim());
			this.Class = new FrameElements((method?.DeclaringType?.Name ?? string.Empty).Trim());
			this.Method = new FrameElements((method?.Name ?? string.Empty).Trim());
			this.Path = new FrameElements(System.IO.Path.GetDirectoryName(stackFrame.GetFileName()).Trim());
            this.File = new FrameElements(System.IO.Path.GetFileName(stackFrame.GetFileName()).Trim());
			this.Line = new FrameElements(stackFrame.GetFileLineNumber().ToString().Trim());
			this.Arguments =GetMethodArguments(method);
		}

		/// <summary>
		/// return param types and names for stackFrame method arguments.
		/// </summary>
		/// <param name="method"></param>
		/// <returns></returns>
		private static Dictionary<FrameElements, FrameElements> GetMethodArguments(MethodBase method)
		{
			ParameterInfo[] parameters = method.GetParameters();

			Dictionary<FrameElements, FrameElements> arguments = parameters
				.Select(p =>
				new
				{
					Type = new FrameElements(p.ParameterType.Name),
					Name = new FrameElements(p.Name),
					DefaultValue = p.HasDefaultValue ? new FrameElements(p.DefaultValue.ToString()) : null

				})
				.ToDictionary(p => p.Type, p => p.Name);

			return arguments;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>return argument dictionnary to String</returns>
		public string ArgumentsToString()
		{
			if (this.Arguments != null && this.Arguments.Count>0)
				return string.Join("", values : Arguments.Select(kv => $"{kv.Key.ToString()} {kv.Value.ToString()}"));
			else
				return string.Empty;
		}
	}
	/// <summary>
	/// frame Elements Decoration structure
	/// </summary>
	public class FrameElements
	{
		public string Id { get; private set;  }

		public char openingDelimiter { get; private set; }
		public char closingDelimiter { get; private set; }

		public Color Color { get; set; }
		public Color openingDelimiterColor { get; private set; }
		public Color closingDelimiterColor { get; private set; }

		public int padLeft { get; private set; }
		public int padRight { get; private set; }

		public FrameElements() { }
		/// <summary>
		/// short constructor for quick instanciation with only Id
		/// </summary>
		/// <param name="Id">frame element string</param>
		public FrameElements(string Id)
		{
			this.Id = Id;
		}
		/// <summary>
		/// complete constructor
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="color"></param>
		/// <param name="openingDelimiter"></param>
		/// <param name="openingDelimiterColor"></param>
		/// <param name="closingDelimiter"></param>
		/// <param name="closingDelimiterColor"></param>
		/// <param name="padLeft"></param>
		/// <param name="padRight"></param>
		public FrameElements(string Id, Color color, char openingDelimiter, Color openingDelimiterColor, char closingDelimiter, Color closingDelimiterColor, int padLeft = 0, int padRight = 0)
		{
			this.Id = Id;
			this.Color = color;
			this.openingDelimiter = openingDelimiter;
			this.openingDelimiterColor = openingDelimiterColor;
			this.closingDelimiter = closingDelimiter;
			this.closingDelimiterColor = closingDelimiterColor;
			this.padLeft = padLeft;
			this.padRight = padRight;
		}
		public void SetDelimiters(char openingDelimiter = char.MinValue, char closingDelimiter = char.MinValue)
		{
			this.openingDelimiter = openingDelimiter;
			this.closingDelimiter = closingDelimiter;
		}
		public void SetColors(Color color, Color openingDelimiterColor)
		{
			this.Color = color;
			this.openingDelimiterColor = openingDelimiterColor;
			this.closingDelimiterColor = openingDelimiterColor;
		}
		public void SetColors(Color color, Color openingDelimiterColor, Color closingDelimiterColor)
		{
			this.Color = color;
			this.openingDelimiterColor = openingDelimiterColor;
			this.closingDelimiterColor = closingDelimiterColor;
		}
		public void SetPad(int padLeft = 0, int padRight = 0)
		{
			this.padLeft = padLeft;
			this.padRight = padRight;
		}
		public void SetId(string id)
		{
			this.Id= id;
		}
		
		/// <summary>
		/// Convert frame element data structure to string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(this.openingDelimiter.ToString().Pastel(openingDelimiterColor));
			sb.Append(this.Id.Pastel(this.Color));
			sb.Append(this.closingDelimiter.ToString().Pastel(closingDelimiterColor));
			string s = sb.ToString().PadLeft(sb.Length + padLeft);
			s = s.ToString().PadRight(s.Length + padRight);
			return s;
		}
	}
}
