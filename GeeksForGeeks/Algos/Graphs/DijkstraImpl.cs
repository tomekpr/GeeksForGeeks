using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks
{
	class DijkstraNode
	{
		public int Id;
		public int Distance;

		public List<DijkstraNode> Adjacent;

		public DijkstraNode()
		{
			Adjacent = new List<DijkstraNode>();
		}

		public void Add(DijkstraNode dn) => Adjacent.Add(dn);
	}

	class DijkstraImpl
	{
		// Not valid, check this!
		public List<int> ShortestPath(DijkstraNode start, DijkstraNode end)
		{
			var visited = new HashSet<int>();
			var pq = new PQ();

			pq.Add(start);

			while (pq.Count() > 0)
			{
				var u = pq.GetMin();
				if (visited.Contains(u.Id)) continue;
				visited.Add(u.Id);

				foreach (var n in u.Adjacent)
				{
					// to nie ma sensu
					if (u.Distance + n.Distance <= n.Distance)
						n.Distance = u.Distance + n.Distance;

					pq.AddOrUpdate(n);
				}
			}

			return visited.ToList();
		}
	}

	class PQ
	{
		private SortedDictionary<DijkstraNode, bool> pq;

		public PQ()
			: this(Comparer<DijkstraNode>.Create((x, y) => x.Distance.CompareTo(y.Distance)))
		{
		}

		public PQ(IComparer<DijkstraNode> comparer)
		{
			pq = new SortedDictionary<DijkstraNode, bool>(comparer);
		}

		public DijkstraNode GetMin()
		{
			var min = pq.Keys.First();
			pq.Remove(min);

			return min;
		}

		public int Count() => pq.Count;
		public void Add(DijkstraNode n) => pq.Add(n, true);

		public void Update(int id, int distance)
		{
			var element = pq.Keys.First(x => x.Id == id);
			pq.Remove(element);

			element.Distance = distance;
			pq.Add(element, true);
		}

		public void AddOrUpdate(DijkstraNode dn)
		{
			if (pq.ContainsKey(dn))
				pq.Remove(dn);

			pq.Add(dn, true);

		}
	}

	[TestFixture]
	public class DijkstraTest
	{
		DijkstraImpl dijkstra = new DijkstraImpl();

		[Test]
		public void Test1()
		{
			var a = new GraphNode<int>(0);
			var b = new GraphNode<int>(5);
			var c = new GraphNode<int>(10);
			var d = new GraphNode<int>(15);

			a.Add(b);
			b.Add(c);
			c.Add(d);

			var e = new GraphNode<int>(20);
			var f = new GraphNode<int>(30);

			a.Add(e);
			e.Add(f);

			//var result = dijkstra.ShortestPath(a, d);
			//Console.WriteLine(String.Join(",", result));
		}
	}
}
