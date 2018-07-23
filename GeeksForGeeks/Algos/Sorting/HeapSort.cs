using NUnit.Framework;
using System;
using System.Linq;

namespace GeeksForGeeks
{
	class HeapSort
	{
		public void Sort(int[] arr)
		{
			var minHeap = BuildMinHeap(arr);
			int count = 0;

			while (minHeap.Count() > 0)
			{
				arr[count++] = minHeap.DeleteMin();
			}
		}

		MinHeap BuildMinHeap(int[] arr)
		{
			var mh = new MinHeap();
			mh.Build(arr);

			return mh;
		}
	}

	class MinHeap
	{
		int[] heap = new int[100];
		int elemCount = 0;
		int lastFree = 1;

		public void Build(int[] arr)
		{
			foreach (var n in arr)
				Insert(n);
		}

		void Insert(int x)
		{
			heap[lastFree] = x;
			MoveUp(lastFree);
			lastFree++;
			elemCount++;
		}

		void MoveUp(int i)
		{
			var parentIndex = (int)Math.Floor(i / 2.0);
			if (parentIndex == 0) return;

			if (heap[parentIndex] < heap[i]) return;

			var child = i - 1;
			Swap(ref child, ref i);
			MoveUp(child);
		}

		void Swap(ref int a, ref int b)
		{
			var tmp = heap[a];
			heap[a] = heap[b];
			heap[b] = tmp;
		}

		public int DeleteMin()
		{
			int elem = heap[1];
			heap[1] = heap[lastFree - 1];
			heap[lastFree - 1] = 0;

			lastFree--;
			MoveDown(1);
			elemCount--;

			return elem;
		}

		void MoveDown(int i)
		{
			if (i == lastFree) return;

			int leftIndex = 2 * i;
			int rightIndex = (2 * i) + 1;

			if (heap[leftIndex] >= heap[i] && heap[rightIndex] >= heap[i]) return;

			if (heap[rightIndex] >= i)
			{
				Swap(ref rightIndex, ref i);
				MoveDown(rightIndex);
			}

			if (heap[leftIndex] >= i)
			{
				Swap(ref leftIndex, ref i);
				MoveDown(leftIndex);
			}
		}

		public int Count()
		{
			return elemCount;
		}
	}

	[TestFixture]
	public class TestHeapSort
	{
		[Test]
		public void Test1()
		{
			var items = new int[] { 5, 4 };
			var exp = new int[items.Length];

			Array.Copy(items, exp, items.Length);
			Array.Sort(exp);

			var hs = new HeapSort();
			hs.Sort(items);

			Assert.That(items.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test2()
		{
			var items = new int[] { 10, 12, 18, 7 };
			var exp = new int[items.Length];

			Array.Copy(items, exp, items.Length);
			Array.Sort(exp);

			var hs = new HeapSort();
			hs.Sort(items);

			Assert.That(items.SequenceEqual(exp), Is.True);
		}
	}
}
