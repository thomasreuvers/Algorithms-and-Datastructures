namespace DataStructures;

public class Stack<T>(int capacity)
{
	private readonly T[] _elements = new T[capacity];
	private int _top = -1;
	
	public void Push(T element)
	{
		if (_top == _elements.Length - 1)
		{
			throw new StackOverflowException();
		}
		
		_elements[++_top] = element;
	}
	
	public T Pop()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Stack is empty");
		}

		var poppedItem = _elements[_top];
		_elements[_top--] = default;
		return poppedItem;
	}
	
	
	public T Top()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Stack is empty");
		}

		return _elements[_top];
	}
	
	public bool IsEmpty()
	{
		return _top == -1;
	}
	
	public int Size()
	{
		return _top + 1;
	}
}