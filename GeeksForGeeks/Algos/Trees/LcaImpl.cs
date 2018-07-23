using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	public class LcaImpl
	{
		public BinaryNodeWithParent Lca(BinaryNodeWithParent root, BinaryNodeWithParent a, BinaryNodeWithParent b)
		{
			var pathFromA = new HashSet<BinaryNode>();
			var tmp = a;

			while(tmp != null)
			{
				pathFromA.Add(tmp);
				tmp = tmp = tmp.Parent;
			}

			tmp = b;

			while(tmp != null)
			{
				if (pathFromA.Contains(tmp)) return tmp;
				tmp = tmp.Parent;
			}

			return null;
		}
	}

	[TestFixture]
	public class TestLcaImpl
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNodeWithParent() { Value = 1 };
			var three = new BinaryNodeWithParent() { Value = 3, Parent = root };
			var two = new BinaryNodeWithParent() { Value = 2, Parent = root };

			var four = new BinaryNodeWithParent() { Value = 4, Parent = three };
			var six = new BinaryNodeWithParent() { Value = 6, Parent = three };
			var five = new BinaryNodeWithParent() { Value = 5, Parent = six };

			root.Left = three;
			root.Right = two;

			three.Left = four;
			three.Right = six;

			six.Left = five;

			var impl = new LcaImpl();
			var res = impl.Lca(root, four, five);

			Assert.That(res.Value, Is.EqualTo(3));
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNodeWithParent() { Value = 1 };
			var three = new BinaryNodeWithParent() { Value = 3, Parent = root };
			var two = new BinaryNodeWithParent() { Value = 2, Parent = root };

			var four = new BinaryNodeWithParent() { Value = 4, Parent = three };
			var six = new BinaryNodeWithParent() { Value = 6, Parent = three };
			var five = new BinaryNodeWithParent() { Value = 5, Parent = six };

			root.Left = three;
			root.Right = two;

			three.Left = four;
			three.Right = six;

			six.Left = five;

			var impl = new LcaImpl();
			var res = impl.Lca(root, three, five);

			Assert.That(res.Value, Is.EqualTo(3));
		}

		[Test]
		public void Test3()
		{
			var root = new BinaryNodeWithParent() { Value = 1 };
			var three = new BinaryNodeWithParent() { Value = 3, Parent = root };
			var two = new BinaryNodeWithParent() { Value = 2, Parent = root };

			var four = new BinaryNodeWithParent() { Value = 4, Parent = three };
			var six = new BinaryNodeWithParent() { Value = 6, Parent = three };
			var five = new BinaryNodeWithParent() { Value = 5, Parent = six };

			root.Left = three;
			root.Right = two;

			three.Left = four;
			three.Right = six;

			six.Left = five;

			var impl = new LcaImpl();
			var res = impl.Lca(root, four, two);

			Assert.That(res.Value, Is.EqualTo(1));
		}

		[Test]
		public void Test4()
		{
			var root = new BinaryNodeWithParent() { Value = 1 };
			var three = new BinaryNodeWithParent() { Value = 3, Parent = root };
			var two = new BinaryNodeWithParent() { Value = 2, Parent = root };

			var four = new BinaryNodeWithParent() { Value = 4, Parent = three };
			var six = new BinaryNodeWithParent() { Value = 6, Parent = three };
			var five = new BinaryNodeWithParent() { Value = 5, Parent = six };

			root.Left = three;
			root.Right = two;

			three.Left = four;
			three.Right = six;

			six.Left = five;

			var impl = new LcaImpl();
			var res = impl.Lca(root, six, six);

			Assert.That(res.Value, Is.EqualTo(6));
		}
	}
}
