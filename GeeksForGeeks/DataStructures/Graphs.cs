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

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, null)) return false;
			if (ReferenceEquals(obj, this)) return true;

			return false;
		}

		public override int GetHashCode()
		{
			return Val.GetHashCode();
		}
	}

	[DebuggerDisplay("{Nodes?.Count}")]
	public class Graph<T> where T : struct
	{
		public List<GraphNode<T>> Nodes;
		public Graph()
		{
			Nodes = new List<GraphNode<T>>();
		}

		public void Add(GraphNode<T> graphNode) => Nodes.Add(graphNode);

		public void Add(params GraphNode<T>[] nodes) {
			foreach (var n in nodes)
				Nodes.Add(n);
		}

		public int NodeCount() => Nodes.Count;
	}
}
