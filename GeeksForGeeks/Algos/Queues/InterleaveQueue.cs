using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Queues
{
	// interleave first half of the queue with second half of the queue
	// use only stacks as an auxiliary structure.
	// https://www.youtube.com/watch?v=BNuXP58kAWk
	class InterleaveQueue
	{
		public void Interleave(Queue<int> queue)
		{
			var firstHalf = new Stack<int>();
			var secondHalf = new Stack<int>();

			int half = queue.Count / 2;
			while(half > 0)
			{
				firstHalf.Push(queue.Dequeue());
				half--;
			}

			while (queue.Count > 0)
				secondHalf.Push(queue.Dequeue());

			bool takeFromSecondHalf = true;
			var orderedStack = new Stack<int>();

			while(secondHalf.Count > 0 || firstHalf.Count > 0)
			{
				var elem = takeFromSecondHalf ? secondHalf.Pop() : firstHalf.Pop();
				orderedStack.Push(elem);
				takeFromSecondHalf = !takeFromSecondHalf;
			}

			while (orderedStack.Count > 0)
				queue.Enqueue(orderedStack.Pop());
		}
	}

	[TestFixture]
	public class TestInterleaveQueue
	{
		[Test]
		public void Test1()
		{
			var q = new Queue<int>();
			q.Enqueue(4);
			q.Enqueue(3);
			q.Enqueue(2);
			q.Enqueue(1);

			var expected = new Queue<int>();
			expected.Enqueue(4);
			expected.Enqueue(2);
			expected.Enqueue(3);
			expected.Enqueue(1);

			var iq = new InterleaveQueue();
			iq.Interleave(q);

			bool areEqual = q.SequenceEqual(expected);
			Assert.That(areEqual, Is.True);
		}
	}
}
