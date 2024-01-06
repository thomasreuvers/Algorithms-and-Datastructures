using DataStructures;

namespace Tests.Datastructures;

[TestFixture]
public class DequeTests
{
	[Test]
	public void InsertLeft_WhenDequeIsEmpty_InsertsElementAtFront()
	{
		// Arrange
		var deque = new Deque<int>(5);
		
		// Act
		deque.InsertLeft(10);
		
		// Assert
		Assert.That(deque.Size(), Is.EqualTo(1));
	}
	
	[Test]
	public void InsertRight_WhenDequeIsFull_ThrowsInvalidOperationException()
	{
		// Arrange
		var deque = new Deque<string>(2);
		deque.InsertRight("A");
		deque.InsertRight("B");

		// Act & Assert
		Assert.Throws<InvalidOperationException>(() => deque.InsertRight("C"));
	}
	
	[Test]
	public void DeleteLeft_WhenDequeIsNotEmpty_DeletesElementFromFront()
	{
		// Arrange
		var deque = new Deque<char>(4);
		deque.InsertRight('a');
		deque.InsertRight('b');
		deque.InsertRight('c');

		// Act
		deque.DeleteLeft();

		// Assert
		Assert.That(deque.Size(), Is.EqualTo(2));
	}
	
	[Test]
	public void DeleteRight_WhenDequeIsEmpty_ThrowsInvalidOperationException()
	{
		// Arrange
		var deque = new Deque<double>(3);

		// Act & Assert
		Assert.Throws<InvalidOperationException>(() => deque.DeleteRight());
	}
	
	[Test]
	public void Size_WhenDequeIsManipulated_ReturnsCorrectSize()
	{
		// Arrange
		var deque = new Deque<int>(4);
		deque.InsertLeft(1);
		deque.InsertLeft(2);
		deque.InsertRight(3);
		deque.DeleteLeft();

		// Act
		var size = deque.Size();

		// Assert
		Assert.That(size, Is.EqualTo(2));
	}
}