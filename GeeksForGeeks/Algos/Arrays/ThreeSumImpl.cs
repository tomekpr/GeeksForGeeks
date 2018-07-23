using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class ThreeSumImpl
	{
		public List<List<int>> ThreeSum(int[] nums)
		{
			var sol = new List<List<int>>();

			if (nums == null || nums.Length < 3) return sol;

			Array.Sort(nums);
			var len = nums.Length;

			for (int i = 0; i < len - 2; i++)
			{
				if (i == 0 || nums[i] > nums[i - 1])
				{
					int j = i + 1;
					int k = len - 1;

					while (j < k)
					{
						if (nums[i] + nums[j] + nums[k] == 0)
						{
							var res = new List<int>();
							res.Add(nums[i]);
							res.Add(nums[j]);
							res.Add(nums[k]);

							sol.Add(res);

							j++;
							k--;

							// dups
							while (j < k && nums[j] == nums[j - 1])
								j++;

							while (j < k && nums[k] == nums[k + 1])
								k--;
						}
						else if (nums[i] + nums[j] + nums[k] < 0)
						{
							j++;
						}
						else
						{
							k--;
						}
					}
				}
			}

			return sol;
		}
	}

	[TestFixture]
	public class TestThreeSumImpl
	{
		[Test]
		public void Test1()
		{
			var sol = new ThreeSumImpl();
			var r = sol.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });

			foreach (var ss in r)
			{
				Console.WriteLine(String.Join(",", ss));
			}
		}
	}
}
