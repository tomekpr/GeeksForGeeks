using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Graphs
{
	class DetectCycleInAGraph
	{
		public bool HasCycle<T>(GraphNode<T> start) where T : struct, IComparable<T>
		{
			var pending = new Queue<GraphNode<T>>();
			foreach (var adj in start.Adjacent)
				pending.Enqueue(adj);

			while(pending.Any())
			{
				var next = pending.Dequeue();

				if (next == null || next.Visisted)
				{
					continue;
				}

				next.Visisted = true;
				if (next.Val.CompareTo(start.Val) == 0)
				{
					Console.WriteLine("{0} is equal to {1}", next.Val, start.Val);
					return true;
				}

				Console.WriteLine("{0} is NOT equal to {1}", next.Val, start.Val);
				
				foreach (var adj in next.Adjacent)
					pending.Enqueue(adj);
			}

			return false;
		}
	}

	[TestFixture]
	public class TestDetectCycleInAGraph
	{
		[Test]
		public void Test1()
		{
			var start = new GraphNode<int>(10);
			var twenty = new GraphNode<int>(20);
			var thirty = new GraphNode<int>(30);

			start.Add(twenty);
			twenty.Add(thirty);
			thirty.Add(start);

			var detect = new DetectCycleInAGraph();
			var hasCycle = detect.HasCycle(start);

			Assert.IsTrue(hasCycle);
		}

		[Test]
		public void Test2()
		{
			var start = new GraphNode<int>(10);
			var twenty = new GraphNode<int>(20);
			var thirty = new GraphNode<int>(30);

			start.Add(twenty);
			twenty.Add(thirty);

			var detect = new DetectCycleInAGraph();
			var hasCycle = detect.HasCycle(start);

			Assert.IsFalse(hasCycle);
		}

		[Test]
		public void Test3()
		{
			var a = new GraphNode<char>('A');
			var b = new GraphNode<char>('B');
			var e = new GraphNode<char>('E');
			var f = new GraphNode<char>('F');
			var d = new GraphNode<char>('D');

			a.Add(b);
			b.Add(e);
			e.Add(f);
			f.Add(d);
			d.Add(a);

			// another branch
			var c = new GraphNode<char>('C');
			var g = new GraphNode<char>('G');

			a.Add(c);
			c.Add(g);

			// another branch
			var x = new GraphNode<char>('X');
			var w = new GraphNode<char>('W');
			var k = new GraphNode<char>('K');

			c.Add(x);
			x.Add(w);
			w.Add(k);
			
			var detect = new DetectCycleInAGraph();
			var hasCycle = detect.HasCycle(a);

			Assert.IsTrue(hasCycle);
		}
	}
}
