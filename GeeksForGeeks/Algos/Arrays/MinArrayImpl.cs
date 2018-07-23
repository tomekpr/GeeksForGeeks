using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class MinArrayImpl
	{
		public int FindMin(int[] arr, int s)
		{
			int minLength = Int32.MaxValue;

			for(int i=0; i < arr.Length; i++)
			{
				int currentSum = arr[i];
				for (int j = i + 1; j < arr.Length; j++)
				{
					currentSum += arr[j];
					if (currentSum >= s && ((j - i) + 1 < minLength))
					{
						minLength = (j - i) + 1;
						break;
					}
				}
			}

			return minLength == Int32.MaxValue ? 0 : minLength;
		}
	}

	[TestFixture]
	public class TestMinArrayImpl
	{
		[Test]
		public void Test1()
		{
			int[] arr = new int[] { 2, 3, 1, 2, 4, 3 };
			int minSum = 7;

			var impl = new MinArrayImpl();
			var result = impl.FindMin(arr, minSum);

			Assert.That(result, Is.EqualTo(2));
		}
	}
}
