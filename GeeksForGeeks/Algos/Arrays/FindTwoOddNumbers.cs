using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeeksForGeeks.Algos.Arrays
{
	class FindTwoOddNumbers
	{
		// https://codesays.com/2014/solution-to-numbers-appear-once-from-jobdu/
		public int[] Find(int[] arr)
		{
			Array.Sort(arr);
			int n1 = -1, n2 = -1;

			for (int i = 1; i < arr.Length;)
			{
				if (arr[i - 1] == arr[i])
				{
					i = i + 2 < arr.Length ? i + 2 : i + 1;
				}
				else
				{
					if (n1 == -1) n1 = arr[i - 1];
					else
					{
						if (i == arr.Length - 1)
							n2 = arr[i];
						else n2 = arr[i - 1];
					}

					i++;
				}
			}

			if (n1 < n2) return new int[] { n1, n2 };
			return new int[] { n2, n1 };
		}
	}

	[TestFixture]
	public class TestFindTwoOddNumbers
	{
		[Test]
		public void Test1()
		{
			int[] nums = "2,4,3,6,3,2,5,5".Split(',').Select(Int32.Parse).ToArray();
			var sut = new FindTwoOddNumbers();
			var result = sut.Find(nums);

			Assert.That(result[0] == 4);
			Assert.That(result[1] == 6);
		}

		[Test]
		public void Test2()
		{
			int[] nums = "2,3,3,4,4,5,6,6".Split(',').Select(Int32.Parse).ToArray();
			var sut = new FindTwoOddNumbers();
			var result = sut.Find(nums);

			Assert.That(result[0] == 2);
			Assert.That(result[1] == 5);
		}
	}
}
