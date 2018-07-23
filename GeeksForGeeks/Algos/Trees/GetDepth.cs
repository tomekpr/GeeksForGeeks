using NUnit.Framework;
using System;

namespace GeeksForGeeks
{
	[TestFixture]
	class GetDepthImpl
	{
		int GetDepth(BinaryNode node)
		{
			if (node == null) return 0;

			return 1 + Math.Max(GetDepth(node.Left), GetDepth(node.Right));
		}

		[Test]
		public void Null_ReturnsZero()
		{
			Assert.That(GetDepth(null), Is.EqualTo(0));
		}

		[Test]
		public void OnlyRoot_ReturnOne()
		{
			Assert.That(GetDepth(new BinaryNode()), Is.EqualTo(1));
		}

		[Test]
		public void BalancedTree_ReturnCorrectDepth()
		{
			var root = new BinaryNode(19);
			root.Left = new BinaryNode(12);
			root.Left.Left = new BinaryNode(7);
			root.Left.Right = new BinaryNode(15);

			root.Right = new BinaryNode(27);
			root.Right.Right = new BinaryNode(36);
			root.Right.Left = new BinaryNode(20);
			root.Right.Left.Right = new BinaryNode(24);

			var result = GetDepth(root);
			Assert.That(result, Is.EqualTo(4));
		}
	}
}
