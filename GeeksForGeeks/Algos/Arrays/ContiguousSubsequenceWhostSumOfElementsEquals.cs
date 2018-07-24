using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Arrays
{
	// Amortized O(n) cost.
	class ContiguousSubsequenceWhostSumOfElementsEquals
	{
		public bool CaterpillarMethod(int[] a, int s)
		{
			int front = 0, total = 0;
			for(int back = 0; back < a.Length; back++)
			{
				while(front < a.Length && total + a[front] <= s)
				{
					total += a[front];
					front++;
				}

				if (total == s) return true;
				total -= a[back];
			}

			return false;
		}
	}

	[TestFixture]
	public class TestContiguousSubsequenceWhostSumOfElementsEquals
	{
		[Test]
		public void Test1()
		{
			var sut = new ContiguousSubsequenceWhostSumOfElementsEquals();
			var result = sut.CaterpillarMethod(new int[] { 6, 2, 7, 4, 1, 3, 6 }, 12);

			Assert.That(result == true);
		}
	}
}
