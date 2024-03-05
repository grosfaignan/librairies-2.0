//using ExceptionLinter;
using WorkInProgress;
using Croundave.anus;
namespace Croundave;
class Program
{

	static void Main()
	{
		MaClasseGenerique<int> objetEntier = new MaClasseGenerique<int>(42);
		try
		{
			bool resultat1 = objetEntier.EstEgal(42);
		}catch(Exception ex)
		{
			ExceptionParser stack = new ExceptionParser(ex);
			Console.WriteLine(stack.ToString());
		}

	}
}