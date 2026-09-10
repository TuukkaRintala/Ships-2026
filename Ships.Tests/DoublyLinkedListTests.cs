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

		list.Remove(6);
		Assert.Equal(2, list.Count);
		
		list.Remove(6);
		Assert.Equal(2, list.Count);

		Assert.DoesNotContain(6, list);
	}
}