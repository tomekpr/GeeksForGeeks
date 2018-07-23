using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class CountSort
	{
		public void Sort(int[] nums)
		{
			var index = new int[nums.Length + 1];
			foreach (var n in nums)
				index[n]++;

			int j = 0;
			for(int i=0; i < index.Length; i++)
			{
				while(index[i] > 0)
				{
					nums[j] = i;
					j++;
					index[i]--;
				}
			}
		}
	}

	[TestFixture]
	public class TestCountSort
	{
		[Test]
		public void Test1()
		{
			var nums = new int[] { 4, 3, 5, 12, 8, 7, 1, 4, 2, 4, 0, 5 };
			var exp = new int[] { 0, 1, 2, 3, 4, 4, 4, 5, 5, 7, 8, 12 };

			var cs = new CountSort();
			cs.Sort(nums);

			Assert.That(nums.SequenceEqual(exp), Is.True);
		}
	}
}
