using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class MaxCountersSol
	{
		public int[] Sol(int N, int[] A)
		{
			var counters = new int[N];
			int max = 0;

			bool resetToMax = false;
			int resetToVal = 0;

			for(int i=0; i < A.Length; i++)
			{
				if(A[i] == N + 1)
				{
					resetToMax = true;
					resetToVal += max;

					counters = Enumerable.Repeat<int>(max, N).ToArray(); // this breaks the O(N+M) constraint unless we consider that O(1) operation...
				}
				else
				{
					var index = A[i] - 1;
					counters[index]++;
					
					max = Math.Max(max, counters[index]);
				}
			}

			if(resetToMax)
			{
				for (int i = 0; i < counters.Length; i++)
					counters[i] = counters[i] + resetToVal- counters[i];
			}

			return counters;
		}
	}

	[TestFixture]
	public class TestMaxCounters
	{
		[Test]
		public void Test1()
		{
			var sol = new MaxCountersSol();
			var result = sol.Sol(5, new int[] { 3, 4, 4, 6, 1, 4,4 });
			var expected = new int[] { 3, 2, 2, 4, 2 };

			Assert.That(result.SequenceEqual(expected), Is.True);
		}
	}
}
