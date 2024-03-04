using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croundave.anus
{
	public static class ExceptionGenerator
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
	}
}
