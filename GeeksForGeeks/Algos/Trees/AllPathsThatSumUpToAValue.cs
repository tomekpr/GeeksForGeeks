using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class AllPathsThatSumUpToAValue
	{
		List<List<int>> FindAllPaths(BinaryNode root, int val)
		{
			/* redo it */
			return null;
		}

		[Test]
		public void Test1()
		{
			var root = new BinaryNode(4);
			var two = new BinaryNode(2);
			var nine = new BinaryNode(9);

			var one = new BinaryNode(1);
			var three = new BinaryNode(3);

			var minusSix = new BinaryNode(-6);

			root.Left = two;
			root.Right = nine;

			two.Left = one;
			two.Right = three;

			nine.Right = minusSix;

			var paths = FindAllPaths(root, 7);
			Assert.That(paths.Count, Is.EqualTo(2));
			foreach (var p in paths)
				Console.WriteLine("Path: {0}", string.Join(",", paths));
		}

		struct TKey
		{
			public int Val;
			public bool IsLeft;

			public TKey(int v, bool left)
			{
				Val = v;
				IsLeft = left;
			}
		}

		struct TValue
		{
			public BinaryNode Node;
			public int Sum;

			public TValue(BinaryNode bn, int sum)
			{
				Node = bn;
				Sum = sum;
			}
		}
	}
}
