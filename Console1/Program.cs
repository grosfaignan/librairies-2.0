using ExceptionLinter;

namespace Croundave.Anus;
class Program
{
	public static void ThrowExceptionRecursively(int depth, string s)
	{
		if (depth > 0)
		{
			ThrowExceptionRecursively(depth - 1, s);
		}
		else
		{
			throw new Exception("Une exception s'est produite");
		}
	}

	public static void ThrowException()
	{
		ThrowExceptionRecursively(10, "");
	}

	static void Main()
	{
		//// Get the list of available colors
		//// that can be changed
		//ConsoleColor[] consoleColors
		//	= (ConsoleColor[])ConsoleColor
		//		  .GetValues(typeof(ConsoleColor));

		//// Display the list
		//// of available console colors
		//Console.WriteLine("List of available "
		//				  + "Console Colors:");
		//foreach (var color in consoleColors)
		//	Console.WriteLine(color);

		//for (char c = (char)169; c <= (char)218; ++c)
		//{
		//	Console.WriteLine(c);
		//}

		try
		{
			ThrowException();
		}
		catch (Exception ex)
		{
			StackFrameParser stack = new StackFrameParser(ex);
			Console.WriteLine(stack.ToString());
			//StackTrace ex1 = new StackTrace(true);
			//string s = "";
			//Console.WriteLine(ex.StackTrace.ToString());
			//Console.WriteLine(ex.StackTrace.LastIndexOf(" at P",true));
			//Console.WriteLine(ex.StackTrace.LastIndexOf(" at ",false));
			//Console.WriteLine(ex.StackTrace.Remove(ref s, " in ",":line ",OnOffOn.NegativeOn));
			//Console.WriteLine(s);

			//StackFrameParser trace = new StackFrameParser(ex);
			//        foreach (var item in trace.StackFrameInfoList)
			//        {
			//Console.WriteLine(item.NameSpace);
			//Console.WriteLine(item.ClassName);
			//Console.WriteLine(item.MethodName);
			//Console.WriteLine(item.FilePath);
			//Console.WriteLine(item.FileName);
			//Console.WriteLine(item.LineNumber);

			//Console.WriteLine(item.ToString());
			//        }
			//string t =trace.ToString();
			//Console.WriteLine(t);
			//Console.WriteLine(ex1.ToString());
			//Console.WriteLine(frame.ToString());
			//Console.WriteLine(frame2.ToString());
			//Console.WriteLine(trace.ToString());
		}

	}
}