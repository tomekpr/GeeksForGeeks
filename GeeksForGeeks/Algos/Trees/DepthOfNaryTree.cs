using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=x_hJLIOIqa8
	class DepthOfNaryTree
	{
		public int GetDepth(NNode node)
		{
			if (node == null) return 0;

			int maxDepth = 0;
			foreach (var c in node.ChildNodes)
				maxDepth = Math.Max(maxDepth, GetDepth(c));

			return maxDepth + 1;
		}
	}

	[TestFixture]
	public class TestDepthOfNAryTree
	{
		[Test]
		public void Test1()
		{
			var root = new NNode(1);
			root.Add(7, 8);

			var three = new NNode(3);
			three.Add(5, 4);

			root.Add(three);

			var depth = new DepthOfNaryTree().GetDepth(root);
			Assert.That(depth, Is.EqualTo(3));
		}
	}
}
