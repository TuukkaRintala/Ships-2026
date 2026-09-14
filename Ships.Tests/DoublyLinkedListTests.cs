using GA.Collections;
using Xunit;

public class DoublyLinkedListTests
{
	[Fact]
	public void TestBasicAdd()
	{
		DoublyLinkedList<int> list = new DoublyLinkedList<int>();
		list.Add(1);
		list.Add(6);
		list.Add(-1);

		Assert.Equal(3, list.Count);
	}

	[Fact]
	public void TestBasicRemove()
	{
		DoublyLinkedList<int> list = new DoublyLinkedList<int>();
		list.Add(1);
		list.Add(6);
		list.Add(-1);

		// Remove 1 item from the list.
		list.Remove(6);
		Assert.Equal(2, list.Count);

		// Try to remove an item that is not in the list.
		list.Remove(6);
		Assert.Equal(2, list.Count);

		Assert.DoesNotContain(6, list);
	}

	[Fact]
	public void TestBasicContains()
	{
		DoublyLinkedList<int> list = new DoublyLinkedList<int>();

		// Using Contains() in an empty list.
		Assert.False(list.Contains(0));

		list.Add(0);
		// Contains(0) when it was added.
		Assert.True(list.Contains(0));

		list.Add(0);
		// Contains(0) with duplicates.
		Assert.True(list.Contains(0));
		// Contains() with an item not in the list.
		Assert.False(list.Contains(1));
	}

	[Fact]
	public void TestAdvancedRemove()
	{
		DoublyLinkedList<int> list = new DoublyLinkedList<int>();

		// Remove from empty list
		Assert.Empty(list);

		list.Remove(1);

		Assert.Empty(list);

		list.Add(1);
		list.Add(6);
		list.Add(-1);

		// Remove head
		list.Remove(1);
		Assert.DoesNotContain(1, list);
		Assert.Equal(2, list.Count);

		// Remove tail
		list.Remove(-1);
		Assert.DoesNotContain(-1, list);
		Assert.Single(list);

		// Remove last item in list
		list.Remove(6);
		Assert.Empty(list);

		// Adding and removing duplicates
		list.Add(6);
		list.Add(6);
		Assert.Equal(2, list.Count);

		list.Remove(6);
		Assert.Single(list);
	}
}