using NUnit.Framework;
using System;

namespace GeeksForGeeks.Algos.Strings
{
	// https://www.youtube.com/watch?v=cXf7NKgT13s
	class AtoInt
	{
		public int atoi(string s)
		{
			int result = 0;
			int digit = 0;

			bool isNeg = s[0] == '-';
			if (isNeg)
				s = s.Substring(1);

			atoihelper(s, digit, s.Length - 1, ref result);
			return isNeg ? -result : result;
		}

		void atoihelper(string s, int i, int len, ref int result)
		{
			if (len >= 0)
			{
				if (!Char.IsDigit(s[i]))
					throw new ArgumentException(nameof(s));

				int mul = (int)Math.Pow(10, len);
				result += (Int32.Parse(s[i].ToString()) * mul);
				atoihelper(s, i + 1, len - 1, ref result);
			}
		}
	}

	[TestFixture]
	public class TestAToInt
	{
		[Test]
		public void Test1()
		{
			var result = new AtoInt().atoi("456");
			Assert.That(result, Is.EqualTo(456));
		}

		[Test]
		public void Test2()
		{
			var result = new AtoInt().atoi("5");
			Assert.That(result, Is.EqualTo(5));
		}

		[Test]
		public void Test3()
		{
			var result = new AtoInt().atoi("0");
			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		public void Test4()
		{
			var result = new AtoInt().atoi("-50");
			Assert.That(result, Is.EqualTo(-50));
		}

		[Test]
		public void Test5()
		{
			Assert.Throws<ArgumentException>(() => new AtoInt().atoi("-5A0"));
		}
	}
}
