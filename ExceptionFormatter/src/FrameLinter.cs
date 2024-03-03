using System.Reflection;
using System.Text;
using System.Diagnostics;
using Pastel;
using System.Drawing;

namespace ExceptionLinter
{
	public class StackFrameFormater
	{
		public StackFrameInfo SFI { get; set; } = new StackFrameInfo();

		public StackFrameFormater(StackFrame stackFrame)
		{
			if (stackFrame == null)
				throw new ArgumentNullException(nameof(stackFrame));
			MethodBase? method = stackFrame.GetMethod();
			this.SFI.NSpace = new FrameElements((method?.DeclaringType?.Namespace ?? string.Empty).Trim());
			this.SFI.Class = new FrameElements((method?.DeclaringType?.Name ?? string.Empty).Trim());
			this.SFI.Method =new FrameElements((method?.Name ??string.Empty).Trim());
			this.SFI.Path =new FrameElements(Path.GetDirectoryName(stackFrame.GetFileName()).Trim());
			this.SFI.File=new FrameElements(Path.GetFileName(stackFrame.GetFileName()).Trim());
			this.SFI.Line = new FrameElements(stackFrame.GetFileLineNumber().ToString().Trim());
			this.SFI.Arguments =GetMethodArguments(method);
			Colorize();
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(this.SFI.NSpace.ToString());
			sb.Append(this.SFI.Class.ToString());
			sb.Append(this.SFI.Method.ToString());
			sb.Append(this.SFI.ArgumentsToString(this.SFI.Arguments));
			sb.Append(Environment.NewLine);
			sb.Append(this.SFI.Path.ToString());
			sb.Append(this.SFI.File.ToString());
			sb.Append(this.SFI.Line.ToString());
			sb.Append(Environment.NewLine);
				
			return sb.ToString();
		}
		private void Colorize()
		{
			if (!string.IsNullOrEmpty(this.SFI.NSpace.Id))
			{
				this.SFI.NSpace.SetColors(LinterColors.NSpaceClr, LinterColors.FuncDelimClr);
				this.SFI.NSpace.SetDelimiters(char.MinValue, '.');
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
				this.SFI.Path.Id = this.SFI.Path.Id.Replace("\\", "\\".Pastel(LinterColors.FolderDelimClr));
				this.SFI.Path.SetColors(LinterColors.StdClr, LinterColors.FolderDelimClr);
				this.SFI.Path.SetDelimiters(char.MinValue, '\\');
				this.SFI.Path.SetPad(4);
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
					FrameElements key = new FrameElements("",Color.White, '(', Color.Green, char.MinValue, Color.Green, 1, 1);
					FrameElements value = new FrameElements("",Color.White, char.MinValue, Color.Green, ')', Color.Green, 1, 1);
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
		private static Dictionary<FrameElements, FrameElements> GetMethodArguments(MethodBase method)
		{
			Dictionary<FrameElements, FrameElements> arguments = new Dictionary<FrameElements, FrameElements>();

			ParameterInfo[] parameters = method.GetParameters();
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameter = parameters[i];

				FrameElements ArgTypeFormatedData = new FrameElements(parameter?.ParameterType.Name.ToString());
				FrameElements ArgNameFormatedData = new FrameElements(parameter.Name);

				arguments.Add(ArgTypeFormatedData, ArgNameFormatedData);
			}

			return arguments;
		}


	}
	
}
