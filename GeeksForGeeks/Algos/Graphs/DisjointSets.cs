using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks
{
	public class DisjointSetsImpl
	{
		public List<int> Set;

		public bool HasCycle(List<GraphNode<int>> vertices)
		{
			int[] array = new List<int>(Enumerable.Repeat(-1, vertices.Count())).ToArray();

			foreach (var v in vertices)
			{
				var from = v;
				var to = v.Adjacent.FirstOrDefault();
				if (to == null) continue;

				var parent = array[from.Val - 1];
				var parentChild = array[to.Val - 1];

				if (parent == -1 && parentChild == -1)
				{
					array[from.Val - 1] = -2;
					array[to.Val - 1] = from.Val - 1;
				}

				// perform union?
			}

			Set = array.ToList();

			return false;
		}
	}

	[TestFixture]
	public class TestDisjointSetImpl
	{
		DisjointSetsImpl impl;

		[SetUp]
		public void Setup()
		{
			impl = new DisjointSetsImpl();
		}

		[Test]
		public void Test1()
		{
			GraphNode<int> one = new GraphNode<int>(1);
			GraphNode<int> two = new GraphNode<int>(2);

			one.Add(two);

			bool result = impl.HasCycle(new List<GraphNode<int>>() { one, two });
			Assert.That(result, Is.False);

			Assert.That(impl.Set.Count(), Is.EqualTo(2), "Invalid set count");
			Assert.That(impl.Set[0], Is.EqualTo(-2));
			Assert.That(impl.Set[1], Is.EqualTo(0));
		}

		[Test]
		public void Test2()
		{
			GraphNode<int> one = new GraphNode<int>(1);
			GraphNode<int> two = new GraphNode<int>(2);

			one.Add(two);

			GraphNode<int> three = new GraphNode<int>(3);
			GraphNode<int> four = new GraphNode<int>(4);

			three.Add(four);

			bool result = impl.HasCycle(new List<GraphNode<int>>() { one, two, three, four });
			Assert.That(result, Is.False);

			Assert.That(impl.Set.Count(), Is.EqualTo(4), "Invalid set count");
			Assert.That(impl.Set[0], Is.EqualTo(-2));
			Assert.That(impl.Set[1], Is.EqualTo(0));

			Assert.That(impl.Set[2], Is.EqualTo(-2));
			Assert.That(impl.Set[3], Is.EqualTo(2));
		}

		[Test]
		public void Test3()
		{
			GraphNode<int> one = new GraphNode<int>(1);
			GraphNode<int> two = new GraphNode<int>(2);

			one.Add(two);

			GraphNode<int> three = new GraphNode<int>(3);
			GraphNode<int> four = new GraphNode<int>(4);

			three.Add(four);

			GraphNode<int> five = new GraphNode<int>(5);
			GraphNode<int> six = new GraphNode<int>(6);

			five.Add(six);

			bool result = impl.HasCycle(new List<GraphNode<int>>() { one, two, three, four, five, six });
			Assert.That(result, Is.False);

			Assert.That(impl.Set.Count(), Is.EqualTo(6), "Invalid set count");
			Assert.That(impl.Set[0], Is.EqualTo(-2));
			Assert.That(impl.Set[1], Is.EqualTo(0));

			Assert.That(impl.Set[2], Is.EqualTo(-2));
			Assert.That(impl.Set[3], Is.EqualTo(2));

			Assert.That(impl.Set[4], Is.EqualTo(-2));
			Assert.That(impl.Set[5], Is.EqualTo(4));
		}

		[Test]
		public void Test4()
		{
			GraphNode<int> one = new GraphNode<int>(1);
			GraphNode<int> two = new GraphNode<int>(2);

			one.Add(two);

			GraphNode<int> three = new GraphNode<int>(3);
			GraphNode<int> four = new GraphNode<int>(4);

			three.Add(four);

			GraphNode<int> five = new GraphNode<int>(5);
			GraphNode<int> six = new GraphNode<int>(6);

			five.Add(six);

			var seven = new GraphNode<int>(7);
			var eight = new GraphNode<int>(8);

			seven.Add(eight);

			bool result = impl.HasCycle(new List<GraphNode<int>>() { one, two, three, four, five, six, seven, eight });
			Assert.That(result, Is.False);

			Assert.That(impl.Set.Count(), Is.EqualTo(8), "Invalid set count");
			Assert.That(impl.Set[0], Is.EqualTo(-2));
			Assert.That(impl.Set[1], Is.EqualTo(0));

			Assert.That(impl.Set[2], Is.EqualTo(-2));
			Assert.That(impl.Set[3], Is.EqualTo(2));

			Assert.That(impl.Set[4], Is.EqualTo(-2));
			Assert.That(impl.Set[5], Is.EqualTo(4));

			Assert.That(impl.Set[6], Is.EqualTo(-2));
			Assert.That(impl.Set[7], Is.EqualTo(6));
		}

		[Test]
		public void Test5()
		{
			GraphNode<int> one = new GraphNode<int>(1);
			GraphNode<int> two = new GraphNode<int>(2);

			one.Add(two);

			GraphNode<int> three = new GraphNode<int>(3);
			GraphNode<int> four = new GraphNode<int>(4);

			three.Add(four);

			GraphNode<int> five = new GraphNode<int>(5);
			GraphNode<int> six = new GraphNode<int>(6);

			five.Add(six);

			var seven = new GraphNode<int>(7);
			var eight = new GraphNode<int>(8);

			seven.Add(eight);

			var two2 = new GraphNode<int>(2);
			var four2 = new GraphNode<int>(4);

			two2.Add(four2);

			bool result = impl.HasCycle(new List<GraphNode<int>>() { one, two, three, four, five, six, seven, eight, two2, four2 });
			Assert.That(result, Is.False);

			Assert.That(impl.Set.Count(), Is.EqualTo(8), "Invalid set count");
			Assert.That(impl.Set[0], Is.EqualTo(-4));
			Assert.That(impl.Set[1], Is.EqualTo(0));

			Assert.That(impl.Set[2], Is.EqualTo(1));
			Assert.That(impl.Set[3], Is.EqualTo(2));

			Assert.That(impl.Set[4], Is.EqualTo(-2));
			Assert.That(impl.Set[5], Is.EqualTo(4));

			Assert.That(impl.Set[6], Is.EqualTo(-2));
			Assert.That(impl.Set[7], Is.EqualTo(6));
		}
	}
}
