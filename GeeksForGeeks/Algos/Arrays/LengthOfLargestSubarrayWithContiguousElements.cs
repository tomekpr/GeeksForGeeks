using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	// https://www.geeksforgeeks.org/length-largest-subarray-contiguous-elements-set-1/
	class LengthOfLargestSubarrayWithContiguousElements
	{
		public int FindLength(int[] arr)
		{
			int n = arr.Length;

			int max_len = 1; // Initialize result
			for (int i = 0; i < n - 1; i++)
			{
				// Initialize min and max for all 
				// subarrays starting with i
				int mn = arr[i], mx = arr[i];

				// Consider all subarrays starting 
				// with i and ending with j
				for (int j = i + 1; j < n; j++)
				{
					// Update min and max in this
					// subarray if needed
					mn = Math.Min(mn, arr[j]);
					mx = Math.Max(mx, arr[j]);

					// If current subarray has all
					// contiguous elements
					if ((mx - mn) == j - i)
						max_len = Math.Max(max_len,
									  mx - mn + 1);
				}
			}
			return max_len; // Return result
		}
	}

	[TestFixture]
	public class TestLengthOfLargestSubarrayWithContiguousElements
	{
		[Test]
		public void Test1()
		{
			var len = new LengthOfLargestSubarrayWithContiguousElements();
			var result = len.FindLength(new int[] { 10, 12, 11 });

			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public void Test2()
		{
			var len = new LengthOfLargestSubarrayWithContiguousElements();
			var result = len.FindLength(new int[] { 14, 12, 11, 20 });

			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		public void Test3()
		{
			var len = new LengthOfLargestSubarrayWithContiguousElements();
			var result = len.FindLength(new int[] { 1, 56, 58, 57, 90, 92, 94, 93, 91, 45 });

			Assert.That(result, Is.EqualTo(5));
		}

		[Test]
		public void Test4()
		{
			var len = new LengthOfLargestSubarrayWithContiguousElements();
			var result = len.FindLength(new int[] { 13,0,11,12 });

			Assert.That(result, Is.EqualTo(2));
		}
	}
}
