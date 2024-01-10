namespace DataStructures;

public class PriorityQueue<T>(Func<T, T, int> comparer, int capacity = 10)
{
	private T[] _heap = new T[capacity];
	private int _size;

	public void Add(T element)
	{
		if(_size == _heap.Length)
		{
			Resize();
		}
		
		_heap[_size] = element;
		_size++;
		
		HeapifyUp();
	}

	private void Resize()
	{
		capacity *= 2;
		var newArray = new T[capacity];
		for (var i = 0; i < _size; i++)
		{
			newArray[i] = _heap[i];
		}

		_heap = newArray;
	}

	public T Peek()
	{
		if (_size == 0)
			throw new InvalidOperationException("Priority queue is empty");

		return _heap[0];
	}
	
	public T Poll()
	{
		if (_size == 0)
			throw new InvalidOperationException("Priority queue is empty");

		var item = _heap[0];
		_heap[0] = _heap[_size - 1];
		_heap[_size - 1] = default;
		_size--;

		HeapifyDown();

		return item;
	}
	
	private void HeapifyUp()
	{
		var index = _size - 1;
		while (index > 0 && comparer(_heap[index], _heap[Parent(index)]) < 0)
		{
			Swap(index, Parent(index));
			index = Parent(index);
		}
	}

	private void HeapifyDown()
	{
		var index = 0;
		while (LeftChild(index) < _size)
		{
			var smallerChildIndex = LeftChild(index);
			var rightChildIndex = RightChild(index);

			if (rightChildIndex < _size && comparer(_heap[rightChildIndex], _heap[smallerChildIndex]) < 0)
				smallerChildIndex = rightChildIndex;

			if (comparer(_heap[index], _heap[smallerChildIndex]) < 0)
				break;

			Swap(index, smallerChildIndex);
			index = smallerChildIndex;
		}
	}

	private void Swap(int i, int j)
	{
		(_heap[i], _heap[j]) = (_heap[j], _heap[i]);
	}

	private int Parent(int index) => (index - 1) / 2;
	private int LeftChild(int index) => 2 * index + 1;
	private int RightChild(int index) => 2 * index + 2;
}