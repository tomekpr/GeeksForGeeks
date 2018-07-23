using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class PartitionItemsInArray
	{
		public List<int> Partition(int[] arr, int p)
		{
			var lessThan = new List<int>();
			var greaterThan = new List<int>();

			foreach (var a in arr)
			{
				if (a < p) lessThan.Add(a);
				else greaterThan.Add(a);
			}

			return lessThan.Union(greaterThan).ToList();
		}

		public void ParititionInPlace(int[] arr, int p)
		{
			// result directly stored in array
			// input:  { 3, 50, 2, 11, 42, 8, 4 }; & p = 20
			// read and write pointers, swap locations, move right
			// read always moves, write only if we save anything

			int read = 0, write = 0;
			while (read < arr.Length && write < arr.Length)
			{
				if (arr[read] < p)
				{
					var tmp = arr[read];
					arr[read] = arr[write];
					arr[write] = tmp;

					write++;
				}

				read++;
			}
		}

		public List<int> PartitionPolicy(int[] arr, Func<int, bool> policy)
		{
			var p1 = new List<int>();
			var notP1 = new List<int>();

			foreach (var a in arr)
			{
				if (policy(a)) p1.Add(a);
				else notP1.Add(a);
			}

			return p1.Union(notP1).ToList();
		}

		public void PartitionPolicyInPlace(int[] arr, Func<int, bool> policy)
		{
			int read = 0, write = 0;
			while (read < arr.Length && write < arr.Length)
			{
				if (policy(arr[read]))
				{
					var tmp = arr[read];
					arr[read] = arr[write];
					arr[write] = tmp;

					write++;
				}

				read++;
			}
		}

		public void PartitionThreeWayInPlace(int[] arr, Func<int, int> threeWay)
		{
			int read = 0;
			int write = 0;

			int topwrite = arr.Length - 1;
			int stop = arr.Length - 1;

			while(read <= stop)
			{
				var direction = threeWay(arr[read]);
				if (direction == 0)
				{
					var tmp = arr[write];
					arr[write] = arr[read];
					arr[read] = tmp;

					read++;
					write++;
				}
				else if (direction == 1) read++;
				else
				{
					var tmp = arr[topwrite];
					arr[topwrite] = arr[read];
					arr[read] = tmp;

					stop--;
					topwrite--;
				}
			}
		}
	}

	[TestFixture]
	public class TestPartitionsItemsInArray
	{
		[Test]
		public void Test1()
		{
			var arr = new int[] { 3, 50, 2, 11, 42, 8, 4 };
			var p = 20;

			var par = new PartitionItemsInArray();
			var result = par.Partition(arr, p);

			Assert.That(result.SequenceEqual(new int[] { 3, 2, 11, 8, 4, 50, 42 }), Is.True);
		}

		[Test]
		public void TestPartitionInPlace()
		{
			var arr = new int[] { 3, 50, 2, 11, 42, 8, 4 };
			var p = 20;

			var par = new PartitionItemsInArray();
			par.ParititionInPlace(arr, p);

			Assert.That(arr.SequenceEqual(new int[] { 3, 2, 11, 8, 4, 50, 42 }), Is.True);
		}

		[Test]
		public void TestPartitionAccordingToAPolicy()
		{
			var arr = new int[] { 3, 50, 2, 11, 42, 8, 4 };

			Func<int, bool> policy = (n) => n % 2 == 0;

			var par = new PartitionItemsInArray();
			var result = par.PartitionPolicy(arr, policy);

			Assert.That(result.SequenceEqual(new int[] { 50, 2, 42, 8, 4, 3, 11 }), Is.True);
		}

		[Test]
		public void TestPartitionAccordingToAPolicyInPlace()
		{
			var arr = new int[] { 3, 50, 2, 11, 42, 8, 4 };

			Func<int, bool> policy = (n) => n % 2 == 0;

			var par = new PartitionItemsInArray();
			par.PartitionPolicyInPlace(arr, policy);

			Assert.That(arr.SequenceEqual(new int[] { 50, 2, 42, 8, 4, 11, 3 }), Is.True);
		}

		[Test]
		public void TestPartitionForPrimeNumbersInPlace()
		{
			Func<int, bool> isPrime = (n) =>
			 {
				 if (n < 2) return false;
				 if (n == 2) return true;

				 int max = (int)Math.Pow(n, 0.5) + 1;
				 for (int i = 2; i < max; i++)
					 if (n % i == 0) return false;

				 return true;
			 };

			var arr = new int[] { 3, 50, 2, 11, 42, 8, 4 };

			var par = new PartitionItemsInArray();
			par.PartitionPolicyInPlace(arr, isPrime);

			Assert.That(arr.SequenceEqual(new int[] { 3, 2, 11, 50, 42, 8, 4 }), Is.True);
		}

		[Test]
		public void PartitionInPlaceThreeWayJustLikeInDutchNationalFlagProblem()
		{
			Func<int, int> threeWay = n => n;
			var arr = new int[] { 1, 0, 2, 0, 0, 1, 1, 2, 1, 2 };

			var par = new PartitionItemsInArray();
			par.PartitionThreeWayInPlace(arr, threeWay);

			Assert.That(arr.SequenceEqual(new int[] { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2 }), Is.True);
		}
	}
}
