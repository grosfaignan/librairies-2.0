using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace System
{
	[TestClass]
	public class LastIndexOfTest
	{
		[TestMethod]
		public void LastIndexOf_True()
		{
			// Arrange
			string input = "abcdeabcde";
			string delimiter = "abc";

			// Act
			int result = input.LastIndexOf(delimiter, true);

			// Assert
			Assert.AreEqual(8, result);
		}
		[TestMethod]
		public void LastIndexOf_False()
		{
			// Arrange
			string input = "abcdeabcde";
			string delimiter = "abc";

			// Act
			int result = input.LastIndexOf(delimiter, false );

			// Assert
			Assert.AreEqual(5, result);
		}
		[TestMethod]
		public void LastIndexOf_TrueFalseComparison()
		{
			// Arrange
			string input = "abcdeabcde";
			string delimiter = "abc";

			// Act
			int resultTrue = input.LastIndexOf(delimiter, true);
			
			//Act 
			int resultFalse = input.LastIndexOf(delimiter, false);

			// Assert
			Assert.AreEqual(resultTrue, resultFalse + delimiter.Length);
		}
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void LastIndexOf_NullString()
		{
			// Arrange
			string input = null;
			string delimiter = "abc";

			// Act
			int result = StringUtilities.LastIndexOf(input, delimiter, true);
		}
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void LastIndexOf_NullString2()
		{
			// Arrange
			string input = null;
			string delimiter = "abc";

			// Act
			int result = input.LastIndexOf(delimiter, true);
		}
	}

	[TestClass]
	public class ExtractTests
	{
		[TestMethod]
		public void Extract_NullString_ThrowsArgumentNullException()
		{
			string? s = null;
			Assert.ThrowsException<ArgumentNullException>(() => s.Extract( 0, 5));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Extract(null, 0, 5));
		}
		[TestMethod]
		public void Extract_EmptyString_ThrowsArgumentNullException()
		{
			string s = string.Empty;
			Assert.ThrowsException<ArgumentNullException>(() => s.Extract(0, 5));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Extract(s, 0, 5));
		}
		[TestMethod]
		public void Extract_NegativeStartIndex_ThrowsIndexOutOfRangeException()
		{
			string s = "Hello, World!";
			Assert.ThrowsException<IndexOutOfRangeException>(() => s.Extract(-1, 5));
			Assert.ThrowsException<IndexOutOfRangeException>(() => StringUtilities.Extract(s, -1, 5));

			Assert.ThrowsException<IndexOutOfRangeException>(() => s.Extract(0, -5));
			Assert.ThrowsException<IndexOutOfRangeException>(() => StringUtilities.Extract(s, 0, -5));

			Assert.ThrowsException<IndexOutOfRangeException>(() => s.Extract(-1, -5));
			Assert.ThrowsException<IndexOutOfRangeException>(() => StringUtilities.Extract(s, -1, -5));

			Assert.ThrowsException<IndexOutOfRangeException>(() => s.Extract(-10, -5));
			Assert.ThrowsException<IndexOutOfRangeException>(() => StringUtilities.Extract(s, -10, -5));

			Assert.ThrowsException<IndexOutOfRangeException>(() => s.Extract(10, 9));
			Assert.ThrowsException<IndexOutOfRangeException>(() => StringUtilities.Extract(s, 10, 9));
		}

		[TestMethod]
		public void Extract_ValidParameters_ReturnsCorrectResult()
		{
			string input = "Hello, World!";
			int startIndex = 7;
			int endIndex = 12;

			string expectedResult = "World";
			string stdResult = StringUtilities.Extract(input, startIndex, endIndex);
			string thisResult = input.Extract( startIndex, endIndex);

			Assert.AreEqual(expectedResult, stdResult);
			Assert.AreEqual(expectedResult, thisResult);
		}

		[TestMethod]
		public void Extract_EquivalentToSubstring()
		{
			string input = "Hello, World!";
			int startIndex = 7;
			int endIndex = 12;

			string expectedSubstring = input.Substring(startIndex, endIndex - startIndex);
			string stdResult = StringUtilities.Extract(input, startIndex, endIndex);
			string thisResult = input.Extract( startIndex, endIndex);

			Assert.AreEqual(expectedSubstring, stdResult);
			Assert.AreEqual(expectedSubstring, thisResult);
		}
	}

	[TestClass]
	public class Substring_lastDelimiter_false_Tests
	{
		[TestMethod]
		public void Substring_LastDelimiterFound_ReturnsSubstring()
		{
			// Arrange
			string input = "Hello, World!";
			string lastDelimiter = ",";

			// Act
			string stdResult = StringUtilities.Substring(input, lastDelimiter);
			string thisResult = input.Substring(lastDelimiter);
			Trace.WriteLine("this = "+thisResult);
			Trace.WriteLine("std = "+stdResult);
			// Assert
			Assert.AreEqual(", World!", stdResult);
			Assert.AreEqual(", World!", thisResult);
			Assert.AreEqual(stdResult, thisResult);
		}

		[TestMethod]
		public void Substring_LastDelimiterNotFound_ReturnsEmptyString()
		{
			// Arrange
			string input = "Hello, World!";
			string lastDelimiter = "XYZ"; // Assuming XYZ is not in the input string

			// Act
			string stdResult = StringUtilities.Substring(input,lastDelimiter);
			string thisResult = input.Substring(lastDelimiter);

			// Assert
			Assert.AreEqual(string.Empty, stdResult);
			Assert.AreEqual(string.Empty, thisResult);
			Assert.AreEqual(stdResult, thisResult);
		}

		[TestMethod]
		public void Substring_NullInput_ThrowsArgumentNullException()
		{
			// Arrange
			string input = null;
			string lastDelimiter = ",";

			// Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(lastDelimiter));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input,lastDelimiter));
		}

		[TestMethod]
		public void Substring_EmptyInput_ReturnsEmptyString()
		{
			// Arrange
			string input = string.Empty;
			string lastDelimiter = ",";

			// Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(lastDelimiter));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input, lastDelimiter));
		}

		[TestMethod]
		public void Substring_NullorEmptyDelimiter_ThrowsArgumentNullException()
		{
			// Arrange
			string input = "Hello, World!";
			string lastDelimiter = null;

			// Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(lastDelimiter));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input, lastDelimiter));

			lastDelimiter = string.Empty;
			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(lastDelimiter));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input, lastDelimiter));
		}
	}
	[TestClass]
	public class Substring_lastDelimiter_true_tests
	{

		[TestMethod]
		public void Substring_LastDelimiterFound_ReturnsSubstring()
		{
			// Arrange
			string input = "Hello, World!";
			string lastDelimiter = ",";

			// Act
			string stdResult = StringUtilities.Substring(input, lastDelimiter, true);
			string thisResult = input.Substring(lastDelimiter, true);
			Trace.WriteLine("this = " + thisResult);
			Trace.WriteLine("std = " + stdResult);
			// Assert
			Assert.AreEqual(" World!", stdResult);
			Assert.AreEqual(" World!", thisResult);
			Assert.AreEqual(stdResult, thisResult);
		}
		[TestMethod]
		public void Substring_EmptyInput_ReturnsEmptyString()
		{
			// Arrange
			string input = string.Empty;
			string lastDelimiter = ",";

			// Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(lastDelimiter,true));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input, lastDelimiter,true));
		}

		[TestMethod]
		public void Substring_NullorEmptyDelimiter_ThrowsArgumentNullException()
		{
			// Arrange
			string input = "Hello, World!";
			string lastDelimiter = null;

			// Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(lastDelimiter, true));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input, lastDelimiter,true));

			lastDelimiter = string.Empty;
			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(lastDelimiter, true));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input, lastDelimiter,true));
		}
	}

	[TestClass]
	public class Substring_openingClosingDelimiter_false_tests
	{
		[TestMethod]
		public void Substring_OpeningClosingDelimiters_ReturnsSubstringInBetween()
		{
			// Arrange
			string input = "Hello, [Beautiful] World!";
			string openingDelimiter = "[";
			string closingDelimiter = "]";

			// Act
			string falseResult = input.Substring(openingDelimiter, closingDelimiter, false);
			string trueResult = input.Substring(openingDelimiter,closingDelimiter, true);

			// Assert
			Assert.AreEqual("[Beautiful]", falseResult);
			Assert.AreEqual("Beautiful", trueResult);

			//-------------------------------------------------
			input = "at mlfqdkjqdmslf Program.Main() in C:\\Users\\HP\\source\\repos\\librairies2\\Console1\\Program.cs:line 11 Hello, [Beautiful] World!";
			openingDelimiter = " in ";
			closingDelimiter = ":line ";

			// Act
			falseResult = input.Substring(openingDelimiter, closingDelimiter, false);
			trueResult = input.Substring(openingDelimiter, closingDelimiter, true);

			// Assert
			Assert.AreEqual(" in C:\\Users\\HP\\source\\repos\\librairies2\\Console1\\Program.cs:line ", falseResult);
			Assert.AreEqual("C:\\Users\\HP\\source\\repos\\librairies2\\Console1\\Program.cs", trueResult);
		}
		public void Substring_NullorEmptyDelimiter_ThrowsIndexOutOfRangeException()
		{
			// Arrange
			// Arrange
			string input = "at mlfqdkjqdmslf Program.Main() in C:\\Users\\HP\\source\\repos\\librairies2\\Console1\\Program.cs:line 11 Hello, [Beautiful] World!";
			string openingDelimiter = "croundave";
			string closingDelimiter = "saumon";

			// Act
			string falseResult = input.Substring(openingDelimiter, closingDelimiter, false);
			string trueResult = input.Substring(openingDelimiter, closingDelimiter, true);

			// Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(openingDelimiter, closingDelimiter, true));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input, openingDelimiter, closingDelimiter, true));

			Assert.ThrowsException<ArgumentNullException>(() => input.Substring(openingDelimiter, closingDelimiter, false));
			Assert.ThrowsException<ArgumentNullException>(() => StringUtilities.Substring(input, openingDelimiter, closingDelimiter, false)) ;
		}
	}

}