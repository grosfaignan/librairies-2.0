using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public class StackFrame
	{
		public string NameSpace { get; set; } = "";
		public string ClassName { get; set; } = "";
		public string MethodName { get; set; } = "";
		public string FilePath { get; set; } = "";
		public string FileName { get; set; } = "";
		public string LineNumber { get; set; } = "";
		public Dictionary<string, string> Arguments { get; set; }

		public string RemoveAndGet(ref string frame, string delimitor)
		{
			int delimitorIndex = frame.LastIndexOf(delimitor);
			int delimitorLength = delimitor.Length;

			if (delimitorIndex != -1)
			{
				string removedSubstring = frame.Substring(delimitorIndex + delimitorLength);
				frame = frame.Remove(delimitorIndex);
				return removedSubstring;
			}
			else
			{
				return string.Empty;
			}
		}
		public string RemoveAndGet(ref string frame, string startDelimitor, string endDelimitor)
		{
			int startDelimitorIndex = frame.LastIndexOf(startDelimitor);
			int startDelimitorLength = startDelimitor.Length;
			int endDelimitorIndex = frame.LastIndexOf(endDelimitor);
			int endDelimitorLength = endDelimitor.Length;
			Console.WriteLine("startI =" + startDelimitorIndex);
			Console.WriteLine("endI = " + endDelimitorIndex);
			if (startDelimitorIndex != -1 && endDelimitorIndex != -1 && (endDelimitorIndex - startDelimitorIndex) > 2)
			{
				Console.WriteLine(true);
				string removedSubstring = frame.Substring(startDelimitorIndex + startDelimitorLength, endDelimitorIndex - (endDelimitorLength + startDelimitorIndex));
				frame = frame.Remove(startDelimitorIndex);
				return removedSubstring;
			}
			else
			{
				return string.Empty;
			}
		}
	}
}
