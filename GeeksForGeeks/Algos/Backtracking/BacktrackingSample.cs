using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class BacktrackingSample
	{
		List<List<int>> solutions;

		public List<List<int>> Solve()
		{
			solutions = new List<List<int>>();

			ABG(new int[] { 4, 5, 6 }, 0, new int[] { -1, -1, -1 }, 0);

			return solutions;
		}

		private void ABG(int[] people, int pi, int[] chairs, int ci)
		{
			if (chairs.All(x => x != -1))
			{
				var sol = new int[3];
				Array.Copy(chairs, sol, 3);

				solutions.Add(sol.ToList());
				return;
			}

			var visited = new HashSet<int>();
			for (int i = pi; i < people.Length; i++)
			{
				chairs[ci] = people[pi];
				ABG(people, pi + 1, chairs, ci + 1);

				// bt here...
				chairs[ci] = -1;
			}
		}
	}

	[TestFixture]
	public class TestBacktrackingSample
	{
		[Test]
		public void Test1()
		{
			var s = new BacktrackingSample();
			var sol = s.Solve();

			foreach (var r in sol)
			{
				Console.WriteLine(String.Join(",", r));
			}
		}
	}
}
