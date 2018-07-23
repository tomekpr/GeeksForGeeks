using NUnit.Framework;

namespace GeeksForGeeks
{
	class OddOccurrencesInArraySol
	{
		public int Find(int[] A)
		{
			var c = A[0];
			for (int i = 1; i < A.Length; i++)
				c = c ^ A[i];

			return c;
		}
	}

	[TestFixture]
	public class TestOddOccurrencesInArraySol
	{
		[Test]
		public void Test1()
		{
			var sol = new OddOccurrencesInArraySol();
			var n = sol.Find(new int[] { 4, 3, 4 });

			Assert.That(n, Is.EqualTo(3));
		}

		[Test]
		public void Test2()
		{
			var sol = new OddOccurrencesInArraySol();
			var n = sol.Find(new int[] { 9, 3, 9, 3, 9, 7, 9 });

			Assert.That(n, Is.EqualTo(7));
		}
	}
}
