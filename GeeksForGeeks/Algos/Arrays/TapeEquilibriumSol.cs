using NUnit.Framework;
using System;

namespace GeeksForGeeks
{
	class TapeEquilibriumSol
	{
		public int Sol(int[] A)
		{
			int l = A[0];
			int r = 0;

			for (int i = 1; i < A.Length; i++)
				r += A[i];

			int diff = Math.Abs(l - r);
			int min = diff;

			for (int i = 2; i < A.Length; i++)
			{
				l = l + A[i - 1];
				r = r - A[i - 1];

				diff = Math.Abs(l - r);
				min = Math.Min(min, diff);
			}

			return min;
		}
	}

	[TestFixture]
	public class TestTapeEquilibriumSol
	{
		TapeEquilibriumSol sol = new TapeEquilibriumSol();

		[Test]
		public void Test1()
		{
			var result = sol.Sol(new int[] { 3, 1, 2, 4, 1 });
			Assert.That(result == 1);
		}

		[Test]
		public void Test2()
		{
			var result = sol.Sol(new int[] { 4 });
			Assert.That(result == 4);
		}

		[Test]
		public void Test3()
		{
			var result = sol.Sol(new int[] { 4,2 });
			Assert.That(result == 2);
		}

		[Test]
		public void Test4()
		{
			var result = sol.Sol(new int[] { 4, -2 });
			Assert.That(result == 6);
		}
	}
}
