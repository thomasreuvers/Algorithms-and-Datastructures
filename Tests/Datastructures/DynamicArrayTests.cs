using DataStructures;

namespace Tests.Datastructures;

[TestFixture]
public class DynamicArrayTests
{
	[Test]
	public void Add_ElementToDynamicArray_IncreasesSize()
	{
		// Arrange
		var dynamicArray = new DynamicArray<int>();

		// Act
		dynamicArray.Add(5);

		// Assert
		Assert.That(dynamicArray.Size(), Is.EqualTo(1));
	}

	[Test]
	public void Get_ElementAtIndex_ReturnsCorrectValue()
	{
		// Arrange
		var dynamicArray = new DynamicArray<string>();
		dynamicArray.Add("Hello");
		dynamicArray.Add("World");

		// Act
		var result = dynamicArray.Get(1);

		// Assert
		Assert.That(result, Is.EqualTo("World"));
	}
	
	[Test]
	public void Set_ElementAtIndex_UpdatesCorrectly()
	{
		// Arrange
		var dynamicArray = new DynamicArray<double>();
		dynamicArray.Add(3.14);

		// Act
		dynamicArray.Set(0, 2.718);

		// Assert
		Assert.That(dynamicArray.Get(0), Is.EqualTo(2.718));
	}
	
	[Test]
	public void Remove_AtValidIndex_DecreasesSize()
	{
		// Arrange
		var dynamicArray = new DynamicArray<char>();
		dynamicArray.Add('a');
		dynamicArray.Add('b');
		dynamicArray.Add('c');

		// Act
		dynamicArray.Remove(1);

		// Assert
		Assert.That(dynamicArray.Size(), Is.EqualTo(2));
	}
	
	[Test]
	public void Remove_InvalidIndex_ThrowsIndexOutOfRangeException()
	{
		// Arrange
		var dynamicArray = new DynamicArray<int>();
		dynamicArray.Add(1);
		dynamicArray.Add(2);

		// Act & Assert
		Assert.Throws<IndexOutOfRangeException>(() => dynamicArray.Remove(5));
	}
	
	[Test]
	public void Remove_Element_RemovesFirstInstance()
    {
        // Arrange
        var dynamicArray = new DynamicArray<string>();
		dynamicArray.Add("apple");
		dynamicArray.Add("banana");
		dynamicArray.Add("apple");

		// Act
		dynamicArray.Remove("apple");
		
		// Assert
        Assert.Multiple(() =>
        {
            Assert.That(dynamicArray.Size(), Is.EqualTo(2));
            Assert.That(dynamicArray.IndexOf("apple"), Is.EqualTo(1)); // Second instance of "apple"
        });
    }
	
	[Test]
	public void Contains_CheckExistingElement_ReturnsTrue()
	{
		// Arrange
		var dynamicArray = new DynamicArray<int>();
		dynamicArray.Add(10);
		dynamicArray.Add(20);
		dynamicArray.Add(30);

		// Act & Assert
		Assert.That(dynamicArray.Contains(20), Is.True);
	}
	
	[Test]
	public void IndexOf_ExistingElement_ReturnsCorrectIndex()
	{
		// Arrange
		var dynamicArray = new DynamicArray<string>();
		dynamicArray.Add("One");
		dynamicArray.Add("Two");
		dynamicArray.Add("Three");

		// Act
		var index = dynamicArray.IndexOf("Two");

		// Assert
		Assert.That(index, Is.EqualTo(1));
	}
}