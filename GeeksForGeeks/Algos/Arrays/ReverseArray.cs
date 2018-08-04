using NUnit.Framework;
using System;
using System.Linq;

namespace GeeksForGeeks.Algos.Arrays
{
	class ReverseArray
	{
		public void Reverse(char[] array, int first, int last)
		{
			while(first < last)
			{
				var tmp = array[first];
				array[first] = array[last];
				array[last] = tmp;

				first++;
				last--;
			}
		}
	}

	[TestFixture]
	public class TestReverseArray
	{
		[Test]
		public void Test1()
		{
			var input = new char[] { 'c', 'a', 'r', 'b', 'o', 'n' };
			var expected = new char[input.Length];

			Array.Copy(input, expected, input.Length);
			Array.Reverse(expected);

			var sut = new ReverseArray();
			sut.Reverse(input, 0, input.Length - 1);

			var areEqual = input.SequenceEqual(expected);
			Assert.That(areEqual, Is.True);
		}
		
		[Test]
		public void Test2()
		{
			var input = new char[] { 'c' };
			var expected = new char[] { 'c' };

			var sut = new ReverseArray();
			sut.Reverse(input, 0, 0);

			var areEqual = input.SequenceEqual(expected);
			Assert.That(areEqual, Is.True);
		}
	}
}
