namespace DataStructures;

public class Deque<T>(int capacity)
{
	private readonly T[] _dequeArray = new T[capacity];
	private int _front = 0;
	private int _rear = capacity - 1;
	private int _count = 0;
	
	// Method to insert an element at the front of the deque
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
	
	// Method to insert an element at the rear of the deque
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
	
	// Method to delete an element from the front of the deque
	public void DeleteLeft()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Deque is empty");
		}
		
		_front = (_front + 1) % capacity;
		_count--;
	}
	
	// Method to delete an element from the end of the deque
	public void DeleteRight()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Deque is empty.");
		}

		_rear = (_rear - 1 + capacity) % capacity;
		_count--;
	}

	// Method to get the current size of the deque
	public int Size()
	{
		return _count;
	}

	// Helper method to check if the deque is empty
	private bool IsEmpty()
	{
		return _count == 0;
	}

	// Helper method to check if the deque is full
	private bool IsFull()
	{
		return _count == capacity;
	}
}