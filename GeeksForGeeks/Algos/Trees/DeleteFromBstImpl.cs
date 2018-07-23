using NUnit.Framework;
using System.Collections.Generic;

namespace GeeksForGeeks
{
	[TestFixture]
	class DeleteFromBstImpl
	{
		void Delete2(ref BinaryNode root, int x)
		{
			if (root == null) return;
			if(root.Value == x)
			{
				DeleteRoot(ref root);
				return;
			}

			var parent = FindParentOf(x, root, root);
			if (parent == null) return;

			if (parent.Left?.Value == x)
				DeleteLeftNode(ref parent);
			else
				DeleteRightNode(ref parent);
		}

		void DeleteRoot(ref BinaryNode root)
		{
			var left = root.Left;
			AddNode(left, root.Right);

			root = left;
		}

		BinaryNode FindParentOf(int x, BinaryNode parent, BinaryNode current)
		{
			if (current == null) return null;

			if (current.Value == x) return parent;
			if (x < current.Value)
				return FindParentOf(x, current, current.Left);

			return FindParentOf(x, current, current.Right);
		}

		void DeleteLeftNode(ref BinaryNode parent)
		{
			var left = parent.Left.Left;
			var right = parent.Left.Right;

			parent.Left = null;

			AddNode(parent, left);
			AddNode(parent, right);
		}

		void DeleteRightNode(ref BinaryNode parent)
		{
			var left = parent.Right.Left;
			var right = parent.Right.Right;

			parent.Right = null;

			AddNode(parent, left);
			AddNode(parent, right);
		}

		private void AddNode(BinaryNode node, BinaryNode toAdd)
		{
			if (toAdd == null) return;

			if (toAdd.Value < node.Value)
			{
				if (node.Left == null)
					node.Left = toAdd;
				else
					AddNode(node.Left, toAdd);
			}
			else
			{
				if (node.Right == null)
					node.Right = toAdd;
				else
					AddNode(node.Right, toAdd);
			}
		}

		private List<int> PrintTree(BinaryNode node)
		{
			var result = new List<int>();
			PrintTreeHelper(node, result);
			return result;
		}

		private void PrintTreeHelper(BinaryNode node, List<int> result)
		{
			if (node == null) return;

			PrintTreeHelper(node.Left, result);
			result.Add(node.Value);
			PrintTreeHelper(node.Right, result);
		}

		[Test]
		public void CanDeleteRoot()
		{
			var root = new BinaryNode(1);
			Delete2(ref root, 1);

			Assert.That(root, Is.Null);

			var result = PrintTree(root);
			Assert.That(result.Count, Is.EqualTo(0));
		}

		[Test]
		public void CanDeleteRootsSingleChild()
		{
			var root = new BinaryNode(1);
			root.Left = new BinaryNode(0);

			Delete2(ref root, 0);
			var result = PrintTree(root);

			Assert.That(result.Count, Is.EqualTo(1));
			Assert.That(result.Contains(0), Is.False);
		}

		[Test]
		public void CanDeleteSingleChildThatHasTwoChildren()
		{
			var root = new BinaryNode(5);
			root.Left = new BinaryNode(3);
			root.Left.Left = new BinaryNode(2);
			root.Left.Right = new BinaryNode(4);

			Delete2(ref root, 3);

			var result = PrintTree(root);
			Assert.That(result.Count, Is.EqualTo(3));

			Assert.That(result.Contains(3), Is.False);
			Assert.That(root.Left.Value, Is.EqualTo(2));
			Assert.That(root.Left.Right.Value, Is.EqualTo(4));
		}
	}
}
