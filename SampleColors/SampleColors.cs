namespace System
{
	public static class Decoration
	{
		public static string Bold = "\u001b[1m";
		public static string Italic = "\u001b[3m";
		public static string Underlined = "\u001b[4m";
		public static string Reset = "\u001b[0m";
	}
	public class ColorsSample
	{
		// Réinitialiser les couleurs par défaut
		public  string Reset = "\x1B[0m";

		// Couleurs de premier plan
		public  string Black = "\x1B[30m";
		public  string Red = "\x1B[31m";
		public  string Green = "\x1B[32m";
		public  string Yellow = "\x1B[33m";
		public  string Blue = "\x1B[34m";
		public  string Magenta = "\x1B[35m";
		public  string Cyan = "\x1B[36m";
		public  string White = "\x1B[37m";

		// Couleurs de premier plan claires
		public  string LightBlack = "\x1B[90m";
		public  string LightRed = "\x1B[91m";
		public  string LightGreen = "\x1B[92m";
		public  string LightYellow = "\x1B[93m";
		public  string LightBlue = "\x1B[94m";
		public  string LightMagenta = "\x1B[95m";
		public  string LightCyan = "\x1B[96m";
		public  string LightWhite = "\x1B[97m";

		// Couleurs de premier plan foncées
		public  string DarkBlack = "\x1B[30;1m";
		public  string DarkRed = "\x1B[31;1m";
		public  string DarkGreen = "\x1B[32;1m";
		public  string DarkYellow = "\x1B[33;1m";
		public  string DarkBlue = "\x1B[34;1m";
		public  string DarkMagenta = "\x1B[35;1m";
		public  string DarkCyan = "\x1B[36;1m";
		public  string DarkWhite = "\x1B[37;1m";

		// Nuances de gris
		public  string Gray0 = "\x1B[30m";
		public  string Gray1 = "\x1B[30;1m";
		public  string Gray2 = "\x1B[90m";
		public  string Gray3 = "\x1B[37m";
		public  string Gray4 = "\x1B[37;1m";
		public  string Gray5 = "\x1B[97m";
	}
	public static class ForegroundColorsSample
	{
		// Réinitialiser les couleurs par défaut
		public static string Reset = "\x1B[0m";

		// Couleurs de premier plan
		public static string Black = "\x1B[30m";
		public static string Red = "\x1B[31m";
		public static string Green = "\x1B[32m";
		public static string Yellow = "\x1B[33m";
		public static string Blue = "\x1B[34m";
		public static string Magenta = "\x1B[35m";
		public static string Cyan = "\x1B[36m";
		public static string White = "\x1B[37m";

		// Couleurs de premier plan claires
		public static string LightBlack = "\x1B[90m";
		public static string LightRed = "\x1B[91m";
		public static string LightGreen = "\x1B[92m";
		public static string LightYellow = "\x1B[93m";
		public static string LightBlue = "\x1B[94m";
		public static string LightMagenta = "\x1B[95m";
		public static string LightCyan = "\x1B[96m";
		public static string LightWhite = "\x1B[97m";

		// Couleurs de premier plan foncées
		public static string DarkBlack = "\x1B[30;1m";
		public static string DarkRed = "\x1B[31;1m";
		public static string DarkGreen = "\x1B[32;1m";
		public static string DarkYellow = "\x1B[33;1m";
		public static string DarkBlue = "\x1B[34;1m";
		public static string DarkMagenta = "\x1B[35;1m";
		public static string DarkCyan = "\x1B[36;1m";
		public static string DarkWhite = "\x1B[37;1m";

		// Nuances de gris
		public static string Gray0 = "\x1B[30m";
		public static string Gray1 = "\x1B[30;1m";
		public static string Gray2 = "\x1B[90m";
		public static string Gray3 = "\x1B[37m";
		public static string Gray4 = "\x1B[37;1m";
		public static string Gray5 = "\x1B[97m";
	}
	public static class BackgroundColorsSample
	{
		// Couleurs d'arrière-plan
		public static string BackgroundBlack = "\x1B[40m";
		public static string BackgroundRed = "\x1B[41m";
		public static string BackgroundGreen = "\x1B[42m";
		public static string BackgroundYellow = "\x1B[43m";
		public static string BackgroundBlue = "\x1B[44m";
		public static string BackgroundMagenta = "\x1B[45m";
		public static string BackgroundCyan = "\x1B[46m";
		public static string BackgroundWhite = "\x1B[47m";

		// Couleurs d'arrière-plan claires
		public static string LightBackgroundBlack = "\x1B[100m";
		public static string LightBackgroundRed = "\x1B[101m";
		public static string LightBackgroundGreen = "\x1B[102m";
		public static string LightBackgroundYellow = "\x1B[103m";
		public static string LightBackgroundBlue = "\x1B[104m";
		public static string LightBackgroundMagenta = "\x1B[105m";
		public static string LightBackgroundCyan = "\x1B[106m";
		public static string LightBackgroundWhite = "\x1B[107m";

		// Couleurs d'arrière-plan foncées
		public static string DarkBackgroundBlack = "\x1B[40;1m";
		public static string DarkBackgroundRed = "\x1B[41;1m";
		public static string DarkBackgroundGreen = "\x1B[42;1m";
		public static string DarkBackgroundYellow = "\x1B[43;1m";
		public static string DarkBackgroundBlue = "\x1B[44;1m";
		public static string DarkBackgroundMagenta = "\x1B[45;1m";
		public static string DarkBackgroundCyan = "\x1B[46;1m";
		public static string DarkBackgroundWhite = "\x1B[47;1m";

	}
}
