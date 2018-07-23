using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class TwoSumSortedArray
	{
		public int[] Solve(int[] nums, int t)
		{
			int i = 0;
			int j = nums.Length - 1;

			while(i<j)
			{
				int sum = nums[i] + nums[j];
				if (sum < t) i++;
				else if (sum > t) j--;
				else return new int[] { i + 1, j + 1 };
			}

			return new int[] { -1, -1 };
		}
	}

	[TestFixture]
	public class TestTwoSumSortedArray
	{
		[Test]
		public void Test1()
		{
			var impl = new TwoSumSortedArray();
			var result = impl.Solve(new int[] { 2, 7, 11, 15 }, 9);

			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 2);
		}
	}
}
