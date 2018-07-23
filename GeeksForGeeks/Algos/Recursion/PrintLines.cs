using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class PrintLines
	{
		List<string> Print(string[] text)
		{
			var result = new List<string>();
			int currentLine = 0;
			PrintLinesRec(text, currentLine, result);

			return result;
		}

		void PrintLinesRec(string[] text, int currentLine, List<string> result)
		{
			if (currentLine < text.Length)
			{
				result.Add(text[currentLine]);
				PrintLinesRec(text, currentLine + 1, result);
			}
		}

		void PrintLinesRecReverse(string[] text, int currentLine, List<string> result)
		{
			if(currentLine < text.Length)
			{
				PrintLinesRecReverse(text, currentLine + 1, result);
				result.Add(text[currentLine]);
			}
		}

		List<string> PrintInReverseOrder(string[] text)
		{
			var result = new List<string>();
			var currentLine = 0;
			PrintLinesRecReverse(text, currentLine, result);

			return result;
		}

		[Test]
		public void TestRec()
		{
			var text = new string[] { "Tomek", "mieszka", "w", "Londynie" };
			var printLines = new PrintLines();
			var result = printLines.Print(text);

			Assert.That(result.Count, Is.EqualTo(4));
			Assert.That(result.SequenceEqual(new string[] { "Tomek", "mieszka", "w", "Londynie" }));
		}

		[Test]
		public void TestRecReverseOrder()
		{
			var text = new string[] { "Tomek", "mieszka", "w", "Londynie" };
			var printLines = new PrintLines();
			var result = printLines.PrintInReverseOrder(text);

			Assert.That(result.Count, Is.EqualTo(4));
			Assert.That(result.SequenceEqual(new string[] { "Londynie", "w", "mieszka", "Tomek" }));
		}
	}
}
