using NUnit.Framework;
using System;

namespace GeeksForGeeks.Algos.Arrays
{
	class FindSubarrayWithGreatestSum
	{
		public int Find(int[] input)
		{
			int maxSoFar = Int32.MinValue;
			int begin = 0;
			int end = 0;
			int maxEndingHere = 0;
			int maxEndingHereBegin = 0;

			for (int i = 0; i < input.Length; ++i)
			{
				// Find the max sum of any sub-array, which is ending here.
				if (maxEndingHere < 0)
				{
					maxEndingHere = input[i];
					maxEndingHereBegin = i;
				}
				else
				{
					maxEndingHere += input[i];
				}

				// Check whether we need to update the maxSoFar.
				// maxSoFar records the the sub-array with greatest sum globally.
				if (maxEndingHere > maxSoFar)
				{
					maxSoFar = maxEndingHere;
					begin = maxEndingHereBegin;
					end = i;
				}
			}

			Console.WriteLine($"Max so far: {maxSoFar} Begin: {begin} End: {end}");
			return maxSoFar;
		}
	}

	[TestFixture]
	public class TestFindSubarrayWithGreatestSum
	{
		[Test]
		public void Test1()
		{
			var s = new FindSubarrayWithGreatestSum();
			var result = s.Find(new int[] { -1, -3, -2 });

			Assert.That(result == -1);
		}

		[Test]
		public void Test2()
		{
			var s = new FindSubarrayWithGreatestSum();
			var result = s.Find(new int[] { -8, 3, 2, 0, 5 });

			Assert.That(result == 10);
		}

		[Test]
		public void Test3()
		{
			var s = new FindSubarrayWithGreatestSum();
			var result = s.Find(new int[] { 6, -3, -2, 7, -15, 1, 2 ,2 });

			Assert.That(result == 8);
		}
	}
}
