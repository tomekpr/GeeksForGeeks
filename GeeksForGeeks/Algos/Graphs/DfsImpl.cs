using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks
{
	class DfsImpl
	{
		public void Dfs(GraphNode<int> node, List<int> result)
		{
			if (node == null || node.Visisted) return;

			node.Visisted = true;
			result.Add(node.Val);

			foreach (var n in node.Adjacent)
				Dfs(n, result);
		}
	}

	[TestFixture]
	public class DfsTests
	{
		DfsImpl impl = new DfsImpl();

		[Test]
		public void Test1()
		{
			var warsaw = new GraphNode<int>(0);
			var ostrow = new GraphNode<int>(1);
			var wroclaw = new GraphNode<int>(2);
			var kalisz = new GraphNode<int>(3);

			var gdansk = new GraphNode<int>(4);
			var gdynia = new GraphNode<int>(5);

			warsaw.Add(ostrow);
			ostrow.Add(wroclaw);
			wroclaw.Add(kalisz);

			warsaw.Add(gdansk);
			gdansk.Add(gdynia);

			var result = new List<int>();
			impl.Dfs(warsaw, result);

			Assert.That(result.SequenceEqual(new int[] { 0, 1, 2, 3, 4, 5 }), Is.True);
		}
	}
}
