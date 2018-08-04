using NUnit.Framework;
using System;
using System.Text;

namespace GeeksForGeeks.Algos.Strings
{
	// Another approach to this is:
	// 1) Reverse whole array
	// 2) Reverse each string
	// "student. a am I" -> "I ma a .tneduts"
	//"I ma a .tneduts" -> "I am a student."
	// https://codesays.com/2014/solution-to-reverse-words-in-sentence-from-jobdu/
	class ReverseWordsInString
	{
		public string ReverseWords(string words)
		{
			var sb = new StringBuilder();
			for (int i = words.Length - 1; i >= 0; i--)
			{
				int j = i;
				while (j >= 0 && Char.IsWhiteSpace(words[j]) == false)
					j--;

				var length = i - j + 1;
				if (j + 1 + length >= words.Length)
					length = length - 1;

				var ss = words.Substring(j + 1, length);
				sb.Append(ss);

				// Keep asking yourself, will this line be always the true? 
				// Previously I didn't have that if condition (similar to this, while loop, line 16)
				if (j + 1 > 0) 
					sb.Append(" ");

				i = j - 1;
			}

			return sb.ToString();
		}
	}

	[TestFixture]
	public class TestReverseWordsInString
	{
		[Test]
		public void Test1()
		{
			var sut = new ReverseWordsInString();
			var result = sut.ReverseWords("student. a am I");

			Assert.That(result == "I am a student.");
		}

		[Test]
		public void Test2()
		{
			var sut = new ReverseWordsInString();
			var result = sut.ReverseWords("I'm a Freshman and I like JOBDU!");

			Assert.That(result == "JOBDU! like I and Freshman a I'm");
		}
	}
}
