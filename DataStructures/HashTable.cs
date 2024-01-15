namespace DataStructures;

public class HashTable<T>
{
	private readonly List<KeyValuePair<string, T>> _table = new();
	
	private int Hash(string key)
	{
		return key.GetHashCode() % _table.Count;
	}

	public void Insert(string key, T value)
	{
		var index = Hash(key);
		var keyValue = new KeyValuePair<string, T>(key, value);
		_table[index] = keyValue;
	}

	public T Get(string key)
	{
		var index = Hash(key);
		
		if (_table[index].Key.Equals(key))
		{
			return _table[index].Value;
		}
		
		throw new KeyNotFoundException("Key not found");
	}

	public void Delete(string key)
	{
		var index = Hash(key);
		if (!_table[index].Key.Equals(key)) throw new KeyNotFoundException("Key not found");
		
		_table.RemoveAt(index);
	}

	public void Update(string key, T newValue)
	{
		var index = Hash(key);
		
		if (!_table[index].Key.Equals(key)) throw new KeyNotFoundException("Key not found");
		
		_table[index] = new KeyValuePair<string, T>(key, newValue);
	}
}