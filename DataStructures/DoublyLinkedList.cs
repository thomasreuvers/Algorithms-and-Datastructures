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