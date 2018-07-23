using System.Collections.Generic;
using System.Diagnostics;

namespace GeeksForGeeks.DataStructures
{
	[DebuggerDisplay("{Val} {Visisted}")]
	public class GraphNode<T> where T : struct
	{
		public T Val;
		public bool Visisted;
		public List<GraphNode<T>> Adjacent;

		public GraphNode(T v)
		{
			Val = v;
			Adjacent = new List<GraphNode<T>>();
		}

		public void Add(GraphNode<T> vertex) => Adjacent.Add(vertex);
	}

	[DebuggerDisplay("{Nodes?.Count}")]
	public class Graph<T> where T : struct
	{
		public List<GraphNode<T>> Nodes;
		public void Add(GraphNode<T> graphNode) => Nodes.Add(graphNode);
		public Graph()
		{
			Nodes = new List<GraphNode<T>>();
		}
	}
}
