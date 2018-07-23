using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Recursion
{
	class TowerOfHonoi
	{
		public void Move(int n, List<int> a, List<int> b, List<int> c)
		{
			if (n > 0)
			{
				// Move from a to b using c
				// After that. C is free to accept largest element, because
				// everything is waiting on rod b.
				Move(n - 1, a, c, b);

				// Move from a to c
				var last = a.Last();
				a.RemoveAt(a.Count - 1);

				c.Add(last);

				// b is still a mess, we can't touch C because that's our final
				// result in correct order so what's left ? move from b to c (final destination) using a (the only available rod)

				// Move from b to c using a
				Move(n - 1, b, a, c);
			}
		}
	}

	[TestFixture]
	public class TestTowerOfHanoi
	{
		[Test]
		public void Test()
		{
			var a = new List<int> { 3, 2, 1 };
			var b = new List<int> { };
			var c = new List<int> { };

			var exp = new List<int> { 3, 2, 1 };

			var toh = new TowerOfHonoi();
			toh.Move(a.Count, a, b, c);

			bool areListsEqual = c.SequenceEqual(exp);
			Assert.That(areListsEqual, Is.True);

			Assert.That(a.Count, Is.EqualTo(0));
			Assert.That(b.Count, Is.EqualTo(0));
		}

		[Test]
		public void Test2()
		{
			var a = new List<int> { 5, 4, 3, 2, 1 };
			var b = new List<int> { };
			var c = new List<int> { };

			var exp = new List<int> { 5,4,3, 2, 1 };

			var toh = new TowerOfHonoi();
			toh.Move(a.Count, a, b, c);

			bool areListsEqual = c.SequenceEqual(exp);
			Assert.That(areListsEqual, Is.True);

			Assert.That(a.Count, Is.EqualTo(0));
			Assert.That(b.Count, Is.EqualTo(0));
		}
	}
}
