using Pastel;
using System.Drawing;
using System.Text;

namespace ExceptionLinter
{
	public class StackFrameInfo
	{
		public FrameElements NSpace { get; set; }
		public FrameElements Class { get; set; }
		public FrameElements Method { get; set; }
		public FrameElements Path { get; set; }
		public FrameElements File { get; set; }
		public FrameElements Line { get; set; }
		public Dictionary<FrameElements, FrameElements>? Arguments { get; set; }

		public string ArgumentsToString(Dictionary<FrameElements, FrameElements> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException(nameof(dictionary));
			}

			return string.Join("", dictionary.Select(kv => $"{kv.Key.ToString()} {kv.Value.ToString()}"));

		}
	}
	public class FrameElements
	{
		public string Id { get; set; }

		public char openingDelimiter { get; set; }
		public char closingDelimiter { get; set; }

		public Color Color { get; set; }
		public Color openingDelimiterColor { get; set; }
		public Color closingDelimiterColor { get; set; }

		public int padLeft { get; set; }
		public int padRight { get; set; }

		public FrameElements(string Id)
		{
			this.Id = Id;
		}

		public FrameElements(string Id, Color color, char openingDelimiter, Color openingDelimiterColor, char closingDelimiter, Color closingDelimiterColor, int padLeft = 0, int padRight = 0)
		{
			this.Id = Id;
			this.Color = color;
			this.openingDelimiter = openingDelimiter;
			this.openingDelimiterColor = openingDelimiterColor;
			this.closingDelimiter = closingDelimiter;
			this.closingDelimiterColor = closingDelimiterColor;
			this.padLeft = padLeft;
			this.padRight = padRight;
		}
		public void SetDelimiters(char openingDelimiter = char.MinValue, char closingDelimiter = char.MinValue)
		{
			this.openingDelimiter = openingDelimiter;
			this.closingDelimiter = closingDelimiter;
		}
		public void SetColors(Color color, Color openingDelimiterColor)
		{
			this.Color = color;
			this.openingDelimiterColor = openingDelimiterColor;
			this.closingDelimiterColor = openingDelimiterColor;
		}
		public void SetColors(Color color, Color openingDelimiterColor, Color closingDelimiterColor)
		{
			this.Color = color;
			this.openingDelimiterColor = openingDelimiterColor;
			this.closingDelimiterColor = closingDelimiterColor;
		}
		public void SetPad(int padLeft = 0, int padRight = 0)
		{
			this.padLeft = padLeft;
			this.padRight = padRight;

		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(this.openingDelimiter.ToString().Pastel(openingDelimiterColor));
			sb.Append(this.Id.Pastel(this.Color));
			sb.Append(this.closingDelimiter.ToString().Pastel(closingDelimiterColor));
			string s = sb.ToString().PadLeft(sb.Length + padLeft);
			s = s.ToString().PadRight(s.Length + padRight);
			return s;
		}
	}
}
