using NUnit.Framework;
using System;
using System.Linq;

namespace GeeksForGeeks
{
	class SubsetGeneration
	{
		public void Generate(int[] set)
		{
			var subset = new int?[set.Length];
			Generate(set, subset, 0);
		}

		public void Generate(int n)
		{
			Generate(Enumerable.Range(1, n).ToArray());
		}

		void Generate(int[] set, int?[] subset, int i)
		{
			if (i == set.Length)
			{
				Print(subset);
			}
			else
			{
				subset[i] = null;
				Generate(set, subset, i + 1);
				subset[i] = set[i];
				Generate(set, subset, i + 1);
			}
		}

		void Print(int?[] ss)
		{
			foreach (var n in ss)
				if(n != null)
					Console.Write($"{n}.");

			if (ss.All(s => s == null))
				Console.Write("{}");

			Console.WriteLine("");
		}
	}

	[TestFixture]
	public class TestSubsetGeneration
	{
		[Test]
		public void Test()
		{
			var sg = new SubsetGeneration();
			sg.Generate(new int[] { 1, 2 });
		}

		[Test]
		public void Test2()
		{
			var sg = new SubsetGeneration();
			sg.Generate(5);
		}
	}
}
