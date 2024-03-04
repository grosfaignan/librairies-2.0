using ExceptionLinter;
using Croundave.anus;
namespace Croundave;
class Program
{
	

	static void Main()
	{

		try
		{
			ExceptionGenerator.ThrowException();
		}
		catch (Exception ex)
		{
			StackFrameParser stack = new StackFrameParser(ex);
			Console.WriteLine(stack.ToString());
		}

	}
}