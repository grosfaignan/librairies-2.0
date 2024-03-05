using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkInProgress
{

	public class ExceptionParser 
	{
		private Exception Exception;
		private ExceptionParser InnerEx;
		//public string ExceptionType;


		public FramesList StackTrace {  get; private set; }


		public ExceptionParser(Exception ex)
		{
			this.Exception = ex;
			if (ex.InnerException != null)
			{
				this.InnerEx = new ExceptionParser(ex.InnerException);
			}
			this.StackTrace = new FramesList(ex);
			
		}
		public override string ToString()
		{
			return new StringBuilder()
				.Append(this.Exception.Message)
				.Append(this.Exception.Source)
				.Append(this.Exception.HelpLink)
				.Append(this.Exception.GetType().ToString())
				.Append(this.Exception.HResult)
				.Append(this.StackTrace.ToString())
				.Append(this.Exception.TargetSite)
				.Append(this.Exception)
				.Append(this.Exception.Data.ToString())
				.ToString();
		}
	}
}
