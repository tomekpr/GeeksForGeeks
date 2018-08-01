using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Arrays
{
	class TwoNumbersWithSum
	{
		// https://codesays.com/2014/solution-to-two-numbers-with-sum-from-jobdu/
		// variant of http://en.wikipedia.org/wiki/3SUM
		public int[] TwoNumbers(int[] arr, int target)
		{
			var index = new HashSet<int>();
			foreach (var n in arr)
			{
				if (!index.Contains(n)) index.Add(n);
			}

			int minA = 0, minB = 0, minProduct = 0;
			foreach (var n in arr)
			{
				if (index.Contains(target - n))
				{
					index.TryGetValue(target - n, out var k);

					if (minProduct == 0)
					{
						minA = n;
						minB = k;
					}
					else
					{
						if (n * k < minProduct)
						{
							minProduct = n * k;
							minA = n;
							minB = k;
						}
					}
				}
			}

			return new int[] { minA, minB };
		}
	}

	[TestFixture]
	public class TestTwoNumbersWithSum
	{
		[Test]
		public void Test1()
		{
			var sut = new TwoNumbersWithSum();
			var result = sut.TwoNumbers(new int[] { 1, 2, 4, 7, 8, 11, 15 }, 15);

			Assert.That(result.Any(x => x == 4));
			Assert.That(result.Any(x => x == 11));
		}
	}
}
