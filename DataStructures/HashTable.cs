#nullable disable
namespace DataStructures;

public class HashTable<T>(int defaultCapacity = 10)
{
    private readonly LinkedList<KeyValuePair<string, T>>[] _buckets = new LinkedList<KeyValuePair<string, T>>[defaultCapacity];

    public int Hash(string key)
    {
        return Math.Abs(key.GetHashCode()) % _buckets.Length;
    }

    public void Insert(string key, T value)
    {
        var x = key.GetHashCode();
        var hash = Hash(key);
        
        _buckets[hash] ??= new LinkedList<KeyValuePair<string, T>>();
        
        _buckets[hash].AddLast(new KeyValuePair<string, T>(key, value));
    }
    
    public T Get(string key)
    {
        var hash = Hash(key);
        
        if (_buckets[hash] != null)
        {
            foreach (var item in _buckets[hash])
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
        }
        
        throw new KeyNotFoundException("Key not found in the hashtable");
    }
    
    public void Delete(string key)
    {
        var hash = Hash(key);
        
        if (_buckets[hash] != null)
        {
            var currentNode = _buckets[hash].First;
            
            while (currentNode != null)
            {
                if (currentNode.Value.Key.Equals(key))
                {
                    _buckets[hash].Remove(currentNode);
                    return;
                }
                
                currentNode = currentNode.Next;
            }
        }
        
        throw new KeyNotFoundException("Key not found in the hashtable");
    }
    
    public void Update(string key, T newValue)
    {
        var hash = Hash(key);
        
        if (_buckets[hash] != null)
        {
            for (var i = 0; i < _buckets[hash].Count; i++)
            {
                var item = _buckets[hash].ElementAt(i);
                
                if (item.Key.Equals(key))
                {
                    var updatedItem = new KeyValuePair<string, T>(key, newValue);
                    _buckets[hash].Remove(item);
                    _buckets[hash].AddLast(updatedItem);
                    return;
                }
            }
        }
        
        throw new KeyNotFoundException("Key not found in the hashtable");
    }
}