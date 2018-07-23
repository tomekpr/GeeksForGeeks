using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=jC36sjf3PCo
	// Version2: USE PROPERTY OF BST !!!!
	class FindClosestElementInTree
	{
		public int FindClosestElement(BinaryNode node, int x)
		{
			int closest = Int32.MaxValue;
			FindClosest(node, x, ref closest);
			return closest;
		}

		void FindClosest(BinaryNode node, int x, ref int closest)
		{
			if (node == null) return;
			FindClosest(node.Left, x, ref closest);

			int minDiff = (int)Math.Abs(x - closest);
			int currentDiff = (int)Math.Abs(x - node.Value);

			if (currentDiff < minDiff) closest = node.Value;

			FindClosest(node.Right, x, ref closest);
		}
	}

	[TestFixture]
	public class TestFindClosestElementInTree
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(9);
			root.Left = new BinaryNode(4);
			root.Left.Left = new BinaryNode(3);
			root.Left.Right = new BinaryNode(6);

			root.Right = new BinaryNode(17);
			root.Right.Right = new BinaryNode(22);

			var findClosest = new FindClosestElementInTree();
			var closest = findClosest.FindClosestElement(root, 4);
			Assert.That(closest, Is.EqualTo(4));

			closest = findClosest.FindClosestElement(root, 18);
			Assert.That(closest == 17);

			closest = findClosest.FindClosestElement(root, 12);
			Assert.That(closest == 9);
		}
	}
}
