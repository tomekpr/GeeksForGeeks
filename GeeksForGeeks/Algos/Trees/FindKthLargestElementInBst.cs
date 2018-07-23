using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// Reversal of in-order to get keys in decreasing order
	// https://www.youtube.com/watch?v=QavTg43VDsU
	class FindKthLargestElementInBst
	{
		public int FindKthLargestElement(BinaryNode node, int k)
		{
			int largest = Int32.MinValue;
			int current = k;
			LargestHelper(node, ref current, ref largest);
			return largest;
		}

		void LargestHelper(BinaryNode node, ref int current, ref int largest)
		{
			if (node == null) return;

			LargestHelper(node.Right, ref current, ref largest);

			if (current == 0) return;

			// remember largest.
			current--;
			largest = node.Value;

			// visit left node
			LargestHelper(node.Left, ref current, ref largest);
		}
	}

	[TestFixture]
	public class TestFindKthLargestElementInBst
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(20);
			root.Right = new BinaryNode(22);

			root.Left = new BinaryNode(8);
			root.Left.Left = new BinaryNode(4);

			root.Left.Right = new BinaryNode(12);
			root.Left.Right.Left = new BinaryNode(10);
			root.Left.Right.Right = new BinaryNode(14);

			var finder = new FindKthLargestElementInBst();
			var largest = finder.FindKthLargestElement(root, 3);
			Assert.That(largest == 14);

			largest = finder.FindKthLargestElement(root, 5);
			Assert.That(largest == 10);
		}
	}
}
