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
			Resize();
		}
        
		_array[_size] = element;
		_size++;
	}

	private void Resize()
	{
		_capacity *= 2;
		var newArray = new T[_capacity];
		for (var i = 0; i < _size; i++)
		{
			newArray[i] = _array[i];
		}

		_array = newArray;
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
		var index = -1;
		for (var i = 0; i < _size; i++)
		{
			if (!EqualityComparer<T>.Default.Equals(_array[i], element)) continue;
			
			index = i;
			break;
		}

		if (index >= 0)
		{
			Remove(index);
		}
	}
	
	public bool Contains(T element)
	{
		return IndexOf(element) >= 0;
	} 
	
	public int IndexOf(T element)
	{
		for (var i = 0; i < _size; i++)
		{
			if (EqualityComparer<T>.Default.Equals(_array[i], element))
			{
				return i;
			}
		}

		return -1;
	}
	
	public int Size()
	{
		return _size;
	}
}