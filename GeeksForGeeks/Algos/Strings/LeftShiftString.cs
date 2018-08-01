using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeeksForGeeks.Algos.Strings
{
	// https://codesays.com/2014/solution-to-left-rotate-string-from-jobdu/
	class LeftShiftString
	{
		public string LeftShift(string s, int n)
		{
			if (n <= 0) return s;

			var output = new char[s.Length];
			for (int i = 0; i < s.Length; i++)
			{
				int newIndex = i - n;
				if (newIndex < 0)
					newIndex = newIndex + s.Length;

				output[newIndex] = s[i];
			}

			return new string(output);
		}
	}

	[TestFixture]
	public class TestLeftShiftString
	{
		[Test]
		public void Test1()
		{
			var sut = new LeftShiftString();
			var result = sut.LeftShift("abba", 1);

			Assert.That(result == "bbaa");
		}

		[Test]
		public void Test2()
		{
			var sut = new LeftShiftString();
			var result = sut.LeftShift("UDBOJ", 4);

			Assert.That(result == "JUDBO");
		}
	}
}
