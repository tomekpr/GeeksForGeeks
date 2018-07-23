using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	public class IsBstIterative
	{
		public static bool IsBst(BinaryNode rootNode)
		{
			var orderedNodes = BinaryTreeIterativeTraversal.Visit(rootNode);
			for (int i = 1; i < orderedNodes.Count; i++)
				if (orderedNodes[i - 1] > orderedNodes[i]) return false;

			return true;
		}

		public static bool IsBst2(BinaryNode rootNode)
		{
			var visited = new HashSet<int>();
			var pending = new Stack<BinaryNode>();
			pending.Push(rootNode);

			int? min = null;

			while(pending.Count > 0)
			{
				var node = pending.Pop();
				if (node == null) continue;

				if(node.Left == null && node.Right == null)
				{
					if (min.HasValue && node.Value < min) return false;

					visited.Add(node.Value);
					min = node.Value;
				}
				else
				{
					if(node.Left == null || visited.Contains(node.Left.Value))
					{
						if (min.HasValue && node.Value < min) return false;

						min = node.Value;

						visited.Add(node.Value);
						pending.Push(node.Right);
					}
					else
					{
						pending.Push(node);
						pending.Push(node.Left);
					}
				}
			}

			return true;
		}
	}

	[TestFixture]
	public class TestIsBstIterative
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

			bool isBst = IsBstIterative.IsBst(root);
			Assert.That(isBst, Is.True);
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNode() { Value = 10 };
			root.Left = new BinaryNode() { Value = 2 };

			var fifteen = new BinaryNode() { Value = 15 };
			fifteen.Left = new BinaryNode() { Value = 7 };
			fifteen.Right = new BinaryNode() { Value = 18 };

			root.Right = fifteen;

			bool isBst = IsBstIterative.IsBst(root);
			Assert.That(isBst, Is.False);
		}

		[Test]
		public void Test3()
		{
			var root = new BinaryNode() { Value = 10 };
			root.Left = new BinaryNode() { Value = 2 };

			var fifteen = new BinaryNode() { Value = 15 };
			fifteen.Left = new BinaryNode() { Value = 12 };
			fifteen.Right = new BinaryNode() { Value = 18 };

			root.Right = fifteen;

			bool isBst = IsBstIterative.IsBst2(root);
			Assert.That(isBst, Is.True);
		}

		[Test]
		public void Test4()
		{
			var root = new BinaryNode() { Value = 10 };
			root.Left = new BinaryNode() { Value = 2 };

			var fifteen = new BinaryNode() { Value = 15 };
			fifteen.Left = new BinaryNode() { Value = 7 };
			fifteen.Right = new BinaryNode() { Value = 18 };

			root.Right = fifteen;

			bool isBst = IsBstIterative.IsBst2(root);
			Assert.That(isBst, Is.False);
		}
	}
}
