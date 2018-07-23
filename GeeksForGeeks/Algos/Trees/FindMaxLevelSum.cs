using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	class FindMaxLevelSum
	{
		//https://www.youtube.com/watch?v=oiStyIvqwCg
		public int FindMax(BinaryNode n)
		{
			var levelToSum = new Dictionary<int, int>();
			int max = Int32.MinValue;
			int level = 0;

			PreOrder(n, levelToSum, ref max, level);
			return max;
		}

		void PreOrder(BinaryNode n, Dictionary<int, int> lts, ref int max, int level)
		{
			if (n == null) return;

			int currentSum = 0;
			lts.TryGetValue(level, out currentSum);

			currentSum += n.Value;
			lts[level] = currentSum;
			max = Math.Max(max, currentSum);

			PreOrder(n.Left, lts, ref max, level + 1);
			PreOrder(n.Right, lts, ref max, level + 1);
		}
	}

	[TestFixture]
	public class TestFindMaxLevelSum
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(4);
			root.Left = new BinaryNode(2);
			root.Left.Left = new BinaryNode(-1);
			root.Left.Right = new BinaryNode(3);

			root.Right = new BinaryNode(-5);
			root.Right.Left = new BinaryNode(-2);
			root.Right.Right = new BinaryNode(6);

			var sum = new FindMaxLevelSum();
			int maxSum = sum.FindMax(root);

			Assert.That(maxSum, Is.EqualTo(6));
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNode(1);
			root.Left = new BinaryNode(2);
			root.Left.Left = new BinaryNode(4);
			root.Left.Right = new BinaryNode(5);

			root.Right = new BinaryNode(3);
			root.Right.Right = new BinaryNode(8);
			root.Right.Right.Left = new BinaryNode(6);
			root.Right.Right.Right = new BinaryNode(7);

			var sum = new FindMaxLevelSum();
			int maxSum = sum.FindMax(root);

			Assert.That(maxSum, Is.EqualTo(17));
		}
	}
}
