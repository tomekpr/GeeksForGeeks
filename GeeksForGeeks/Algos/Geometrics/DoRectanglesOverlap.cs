using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Geometrics
{
	class Point
	{
		public int X, Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"[{X},{Y}]";
		}
	}

	// https://www.youtube.com/watch?v=wx0nyomRS_U
	// or check every point from r1 whether it falls into the r2 area.
	class DoRectanglesOverlap
	{
		public bool DoOverlap(Point l1, Point r1, Point l2, Point r2)
		{
			if (l2.X > r1.X || l1.X > r2.X)
				return false;

			if (l2.Y < r1.Y || l1.Y < r2.Y)
				return false;

			return true;
		}
	}

	[TestFixture]
	public class TestDoRectanglesOverlap
	{
		[Test]
		public void Test1()
		{
			var l1 = new Point(10, 10);
			var r1 = new Point(20, 20);

			var l2 = new Point(30, 30);
			var r2 = new Point(40, 40);

			var sut = new DoRectanglesOverlap();
			var result = sut.DoOverlap(l1,r1,l2,r2);

			Assert.That(result, Is.False);
		}
	}
}
