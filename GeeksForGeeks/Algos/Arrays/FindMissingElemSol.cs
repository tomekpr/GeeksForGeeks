using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class FindMissingElemSol
	{
		public int Find(int[] A)
		{
			int sum = 0;

			for (int i = 0; i < A.Length; i++)
				sum += A[i];

			int max = A.Length + 1;
			int expected = (max * (max + 1)) / 2;

			return expected - sum;
		}
	}

	[TestFixture]
	public class TestFindMissingElemSol
	{
		[Test]
		public void Test1()
		{
			var sol = new FindMissingElemSol();
			var result = sol.Find(new int[] { 2, 3, 1, 5 });

			Assert.That(result, Is.EqualTo(4));
		}
	}
}
