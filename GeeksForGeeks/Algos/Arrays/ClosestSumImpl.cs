using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class ClosestSumImpl
	{
		public int ThreeSum(int[] nums, int t)
		{
			int min = Int32.MaxValue;
			int r = 0;

			for(int i=0; i < nums.Length; i++)
			{
				int j = i + 1;
				int k = nums.Length - 1;

				while(j < k)
				{
					int sum = nums[i] + nums[j] + nums[k];
					int diff = Math.Abs(sum - t);

					if (diff == 0) return sum;
					if(diff < min)
					{
						min = diff;
						r = sum;
					}

					if (sum <= t) j++;
					else k--;
				}
			}

			return r;
		}
	}

	[TestFixture]
	public class ClosestSumImplTests
	{
		[Test]
		public void Test1()
		{
			var set = new int[] { -1, 2, 1, -4 };
			int target = 1;

			var sol = new ClosestSumImpl().ThreeSum(set, target);
			Console.WriteLine(sol);

			Assert.That(sol, Is.EqualTo(-1));
		}
	}
}
