using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Combinations
{
	// https://www.youtube.com/watch?v=tE9EF-2Jw8U
	class AllCombOfStringsToDialAnumber
	{
		private static readonly Dictionary<int, List<char>> digitToLetters = new Dictionary<int, List<char>>
		{
			{0, new List<char> {'0'}},
			{1, new List<char> {'1'} },
			{2, new List<char> {'A','B','C'} },
			{3, new List<char> {'D', 'E','F'} },
			{8, new List<char> {'T','U','V'} },
			{9, new List<char> {'W','X','Y','Z'} }
		};

		private static readonly Dictionary<char, List<char>> inputToLetters = new Dictionary<char, List<char>>
		{
			{'0', new List<char> {'0'}},
			{'1', new List<char> {'1'} },
			{'2', new List<char> {'A','B','C'} },
			{'3', new List<char> {'D', 'E','F'} },
			{'8', new List<char> {'T','U','V'} },
			{'9', new List<char> {'W','X','Y','Z'} }
		};

		public List<string> GenerateV2(string phoneNumber)
		{
			var result = new List<string>();
			var sb = new StringBuilder();
			GenerateCombinationsV2(phoneNumber, 0, sb, result);

			return result;
		}

		void GenerateCombinationsV2(string phoneNumber, int currentDigit, StringBuilder output, List<string> finalResult)
		{
			if (currentDigit == phoneNumber.Length)
			{
				finalResult.Add(output.ToString());
				return;
			}

			var s = inputToLetters[phoneNumber[currentDigit]];
			for (int j = 0; j < s.Count; j++)
			{
				output.Append(s[j]);
				GenerateCombinationsV2(phoneNumber, currentDigit + 1, output, finalResult);
				output.Remove(output.Length - 1, 1);
			}
		}

		public List<string> Generate(int[] nums)
		{
			var result = new List<string>();
			foreach (var n in nums)
				result = GenerateCombinations(result, n);

			return result;
		}

		List<string> GenerateCombinations(List<string> current, int n)
		{
			if (current.Count == 0) return digitToLetters[n].Select(x => x.ToString()).ToList();

			var result = new List<string>();
			foreach (var c in current)
			{
				foreach (var next in digitToLetters[n])
				{
					result.Add($"{c}{next}");
				}
			}

			return result;
		}
	}

	[TestFixture]
	public class TestAllCombOfStringsToDialAnumber
	{
		[Test]
		public void Test1()
		{
			var expected = new List<string>() { "AD", "AE", "AF", "BD", "BE", "BF", "CD", "CE", "CF" };
			var comb = new AllCombOfStringsToDialAnumber();

			var actual = comb.Generate(new int[] { 2, 3 });
			var areEqual = actual.SequenceEqual(expected);

			Assert.That(areEqual, Is.True);
		}

		[Test]
		public void Test2()
		{
			var expected = new List<string>() { "AD", "AE", "AF", "BD", "BE", "BF", "CD", "CE", "CF" };
			var comb = new AllCombOfStringsToDialAnumber();

			var actual = comb.GenerateV2("23");
			var areEqual = actual.SequenceEqual(expected);

			Assert.That(areEqual, Is.True);
		}
	}
}
