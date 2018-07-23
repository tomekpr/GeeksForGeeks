using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class NQueens
	{
		public void Solve(bool[][] board)
		{
			SolveUsingBacktracking(board, 0);
		}

		private bool SolveUsingBacktracking(bool[][] board, int num_of_queens_positioned)
		{
			if (IsValid(board) == false) return false;

			if (num_of_queens_positioned == board.Length)
			{
				Print(board);
				return true;
			}

			for (int row = 0; row < board.Length; row++)
			{
				for (int col = 0; col < board.Length; col++)
				{
					// if spot not taken
					if (board[row][col] == false)
					{
						board[row][col] = true;
						if (SolveUsingBacktracking(board, num_of_queens_positioned + 1)) return true;

						// backtrack
						board[row][col] = false;
					}
				}
			}

			return false;
		}

		private void Print(bool[][] board)
		{
			for (int row = 0; row < board.Length; row++)
			{
				for (int col = 0; col < board.Length; col++)
				{
					char c = board[row][col] ? 'X' : '-';
					Console.Write(c);
				}
				Console.WriteLine("");
			}

			Console.WriteLine("");
		}


		private bool IsValid(bool[][] board)
		{
			// rows, cols and diagonals
			for (int row = 0; row < board.Length; row++)
			{
				bool exists = false;
				for (int col = 0; col < board.Length; col++)
				{
					if (board[row][col])
					{
						// check diag
						if (row > 0 && col > 0)
							if (board[row - 1][col - 1]) return false;

						if (row > 0 && row < board.Length && (col > 0 && col + 1 < board.Length))
							if (board[row - 1][col + 1]) return false;

						// diagonals are fine, check columns
						if (exists) return false;
						exists = true;
					}
				}
			}

			for (int col = 0; col < board.Length; col++)
			{
				bool exists = false;
				for (int row = 0; row < board.Length; row++)
				{
					if (board[row][col])
					{
						if (exists) return false;
						exists = true;
					}
				}
			}

			return true;
		}
	}

	[TestFixture]
	public class TestNQueens
	{
		[Test]
		public void Test1()
		{
			var board = BuildBoard(4);

			var solver = new NQueens();
			solver.Solve(board);
		}

		[Test]
		public void Test2()
		{
			var board = BuildBoard(8);

			var solver = new NQueens();
			solver.Solve(board);
		}

		private bool[][] BuildBoard(int length)
		{
			bool[][] b = new bool[length][];
			for (int i = 0; i < length; i++)
				b[i] = new bool[length];

			return b;
		}
	}
}
