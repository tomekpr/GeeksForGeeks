using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Trees
{
	class MaxWidthTree
	{
		public int MaxWidth(BinaryNode node)
		{
			int maxWidth = 0;
			var queue = new Queue<BinaryNode>();
			queue.Enqueue(node);

			while (queue.Any())
			{
				int size = queue.Count;
				maxWidth = Math.Max(maxWidth, size);
				while (size-- > 0)
				{
					var next = queue.Dequeue();

					if (next.Left != null)
						queue.Enqueue(next.Left);

					if (next.Right != null)
						queue.Enqueue(next.Right);
				}
			}

			return maxWidth;
		}
	}

	[TestFixture]
	public class TestMaxWidthTree
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(1);
			root.Left = new BinaryNode(2);
			root.Left.Left = new BinaryNode(4);
			root.Left.Right = new BinaryNode(5);

			root.Right = new BinaryNode(3);
			root.Right.Left = new BinaryNode(7);
			root.Right.Right = new BinaryNode(6);
			root.Right.Left.Left = new BinaryNode(20);

			var sut = new MaxWidthTree();
			var result = sut.MaxWidth(root);

			Assert.That(result == 4);
		}
	}
}
