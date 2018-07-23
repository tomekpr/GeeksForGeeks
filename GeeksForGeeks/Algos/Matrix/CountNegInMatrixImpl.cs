using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class CountNegInMatrixImpl
	{
		public int CountNeg(int[][] m)
		{
			int count = 0;
			int j = m.Length - 1;
			int i = 0;

			while(j >= 0 && i < m.Length)
			{
				if(m[i][j] < 0)
				{
					count += (j + 1);
					i += 1;
				}
				else
				{
					j -= 1;
				}
			}

			return count;
		}
	}

	[TestFixture]
	public class TestCountNegInMatrixImpl
	{
		[Test]
		public void Test1()
		{
			int[][] m = new int[4][];
			m[0] = new int[] { -3, -2, -1, 1 };
			m[1] = new int[] { -2, 2, 3, 4 };
			m[2] = new int[] { 4, 5, 7, 8 };

			var impl = new CountNegInMatrixImpl();
			var count = impl.CountNeg(m);

			Assert.That(count, Is.EqualTo(4));
		}
	}
}
