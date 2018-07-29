using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeeksForGeeks.Algos.NumberTheory
{
	// should be n(n+1)/2 but we cannot use any multiplication or division
	//we can't use if else!
	// https://codesays.com/2014/solution-to-accumulate-from-jobdu/
	class SumFromOnetoN
	{
		public int Sum(int n)
		{
			int total = 0;
			SumHelper(n, ref total);
			return total;
		}

		bool SumHelper(int n, ref int total)
		{
			total += n;
			return (n == 1) || SumHelper(n - 1, ref total); // short-circuit evaluation
		}
	}

	[TestFixture]
	public class TestSumFromOnetoN
	{
		[TestCase(3,6)]
		[TestCase(5,15)]
		public void Test1(int n, int target)
		{
			var sut = new SumFromOnetoN();
			var result = sut.Sum(n);

			var expected = (n * (n + 1)) / 2;

			Assert.That(expected == target);
			Assert.That(result == target);
		}
	}
}
