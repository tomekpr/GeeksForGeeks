using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Graphs
{
	class BfsOnAGrid
	{
		void _()
		{
			// define direction vectors || north || south || east || west
			var dr = new int[] { -1, 1, 0,  0 };
			var dc = new int[] {  0, 0, 1, -1 };

			int r = 0, c = 0;
			int rMax = 10;
			int cMax = 10;

			bool[][] visited = null;
			char[][] m = null;

			for(int i=0; i < 4; i++)
			{
				var rr = r + dr[i];
				var cc = c + dc[i];

				// check out of bounds
				if (rr < 0 || cc < 0) continue;
				if (rr >= rMax || cc >= cMax) continue;

				// (rr,cc) is a neighbouring cell of (r,c)

				if (visited[rr][cc]) continue;
				if (m[rr][cc] == '#') continue;
			}
		}
	}
}
