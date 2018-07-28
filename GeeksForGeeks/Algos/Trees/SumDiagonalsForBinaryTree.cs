using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Trees
{
	class SumDiagonalsForBinaryTree
	{
		public List<int> SumDiagonals(BinaryNode node)
		{
			var result = new Dictionary<int,int>();
			SumHelper(node, 0, result);

			return new int[]
			{
				result[0],
				result[1],
				result[2]
			}.ToList();
		}

		void SumHelper(BinaryNode node, int currentDiag, Dictionary<int,int> result)
		{
			if (node == null) return;
			SumHelper(node.Left, currentDiag + 1, result);

			int prevSum = 0;
			if(result.ContainsKey(currentDiag))
			{
				prevSum = result[currentDiag];
			}

			result[currentDiag] = prevSum + node.Value;
			SumHelper(node.Right, currentDiag, result);
		}
	}

	[TestFixture]
	public class TestSumDiagonalsForBinaryTree
	{
		[Test]
		public void Test1()
		{
			var diag1 = new BinaryNode(1);
			diag1.Right = new BinaryNode(3);
			diag1.Right.Right = new BinaryNode(6);
			diag1.Right.Right.Left = new BinaryNode(7);

			var diag2 = new BinaryNode(2);
			diag2.Right = new BinaryNode(5);
			diag2.Right.Left = new BinaryNode(8);

			var diag3 = new BinaryNode(4);

			diag2.Left = diag3;
			diag1.Left = diag2;

			var sum = new SumDiagonalsForBinaryTree();
			var result = sum.SumDiagonals(diag1);

			Assert.That(result[0], Is.EqualTo(10));
			Assert.That(result[1], Is.EqualTo(14));
			Assert.That(result[2], Is.EqualTo(12));
		}
	}
}
