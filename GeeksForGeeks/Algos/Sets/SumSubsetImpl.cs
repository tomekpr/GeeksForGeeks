using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class SumSubsetImpl
	{
		public List<List<int>> SubsetsThatSumTo(int[] w, int sum)
		{
			var allSolutions = new List<List<int>>();

			LeadsToSolution(new List<int>(), 0, w.Length, sum, 0, w, allSolutions);

			return allSolutions;
		}

		bool LeadsToSolution(List<int> testSolution, int elementsInSolution, int maxElementsToUse, int sum, int nextElement, int[] w, List<List<int>> allSolutions)
		{
			int localSum = testSolution.Sum();
			if (localSum == sum)
			{
				//Console.WriteLine($"Sol found!: {String.Join(",", testSolution)}");
				allSolutions.Add(new List<int>(testSolution));
				return false;
			}

			if (localSum < sum && elementsInSolution == maxElementsToUse)
			{
				//Console.WriteLine($"Not a solution: {String.Join(",", testSolution)}");
				return false; // Exhausted all possibilities!
			}

			//Console.WriteLine($"Not a solution: {String.Join(",", testSolution)}");
			for (int i = nextElement; i < maxElementsToUse; i++)
			{
				testSolution.Add(w[i]);
				if (LeadsToSolution(testSolution, elementsInSolution + 1, maxElementsToUse, sum, i + 1, w, allSolutions))
				{
					return true;
				}
				else
				{
					// remove last item i.e. backtrack
					testSolution.RemoveAt(testSolution.Count - 1);
				}
			}

			return false;
		}
	}

	[TestFixture]
	public class TestSumSubsetImpl
	{
		[Test]
		public void Test1()
		{
			int[] w = new int[] { 1, 2, 3 };
			int sum = 7;

			var impl = new SumSubsetImpl();
			var result = impl.SubsetsThatSumTo(w, sum);

			Console.WriteLine($"Found: {result.Count} solutions");
			foreach (var r in result)
			{
				Console.WriteLine(String.Join(",", r));
			}
		}

		[Test]
		public void Test2()
		{
			int[] w = new int[] { 5,10,12,13,15,18 };
			int sum = 30;

			var impl = new SumSubsetImpl();
			var result = impl.SubsetsThatSumTo(w, sum);

			Console.WriteLine($"Found: {result.Count} solutions");
			foreach (var r in result)
			{
				Console.WriteLine(String.Join(",", r));
			}
		}

		[Test]
		public void Test3()
		{
			int[] w = new int[] { 2,3,6,7 };
			int sum = 7;

			var impl = new SumSubsetImpl();
			var result = impl.SubsetsThatSumTo(w, sum);

			Console.WriteLine($"Found: {result.Count} solutions");
			foreach (var r in result)
			{
				Console.WriteLine(String.Join(",", r));
			}
		}

		[Test]
		public void Test4()
		{
			int[] w = new int[] { 2, 3, 5 };
			int sum = 8;

			var impl = new SumSubsetImpl();
			var result = impl.SubsetsThatSumTo(w, sum);

			Console.WriteLine($"Found: {result.Count} solutions");
			foreach (var r in result)
			{
				Console.WriteLine(String.Join(",", r));
			}
		}
	}
}
