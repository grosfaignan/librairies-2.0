using System.Reflection;
using System.Text;
using System.Diagnostics;
using Pastel;
using System.Drawing;

namespace ExceptionLinter
{
	public class StackFrameFormater
	{
		private StackFrameInfo SFI { get; set; }

		/// <summary>
		/// instanciate new StackFrameFormater object 
		/// create a private StackFrameInfo structure and format it
		/// </summary>
		/// <param name="stackFrame">a StackFrame Element</param>
		public StackFrameFormater(StackFrame stackFrame)
		{
			this.SFI = new StackFrameInfo(stackFrame);
			Format();
		}

		/// <summary>
		/// convert a StackFrameInfo structure to formated String
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(this.SFI.NSpace.ToString());
			sb.Append(this.SFI.Class.ToString());
			sb.Append(this.SFI.Method.ToString());
			sb.Append(this.SFI.ArgumentsToString());
			sb.Append(Environment.NewLine);
			sb.Append(this.SFI.Path.ToString());
			sb.Append(this.SFI.File.ToString());
			sb.Append(this.SFI.Line.ToString());
			sb.Append(Environment.NewLine);
				
			return sb.ToString();
		}

		/// <summary>
		/// set colors, delimiters and pad for StackFrameInfo element
		/// </summary>
		private void Format()
		{
			if (!string.IsNullOrEmpty(this.SFI.NSpace.Id))
			{
				this.SFI.NSpace.SetColors(LinterColors.NSpaceClr, LinterColors.FuncDelimClr);
				this.SFI.NSpace.SetDelimiters(char.MinValue, '.');
				this.SFI.NSpace.SetPad(12);
			}

			if (!string.IsNullOrEmpty(this.SFI.Class.Id))
			{
				this.SFI.Class.SetColors(LinterColors.ClassNameClr, LinterColors.FuncDelimClr);
				this.SFI.Class.SetDelimiters(char.MinValue, '.');
			}
			if (!string.IsNullOrEmpty(this.SFI.Class.Id))
			{
				this.SFI.Method.SetColors(LinterColors.MethodClr, LinterColors.FuncDelimClr);
			}
			if (!string.IsNullOrEmpty(this.SFI.Path.Id))
			{
				this.SFI.Path.SetId(this.SFI.Path.Id.Replace("\\", "\\".Pastel(LinterColors.FolderDelimClr)));
				this.SFI.Path.SetColors(LinterColors.StdClr, LinterColors.FolderDelimClr);
				this.SFI.Path.SetDelimiters(char.MinValue, '\\');
				this.SFI.Path.SetPad(16);
			}
			if (!string.IsNullOrEmpty(this.SFI.File.Id))
			{
				this.SFI.File.SetColors(LinterColors.FileClr, LinterColors.FuncDelimClr);
				this.SFI.File.SetPad(1, 1);
			}
			if (!string.IsNullOrEmpty(this.SFI.Line.Id))
			{
				this.SFI.Line.SetColors(LinterColors.LNClr, LinterColors.StdClr, LinterColors.Reset);
			}
			if (this.SFI.Arguments != null)
			{
				int i = 0;
				if (this.SFI.Arguments.Count == 0)
				{
					FrameElements key = new FrameElements("",LinterColors.TypeClr, '(',LinterColors.ArgsScopeDelimClr, char.MinValue, LinterColors.ArgsScopeDelimClr, 1, 1);
					FrameElements value = new FrameElements("",LinterColors.ArgsClr, char.MinValue, LinterColors.ArgsScopeDelimClr, ')', LinterColors.ArgsScopeDelimClr, 1, 1);
					this.SFI.Arguments.Add(key, value);
				}
				foreach (var arg in this.SFI.Arguments)
				{
					if( !string.IsNullOrWhiteSpace(arg.Key.Id) || !string.IsNullOrWhiteSpace(arg.Value.Id) )
					{
						if (i == 0)
						{
							arg.Key.SetColors(LinterColors.TypeClr, LinterColors.ArgsScopeDelimClr);
							arg.Key.SetDelimiters('(');
						}
						else
						{
							arg.Key.SetColors(LinterColors.TypeClr, LinterColors.ArgsScopeDelimClr);
							arg.Key.SetDelimiters(' ');
						}
						if (i == this.SFI.Arguments.Count() - 1)
						{
							arg.Value.SetColors(LinterColors.ArgsClr, LinterColors.ArgsScopeDelimClr);
							arg.Value.SetDelimiters(char.MinValue, ')');
						}
						else
						{
							arg.Value.SetDelimiters(char.MinValue, ',');
							arg.Value.SetColors(LinterColors.ArgsClr, LinterColors.StdClr);
						}
						i++;
					}
				}

			}
		}
	}
	
}
