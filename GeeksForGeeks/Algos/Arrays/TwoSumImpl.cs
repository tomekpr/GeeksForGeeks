using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class TwoSumImpl
	{
		public int[] TwoSum(int[] nums, int t)
		{
			var diffToIndex = new Dictionary<int, List<int>>();
			int len = nums.Length;

			for (int i = 0; i < len; i++)
			{
				if (diffToIndex.TryGetValue(nums[i], out var indices))
				{
					var matching = indices.FirstOrDefault(s => s > i);
					if (matching != 0) return new int[] { matching + 1, i + 1 };
				}
				else diffToIndex.Add(t - nums[i], new List<int>(i));
			}

			return new int[] { -1, -1 };
		}
	}

	[TestFixture]
	public class TestTwoSumImpl
	{
		[Test]
		public void Test1()
		{
			var impl = new TwoSumImpl();
			var result = impl.TwoSum(new int[] { 2, 7, 11, 15 }, 9);

			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 2);
		}
	}
}
