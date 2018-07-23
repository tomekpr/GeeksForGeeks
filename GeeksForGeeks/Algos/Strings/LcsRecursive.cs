using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class LcsRecursive
	{
		public static int CallCount = 0;

		public int LCS(string a, string b, int i, int j)
		{
			CallCount++;

			if (i == a.Length || j == b.Length) return 0;

			if (a[i] == b[j]) return 1 + LCS(a, b, i + 1, j + 1);

			return Math.Max(LCS(a, b, i + 1, j), LCS(a, b, i, j + 1));
		}

		public int LCS2(string a, string b)
		{
			int[][] temp = new int[a.Length + 1][];
			for (int k = 0; k < a.Length + 1; k++)
				temp[k] = new int[b.Length + 1];

			int max = 0;

			int maxi = 0;
			int maxj = 0;

			for (int i = 1; i < temp.Length; i++)
			{
				for (int j = 1; j < temp[i].Length; j++)
				{
					// if previous matched then add 1 to the previous LCS and treat as new LCS
					if (a[i - 1] == b[j - 1])
					{
						temp[i][j] = temp[i - 1][j - 1] + 1;
					}
					else
					{
						// take the LCS from one of the aligned strings previously.
						temp[i][j] = Math.Max(temp[i][j - 1], temp[i - 1][j]);
					}
					if (temp[i][j] > max)
					{
						max = temp[i][j];
						maxi = i;
						maxj = j;
					}
				}
			}

			string result = "";
			maxi = maxi >= a.Length ? a.Length - 1 : maxi;
			maxj = maxj >= b.Length ? b.Length - 1 : maxj;

			while(maxi >= 0 && maxj >= 0)
			{
				if(a[maxi] == b[maxj])
				{
					result = a[maxi] + result;
					maxi--;
					maxj--;
				}
				else
				{
					maxj--;
				}
			}

			Console.WriteLine("LCS is: {0}", result);
			return max;
		}
	}

	[TestFixture]
	public class TestLCS
	{
		[Test]
		public void Test1()
		{
			string a = "bd";
			string b = "abcd";

		//	var result = new LcsRecursive().LCS(a, b, 0, 0);
		//	Console.WriteLine("Total call count: {0}", LcsRecursive.CallCount);

			var result2 = new LcsRecursive().LCS2(a, b);

			//Assert.That(result, Is.EqualTo(2));
			Assert.That(result2, Is.EqualTo(2));
		}

		[Test]
		public void Test2()
		{
			string a = "bcd";
			string b = "bd";

			var result = new LcsRecursive().LCS(a, b, 0, 0);
			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		public void Test3()
		{
			string a = "bd";
			string b = "bcd";

			var result = new LcsRecursive().LCS(a, b, 0, 0);
			Console.WriteLine("Total call count: {0}", LcsRecursive.CallCount);

			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		public void Test4()
		{
			string a = "AGGTAB";
			string b = "GXTXAYB";

			var lcs = new LcsRecursive();
			var result = lcs.LCS(a, b, 0, 0);

			Console.WriteLine("Total call count: {0}", LcsRecursive.CallCount);

			Assert.That(result, Is.EqualTo(4));
		}

		[Test]
		public void Test5()
		{
			string a = "stone";
			string b = "longest";

			var lcs = new LcsRecursive();
			var result = lcs.LCS(a, b, 0, 0);

			Console.WriteLine("Total call count: {0}", LcsRecursive.CallCount);
			var result2 = new LcsRecursive().LCS2(a, b);

			Assert.That(result, Is.EqualTo(3));
		}
	}
}
