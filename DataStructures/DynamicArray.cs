namespace DataStructures;

public class DynamicArray
{
	private int[] _array;
	private int _size;
	private int _capacity;

	public DynamicArray()
	{
		_capacity = 4; // Initial capacity of the array
		_array = new int[_capacity];
		_size = 0; // Initial size of the array
	}

	// Function to add an element to the array
	public void Add(int element)
	{
		if (_size == _capacity)
		{
			// If the array is full, double its capacity
			var newArray = new int[_capacity * 2];
			Array.Copy(_array, newArray, _capacity);
			_array = newArray;
			_capacity *= 2;
		}
        
		_array[_size] = element;
		_size++;
	}

	// Function to get an element from the array at a given index
	public int Get(int index)
	{
		if (index < 0 || index >= _size)
		{
			throw new IndexOutOfRangeException("Index out of range");
		}

		return _array[index];
	}

	// Function to get the current size of the array
	public int Size()
	{
		return _size;
	}
}