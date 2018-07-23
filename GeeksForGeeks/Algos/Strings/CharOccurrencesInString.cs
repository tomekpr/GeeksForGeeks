using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class CharOccurrencesInString
	{
		int NumOccur(char a, string s, int pos = 0)
		{
			if(pos < s.Length)
			{
				int total = s[pos] == a ? 1 : 0;
				return total + NumOccur(a, s, pos + 1);
			}

			return 0;
		}

		[Test]
		public void Test1()
		{
			var counter = new CharOccurrencesInString();
			var actual = counter.NumOccur('a', "aba");

			Assert.That(actual, Is.EqualTo(2));
		}

		[Test]
		public void Test2()
		{
			var counter = new CharOccurrencesInString();
			var actual = counter.NumOccur('x', "aba");

			Assert.That(actual, Is.EqualTo(0));
		}

		[Test]
		public void Test3()
		{
			var counter = new CharOccurrencesInString();
			var actual = counter.NumOccur('x', "");

			Assert.That(actual, Is.EqualTo(0));
		}
	}
}
