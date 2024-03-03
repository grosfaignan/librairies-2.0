//using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
	public static class StringUtilities
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="delimiter"></param>
		/// <param name="includeDelimiterLength"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static int LastIndexOf(this string str, string delimiter, bool includeDelimiterLength)
		{
			if (str == null)
				throw new ArgumentNullException(nameof(str));
			if (delimiter == null)
				throw new ArgumentNullException(nameof(delimiter));
			int delimiterLength = delimiter.Length;
			if (delimiterLength < 0 || delimiterLength > str.Length)
				throw new IndexOutOfRangeException("delimiter can't be empty or longer than string");
			int index = str.LastIndexOf(delimiter);
			if (includeDelimiterLength == true )
				index = index + delimiterLength;
			return index;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="startIndex"></param>
		/// <param name="endIndex"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static string Extract(this string str, int startIndex, int endIndex )
		{
			if(str==null || str==string.Empty)
				throw new ArgumentNullException(nameof(str));
			if (startIndex < 0 || endIndex < 0)
				throw new IndexOutOfRangeException("startIndex or endIndex can't be less than 0");
			if (endIndex <= startIndex)
				throw new IndexOutOfRangeException("endIndex cant be less or equal than startIndex");
			return str.Substring(startIndex, endIndex-startIndex);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="lastDelimiter"></param>
		/// <param name="includeDelimiterLength"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static string Substring(this string str, string lastDelimiter, bool includeDelimiterLength = false)
		{
			if (str == null || str == string.Empty)
				throw new ArgumentNullException(nameof(str));
			if(lastDelimiter == null || lastDelimiter == string.Empty)
				throw new ArgumentNullException(nameof(lastDelimiter));
			int indexOf = str.LastIndexOf(lastDelimiter, includeDelimiterLength);
			if (indexOf < 0)
				return string.Empty;
			return str.Substring(indexOf);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="openingDelimiter"></param>
		/// <param name="closingDelimiter"></param>
		/// <param name="includeDelimiterLength"></param>
		/// <returns></returns>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static string Substring(this string str, string openingDelimiter, string closingDelimiter, bool includeDelimiterLength = false)
		{
			int openingIndex = str.LastIndexOf(openingDelimiter, includeDelimiterLength);
			int closingIndex = str.LastIndexOf(closingDelimiter, !includeDelimiterLength);
			if (openingIndex < 0 || closingIndex < 0)
				throw new IndexOutOfRangeException($"not was able to find {openingDelimiter} or {closingDelimiter} in {str}");
			string temp = str.Extract(openingIndex, closingIndex);
			return temp;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="lastDelimiter"></param>
		/// <returns></returns>
		public static string Remove(this string str, ref string Out, string lastDelimiter, OnOffOn Switch)
		{
			if (str == null)
				throw new ArgumentNullException(nameof(str));
			if (lastDelimiter == null)
				throw new ArgumentNullException(nameof(lastDelimiter));
			if (lastDelimiter == string.Empty)
				return "";
			int lastDelimiterPosition = str.LastIndexOf(lastDelimiter);
			if (lastDelimiterPosition == -1)
			{
				Out = "";
				return str;
			}
			else if (lastDelimiterPosition >= 0)
			{
				if (Switch == OnOffOn.NegativeOn)
				{
					Out = str.Substring(lastDelimiter, false);
					return str.Replace(Out, "");
				}
				else if (Switch == OnOffOn.positiveOn)
				{
					Out = str.Substring(lastDelimiter, true);
					return str.Replace(Out, "");
				}
				else
				{
					Out = str.Substring(lastDelimiter, true);
					return str.Replace(lastDelimiter + Out, "");
				}
			}
			else throw new IndexOutOfRangeException("index of delimiter < -1, unknown Error");
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="lastDelimiter"></param>
		/// <returns></returns>
		public static string Remove(this string str, ref string Out, string openingDelimiter,string closingDelimiter, OnOffOn Switch)
		{
			if (Switch == OnOffOn.NegativeOn)
			{
				Out = str.Substring(openingDelimiter, closingDelimiter, false);
				return str.Replace(Out, "");
			}
			else if (Switch == OnOffOn.positiveOn)
			{
				Out = str.Substring(openingDelimiter, closingDelimiter, true);
				return str.Replace(Out, "");
			}
			else
			{
				Out = str.Substring(openingDelimiter, closingDelimiter, true);
				return str.Replace(openingDelimiter + Out, "");
			}
		}
	}
}
