using DataStructures;
using FileReader;
using FileReader.Models;

namespace Tests.Datastructures;

[TestFixture]
public class StackTests
{
	private DataStructures.Stack<int> _stack = null!;

	[SetUp]
	public void Setup()
	{
		_stack = new DataStructures.Stack<int>(capacity: 5);
	}

	[Test]
	public void Push_ValidElement_ShouldIncreaseSize()
	{
		_stack.Push(5);
		Assert.That(_stack.Size(), Is.EqualTo(1));
	}
	
	[Test]
	public void Pop_EmptyStack_ShouldThrowInvalidOperationException()
	{
		Assert.Throws<InvalidOperationException>(() => _stack.Pop());
	}
	
	[Test]
	public void Pop_NonEmptyStack_ShouldReturnTopElement()
    {
        _stack.Push(10);
		_stack.Push(20);

		var popped = _stack.Pop();
		
        Assert.Multiple(() =>
        {
            Assert.That(popped, Is.EqualTo(20));
            Assert.That(_stack.Size(), Is.EqualTo(1));
        });
    }
	
	[Test]
	public void Top_EmptyStack_ShouldThrowInvalidOperationException()
	{
		Assert.Throws<InvalidOperationException>(() => _stack.Top());
	}
	
	[Test]
	public void Top_NonEmptyStack_ShouldReturnTopElementWithoutRemovingIt()
    {
        _stack.Push(8);
		_stack.Push(15);

		var top = _stack.Top();
		
        Assert.Multiple(() =>
        {
            Assert.That(top, Is.EqualTo(15));
            Assert.That(_stack.Size(), Is.EqualTo(2));
        });
    }
	
	[Test]
	public void IsEmpty_EmptyStack_ShouldReturnTrue()
	{
		Assert.That(_stack.IsEmpty(), Is.True);
	}

	[Test]
	public void IsEmpty_NonEmptyStack_ShouldReturnFalse()
	{
		_stack.Push(3);
		Assert.That(_stack.IsEmpty(), Is.False);
	}
	
	[Test]
	public void Size_EmptyStack_ShouldReturnZero()
	{
		Assert.That(_stack.Size(), Is.EqualTo(0));
	}

	[Test]
	public void Size_NonEmptyStack_ShouldReturnCorrectSize()
	{
		_stack.Push(1);
		_stack.Push(2);

		Assert.That(_stack.Size(), Is.EqualTo(2));
	}
	
	[Test]
	public async Task Can_Read_DataSet()
	{
		// Arrange
		var fileReader = new JsonFileReader();
		var data = await fileReader.ReadFromFileAsync<SortingDataModel>("dataset_sorteren.json");
		var stack = new DataStructures.Stack<int>(data.AscendingList.Length);
		
		// Act
		foreach (var item in data.AscendingList)
		{
			stack.Push(item);
		}
		
		// Assert
		Assert.That(stack.Size(), Is.EqualTo(data.AscendingList.Length));
	}
}