using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks
{
	class BfsImpl
	{
		public List<int> Bfs(GraphNode<int> vertex)
		{
			var result = new List<int>();
			var toVisit = new Queue<GraphNode<int>>();

			toVisit.Enqueue(vertex);
			while(toVisit.Count > 0)
			{
				var current = toVisit.Dequeue();
				if (current.Visisted) continue;

				current.Visisted = true;
				result.Add(current.Val);

				foreach (var n in current.Adjacent)
					toVisit.Enqueue(n);
			}

			return result;
		}
	}

	[TestFixture]
	public class BfsTests
	{
		BfsImpl impl = new BfsImpl();

		[Test]
		public void Test1()
		{
			GraphNode<int> warsaw = new GraphNode<int>(0);
			GraphNode<int> ostrow = new GraphNode<int>(1);
			GraphNode<int> kalisz = new GraphNode<int>(2);
			GraphNode<int> wroclaw = new GraphNode<int>(3);

			warsaw.Add(ostrow);
			warsaw.Add(kalisz);

			kalisz.Add(wroclaw);

			var result = impl.Bfs(warsaw);
			Console.WriteLine(String.Join(",", result));
			Assert.That(result.SequenceEqual(new int[] { 0, 1, 2, 3 }), Is.True);
		}

		[Test]
		public void Test2()
		{
			GraphNode<int> warsaw = new GraphNode<int>(0);
			GraphNode<int> ostrow = new GraphNode<int>(1);
			GraphNode<int> kalisz = new GraphNode<int>(2);
			GraphNode<int> wroclaw = new GraphNode<int>(3);

			warsaw.Add(ostrow);
			warsaw.Add(kalisz);

			kalisz.Add(wroclaw);
			wroclaw.Add(kalisz);
			wroclaw.Add(warsaw);

			var result = impl.Bfs(warsaw);
			Console.WriteLine(String.Join(",", result));
			Assert.That(result.SequenceEqual(new int[] { 0, 1, 2, 3 }), Is.True);
		}
	}
}
