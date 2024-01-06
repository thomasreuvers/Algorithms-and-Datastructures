using DataStructures;

namespace Tests.Datastructures;

[TestFixture]
public class PriorityQueueTests
{
	[Test]
	public void Add_ElementToEmptyQueue_ReturnsPeekAsAddedElement()
	{
		// Arrange
		var queue = new PriorityQueue<int>(
			(x, y) => x.CompareTo(y));
		
		// Act
		queue.Add(5);

		// Assert
		Assert.That(queue.Peek(), Is.EqualTo(5));
	}
	
	[Test]
	public void Peek_EmptyQueue_ThrowsException()
	{
		// Arrange
		var queue = new PriorityQueue<string>(
			(x, y) => string.Compare(x, y, StringComparison.Ordinal));

		// Assert
		Assert.Throws<InvalidOperationException>(() => queue.Peek());
	}
	
	[Test]
	public void Poll_EmptyQueue_ThrowsException()
	{
		// Arrange
		var queue = new PriorityQueue<double>(
			(x, y) => x.CompareTo(y));

		// Assert
		Assert.Throws<InvalidOperationException>(() => queue.Poll());
	}
	
	[Test]
	public void Add_MultipleElementsInQueue_ReturnsCorrectPeekAndPollOrder()
    {
        // Arrange
        var queue = new PriorityQueue<int>(
			(x, y) => x.CompareTo(y));
		
		queue.Add(8);
		queue.Add(3);
		queue.Add(12);
		queue.Add(5);
		
		// Assert
        Assert.Multiple(() =>
        {
            Assert.That(queue.Peek(), Is.EqualTo(3));
            Assert.That(queue.Poll(), Is.EqualTo(3));
            Assert.That(queue.Poll(), Is.EqualTo(5));
            Assert.That(queue.Poll(), Is.EqualTo(8));
            Assert.That(queue.Poll(), Is.EqualTo(12));
        });
    }
	
	[Test]
	public void Poll_ElementFromQueue_ReturnsExpectedElement()
	{
		// Arrange
		var queue = new PriorityQueue<string>((x, y) => string.Compare(x, y, StringComparison.Ordinal));
		queue.Add("Apple");
		queue.Add("Banana");
		queue.Add("Cherry");

		// Act
		var polled = queue.Poll();

		// Assert
		Assert.That(polled, Is.EqualTo("Apple"));
	}
}