using System.Collections;
using System.Text.Json.Serialization;

namespace DataStructures;

public class Bucket<TValue>
{
	public List<TValue> Values { get; set; } = new();
}


public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
	private List<KeyValuePair<TKey, TValue>> _buckets { get; set; } = new();
	
	[JsonConstructor]
	public HashTable(List<KeyValuePair<TKey, TValue>> buckets)
	{
		_buckets = buckets;
	}

	public HashTable()
	{
		
	}
	

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return ((IEnumerable<KeyValuePair<TKey, TValue>>)_buckets).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

// public class HashTable<TK, TV>
// {
// 	public Node<TK, TV>[] _buckets { get; set; } = new Node<TK, TV>[100];
//
// 	private int GetHashIndex(TK key) => Math.Abs(key.GetHashCode()) % 100;
//
// 	public void Insert(TK key, TV value)
// 	{
// 		var index = GetHashIndex(key);
//
// 		if (_buckets[index] == null)
// 		{
// 			_buckets[index] = new Node<TK, TV> {Key = key, Value = value};
// 			return;
// 		}
//
// 		var currentNode = _buckets[index];
// 		while (currentNode.Next != null)
// 		{
// 			currentNode = currentNode.Next;
// 		}
//
// 		currentNode.Next = new Node<TK, TV> {Key = key, Value = value};
// 	}
//
// 	public TV Get(TK key)
// 	{
// 		var index = GetHashIndex(key);
//
// 		if (_buckets[index] == null) throw new KeyNotFoundException("Key not found in hashtable");
//
// 		var currentNode = _buckets[index];
// 		while (currentNode != null)
// 		{
// 			if (currentNode.Key.Equals(key))
// 			{
// 				return currentNode.Value;
// 			}
//
// 			currentNode = currentNode.Next;
// 		}
//
// 		throw new KeyNotFoundException("Key not found in hashtable");
// 	}
//
// 	public void Delete(TK key)
// 	{
// 		var index = GetHashIndex(key);
// 		if (_buckets[index] == null) throw new KeyNotFoundException("Key not found in hashtable");
//
// 		var currentNode = _buckets[index];
// 		if (currentNode.Key.Equals(key))
// 		{
// 			_buckets[index] = currentNode.Next;
// 			return;
// 		}
//
// 		while (currentNode.Next != null)
// 		{
// 			if (currentNode.Next.Key.Equals(key))
// 			{
// 				currentNode.Next = currentNode.Next.Next;
// 				return;
// 			}
//
// 			currentNode = currentNode.Next;
// 		}
//
// 		throw new KeyNotFoundException("Key not found in hashtable");
// 	}
//
// 	public void Update(TK key, TV newValue)
// 	{
// 		var index = GetHashIndex(key);
// 		if (_buckets[index] == null) throw new KeyNotFoundException("Key not found in hashtable");
//
// 		var currentNode = _buckets[index];
// 		while (currentNode != null)
// 		{
// 			if (currentNode.Key.Equals(key))
// 			{
// 				currentNode.Value = newValue;
// 				return;
// 			}
//
// 			currentNode = currentNode.Next;
// 		}
//
// 		throw new KeyNotFoundException("Key not found in hashtable");
// 	}
// }


// public class KeyValuePair<TK, TV>(TK key, TV value)
// {
// 	public TK Key { get; set; } = key;
// 	public TV Value { get; set; } = value;
// }
//
//
// public class HashTable<TK, TV>(int size = 100)
// {
// 	private readonly LinkedList<KeyValuePair<TK, TV>>[] _buckets = new LinkedList<KeyValuePair<TK, TV>>[size];
// 	
// 	private int GetHashIndex(TK key) => Math.Abs(key.GetHashCode()) % size;
//
// 	public void Insert(TK key, TV value)
// 	{
// 		var index = GetHashIndex(key);
// 		
// 		if (_buckets[index] == null)
// 		{
// 			_buckets[index] = new LinkedList<KeyValuePair<TK, TV>>();
// 		}
//
// 		// Check if key already exists, and if so, update the value
// 		foreach (var pair in _buckets[index].Where(pair => pair.Key.Equals(key)))
// 		{
// 			pair.Value = value;
// 			return;
// 		}
//
// 		// If the key doesn't exist, add a new key-value pair
// 		_buckets[index].AddLast(new KeyValuePair<TK, TV>(key, value));
// 	}
// 	
// 	public TV Get(TK key)
// 	{
// 		var index = GetHashIndex(key);
// 		
// 		if (_buckets[index] == null) throw new KeyNotFoundException("Key not found in hashtable");
// 		
// 		foreach (var pair in _buckets[index].Where(pair => pair.Key.Equals(key)))
// 		{
// 			return pair.Value;
// 		}
//
// 		throw new KeyNotFoundException("Key not found in hashtable");
// 	}
// 	
// 	public void Delete(TK key)
// 	{
// 		var index = GetHashIndex(key);
// 		if (_buckets[index] == null) throw new KeyNotFoundException("Key not found in hashtable");
// 		
// 		var currentNode = _buckets[index].First;
// 		while (currentNode != null)
// 		{
// 			if (currentNode.Value.Key.Equals(key))
// 			{
// 				_buckets[index].Remove(currentNode);
// 				return;
// 			}
// 			currentNode = currentNode.Next;
// 		}
//
// 		throw new KeyNotFoundException("Key not found in hashtable");
// 	}
// 	
// 	public void Update(TK key, TV newValue)
// 	{
// 		var index = GetHashIndex(key);
// 		if (_buckets[index] == null) throw new KeyNotFoundException("Key not found in hashtable");
// 		
// 		foreach (var pair in _buckets[index].Where(pair => pair.Key.Equals(key)))
// 		{
// 			pair.Value = newValue;
// 			return;
// 		}
//
// 		throw new KeyNotFoundException("Key not found in hashtable");
// 	}
// }