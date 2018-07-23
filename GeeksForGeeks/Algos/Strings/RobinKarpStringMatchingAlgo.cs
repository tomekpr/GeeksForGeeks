using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Strings
{
	// Finger print algorithm :)
	// https://www.youtube.com/watch?v=qQ8vS2btsxI
	// O (n-m+1)
	// text -> n
	// pattern -> m
	// https://www.geeksforgeeks.org/searching-for-patterns-set-3-rabin-karp-algorithm/
	class RobinKarpStringMatchingAlgo
	{
		public bool HasPattern(string text, string pattern)
		{
			int expectedCode = GetCode(pattern);
			int testCode = GetCode(text.Substring(0, pattern.Length));

			if (testCode == expectedCode)
			{
				if (CompareStrings(0, text, pattern))
					return true;
			}

			for (int i = pattern.Length; i < text.Length; i++)
			{
				testCode = (testCode + CharToCode(text[i])) - CharToCode(text[i - pattern.Length]);
				if (testCode == expectedCode)
				{
					if (CompareStrings(i - pattern.Length + 1, text, pattern))
						return true;
				}
			}

			return false;
		}

		bool CompareStrings(int start, string text, string pattern)
		{
			for (int i = start, j = 0; j < pattern.Length; i++, j++)
				if (text[i] != pattern[j]) return false;

			return true;
		}

		private int GetCode(string pattern)
		{
			int code = 0;
			for (int i = 0; i < pattern.Length; i++)
				code += CharToCode(pattern[i]);

			return code;
		}

		int CharToCode(char c) => c - 96;// start with 1 not 0
	}

	[TestFixture]
	public class TestRobinKarpStringMatchingAlgo
	{
		[Test]
		public void Test1()
		{
			string text = "aaaaab";
			string pattern = "aab";

			var sut = new RobinKarpStringMatchingAlgo();
			var result = sut.HasPattern(text, pattern);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Test2()
		{
			string text = "abcdabce";
			string pattern = "bce";

			var sut = new RobinKarpStringMatchingAlgo();
			var result = sut.HasPattern(text, pattern);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Test3()
		{
			string text = "abcdabce";
			string pattern = "fce";

			var sut = new RobinKarpStringMatchingAlgo();
			var result = sut.HasPattern(text, pattern);

			Assert.That(result, Is.False);
		}
	}
}
