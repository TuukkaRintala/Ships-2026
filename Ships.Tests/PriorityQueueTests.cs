using GA.Collections;
using Xunit;

public class PriorityQueueTests
{
	[Fact]
	public void TestBasicAdd()
	{
		PriorityQueue<int> queue = new PriorityQueue<int>();

		queue.Enqueue(1);
		Assert.Equal(1, queue.Peek());

		queue.Enqueue(8);
		Assert.Equal(1, queue.Peek());

		queue.Enqueue(4);
		Assert.Equal(1, queue.Peek());


		Assert.Equal(3, queue.Count);
		Assert.True(queue.IsConsistent());
	}

	[Fact]
	public void TestAddNegative()
	{
		PriorityQueue<int> queue = new PriorityQueue<int>();

		queue.Enqueue(-1);
		Assert.Equal(-1, queue.Peek());

		queue.Enqueue(8);
		Assert.Equal(-1, queue.Peek());

		queue.Enqueue(-5);
		Assert.Equal(-5, queue.Peek());

		Assert.Equal(3, queue.Count);
		Assert.True(queue.IsConsistent());
	}

	[Fact]
	public void TestEmpty()
	{
		PriorityQueue<int> queue = new PriorityQueue<int>();

		var emptyException = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
		Assert.Equal("The queue is empty.", emptyException.Message);

		queue.Enqueue(1);

		Assert.Equal(1, queue.Dequeue());

		emptyException = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
		Assert.Equal("The queue is empty.", emptyException.Message);
	}

	[Fact]
	public void TestConsistency()
	{
		PriorityQueue<int> queue = new PriorityQueue<int>();

		queue.Enqueue(1);
		queue.Enqueue(9);
		queue.Enqueue(-3);
		queue.Enqueue(-1);
		queue.Enqueue(4);

		Assert.True(queue.IsConsistent());

		int previous = queue.Dequeue();
		int current = queue.Dequeue();
		Assert.True(previous < current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous < current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous < current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous < current);
	}

	[Fact]
	public void TestAddSame()
	{
		PriorityQueue<int> queue = new PriorityQueue<int>();

		queue.Enqueue(1);
		queue.Enqueue(1);

		Assert.Equal(2, queue.Count);

		queue.Enqueue(2);
		queue.Enqueue(-1);
		queue.Enqueue(1);
		queue.Enqueue(5);
		queue.Enqueue(9);
		queue.Enqueue(8);
		queue.Enqueue(7);

		Assert.True(queue.IsConsistent());

		int previous = queue.Dequeue();
		int current = queue.Dequeue();
		Assert.True(previous < current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous <= current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous <= current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous <= current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous <= current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous <= current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous <= current);

		previous = current;
		current = queue.Dequeue();
		Assert.True(previous <= current);
	}
}