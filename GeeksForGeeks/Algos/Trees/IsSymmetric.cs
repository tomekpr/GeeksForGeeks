using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class IsSymmetric
	{
		bool IsSymm(BinaryNode root)
		{
			return IsSymm(root.Left, root.Right);
		}

		bool IsSymm(BinaryNode left, BinaryNode right)
		{
			if (left != null && right == null) return false;
			if (left == null && right != null) return false;
			if (left == null && right == null) return true;
			if (left.Value != right.Value) return false;

			return IsSymm(left.Left, right.Right) &&
				IsSymm(left.Right, right.Left);
		}

		[Test]
		public void Test1()
		{
			var root = new BinaryNode(314);
			root.Left = new BinaryNode(6);
			root.Right = new BinaryNode(6);

			root.Left.Right = new BinaryNode(2);
			root.Right.Left = new BinaryNode(2);

			root.Left.Right.Right = new BinaryNode(3);
			root.Right.Left.Left = new BinaryNode(3);

			var result = IsSymm(root);
			Assert.That(result, Is.True);
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNode(314);
			root.Left = new BinaryNode(6);
			root.Right = new BinaryNode(6);

			root.Left.Right = new BinaryNode(561);
			root.Right.Left = new BinaryNode(2);

			root.Left.Right.Right = new BinaryNode(3);
			root.Right.Left.Left = new BinaryNode(1);

			var result = IsSymm(root);
			Assert.That(result, Is.False);
		}

		[Test]
		public void Test3()
		{
			var root = new BinaryNode(314);
			root.Left = new BinaryNode(6);
			root.Right = new BinaryNode(6);

			root.Left.Right = new BinaryNode(561);
			root.Right.Left = new BinaryNode(561);

			root.Left.Right.Right = new BinaryNode(3);
			root.Right.Left.Left = null;

			var result = IsSymm(root);
			Assert.That(result, Is.False);
		}
	}
}
