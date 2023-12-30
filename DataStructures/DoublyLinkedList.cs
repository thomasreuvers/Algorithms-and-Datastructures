namespace DataStructures;

public class DoublyLinkedListNode<T>(T value)
{
	public T Value { get; set; } = value;
	public DoublyLinkedListNode<T>? Previous { get; set; }
	public DoublyLinkedListNode<T>? Next { get; set; }
}

public class DoublyLinkedList<T>
{
	private DoublyLinkedListNode<T>? _head;
	private DoublyLinkedListNode<T>? _tail;

	public int Count { get; private set; }

	// Add element to the end of the list
	public void Add(T element)
	{
		var newNode = new DoublyLinkedListNode<T>(element);

		if (_head is null)
		{
			_head = newNode;
			_tail = newNode;
		}
		else
		{
			_tail.Next = newNode;
			newNode.Previous = _tail;
			_tail = newNode;
		}

		Count++;
	}
	
	// Get element at specified index
	public T Get(int index)
	{
		if (index < 0 || index >= Count)
		{
			throw new IndexOutOfRangeException();
		}

		var current = _head;

		for (var i = 0; i < index; i++)
		{
			current = current.Next;
		}

		return current.Value;
	}
	
	// Set element at specified index
	public void Set(int index, T element)
	{
		if(index < 0 || index >= Count)
		{
			throw new IndexOutOfRangeException();
		}

		var current = _head;

		for (var i = 0; i < index; i++)
		{
			current = current.Next;
		}

		current.Value = element;
	}
	
	// Remove element at specified index
	public void Remove(int index)
	{
		if (index < 0 || index >= Count)
		{
			throw new IndexOutOfRangeException();
		}

		var current = _head;

		for (var i = 0; i < index; i++)
		{
			current = current?.Next;
		}

		if (current?.Previous is not null)
		{
			current.Previous.Next = current.Next;
		}
		else
		{
			_head = current?.Next;
		}

		if (current?.Next is not null)
		{
			current.Next.Previous = current.Previous;
		}
		else
		{
			_tail = current?.Previous;
		}

		Count--;
	}
	
	// Remove first occurrence of specified element
	public void Remove(T element)
	{
		var current = _head;

		while (current is not null)
		{
			if (current.Value.Equals(element))
			{
				if (current.Previous is not null)
				{
					current.Previous.Next = current.Next;
				}
				else
				{
					_head = current.Next;
				}

				if (current.Next is not null)
				{
					current.Next.Previous = current.Previous;
				}
				else
				{
					_tail = current.Previous;
				}

				Count--;
				return;
			}

			current = current.Next;
		}
	}
	
	// Check if element exists in the list
	public bool Contains(T element)
	{
		var current = _head;

		while (current != null)
		{
			if (current.Value.Equals(element))
				return true;

			current = current.Next;
		}

		return false;
	}

	// Find index of element
	public int IndexOf(T element)
	{
		var current = _head;
		var index = 0;

		while (current != null)
		{
			if (current.Value.Equals(element))
				return index;

			current = current.Next;
			index++;
		}

		return -1;
	}
}