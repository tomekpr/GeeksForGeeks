using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Strings
{
	class NumberOfFlipsRequired
	{
		public int CountFlips(string s)
		{
			if (string.IsNullOrEmpty(s)) return 0;

			int startWithZero = 0;
			int startWithOne = 0;

			for(int i=0; i < s.Length; i++)
			{
				char exp = (i % 2 == 0) ? '0' : '1';
				if (s[i] == exp) startWithOne++;
				else startWithZero++;
			}

			return Math.Min(startWithOne, startWithZero);
		}
	}

	[TestFixture]
	public class TestNumberOfFlipsRequired
	{
		[Test]
		public void Test1()
		{
			var n = new NumberOfFlipsRequired();
			int count = n.CountFlips("001");

			Assert.That(count, Is.EqualTo(1));
		}

		[Test]
		public void Test2()
		{
			var n = new NumberOfFlipsRequired();
			int count = n.CountFlips("0001010111");

			Assert.That(count, Is.EqualTo(2));
		}
	}
}
