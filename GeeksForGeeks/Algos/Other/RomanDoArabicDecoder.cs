using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks
{
	class RomanToArabicDecoder
	{
		readonly Dictionary<string, int> romanToArabic = new Dictionary<string, int>();
		public RomanToArabicDecoder()
		{
			romanToArabic.Add("I", 1);
			romanToArabic.Add("V", 5);
			romanToArabic.Add("X", 10);
			romanToArabic.Add("L", 50);
			romanToArabic.Add("C", 100);
			romanToArabic.Add("D", 500);
			romanToArabic.Add("M", 1000);
		}

		public int Decode(string n)
		{
			var tmp = n.Reverse();
			int prev = 0;
			int sum = 0;

			foreach(var c in tmp)
			{
				int val = romanToArabic[c.ToString()];
				if (val >= prev) sum += val;
				else sum -= val;

				prev = val;
			}

			return sum;
		}
	}

	[TestFixture]
	public class TestRomanToArabicDecoder
	{
		[TestCase("XIX",19)]
		[TestCase("MCMLXXXIII", 1983)]
		[TestCase("XIII", 13)]
		[TestCase("VIII", 8)]
		[TestCase("DLXIX", 569)]
		[TestCase("MCMXX", 1920)]
		[TestCase("LXXXIX", 89)]
		[TestCase("MCMXXXV", 1935)]
		[TestCase("MMXX", 2020)]
		[TestCase("MCMLXXXIII", 1983)]
		public void Test(string roman, int exp)
		{
			var dec = new RomanToArabicDecoder();
			var result = dec.Decode(roman);

			Assert.That(result, Is.EqualTo(exp));
		}
	}
}
