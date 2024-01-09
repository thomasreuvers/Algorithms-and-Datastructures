using DataStructures;
using FileReader;
using FileReader.Models;

namespace Tests.Datastructures;

[TestFixture]
public class DoublyLinkedListTests
{
	[Test]
	public void Add_WhenCalled_AddsElementToEndOfList()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();

		// Act
		list.Add(5);
		list.Add(10);

		// Assert
		Assert.That(list.Count, Is.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(list.Get(0), Is.EqualTo(5));
            Assert.That(list.Get(1), Is.EqualTo(10));
        });
    }
	
	[Test]
	public void Get_WithValidIndex_ReturnsElement()
	{
		// Arrange
		var list = new DoublyLinkedList<string>();
		list.Add("One");
		list.Add("Two");
		list.Add("Three");

		// Act & Assert
		Assert.That(list.Get(1), Is.EqualTo("Two"));
	}
	
	[Test]
	public void Get_WithInvalidIndex_ThrowsIndexOutOfRangeException()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();

		// Act & Assert
		Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
		Assert.Throws<IndexOutOfRangeException>(() => list.Get(0));
		list.Add(7);
		Assert.Throws<IndexOutOfRangeException>(() => list.Get(1));
	}
	
	[Test]
	public void Set_WithValidIndex_SetsElement()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		list.Add(100);
		list.Add(200);
		list.Add(300);

		// Act
		list.Set(1, 150);

		// Assert
		Assert.That(list.Get(1), Is.EqualTo(150));
	}
	
	[Test]
	public void Set_WithInvalidIndex_ThrowsIndexOutOfRangeException()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();

		// Act & Assert
		Assert.Throws<IndexOutOfRangeException>(() => list.Set(0, 10));
		list.Add(5);
		Assert.Throws<IndexOutOfRangeException>(() => list.Set(1, 10));
	}
	
	[Test]
	public void Remove_ByIndex_RemovesElementAtIndex()
    {
        // Arrange
        var list = new DoublyLinkedList<string>();
		list.Add("Apple");
		list.Add("Banana");
		list.Add("Orange");

		// Act
		list.Remove(1);

		// Assert
		Assert.That(list.Count, Is.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(list.Get(0), Is.EqualTo("Apple"));
            Assert.That(list.Get(1), Is.EqualTo("Orange"));
        });
    }
	
	[Test]
	public void Remove_WithInvalidIndex_ThrowsIndexOutOfRangeException()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();

		// Act & Assert
		Assert.Throws<IndexOutOfRangeException>(() => list.Remove(0));
		list.Add(5);
		Assert.Throws<IndexOutOfRangeException>(() => list.Remove(1));
	}
	
	[Test]
	public void Remove_ByValue_RemovesFirstOccurrenceOfElement()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		list.Add(10);
		list.Add(20);
		list.Add(30);
		list.Add(20);

		// Act
		list.Remove(element: 20); // Parameter specifier because otherwise we'd be calling Remove(int index)

		// Assert
		Assert.That(list.Count, Is.EqualTo(3));
		Assert.That(list.IndexOf(20), Is.EqualTo(2)); // Check the index of the remaining occurence
	}
	
	[Test]
	public void Contains_WithExistingElement_ReturnsTrue()
	{
		// Arrange
		var list = new DoublyLinkedList<string>();
		list.Add("Dog");
		list.Add("Cat");
		list.Add("Rabbit");

		// Act & Assert
		Assert.That(list.Contains("Cat"), Is.True);
	}
	
	[Test]
	public void Contains_WithNonExistingElement_ReturnsFalse()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		// Act & Assert
		Assert.That(list.Contains(5), Is.False);
	}

	[Test]
	public void IndexOf_WithExistingElement_ReturnsCorrectIndex()
	{
		// Arrange
		var list = new DoublyLinkedList<string>();
		list.Add("One");
		list.Add("Two");
		list.Add("Three");

		// Act & Assert
		Assert.That(list.IndexOf("Two"), Is.EqualTo(1));
	}
	
	[Test]
	public void IndexOf_WithNonExistingElement_ReturnsNegativeOne()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		list.Add(5);
		list.Add(10);

		// Act & Assert
		Assert.That(list.IndexOf(20), Is.EqualTo(-1));
	}
	
	[Test]
	public async Task Can_Read_DataSet()
	{
		// Arrange
		var fileReader = new JsonFileReader();
		var data = await fileReader.ReadFromFileAsync<SortingDataModel>("dataset_sorteren.json");
		var doublyLinkedList = new DoublyLinkedList<int>();
		
		// Act
		foreach (var item in data.AscendingList)
		{
			doublyLinkedList.Add(item);
		}
		
		// Assert
		Assert.That(doublyLinkedList.Count, Is.EqualTo(data.AscendingList.Length));
	}
}