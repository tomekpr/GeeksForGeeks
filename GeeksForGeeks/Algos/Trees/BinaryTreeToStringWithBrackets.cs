using NUnit.Framework;
using System;
using System.Text;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=ymIgl_tFAwQ
	class BinaryTreeToStringWithBrackets
	{
		public string ToStringWithBrackets(BinaryNode bnode)
		{
			var sb = new StringBuilder();
			PreOrder(bnode, sb);
			return sb.ToString();
		}

		void PreOrder(BinaryNode node, StringBuilder sb)
		{
			// base case
			if (node == null)
				return;

			// root as string
			sb.Append(node.Value);

			// no children - exit early
			if (node.Left == null && node.Right == null) return;

			// process left tree
			sb.Append("(");
			PreOrder(node.Left, sb);
			sb.Append(")");

			// process right tree, only if it exists, otherwise we will have () printed and we will have to deal with that
			// () is needed for left subtree, to indicate correctly pre-order, but not for right subtree!
			if(node.Right != null)
			{
				sb.Append("(");
				PreOrder(node.Right, sb);
				sb.Append(")");
			}
		}
	}

	[TestFixture]
	public class TestBinaryTreeToStringWithBrackets
	{
		[Test]
		public void Test1()
		{
			var tree = new BinaryNode(1);
			tree.Left = new BinaryNode(2);
			tree.Left.Left = new BinaryNode(4);

			tree.Right = new BinaryNode(3);

			var printer = new BinaryTreeToStringWithBrackets();
			var actual = printer.ToStringWithBrackets(tree);

			var exp = "1(2(4))(3)";

			Console.WriteLine("actual: {0}", actual);
			Console.WriteLine("   exp: {0}", exp);

			Assert.That(actual, Is.EqualTo(exp));
		}

		[Test]
		public void Test2()
		{
			var tree = new BinaryNode(1);
			tree.Left = new BinaryNode(2);
			tree.Left.Right = new BinaryNode(4);

			tree.Right = new BinaryNode(3);

			var printer = new BinaryTreeToStringWithBrackets();
			var actual = printer.ToStringWithBrackets(tree);

			var exp = "1(2()(4))(3)";

			Console.WriteLine("actual: {0}", actual);
			Console.WriteLine("   exp: {0}", exp);

			Assert.That(actual, Is.EqualTo(exp));
		}
	}
}
