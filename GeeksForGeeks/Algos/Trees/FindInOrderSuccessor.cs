using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	public class BinaryNodeWithParent : BinaryNode
	{
		public BinaryNodeWithParent Parent;
	}

	class FindInOrderSuccessor
	{
		public static BinaryNodeWithParent Find(BinaryNodeWithParent node)
		{
			if (node.Parent == null || node.Parent.Parent == null)
				return FindMaxLeft(node);

			var gpa = node.Parent.Parent;
			if (gpa.Value < node.Parent.Value)
				return node.Parent;

			return gpa;
		}

		private static BinaryNodeWithParent FindMaxLeft(BinaryNode node)
		{
			var left = node.Left;
			var prev = node;

			while (left != null)
			{
				prev = left;
				left = left.Left;
			}

			return prev as BinaryNodeWithParent;
		}
	}

	[TestFixture]
	public class TestFindInOrderSuccessor
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNodeWithParent() { Value = 10 };
			root.Left = new BinaryNodeWithParent() { Value = 2, Parent = root };

			var fifteen = new BinaryNodeWithParent() { Value = 15, Parent = root };
			fifteen.Left = new BinaryNodeWithParent() { Value = 12, Parent = fifteen };
			fifteen.Right = new BinaryNodeWithParent() { Value = 18, Parent = fifteen };

			root.Right = fifteen;

			var nextInOrder = FindInOrderSuccessor.Find(root);
			Assert.That(nextInOrder.Value, Is.EqualTo(2));
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNodeWithParent() { Value = 10 };
			root.Left = new BinaryNodeWithParent() { Value = 2, Parent = root };

			var fifteen = new BinaryNodeWithParent() { Value = 15, Parent = root };
			fifteen.Left = new BinaryNodeWithParent() { Value = 12, Parent = fifteen };
			fifteen.Right = new BinaryNodeWithParent() { Value = 18, Parent = fifteen };

			root.Right = fifteen;

			var nextInOrder = FindInOrderSuccessor.Find(fifteen.Left as BinaryNodeWithParent);
			Assert.That(nextInOrder.Value, Is.EqualTo(15));
		}

		[Test]
		public void Test3()
		{
			var root = new BinaryNodeWithParent() { Value = 10 };
			root.Left = new BinaryNodeWithParent() { Value = 2, Parent = root };

			var fifteen = new BinaryNodeWithParent() { Value = 15, Parent = root };
			var twelve = new BinaryNodeWithParent() { Value = 12, Parent = fifteen };

			fifteen.Left = twelve;
			fifteen.Right = new BinaryNodeWithParent() { Value = 18, Parent = fifteen };

			root.Right = fifteen;

			twelve.Right = new BinaryNodeWithParent() { Value = 14, Parent = twelve };

			var nextInOrder = FindInOrderSuccessor.Find(twelve.Right as BinaryNodeWithParent);
			Assert.That(nextInOrder.Value, Is.EqualTo(15));
		}
	}
}
