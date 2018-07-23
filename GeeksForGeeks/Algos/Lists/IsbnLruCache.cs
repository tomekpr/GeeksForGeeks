using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GeeksForGeeks
{
	[TestFixture]
	class IsbnLruCache
	{
		private Dictionary<string, BookPrice> isbnToPrice = new Dictionary<string, BookPrice>();
		private Dictionary<string, DeqNode> isbnToPosition = new Dictionary<string, DeqNode>();
		private DeqNode head, tail;

		void Add(string isbn, decimal price)
		{
			if(!isbnToPrice.ContainsKey(isbn))
			{
				isbnToPrice[isbn] = new BookPrice(price);
				AddToTheFront(isbn);
			}
		}

		decimal GetPrice(string isbn)
		{
			if (!isbnToPrice.ContainsKey(isbn)) throw new ArgumentOutOfRangeException(nameof(isbn));

			var price = isbnToPrice[isbn];
			price.LastAccess = DateTime.UtcNow;

			MoveToFront(isbn);

			return price.Price;
		}

		void UpdatePrice(string isbn, decimal price)
		{
			if (!isbnToPrice.ContainsKey(isbn)) throw new ArgumentNullException(nameof(isbn));

			var bookPrice = isbnToPrice[isbn];

			bookPrice.Price = price;
			bookPrice.LastAccess = DateTime.UtcNow;

			MoveToFront(isbn);
		}

		void DeletePrice(string isbn)
		{
			if (!isbnToPrice.ContainsKey(isbn)) throw new ArgumentNullException(nameof(isbn));

			isbnToPrice.Remove(isbn);
			DeleteFromQueue(isbn);
		}

		void DeleteFromQueue(string isbn)
		{
			var node = isbnToPosition[isbn];

			// am I first in the queue?
			if(head.Next == node)
			{
				head.Next = node.Next;
				node.Next.Prev = head;

				node = null;
				isbnToPosition.Remove(isbn);
				return;
			}

			// am I the last one?
			if(tail.Next == node)
			{
				tail.Next = node.Prev;
				node.Prev.Next = null;

				node = null;
				isbnToPosition.Remove(isbn);
				return;
			}

			// I'm somewhere in the middle
			node.Prev.Next = node.Next;
			node.Next.Prev = node.Prev;

			node = null;
			isbnToPosition.Remove(isbn);
			return;
		}

		void MoveToFront(string isbn)
		{
			var node = isbnToPosition[isbn];

			// am I already at front?
			if (head.Next == node) return;

			// am I the last one?
			if(tail.Next == node)
			{
				tail.Next = node.Prev;
				node.Prev = null;

				AddToFront(node);
				return;
			}

			// I'm somewhere in the middle
			// prev to point at next
			node.Prev.Next = node.Next;
			node.Prev = null;
			node.Next = null;

			AddToFront(node);
		}

		void AddToTheFront(string isbn)
		{
			var node = new DeqNode(isbn);
			AddToFront(node);
		}

		void AddToFront(DeqNode node)
		{
			if (head == null)
			{
				head = new DeqNode(null);
				tail = new DeqNode(null);

				head.Next = node;
				tail.Next = node;
			}
			else
			{
				if (node.Prev != null)
					node.Prev.Next = null;

				node.Prev = null;
				node.Next = head.Next;

				head.Next.Prev = node;

				head.Next = node;
			}

			if(isbnToPosition.ContainsKey(node.Isbn) == false)
				isbnToPosition.Add(node.Isbn, node);
		}

		[SetUp]
		public void SetUp()
		{
			this.isbnToPosition.Clear();
			this.isbnToPrice.Clear();
		}

		[Test]
		public void CanAddNewPrice()
		{
			var isbn = "A";
			var price = 13.99m;

			Add(isbn, price);

			Assert.That(isbnToPosition.Count, Is.EqualTo(1));
			Assert.That(isbnToPrice.Count, Is.EqualTo(1));

			Assert.That(head.Next.Isbn, Is.EqualTo(isbn));
			Assert.That(tail.Next.Isbn, Is.EqualTo(isbn));
		}

		[Test]
		public void CanAddTwoBooks()
		{
			Add("A", 1m);
			Add("B", 2m);

			Assert.That(isbnToPosition.Count, Is.EqualTo(2));
			Assert.That(isbnToPrice.Count, Is.EqualTo(2));

			Assert.That(head.Next.Isbn, Is.EqualTo("B"));
			Assert.That(tail.Next.Isbn, Is.EqualTo("A"));
		}

		[Test]
		public void CanAddThreeBooksAndMaintainCorrectOrderInCache()
		{
			Add("A", 1m);
			Add("B", 2m);
			Add("C", 3m);

			Assert.That(isbnToPosition.Count, Is.EqualTo(3));
			Assert.That(isbnToPrice.Count, Is.EqualTo(3));

			Assert.That(head.Next.Isbn, Is.EqualTo("C"));
			Assert.That(head.Next.Next.Isbn, Is.EqualTo("B"));
			Assert.That(tail.Next.Isbn, Is.EqualTo("A"));
		}

		[Test]
		public void IsbnAccessBringsItToTheFrontOfTheQueue()
		{
			Add("A", 1m);
			Add("B", 2m);
			Add("C", 3m);

			this.GetPrice("B");

			Assert.That(isbnToPosition.Count, Is.EqualTo(3));
			Assert.That(isbnToPrice.Count, Is.EqualTo(3));

			Assert.That(head.Next.Isbn, Is.EqualTo("B"));
			Assert.That(head.Next.Next.Isbn, Is.EqualTo("C"));
			Assert.That(tail.Next.Isbn, Is.EqualTo("A"));
		}
	}

	class BookPrice
	{
		public decimal Price;
		public DateTime LastAccess;

		public BookPrice(decimal price)
		{
			Price = price;
			LastAccess = DateTime.UtcNow;
		}
	}

	class DeqNode
	{
		public string Isbn;
		public DeqNode Prev;
		public DeqNode Next;

		public DeqNode(string v) => Isbn = v;

		public override string ToString() => $"{Isbn} Prev: {Prev?.Isbn} Next: {Next?.Isbn}";
	}
}
