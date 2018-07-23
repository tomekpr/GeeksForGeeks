using GeeksForGeeks.Algos.Geometrics;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GeeksForGeeks.Algos.Backtracking
{
	class RatInAMaze
	{
		public Point Solve(int[][] matrix)
		{
			int start_x = 0;
			int start_y = 0;

			Point p = new Point(-1, -1);

			SolveUtil(matrix, start_x, start_y, p);

			return p;
		}

		bool SolveUtil(int[][] matrix, int x, int y, Point p)
		{
			Console.WriteLine($"Exploring [{x},{y}]");
			if (x == matrix.Length - 1 && y == matrix.Length - 1)
			{
				Console.WriteLine("Found a solution!");
				p.X = x;
				p.Y = y;
				return true;
			}

			if (Visited(new Point(x, y), matrix)) return false;

			// mark as visited!
			matrix[x][y] = 3;

			foreach (var cell in GetAllPossibleCells(matrix, x, y))
			{
				if (IsValid(cell, matrix))
				{
					// Other solutions seem to be suggesting that we go first x+1 then y+1
					if (SolveUtil(matrix, cell.X, cell.Y, p))
					{
						return true;
					}

					// back track - no way we can go here
					matrix[cell.X][cell.Y] = 0;
					return false;
				}
			}

			return false;
		}

		bool Visited(Point p, int[][] m) => m[p.X][p.Y] == 3;
		bool Wall(Point p, int[][] m) => m[p.X][p.Y] == 0;

		private bool IsValid(Point cell, int[][] matrix)
		{
			if (cell.X < 0 || cell.X >= matrix.Length) return false;
			if (cell.Y < 0 || cell.Y >= matrix.Length) return false;

			if (Wall(cell, matrix))
			{
				Console.WriteLine($"[{cell.X},{cell.Y}] is a wall");
				return false; // can't go there! that's a wall
			}
			return true;
		}

		Point[] GetAllPossibleCells(int[][] matrix, int x, int y)
		{
			var points = new List<Point>();
			// we can only go down or right!
			int[] dy = new int[] { 1, 0 };
			int[] dx = new int[] { 0, 1 };

			for (int i = 0; i < 2; i++)
			{
				points.Add(new Point(x + dx[i], y + dy[i]));
			}

			return points.ToArray();
		}
	}

	[TestFixture]
	public class TestRatInAMaze
	{
		[Test]
		public void Test1()
		{
			int[][] m = new int[4][];
			m[0] = new int[] { 1, 1, 1, 0 };
			m[1] = new int[] { 1, 1, 0, 0 };
			m[2] = new int[] { 0, 1, 1, 0 };
			m[3] = new int[] { 0, 0, 1, 1 };

			var sut = new RatInAMaze();
			var result = sut.Solve(m);

			Assert.That(result.X == 3 && result.Y == 3);
		}
	}
}
