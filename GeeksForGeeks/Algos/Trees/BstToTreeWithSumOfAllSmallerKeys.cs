using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=AmSgD5JYMAc
	class BstToTreeWithSumOfAllSmallerKeys
	{
		public void Convert(BinaryNode node)
		{
			int sum = 0;

			ConvertHelper(node, ref sum);
		}

		void ConvertHelper(BinaryNode node, ref int sum)
		{
			if (node == null) return;
			ConvertHelper(node.Left, ref sum);

			sum += node.Value;
			node.Value = sum;

			ConvertHelper(node.Right, ref sum);
		}
	}

	[TestFixture]
	public class TestBstToTreeWithSumOfAllSmallerKeys
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(9);
			root.Left = new BinaryNode(6);
			root.Left.Left = new BinaryNode(3);

			root.Right = new BinaryNode(15);
			root.Right.Right = new BinaryNode(21);

			var convert = new BstToTreeWithSumOfAllSmallerKeys();
			convert.Convert(root);

			var exp = new int[] { 3, 9, 18, 33, 54 };
			var result = AlgoUtils.Trees.InOrder(root);

			Assert.That(exp.SequenceEqual(result));
		}
	}
}
