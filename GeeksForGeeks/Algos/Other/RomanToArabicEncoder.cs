using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	public class RomanToArabicEncoder
	{
		private readonly IEnumerable<KeyValuePair<int, string>> arabicToRoman = new List<KeyValuePair<int, string>>();

		public RomanToArabicEncoder()
		{
			var map = new SortedList<int, string>();
			map.Add(1, "I");
			map.Add(2, "II");
			map.Add(3, "III");
			map.Add(4, "IV");
			map.Add(5, "V");
			map.Add(9, "IX");
			map.Add(10, "X");
			map.Add(40, "XL");
			map.Add(50, "L");
			map.Add(90, "XC");
			map.Add(100, "C");
			map.Add(400, "CD");
			map.Add(500, "D");
			map.Add(900, "CM");
			map.Add(1000, "M");

			arabicToRoman = map.Reverse();
		}

		public string Encode(int n)
		{
			if (n == 0) return null;
			if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));

			var sb = new StringBuilder();
			while(n > 0)
			{
				foreach(var item in arabicToRoman)
				{
					if(n - item.Key >= 0)
					{
						n = n - item.Key;
						sb.Append(item.Value);

						if (n - item.Key >= 0) break; //repeat the same, else just carry on
					}
				}
			}

			return sb.ToString();
		}
	}

	[TestFixture]
	public class TestRomanToArabicEncoder
	{
		[TestCase(13, "XIII")]
		[TestCase(8, "VIII")]
		[TestCase(569, "DLXIX")]
		[TestCase(1920, "MCMXX")]
		[TestCase(89, "LXXXIX")]
		[TestCase(1935, "MCMXXXV")]
		[TestCase(2020, "MMXX")]
		[TestCase(1983, "MCMLXXXIII")]
		public void Test(int n, string expected)
		{
			var encoder = new RomanToArabicEncoder();
			var result = encoder.Encode(n);

			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
