using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class KnapsackGreedy
	{
		class Item
		{
			public double Pw;
			public int Index;

			public override string ToString()
			{
				return $"Pw: {Pw} Index: {Index}: Hash: {GetHashCode()}";
			}
		}

		public List<double> KnapsackProblem(int[] p, int[] w, int n, int capacity)
		{
			var solution = new List<double>();
			double total = 0;

			var ppw = new SortedDictionary<Item, int>(Comparer<Item>.Create((x, y) => y.Pw.CompareTo(x.Pw) != 0 ? y.Pw.CompareTo(x.Pw) : y.Index.CompareTo(x.Index)));

			for(int i=0; i < n; i++)
			{
				double pw = (double)(p[i] / w[i]);
				var item = new Item();
				item.Pw = pw;
				item.Index = i;

				//Console.WriteLine($"Adding {pw}");
				ppw.Add(item, i);
			}

			foreach(var pw in ppw.Keys)
			{
				//Console.WriteLine($"pw:{pw.Pw} item:{pw.Index}");
				double weight = w[pw.Index];
				if (weight <= ((double)capacity - total))
				{
					total += weight;
					solution.Add(p[pw.Index]);

					Console.WriteLine($"Can take: {weight} with profit: {p[pw.Index]} for item: {pw}");

				}
				else
				{
					double canTake = (double)((capacity - total) / weight);
					double profit = canTake * p[pw.Index];

					total += canTake;
					solution.Add(profit);

					Console.WriteLine($"Can take: {canTake} with profit: {profit} for item: {pw}");
				}

				if ((int)total == capacity) break;
			}

			Console.WriteLine($"Total is: {total}");
			return solution;
		}
	}

	[TestFixture]
	public class TestKnapsackGreedyMethod
	{
		[Test]
		public void Test1()
		{
			int[] p = new int[] { 10, 5, 15, 7, 6, 18, 3 };
			int[] w = new int[] { 2, 3, 5, 7, 1, 4, 1 };

			const int maxCapacity = 15;

			var kp = new KnapsackGreedy();
			var solution = kp.KnapsackProblem(p, w, p.Length, maxCapacity);

			var sum = solution.Sum();
			Console.WriteLine("Total profit: {0}", sum);
		}
	}
}
