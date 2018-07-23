using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	class SumOfParentNodesThatHaveChildX
	{
		public int SumParents(BinaryNode node, int x)
		{
			int sum = 0;
			SumHelper(node, ref sum, x);
			return sum;
		}

		void SumHelper(BinaryNode node, ref int sum, int x)
		{
			if (node == null) return;

			SumHelper(node.Left, ref sum, x);

			if (node.Left != null && node.Right != null)
			{
				if (node.Left.Value == x || node.Right.Value == x)
					sum += node.Value;
			}
			else
			{
				if (node.Left?.Value == x)
					sum += node.Value;
				else if (node.Right?.Value == x)
					sum += node.Value;
			}

			SumHelper(node.Right, ref sum, x);
		}
	}

	[TestFixture]
	public class TestSumParentsWithChildX
	{
		[Test]
		public void Test1()
		{
			var node = new BinaryNode(4);
			node.Left = new BinaryNode(2);
			node.Left.Left = new BinaryNode(7);
			node.Left.Right = new BinaryNode(2);

			node.Right = new BinaryNode(5);
			node.Right.Left = new BinaryNode(2);
			node.Right.Right = new BinaryNode(3);

			var sut = new SumOfParentNodesThatHaveChildX();
			var sum = sut.SumParents(node, 2);

			Assert.That(sum, Is.EqualTo(11));
		}
	}
}
