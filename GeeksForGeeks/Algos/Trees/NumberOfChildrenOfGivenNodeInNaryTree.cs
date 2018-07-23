using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksForGeeks.AlgoUtils;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=TPTa3cm5YYc
	public class NumberOfChildrenOfGivenNodeInNaryTree
	{
		public int Count(NNode node, int x)
		{
			if (node == null) return -1;
			var q = new Queue<NNode>();
			q.Enqueue(node);

			while (q.Any())
			{
				int size = q.Count;
				while (size > 0)
				{
					var next = q.Dequeue();

					if (next == null) continue;
					if (next.Value == x) return next.ChildNodes.Count();

					foreach (var nn in next.ChildNodes)
						q.Enqueue(nn);
				}
			}

			return -1;
		}
	}

	[TestFixture]
	public class TestNumberOfChildrenOfGivenNodeInNaryTree
	{
		[Test]
		public void Test1()
		{
			// root
			var root = new NNode(20);

			var twentyFive = new NNode(25);
			var fifty = new NNode(50);

			var twenty = new NNode(20);
			twenty.Add(twentyFive, fifty);

			var fifteen = new NNode(15);

			var two = new NNode(2);
			two.Add(fifteen, twenty);
			root.Add(two);

			var thirty = new NNode(30);

			var thirtyFour = new NNode(34);
			thirtyFour.Add(thirty);
			root.Add(thirtyFour);

			// 50 -> 40, 100, 20
			var fifty2 = new NNode(50);
			fifty2.Add(40, 100, 20);

			root.Add(fifty2);
			root.Add(new NNode(60));
			root.Add(new NNode(70));

			var sut = new NumberOfChildrenOfGivenNodeInNaryTree();
			var count = sut.Count(root, 50);

			Assert.That(count, Is.EqualTo(3));
		}

		// NNode builder with hashmap?!
		[Test, Ignore("To be completed")] 
		public void Test2()
		{
			int level = 1;
			// root
			var root = new NNode(20);
			root.AddChildren(20, new int[] { 2, 34, 50, 60, 70 }, level);

			// level 2
			level++;

			root.AddChildren(2, new int[] { 15, 20 }, level);
			root.AddChildren(34, new int[] { 30 }, level);
			root.AddChildren(50, new int[] { 40, 100, 20 }, level);
			root.AddChildren(60, new int[] { }, level);
			root.AddChildren(70, new int[] { }, level);

			// level 3
			level++;
			root.AddChildren(20, new int[] { 25, 50 }, level);

			var sut = new NumberOfChildrenOfGivenNodeInNaryTree();
			var count = sut.Count(root, 50);

			Assert.That(count, Is.EqualTo(3));
		}
	}
}
