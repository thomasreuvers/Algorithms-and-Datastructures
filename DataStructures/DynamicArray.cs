namespace DataStructures;

public class DynamicArray<T>
{
	private T[] _array;
	private int _size;
	private int _capacity;

	public DynamicArray()
	{
		_capacity = 4;
		_array = new T[_capacity];
		_size = 0;
	}
	
	public void Add(T element)
	{
		if (_size == _capacity)
		{
			var newArray = new T[_capacity * 2];
			Array.Copy(_array, newArray, _capacity);
			_array = newArray;
			_capacity *= 2;
		}
        
		_array[_size] = element;
		_size++;
	}

	public T Get(int index)
	{
		if (index < 0 || index >= _size)
		{
			throw new IndexOutOfRangeException("Index out of range");
		}

		return _array[index];
	}
	
	public void Set(int index, T element)
	{
		if (index < 0 || index >= _size)
		{
			throw new IndexOutOfRangeException("Index out of range");
		}

		_array[index] = element;
	}
	
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
	
	public void Remove(T element)
	{
		var index = Array.IndexOf(_array, element, 0, _size);

		if (index >= 0)
		{
			Remove(index);
		}
	}
	
	public bool Contains(T element)
	{
		return Array.IndexOf(_array, element, 0, _size) >= 0;
	} 
	
	public int IndexOf(T element)
	{
		return Array.IndexOf(_array, element, 0, _size);
	}
	
	public int Size()
	{
		return _size;
	}
}