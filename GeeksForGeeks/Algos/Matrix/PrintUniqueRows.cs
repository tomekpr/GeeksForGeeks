using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Matrix
{
	// Alternative is to use TRIE:
	// https://www.youtube.com/watch?v=GixyVinjtFk
	class PrintUniqueRows
	{
		public List<bool[]> PrintUnique(bool[][] m)
		{
			var index = new HashSet<string>();
			foreach (var row in m)
			{
				var enc = Enc(row);
				if (!index.Contains(enc))
					index.Add(enc);
			}

			return index.Select(s => Dec(s)).ToList();
		}

		private string Enc(bool[] row)
		{
			var sb = new StringBuilder();
			for(int i=0; i < row.Length; i++)
			{
				sb.Append(row[i] ? 'T' : 'F');
			}

			return sb.ToString();
		}

		private bool[] Dec(string s)
		{
			var result = new List<bool>();
			foreach (var c in s)
				result.Add(c == 'T');

			return result.ToArray();
		}
	}

	[TestFixture]
	public class TestPrintUniqueRows
	{
		[Test]
		public void Test1()
		{
			var row1 = new bool[] { true, true, true };
			var row2 = new bool[] { true, false, true };

			var set = new HashSet<bool[]>();
			set.Add(row1);
			set.Add(row2);

			var lookupKey = new bool[] { false, true, false };
			Assert.IsFalse(set.Contains(lookupKey));
			Assert.IsTrue(set.Count == 2);
		}

		[Test]
		public void Test2()
		{
			bool[][] m = new bool[4][];
			m[0] = new bool[] { false, true, false, false, true };
			m[1] = new bool[] { true, false, true, true, false };
			m[2] = new bool[] { false, true, false, false, true };
			m[3] = new bool[] { true, true, true, false, false };

			bool[][] exp = new bool[3][];
			exp[0] = new bool[] { false, true, false, false, true };
			exp[1] = new bool[] { true, false, true, true, false };
			exp[2] = new bool[] { true, true, true, false, false };

			var print = new PrintUniqueRows();
			var result = print.PrintUnique(m);

			Assert.IsTrue(result.Count == 3);
			for (int i = 0; i < exp.Length; i++)
			{
				var eq = exp[i].SequenceEqual(result[i]);
				Assert.IsTrue(eq, String.Join(",", result[i]));
			}
		}
	}
}
