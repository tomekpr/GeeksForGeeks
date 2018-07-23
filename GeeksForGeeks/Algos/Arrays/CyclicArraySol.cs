using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class CyclicArraySol
	{
		public int[] Rotate(int[] A, int k)
		{
			int rotations = k;
			if (k >= A.Length && A.Length > 0)
			{
				rotations = (int)Math.Ceiling((double)k / A.Length);
			}

			var j = 0;
			while (j < k)
			{
				var last = A[A.Length - 1];
				for (var i = A.Length - 1; i > 0; i--)
					A[i] = A[i - 1];

				A[0] = last;
				j++;
			}

			return A;
		}
	}

	[TestFixture]
	public class TestCyclicArray
	{
		[Test]
		public void Test1()
		{
			int[] A = new int[] { 3, 8, 9, 7, 6 };
			int k = 3;

			int[] exp = new int[] { 9, 7, 6, 3, 8 };

			var sol = new CyclicArraySol();
			int[] act = sol.Rotate(A, k);

			Assert.That(act.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test2()
		{
			int[] A = new int[] { 3, 8, 9, 7, 6 };
			int k = 0;

			int[] exp = new int[] { 3, 8, 9, 7, 6 };

			var sol = new CyclicArraySol();
			int[] act = sol.Rotate(A, k);

			Assert.That(act.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test3()
		{
			int[] A = new int[] { 0, 0, 0 };
			int k = 3;

			int[] exp = new int[] { 0, 0, 0 };

			var sol = new CyclicArraySol();
			int[] act = sol.Rotate(A, k);

			Assert.That(act.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test6()
		{
			int[] A = new int[] { 3, 8, 9, 7, 6 };
			int k = 6;

			int[] exp = new int[] { 6, 3, 8, 9, 7 };

			var sol = new CyclicArraySol();
			int[] act = sol.Rotate(A, k);

			Assert.That(act.SequenceEqual(exp), Is.True);
		}
	}
}
