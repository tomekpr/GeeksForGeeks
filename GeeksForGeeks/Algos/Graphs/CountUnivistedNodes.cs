using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace GeeksForGeeks.Algos.Graphs
{
	class CountUnivistedNodes
	{
		public int Count(Graph<int> g, GraphNode<int> root)
		{
			var visited = new HashSet<GraphNode<int>>();
			Dfs(root, visited);

			int count = g.NodeCount() - visited.Count;
			return count;
		}

		void Dfs(GraphNode<int> n, HashSet<GraphNode<int>> visited)
		{
			if (n == null) return;

			if (visited.Contains(n)) return;
			visited.Add(n);

			foreach (var node in n.Adjacent)
				Dfs(node, visited);
		}
	}

	[TestFixture]
	public class TestCountUnivisitedNodes
	{
		[Test]
		public void Test1()
		{
			var gn0 = new GraphNode<int>(0);
			var gn1 = new GraphNode<int>(1);
			var gn2 = new GraphNode<int>(2);
			var gn3 = new GraphNode<int>(3);
			var gn4 = new GraphNode<int>(4);

			gn0.Add(gn1);
			gn0.Add(gn2);

			gn1.Add(gn1);
			gn1.Add(gn2);

			gn2.Add(gn0);
			gn2.Add(gn1);

			gn3.Add(gn4);
			gn4.Add(gn3);

			var graph = new Graph<int>();
			graph.Add(gn0, gn1, gn2, gn3, gn4);

			var sut = new CountUnivistedNodes();
			var count = sut.Count(graph, gn0);

			Assert.That(count, Is.EqualTo(2));
		}
	}
}
