using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class BuildTreeFromSorted
	{
		public BinaryNode BuildTree(int[] nums)
		{
			return Build(nums, 0, nums.Length - 1);
		}

		BinaryNode Build(int[] nums, int left, int right)
		{
			if (left == right) return new BinaryNode(nums[left]);
			if (left > right) return null;

			int mid = (int)Math.Floor((left + right) / 2.0);
			var root = new BinaryNode(nums[mid]);
			root.Left = Build(nums, left, mid - 1);
			root.Right = Build(nums, mid + 1, right);

			return root;
		}
	}

	[TestFixture]
	public class TestBuildBinaryTree
	{
		[Test]
		public void Test1()
		{
			var nums = new int[] { 2, 4, 6, 8, 10 };

			var builder = new BuildTreeFromSorted();
			var root = builder.BuildTree(nums);

			Assert.That(root.Value, Is.EqualTo(6));
			Assert.That(root.Left.Value, Is.EqualTo(2));
			Assert.That(root.Left.Left, Is.Null);
			Assert.That(root.Left.Right.Value, Is.EqualTo(4));

			Assert.That(root.Right.Value, Is.EqualTo(8));
			Assert.That(root.Right.Left, Is.Null);
			Assert.That(root.Right.Right.Value, Is.EqualTo(10));
		}
	}
}
