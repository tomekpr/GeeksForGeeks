using NUnit.Framework;

namespace GeeksForGeeks.Algos.Bits
{
	// You have 4 cases
	// 0 + 0 = 0
	// 0 + 1 = 1
	// 1 + 0 = 1
	// 1 + 1 = 0 (and generates carry)
	// ^ operator only accomodates basic sums (0+1) and (1+0)
	// but we need to take the carry into account to have full addition
	// and we continue until b (the final carry is 0) because there is nothing
	// to carry over.
	class AddSubtractWithOutBasicOperators
	{
		public int Sum(int a, int b)
		{
			while(b != 0)
			{
				int carry = a & b;
				a = a ^ b;
				b = carry << 1;
			}

			return a;
		}

		public int SumRecursive(int a, int b)
		{
			if (b == 0) return a;

			int carry = a & b;
			a = a ^ b;

			return SumRecursive(a, carry << 1);
		}

		public int Subtraction(int a, int b)
		{
			// sum = a + b
			// sub = a - b
			// -b = bitwise complement
			b = Sum(~b, 1);

			return Sum(a, b);
		}
	}

	[TestFixture]
	public class TestAdditionWithoutOperators
	{
		[Test]
		public void Test1()
		{
			// Just some pre-liminary tests to work out the problem
			var a = 3; // 0011
			var b = 5; // 0101
			var expResult = 6; // 0110

			int xorResult = a ^ b;
			Assert.That(xorResult == expResult);
		}

		[Test]
		public void Test2()
		{
			var a = 3; // 0011
			var b = 5; // 0101
			var expResult = 7; // 0111

			int xorResult = a | b;
			Assert.That(xorResult == expResult);
		}

		[Test]
		public void Test3()
		{
			var a = 3; // 0011
			var b = 5; // 0101
			var expResult = 1; // 0001

			int xorResult = a & b;
			Assert.That(xorResult == expResult);
		}

		[TestCase(3,5,8)]
		[TestCase(10,12,22)]
		public void Test4(int a, int b, int exp)
		{
			var sut = new AddSubtractWithOutBasicOperators();

			var result1 = sut.Sum(a, b);
			var result2 = sut.SumRecursive(a, b);

			Assert.That(result1 == exp);
			Assert.That(result2 == exp);
		}

		[Test]
		public void Test5()
		{
			var a = 5;
			var b = ~a+1;

			Assert.That(b == -5);
		}

		[TestCase(3,5,-2)]
		[TestCase(10,4,6)]
		public void Test6(int a, int b, int exp)
		{
			var sut = new AddSubtractWithOutBasicOperators();
			var result = sut.Subtraction(a, b);

			Assert.That(result == exp);
		}
	}
}
