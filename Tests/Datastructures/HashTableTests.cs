using DataStructures;
using FileReader;
using FileReader.Models;

namespace Tests.Datastructures;

[TestFixture]
public class HashTableTests
{
	[Test]
	public async Task Can_Read_DataSet()
	{
		// Arrange
		var fileReader = new JsonFileReader();
		var data = await fileReader.ReadFromFileAsync<HashingDataModel>("dataset_hashing.json");
		var hashTable = new HashTable<List<int>>();
		
		// Act
		foreach (var item in data.HashTableKeyValues)
		{
			hashTable.Insert(item.Key, item.Value);
		}
		
		// Assert
		foreach (var item in data.HashTableKeyValues)
		{
			var value = hashTable.Get(item.Key);
			Assert.That(value, Is.EqualTo(item.Value));
		}
	}

	[Test]
	public void Can_Insert_Value()
	{
		// Arrange
		var hashTable = new HashTable<int>();
		
		// Act
		hashTable.Insert("test", 1);
		
		// Assert
		Assert.That(hashTable.Get("test"), Is.EqualTo(1));
	}

	[Test]
	public void Can_Update_Value()
	{
		// Arrange
		var hashTable = new HashTable<int>();
		hashTable.Insert("test", 1);
		
		// Act
		hashTable.Update("test", 2);
		
		// Assert
		Assert.That(hashTable.Get("test"), Is.EqualTo(2));
	}
	
	[Test]
	public void Can_Delete_Value()
	{
		// Arrange
		var hashTable = new HashTable<int>();
		hashTable.Insert("test", 1);
		
		// Act
		hashTable.Delete("test");
		
		// Assert
		Assert.Throws<KeyNotFoundException>(() => hashTable.Get("test"));
	}

	[Test]
	public void Can_Get_Value()
	{
		// Arrange
		var hashTable = new HashTable<int>();
		hashTable.Insert("test", 1);
		
		// Act & Assert
		Assert.That(hashTable.Get("test"), Is.EqualTo(1));
	}
}