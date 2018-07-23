using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class Edge
	{
		public int Cost;
		public FWVertex Vertex;

		// Represents cost of getting to vertex
		public Edge(int cost = 100) : this(cost, null) {}
		public Edge(int cost, FWVertex vertex)
		{
			Cost = cost;
			Vertex = vertex;
		}
	}

	class FWVertex
	{
		public int Id;
		public List<Edge> Adjacent;

		public FWVertex(int id) {
			Id = id;
			Adjacent = new List<Edge>();
		}

		public void Add(Edge edge) => Adjacent.Add(edge);
	}

	class FloydWarshall
	{
		public int[][] FindAllPairs(Edge[][] edges, int N)
		{
			/* Initialize array */
			int[][] a = new int[N][];
			for (int i = 0; i < N; i++)
				a[i] = new int[N];

			// fill initial matrix
			for(int i = 0; i < N; i++)
				for(int j =0; j < N; j++)
					a[i][j] = edges[i][j].Cost;

			/* Set diagonals to zero */
			for (int i = 0; i < N; i++)
				a[i][i] = 0;

			//return a;

			// k,i,j
			// k <- changes intermediate matrices
			// i,j <- index edges
			for (int k=0; k < N; k++)
			{
				for(int i=0; i < N; i++)
				{
					for(int j=0; j < N; j++)
					{
						if (i == j) continue;

						int min = Math.Min(a[i][j], a[i][k] + a[k][j]);
						a[i][j] = min;
					}
				}
			}


			return a;
		}
	}

	[TestFixture]
	public class FloydWarshallTests
	{
		FloydWarshall fw = new FloydWarshall();

		[Test]
		public void Test()
		{
			var one = new FWVertex(1);
			var two = new FWVertex(2);
			var three = new FWVertex(3);
			var four = new FWVertex(4);

			Edge[][] matrix = new Edge[4][];
			for (int i = 0; i < matrix.Length; i++)
				matrix[i] = new Edge[4];

			// 1 ->
			matrix[0][0] = new Edge(0);
			matrix[0][1] = new Edge(3);
			matrix[0][2] = new Edge();
			matrix[0][3] = new Edge(7);

			// 2 ->
			matrix[1][0] = new Edge(8);
			matrix[1][1] = new Edge(0);
			matrix[1][2] = new Edge(2);
			matrix[1][3] = new Edge();

			// 3 ->
			matrix[2][0] = new Edge(5);
			matrix[2][1] = new Edge();
			matrix[2][2] = new Edge(0);
			matrix[2][3] = new Edge(1);

			// 4 ->
			matrix[3][0] = new Edge(2);
			matrix[3][1] = new Edge();
			matrix[3][2] = new Edge();
			matrix[3][3] = new Edge(0);

			int n = 4;
			int[][] result = fw.FindAllPairs(matrix, n);
			Print(result, n);
		}

		void Print(int[][] result, int n)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Console.Write($"{result[i][j]},");
				}
				Console.WriteLine("");
			}
		}
	}
}
