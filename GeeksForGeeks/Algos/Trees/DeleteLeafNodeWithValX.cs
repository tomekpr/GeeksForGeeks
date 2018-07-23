using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=qasFZ118RTk
	class DeleteLeafNodeWithValX
	{
		public void DelNodeX(BinaryNode n, int x)
		{
			if (n == null) return;

			if(CanDelete(n.Left, x))
			{
				n.Left = null;
				return;
			}

			if(CanDelete(n.Right, x))
			{
				n.Right = null;
				return;
			}

			if(CanDelete(n,x))
			{
				n = null;
				return;
			}

			DelNodeX(n.Left, x);
			DelNodeX(n.Right, x);
		}

		bool CanDelete(BinaryNode n, int x) => n != null &&
			n.Value == x &&
			n.Left == null &&
			n.Right == null;
	}

	[TestFixture]
	public class TestDeleteLeafNodeWithValX
	{
		[Test]
		public void Test1()
		{
			var six = new BinaryNode(6);
			six.Right = new BinaryNode(4);
			six.Right.Right = new BinaryNode(5);

			six.Left = new BinaryNode(5);
			six.Left.Left = new BinaryNode(1);
			six.Left.Right = new BinaryNode(2);

			var del = new DeleteLeafNodeWithValX();
			del.DelNodeX(six, 5);

			var exp = new int[] { 1, 5, 2, 6, 4 };
			var actual = AlgoUtils.Trees.InOrder(six);

			var areEqual = exp.SequenceEqual(actual);
			Assert.IsTrue(areEqual);
		}
	}
}
