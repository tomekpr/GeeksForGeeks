using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=nMRTfhTkxC4
	class FindNthNodeOfInorderTraversal
	{
		public int FindNthNode(BinaryNode bn, int n)
		{
			int currentNode = 0;
			int? result = null;
		
			InOrderHelper(bn, ref currentNode, n, ref result);

			return result.Value;
		}

		void InOrderHelper(BinaryNode bn, ref int currentNode, int n, ref int? result)
		{
			if (bn == null) return;

			if (currentNode <= n)
			{
				InOrderHelper(bn.Left, ref currentNode, n, ref result);

				currentNode++;

				if (currentNode == n)
				{
					result = bn.Value;
					return;
				}

				InOrderHelper(bn.Right, ref currentNode, n, ref result);
			}
		}
	}

	[TestFixture]
	public class TestFindNthNodeOfInorderTraversal
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(10);
			root.Left = new BinaryNode(20);
			root.Left.Left = new BinaryNode(40);
			root.Left.Right = new BinaryNode(50);

			root.Right = new BinaryNode(30);

			var sut = new FindNthNodeOfInorderTraversal();
			var result = sut.FindNthNode(root, 4);

			Assert.That(result, Is.EqualTo(10));
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNode(7);
			root.Left = new BinaryNode(2);
			root.Right = new BinaryNode(3);
			root.Right.Left = new BinaryNode(8);
			root.Right.Right = new BinaryNode(5);

			var sut = new FindNthNodeOfInorderTraversal();
			var result = sut.FindNthNode(root, 3);

			Assert.That(result, Is.EqualTo(8));
		}
	}
}
