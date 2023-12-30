namespace DataStructures;

public class DynamicArray<T>
{
	private T[] _array;
	private int _size;
	private int _capacity;

	public DynamicArray()
	{
		_capacity = 4; // Initial capacity of the array
		_array = new T[_capacity];
		_size = 0; // Initial size of the array
	}

	// Function to add an element to the array
	public void Add(T element)
	{
		if (_size == _capacity)
		{
			// If the array is full, double its capacity
			var newArray = new T[_capacity * 2];
			Array.Copy(_array, newArray, _capacity);
			_array = newArray;
			_capacity *= 2;
		}
        
		_array[_size] = element;
		_size++;
	}

	// Function to get an element from the array at a given index
	public T Get(int index)
	{
		if (index < 0 || index >= _size)
		{
			throw new IndexOutOfRangeException("Index out of range");
		}

		return _array[index];
	}
	
	// Function to set an element at a given index in the array
	public void Set(int index, T element)
	{
		if (index < 0 || index >= _size)
		{
			throw new IndexOutOfRangeException("Index out of range");
		}

		_array[index] = element;
	}
	
	// Function to remove an element from the array at a given index
	public void Remove(int index)
	{
		if(index < 0 || index >= _size)
		{
			throw new IndexOutOfRangeException("Index out of range");
		}
		
		for(var i = index; i < _size - 1; i++)
		{
			_array[i] = _array[i + 1];
		}

		_size--;
	}
	
	// Function to remove a specific element from the array
	public void Remove(T element)
	{
		var index = Array.IndexOf(_array, element, 0, _size);

		if (index >= 0)
		{
			Remove(index);
		}
	}
	
	// Function to check if the array contains a specific element
	public bool Contains(T element)
	{
		return Array.IndexOf(_array, element, 0, _size) >= 0;
	} 
	
	// Function to find the index of a specific element in the array
	public int IndexOf(T element)
	{
		return Array.IndexOf(_array, element, 0, _size);
	}
	
	// Function to get the current size of the array
	public int Size()
	{
		return _size;
	}
}