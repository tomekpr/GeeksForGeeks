using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	class FirstNonMatchingLeavesInTwoBinaryTrees
	{
		public List<BinaryNode> Find(BinaryNode root1, BinaryNode root2)
		{
			if (root1 == null || root2 == null) return new List<BinaryNode>();

			// Create two stacks for preorder traversals - we push nodes onto the stacks
			// until we find leaves, then we compare
			var s1 = new Stack<BinaryNode>();
			s1.Push(root1);
			var s2 = new Stack<BinaryNode>();
			s2.Push(root2);

			while(s1.Count > 0 && s2.Count > 0)
			{
				// not sure I understand this criteria given above while condition
				if (s1.Count == 0 || s2.Count == 0) return new List<BinaryNode>();

				// Do iterative traversal of first tree
				var temp1 = s1.Pop();
				while(temp1 != null && temp1.IsLeaf() == false)
				{
					s1.Push(temp1.Right);
					s1.Push(temp1.Left);

					temp1 = s1.Pop();
				}

				// Do iterative traversal of the second tree
				var temp2 = s2.Pop();
				while(temp2 != null && temp2.IsLeaf() == false)
				{
					s2.Push(temp2.Right);
					s2.Push(temp2.Left);

					temp2 = s2.Pop();
				}

				// if we found leaves in both trees
				if(temp1 != null && temp2 != null)
				{
					if (temp1.Value != temp2.Value)
						return new List<BinaryNode>() { temp1, temp2 };
				}
			}

			return new List<BinaryNode>();
		}
	}

	[TestFixture]
	public class TestFirstNonMatchingLeavesInBinaryTree
	{
		[Test]
		public void Test1()
		{
			var root1 = new BinaryNode(5);
			root1.Left = new BinaryNode(2);
			root1.Left.Left = new BinaryNode(10);
			root1.Left.Right = new BinaryNode(11);

			root1.Right = new BinaryNode(7);

			var root2 = new BinaryNode(6);
			root2.Left = new BinaryNode(10);
			root2.Right = new BinaryNode(15);

			var sut = new FirstNonMatchingLeavesInTwoBinaryTrees();
			var result = sut.Find(root1, root2);

			Assert.That(result.Any(x => x.Value == 11));
			Assert.That(result.Any(x => x.Value == 15));
		}
	}
}
