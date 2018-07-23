using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class Permutations
	{
		public List<string> Generate(string str)
		{
			var currentPermutations = new List<string>();
			foreach (var c in str)
				Permute(c, currentPermutations);

			return currentPermutations;
		}

		void Permute(char c, List<string> currentPermutations)
		{
			if(currentPermutations.Count == 0)
			{
				currentPermutations.Add(c.ToString());
				return;
			}

			var nextPermutations = new List<string>();
			foreach(var perm in currentPermutations)
			{
				var perms = Permute(c, perm);
				nextPermutations.AddRange(perms);
			}

			currentPermutations.Clear();
			currentPermutations.AddRange(nextPermutations);
		}

		// TBD !!!!!!!!!!!!!!
		List<string> Permute(char c, string permutation)
		{
			var result = new List<string>();

			var sb = new StringBuilder();
			foreach(var p in permutation)
			{
				sb.Append(c);
				sb.Append(p);
			}

			result.Add(sb.ToString());
			sb = new StringBuilder();

			foreach(var p in permutation)
			{
				sb.Append(p);
				sb.Append(c);
			}

			result.Add(sb.ToString());
			return result;
		}
	}

	[TestFixture]
	public class TestPermutations
	{
		[Test]
		public void Test()
		{
			var perm = new Permutations();
			var result = perm.Generate("ab");

			var expected = new List<string>() { "ab", "ba" };
			foreach (var ex in expected)
				Assert.That(result.Contains(ex), Is.True);
		}

		[Test]
		public void Test2()
		{
			var perm = new Permutations();
			var result = perm.Generate("abc");

			var expected = new List<string>() { "cab", "acb","abc", "cba", "bca", "bac" };
			foreach (var ex in expected)
				Assert.That(result.Contains(ex), Is.True);
		}
	}
}
