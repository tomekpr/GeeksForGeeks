using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Matrix
{
	class FindInteger
	{
		public bool HasInteger(int[][] m, int d)
		{
			int row = FindRow(m, d);

			if (row == -1) return false;

			// apply BS algo to find in this row
			int left = 0, right = m.Length - 1;
			while (left < right)
			{
				var mid = (left + right) / 2;
				if (m[row][mid] == d) return true;
				if (d > m[row][mid]) left = mid + 1;
				else right = mid - 1;
			}

			return false;
		}

		int FindRow(int[][] m, int d)
		{
			int bottom = 0, top = m.Length - 1;
			while (bottom < top)
			{
				var row = (bottom + top) / 2;
				if (m[row][0] <= d && d <= m[row][m.Length - 1]) return row;
				if (d < m[row][0]) top = row - 1;
				else bottom = row + 1;
			}

			return -1;
		}
	}

	[TestFixture]
	public class TestHasInteger
	{
		[Test]
		public void Test1()
		{
			int[][] m = new int[3][];
			m[0] = new int[] { 1, 2, 3 };
			m[1] = new int[] { 4, 5, 6 };
			m[2] = new int[] { 7, 8, 9 };

			var sut = new FindInteger();
			var result = sut.HasInteger(m, 5);

			Assert.IsTrue(result);
		}

		[Test]
		public void Test2()
		{
			int[][] m = new int[3][];
			m[0] = new int[] { 2, 3, 4 };
			m[1] = new int[] { 5, 6, 7 };
			m[2] = new int[] { 8, 9, 10 };

			var sut = new FindInteger();
			var result = sut.HasInteger(m, 1);

			Assert.IsFalse(result);
		}

		[Test]
		public void Test3()
		{
			int[][] m = new int[3][];
			m[0] = new int[] { 2, 3, 4 };
			m[1] = new int[] { 5, 6, 7 };
			m[2] = new int[] { 8, 9, 10 };

			var sut = new FindInteger();
			var result = sut.HasInteger(m, 12);

			Assert.IsFalse(result);
		}
	}
}
