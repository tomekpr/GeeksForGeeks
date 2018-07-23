using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=7opoOv7SVko
	class LargestSubtreeSumInATree
	{
		public int Sum(BinaryNode node)
		{
			int max = Int32.MinValue;
			SumHelper(node, ref max);
			return max;
		}

		int SumHelper(BinaryNode node, ref int max)
		{
			if (node == null) return 0;

			int leftSum = SumHelper(node.Left, ref max);
			int rightSum = SumHelper(node.Right, ref max);

			int currentSum = node.Value + leftSum + rightSum;
			max = Math.Max(max, currentSum);

			return currentSum;
		}
	}

	[TestFixture]
	public class TestLargestSubtreeSumInATree
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(1);
			root.Left = new BinaryNode(2);
			root.Left.Left = new BinaryNode(4);
			root.Left.Right = new BinaryNode(5);

			root.Right = new BinaryNode(3);
			root.Right.Left = new BinaryNode(6);
			root.Right.Right = new BinaryNode(7);

			var largest = new LargestSubtreeSumInATree();

			var sum = largest.Sum(root);
			Assert.That(sum, Is.EqualTo(28));
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNode(1);
			root.Left = new BinaryNode(-2);
			root.Left.Left = new BinaryNode(4);
			root.Left.Right = new BinaryNode(5);

			root.Right = new BinaryNode(3);
			root.Right.Left = new BinaryNode(-6);
			root.Right.Right = new BinaryNode(2);

			var largest = new LargestSubtreeSumInATree();

			var sum = largest.Sum(root);
			Assert.That(sum, Is.EqualTo(7));
		}
	}
}
