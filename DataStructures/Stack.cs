namespace DataStructures;

public class Stack<T>(int capacity)
{
	private readonly T[] _elements = new T[capacity];
	private int _top = -1; // Index of the top element
	
	// Method to add an element to the top of the stack
	public void Push(T element)
	{
		if (_top == _elements.Length - 1)
		{
			throw new StackOverflowException();
		}
		
		_elements[++_top] = element;
	}
	
	// Method to remove and return the top element from the stack
	public T Pop()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Stack is empty");
		}

		var poppedItem = _elements[_top];
		_elements[_top--] = default; // Clearing the value to prevent memory leaks
		return poppedItem;
	}
	
	
	// Method to return the top element without removing it from the stack
	public T Top()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Stack is empty");
		}

		return _elements[_top];
	}
	
	// Method to check if the stack is empty
	public bool IsEmpty()
	{
		return _top == -1;
	}

	// Method to return the number of elements in the stack
	public int Size()
	{
		return _top + 1;
	}
}