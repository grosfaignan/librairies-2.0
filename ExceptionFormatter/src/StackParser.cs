using System.Diagnostics;
using System.Text;
namespace ExceptionLinter
{
	public class StackFrameParser
	{
		public List<StackFrameFormater> StackFrameInfoList { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ex"></param>
		public StackFrameParser(Exception ex)
		{
			this.StackFrameInfoList = StackTraceToList(ex);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ex"></param>
		/// <returns>parse some stackTrace from any exception and return a list of linted and parsed stackTrace</returns>
		public List<StackFrameFormater> StackTraceToList(Exception ex)
		{
			StackTrace stackTrace = new StackTrace(ex, true);
			StackFrame[] stackFrames = stackTrace.GetFrames();
			var stackFrameInfoList = new List<StackFrameFormater>();

			for (int i = 0; i < stackFrames.Length; i++)
			{
				StackFrame stackFrame = stackFrames[i];
				StackFrameFormater stackFrameInfo = new StackFrameFormater(stackFrame);
				stackFrameInfoList.Add(stackFrameInfo);
			}
			return stackFrameInfoList;
		}
		/// <summary>
		/// return linted full stack string
		/// </summary>
		/// <returns>string</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in StackFrameInfoList)
			{
				sb.Append(item.ToString());
			}
			return sb.ToString();
		}
	}
}
