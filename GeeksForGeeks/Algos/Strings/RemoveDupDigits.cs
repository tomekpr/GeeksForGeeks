using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Strings
{
	class RemoveDupDigits
	{
		public static string DeleteDups(string s)
		{
			var sb = new StringBuilder();
			sb.Append(s[0]);
			for (int ri = 1; ri < s.Length; ri++)
			{
				if (s[ri] != s[ri - 1])
					sb.Append(s[ri]);
			}

			return sb.ToString();
		}

		public static string DeleteDups2(string s)
		{
			char[] letters = s.ToCharArray();
			int wi = 1;

			for (int ri = 1; ri < s.Length;)
			{
				if (s[ri] != s[ri - 1])
				{
					letters[wi] = s[ri];
					wi++;
				}

				ri++;
			}

			while (wi < letters.Length)
				letters[wi++] = ' ';

			return new string(letters);
		}
	}

	[TestFixture]
	public class TestRemoveDupDigits
	{
		[Test]
		public void Test1()
		{
			var s = "1299888833";

			var result1 = RemoveDupDigits.DeleteDups(s);
			var result2 = RemoveDupDigits.DeleteDups2(s);

			Equals(result1 == "12983");
			Equals(result2 == "12983");
		}
	}
}
