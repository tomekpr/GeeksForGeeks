using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	// https://www.geeksforgeeks.org/minimum-length-subarray-sum-greater-given-value/
	public class SmallestSubarray
	{
		public int? Smallest(int[] arr, int x)
		{
			int min = Int32.MaxValue;
			int left = 0, right = 0;

			int sum = arr[left];

			while (right < arr.Length)
			{
				if(sum > x)
				{
					int len = (right - left) + 1;
					min = Math.Min(min, len);

					sum -= arr[left];
					left++;
				}
				else
				{
					right++;
					if (right >= arr.Length) break;

					sum += arr[right];
				}
			}

			return min == Int32.MaxValue ? default(int?) : min;
		}
	}

	[TestFixture]
	public class TestSmallestSubarray
	{
		[Test]
		public void Test1()
		{
			var ss = new SmallestSubarray();
			int? result = ss.Smallest(new int[] { 1, 4, 45, 6, 0, 19 }, 51);

			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public void Test2()
		{
			var ss = new SmallestSubarray();
			int? result = ss.Smallest(new int[] { 1, 10, 5, 2, 7 }, 9);

			Assert.That(result, Is.EqualTo(1));
		}

		[Test]
		public void Test3()
		{
			var ss = new SmallestSubarray();
			int? result = ss.Smallest(new int[] { 1, 11, 100, 1, 0, 200, 3, 2, 1, 250 }, 280);

			Assert.That(result, Is.EqualTo(4));
		}

		[Test]
		public void Test4()
		{
			var ss = new SmallestSubarray();
			int? result = ss.Smallest(new int[] { 1, 2, 4 }, 8);

			Assert.That(result, Is.Null);
		}
	}
}
