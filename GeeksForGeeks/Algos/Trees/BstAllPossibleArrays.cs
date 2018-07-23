using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Trees
{
	class BstAllPossibleArrays
	{
		public List<List<int>> AllPossibleArrays(List<string> lines)
		{
			int edgeCount = Int32.Parse(lines.First().Split(' ')[0]);
			int root = Int32.Parse(lines.First().Split(' ')[1]);

			var solutions = new List<List<int>>();
			solutions.Add(new List<int>() { root });

			for (int i = 2; i < lines.Count;)
			{
				var edge1 = Edge.ToEdge(lines[i - 1]);
				var edge2 = Edge.ToEdge(lines[i]);

				solutions = ExtendSolution(solutions, edge1, edge2);
				if (edge1.FromParent == edge2.FromParent)
					i += 2;
				else i++;
			}

			return solutions;
		}

		List<List<int>> ExtendSolution(List<List<int>> solutions, Edge e1, Edge e2)
		{
			if (e1.FromParent != e2.FromParent)
			{
				ExtendSolution(solutions, e1);
				return solutions;
			}

			return AppendSolutions(solutions, new int[] { e1.ToChild, e2.ToChild });
		}

		List<List<int>> AppendSolutions(List<List<int>> solutions, int[] items)
		{
			var result = new List<List<int>>();
			foreach (var s in solutions)
			{
				var newList1 = s.Union(items).ToList();
				var newList2 = s.Union(items.Reverse()).ToList();

				result.Add(newList1);
				result.Add(newList2);
			}

			return result;
		}

		void ExtendSolution(List<List<int>> solutions, Edge e)
		{
			foreach (var s in solutions)
				s.Add(e.ToChild);
		}

		class Edge
		{
			public int FromParent;
			public int ToChild;

			public static Edge ToEdge(string l)
			{
				var split = l.Split(' ');
				var edge = new Edge()
				{
					FromParent = int.Parse(split[0]),
					ToChild = int.Parse(split[1])
				};

				return edge;
			}
		}
	}

	[TestFixture]
	public class TestBstAllPossibleArrays
	{
		[Test]
		public void Test1()
		{
			var lines = new List<string>();
			lines.Add("2 4");
			lines.Add("4 2");
			lines.Add("4 9");

			var expected = new List<List<int>>();
			expected.Add(new List<int>() { 4, 2, 9 });
			expected.Add(new List<int>() { 4, 9, 2 });

			var sut = new BstAllPossibleArrays();
			var result = sut.AllPossibleArrays(lines);

			for (int i = 0; i < expected.Count; i++)
			{
				var areEqual = expected[i].SequenceEqual(result[i]);
				Assert.IsTrue(areEqual);
			}
		}

		[Test]
		public void Test2()
		{
			var lines = new List<string>();
			lines.Add("2 4");
			lines.Add("4 2");
			lines.Add("4 9");
			lines.Add("2 3");
			lines.Add("9 6");
			lines.Add("9 12");

			var expected = new List<List<int>>();
			expected.Add(new List<int>() { 4, 2, 9, 3, 6, 12 });
			expected.Add(new List<int>() { 4, 2, 9, 3, 12, 6 });
			expected.Add(new List<int>() { 4, 9, 2, 3, 6, 12 });
			expected.Add(new List<int>() { 4, 9, 2, 3, 12, 6 });

			var sut = new BstAllPossibleArrays();
			var result = sut.AllPossibleArrays(lines);

			for (int i = 0; i < expected.Count; i++)
			{
				var areEqual = expected[i].SequenceEqual(result[i]);
				Assert.IsTrue(areEqual);
			}
		}
	}
}
