using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Trees
{
	// Iterative and Recursive
	// Preoder: Like reading from left to right.
	class Preorder
	{
		public List<int> VisitRec(BinaryNode node)
		{
			var result = new List<int>();
			VisitHelper(node, result);
			return result;
		}

		public List<int> VisitIt(BinaryNode node)
		{
			var result = new List<int>();
			var stack = new Stack<BinaryNode>();
			var visited = new HashSet<int>();

			stack.Push(node);
			
			while(stack.Count > 0)
			{
				var tmp = stack.Pop();
				if (tmp == null || visited.Contains(tmp.Value)) continue;

				if(tmp.IsLeaf())
				{
					result.Add(tmp.Value);
					visited.Add(tmp.Value);
				}
				else if(visited.Contains(tmp.Left.Value))
				{
					result.Add(tmp.Value);
					visited.Add(tmp.Value);
				}
				else
				{
					stack.Push(tmp.Right);
					stack.Push(tmp);
					stack.Push(tmp.Left);
				}
			}

			return result;
		}

		void VisitHelper(BinaryNode node, List<int> result)
		{
			if (node == null) return;
			VisitHelper(node.Left, result);

			result.Add(node.Value);

			VisitHelper(node.Right, result);
		}
	}

	[TestFixture]
	public class TestPreorder
	{
		[Test]
		public void Test1()
		{
			var root1 = new BinaryNode(5);
			root1.Left = new BinaryNode(2);
			root1.Left.Left = new BinaryNode(10);
			root1.Left.Right = new BinaryNode(11);

			root1.Right = new BinaryNode(7);

			var expected = new int[] { 10, 2, 11, 5, 7 };
			var sut = new Preorder();

			var resultRec = sut.VisitRec(root1);
			var areEqual = expected.SequenceEqual(resultRec);

			Assert.IsTrue(areEqual);

			var resultIt = sut.VisitIt(root1);
			areEqual = expected.SequenceEqual(resultIt);

			Assert.IsTrue(areEqual);
		}
	}
}
