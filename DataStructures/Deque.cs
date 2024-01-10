namespace DataStructures;

public class Deque<T>(int capacity)
{
	private readonly T[] _dequeArray = new T[capacity];
	private int _front;
	private int _rear = capacity - 1;
	private int _count;
	
	public void InsertLeft(T item)
	{
		if (IsFull())
		{
			throw new InvalidOperationException("Deque is full");
		}

		_front = (_front - 1 + capacity) % capacity;
		_dequeArray[_front] = item;
		_count++;
	}
	
	public void InsertRight(T item)
	{
		if (IsFull())
		{
			throw new InvalidOperationException("Deque is full");
		}

		_rear = (_rear + 1) % capacity;
		_dequeArray[_rear] = item;
		_count++;
	}
	
	public void DeleteLeft()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Deque is empty");
		}
		
		_front = (_front + 1) % capacity;
		_count--;
	}
	
	public void DeleteRight()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Deque is empty.");
		}

		_rear = (_rear - 1 + capacity) % capacity;
		_count--;
	}
	
	public int Size()
	{
		return _count;
	}
	
	private bool IsEmpty()
	{
		return _count == 0;
	}
	
	private bool IsFull()
	{
		return _count == capacity;
	}
}