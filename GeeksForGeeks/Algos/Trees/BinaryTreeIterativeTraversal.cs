using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks
{
	public class BinaryNode
	{
		public int Value;
		public BinaryNode Left;
		public BinaryNode Right;
		public BinaryNode Next;

		public BinaryNode() { }
		public BinaryNode(int v) => Value = v;
		public override string ToString() => $"{Value} Left:{Left?.Value} Right:{Right?.Value}";

		public bool IsLeaf() => Left == null && Right == null;
		public bool HasOnlyOneChild() => (Left == null && Right != null) || (Left != null && Right == null);

		public override bool Equals(object obj)
		{
			if (!ReferenceEquals(this, obj)) return false;
			if (ReferenceEquals(obj, null)) return false;

			return Equals(this, obj as BinaryNode);
		}

		public static bool Equals(BinaryNode node, BinaryNode other)
		{
			if (ReferenceEquals(node, other)) return true;
			if (ReferenceEquals(node, null)) return false;
			if (ReferenceEquals(other, null)) return false;

			return node.Value == other.Value;
		}

		public static bool operator ==(BinaryNode n1, BinaryNode n2)
		{
			return Equals(n1, n2);
		}

		public static bool operator !=(BinaryNode n1, BinaryNode n2)
		{
			return !Equals(n1, n2);
		}
	}

	public class BinaryTreeIterativeTraversal
	{
		public static List<int> Visit(BinaryNode root)
		{
			var orderedNodes = new HashSet<int>();
			var pending = new Stack<BinaryNode>();
			pending.Push(root);

			while (pending.Count() > 0)
			{
				var current = pending.Pop();
				if (current == null)
				{
					continue;
				}
				else if (current.Left == null && current.Right == null)
				{
					orderedNodes.Add(current.Value);
				}
				else
				{
					if (current.Left == null || orderedNodes.Contains(current.Left.Value))
					{
						orderedNodes.Add(current.Value);
						pending.Push(current.Right);
					}
					else
					{
						pending.Push(current);
						pending.Push(current.Left);
					}
				}
			}

			return orderedNodes.ToList();
		}
	}

	[TestFixture]
	public class TestBinaryTreeIterativeTraversal
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode() { Value = 10 };
			root.Left = new BinaryNode() { Value = 2 };

			var fifteen = new BinaryNode() { Value = 15 };
			fifteen.Left = new BinaryNode() { Value = 12 };
			fifteen.Right = new BinaryNode() { Value = 18 };

			root.Right = fifteen;

			var expectedNodes = new List<int>() { 2, 10, 12, 15, 18 };
			var orderedNodes = BinaryTreeIterativeTraversal.Visit(root);

			Assert.That(orderedNodes.SequenceEqual(expectedNodes), Is.True);
		}
	}
}
