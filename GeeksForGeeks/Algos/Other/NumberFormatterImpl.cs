using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class NumberFormatterImpl
	{
		public string Format(int num)
		{
			var result = new StringBuilder();
			int tp = 0;

			while(num > 0)
			{
				if (tp > 0 && tp % 3 == 0)
					result.Append(",");

				// num % 10 can give you 0 (int) if you cast this to char, you will get 4 (or other unknown number)
				// so we have to shift it by 0 to get proper number
				//result.Append((char)(num % 10 + '0'));
				result.Append((char)(num % 10));
				num /= 10;
				tp++;
			}

			var str = result.ToString();
			return new string(str.Reverse().ToArray());
		}
	}

	[TestFixture]
	public class TestNumberFormatterImpl
	{
		[TestCase(1234, "1,234")]
		[TestCase(104450, "104,450")]
		[TestCase(123123123, "123,123,123")]
		public void Test(int num, string expected)
		{
			var impl = new NumberFormatterImpl();
			var actual = impl.Format(num);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void TestCharConversion()
		{
			var num = 2450;

			var resultAsChar = (char)(num % 10);
			Assert.That(resultAsChar, Is.EqualTo('0'));
		}
	}
}
