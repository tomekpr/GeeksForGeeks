using NUnit.Framework;

namespace GeeksForGeeks.Algos.Trees
{
	// Alternatively use simple pre-order or level order traversal.
	// https://www.youtube.com/watch?v=_Hehd1KSq7Y
	class IsFullBinaryTree
	{
		public bool IsFullBT(BinaryNode bn)
		{
			if (bn == null) return true;
			//System.Console.WriteLine($"Checking:{bn.Value}");
			if (bn.HasOnlyOneChild()) return false;

			return IsFullBT(bn.Left) && IsFullBT(bn.Right);
		}
	}

	[TestFixture]
	public class TestIsFullBinaryTree
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(1);
			root.Left = new BinaryNode(2);
			root.Right = new BinaryNode(3);

			root.Left.Left = new BinaryNode(4);
			root.Left.Right = new BinaryNode(5);

			var sut = new IsFullBinaryTree();
			var result = sut.IsFullBT(root);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNode(1);
			root.Left = new BinaryNode(2);
			root.Right = new BinaryNode(3);

			root.Left.Left = new BinaryNode(4);

			var sut = new IsFullBinaryTree();
			var result = sut.IsFullBT(root);

			Assert.That(result, Is.False);
		}

		[Test]
		public void Test3()
		{
			var root = new BinaryNode(1);
			root.Right = new BinaryNode(3);
			root.Right.Left = new BinaryNode(4);

			var sut = new IsFullBinaryTree();
			var result = sut.IsFullBT(root);

			Assert.That(result, Is.False);
		}

		[Test]
		public void Test4()
		{
			var root = new BinaryNode(1);

			var sut = new IsFullBinaryTree();
			var result = sut.IsFullBT(root);

			Assert.That(result, Is.True);
		}
	}
}
