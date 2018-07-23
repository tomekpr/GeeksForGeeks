using GeeksForGeeks.AlgoUtils;
using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace GeeksForGeeks.Algos.Graphs
{
	class TopologicalSort
	{
		public Stack<char> Sort(Graph<char> graph)
		{
			var result = new Stack<char>();
			var visited = new HashSet<GraphNode<char>>();

			foreach (var node in graph.Nodes)
			{
				if (visited.Contains(node)) continue;

				SortHelper(node, visited, result);
			}

			return result;
		}

		void SortHelper(GraphNode<char> node, HashSet<GraphNode<char>> visited, Stack<char> result)
		{
			if (node == null) return;

			if (visited.Contains(node)) return; // nothing to do!

			visited.Add(node);
			foreach (var neighbour in node.Adjacent)
				SortHelper(neighbour, visited, result);

			result.Push(node.Val);
		}
	}

	[TestFixture]
	public class TestTopologicalSort
	{
		public GraphNode<char> Create(char c) => new GraphNode<char>(c);

		[Test]
		public void Test1()
		{
			var a = Create('A');
			var b = Create('B');
			var c = Create('C');
			var d = Create('D');
			var e = Create('E');
			var f = Create('F');
			var g = Create('G');
			var h = Create('H');

			a.Add(c);

			b.Add(c);
			b.Add(d);

			c.Add(e);

			d.Add(f);
			e.Add(h);
			e.Add(f);

			f.Add(g);

			var graph = new Graph<char>();
			graph.Add(e);
			graph.Add(b);
			graph.Add(a);
			graph.Add(c);
			graph.Add(d);
			graph.Add(f);
			graph.Add(g);

			var expected = new Stack<char>();
			expected.Push('H');
			expected.Push('G');
			expected.Push('F');
			expected.Push('E');
			expected.Push('C');
			expected.Push('D');
			expected.Push('B');
			expected.Push('A');

			var sut = new TopologicalSort();
			var result = sut.Sort(graph);

			var areEqual = Collections.CompareStacks(result, expected);
			Assert.That(areEqual, Is.True);
		}
	}
}
