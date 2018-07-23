using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class BinGapSol
	{
		public int BinGap(int n)
		{
			int maxGap = 0;
			int currentGap = 0;

			bool split = false;

			for (int i = 0; i <= 31; i++)
			{
				var mask = 1 << i;
				if ((n & mask) != 0)
				{
					if (split)
					{
						maxGap = Math.Max(maxGap, currentGap);
						currentGap = 0;
					}
					else split = true;
				}
				else
				{
					if (split) currentGap++;
				}
			}

			return maxGap;
		}
	}

	[TestFixture]
	public class BinGapSolTests
	{
		[TestCase(9, 2)]
		[TestCase(529, 4)]
		[TestCase(3, 0)]
		[TestCase(1, 0)]
		[TestCase(371, 2)]
		public void Test1(int n, int expected)
		{
			var sol = new BinGapSol();
			var actual = sol.BinGap(n);

			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
