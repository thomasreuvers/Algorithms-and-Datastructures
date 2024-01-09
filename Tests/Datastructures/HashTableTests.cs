using DataStructures;
using FileReader;
using FileReader.Models;

namespace Tests.Datastructures;

[TestFixture]
public class HashTableTests
{
	
	[SetUp]
	public async Task Setup()
	{
		var fileReader = new JsonFileReader();
		var x = await fileReader.ReadFromFileAsync<HashTable<string, int[]>>("dataset_hashing.json");
	}
	
	// [Test]
	// public void Insert_NewKey_Successfully()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	//
	// 	// Act
	// 	hashTable.Insert(1, "One");
	//
	// 	// Assert
	// 	Assert.That(hashTable.Get(1), Is.EqualTo("One"));
	// }
	//
	// [Test]
	// public void Insert_ExistingKey_UpdatesValue()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	// 	hashTable.Insert(1, "One");
	//
	// 	// Act
	// 	hashTable.Insert(1, "NewOne");
	//
	// 	// Assert
	// 	Assert.That(hashTable.Get(1), Is.EqualTo("NewOne"));
	// }
	//
	// [Test]
	// public void Get_ExistingKey_ReturnsCorrectValue()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	// 	hashTable.Insert(1, "One");
	//
	// 	// Act
	// 	var result = hashTable.Get(1);
	//
	// 	// Assert
	// 	Assert.That(result, Is.EqualTo("One"));
	// }
	//
	// [Test]
	// public void Get_NonExistingKey_ThrowsKeyNotFoundException()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	//
	// 	// Act & Assert
	// 	Assert.Throws<KeyNotFoundException>(() => hashTable.Get(100));
	// }
	//
	// [Test]
	// public void Delete_ExistingKey_RemovesKey()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	// 	hashTable.Insert(1, "One");
	//
	// 	// Act
	// 	hashTable.Delete(1);
	//
	// 	// Assert
	// 	Assert.Throws<KeyNotFoundException>(() => hashTable.Get(1));
	// }
	//
	// [Test]
	// public void Delete_NonExistingKey_ThrowsKeyNotFoundException()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	//
	// 	// Act & Assert
	// 	Assert.Throws<KeyNotFoundException>(() => hashTable.Delete(100));
	// }
	//
	// [Test]
	// public void Update_ExistingKey_Successfully()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	// 	hashTable.Insert(1, "One");
	//
	// 	// Act
	// 	hashTable.Update(1, "NewOne");
	//
	// 	// Assert
	// 	Assert.That(hashTable.Get(1), Is.EqualTo("NewOne"));
	// }
	//
	// [Test]
	// public void Update_NonExistingKey_ThrowsKeyNotFoundException()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	//
	// 	// Act & Assert
	// 	Assert.Throws<KeyNotFoundException>(() => hashTable.Update(100, "NewValue"));
	// }
	//
	// [Test]
	// public void CanHandleCollisions()
	// {
	// 	// Arrange
	// 	var hashTable = new HashTable<int, string>();
	// 	hashTable.Insert(1, "One");
	// 	hashTable.Insert(101, "OneHundredOne");
	//
	// 	// Act
	// 	var result = hashTable.Get(101);
	//
	// 	// Assert
	// 	Assert.That(result, Is.EqualTo("OneHundredOne"));
	// }

	[Test]
	public void Can_Read_Json_Input()
	{
		// // Arrange
		// var hashTable = new HashTable<string, int>();

		// hashTable = _data.HashTable;

		// Act
		// var result = hashTable.Get("d");
		//
		// // Assert
		// Assert.That(result, Is.EqualTo(
		// 	));
	}
}