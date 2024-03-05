using System.Drawing;

namespace ExceptionLinter
{
	/// <summary>
	/// some color collections
	/// </summary>
	public static class LinterColors
	{
		public static Color NSpaceClr { get; set; } = Color.RoyalBlue;
		public static Color ClassNameClr { get; set; } = Color.DeepSkyBlue;
		public static Color MethodClr { get; set; } = Color.Aqua;
		public static Color TypeClr { get; set; } = Color.LimeGreen;
		public static Color StdClr { get; set; } = Color.Gray;
		public static Color FileClr { get; set; } = Color.DeepSkyBlue;
		public static Color LNClr { get; set; } = Color.Violet;
		public static Color ArgsClr { get; set; } = Color.DimGray;
		public static Color FuncDelimClr { get; set; } = Color.White;
		public static Color ArgsScopeDelimClr { get; set; } = Color.MediumVioletRed;
		public static Color ArsDelimClr { get; set; } = Color.MediumVioletRed;
		public static Color FolderDelimClr { get; set; } = Color.MediumVioletRed;
		public static Color Reset { get; set; } = Color.White;
	}
}
