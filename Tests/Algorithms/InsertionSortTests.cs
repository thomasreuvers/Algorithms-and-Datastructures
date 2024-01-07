using Algorithms;
using FileReader;
using FileReader.Models;

namespace Tests.Algorithms;

[TestFixture]
public class InsertionSortTests
{
	private SortingDataModel _data = null!;
	
	[SetUp]
	public async Task Setup()
	{
		var fileReader = new JsonFileReader();
		_data = await fileReader.ReadFromFileAsync<SortingDataModel>("data_sorteren.json");
	}
	
	[Test]
	public void InsertionSort_UnsortableArray_ThrowsArgumentException()
	{
		// Act & Arrange & Assert
		Assert.Throws<ArgumentException>(() => InsertionSort.Sort(_data.UnsortableList));
	}

	[Test]
	public void Test_InsertionSort_EmptyArray()
	{
		// Arrange & Act
		var sortedArray = InsertionSort.Sort(_data.EmptyList);
		
		// Assert
		Assert.AreEqual(0, sortedArray.Length);
	}
	
	[Test]
	public void Test_InsertionSort_ListWithNullAtBeginning()
	{
		// Arrange & Act
		var sortedArray = InsertionSort.Sort(_data.NullList);
        
		// Assert
		Assert.AreEqual(null, sortedArray[0]);
	}
	
	[Test]
	public void Test_InsertionSort_ListWithNullInMiddle()
	{
		// Arrange
		int?[] expectedSortedArray = { null, 1, 3 };
		
		// Act
		var sortedArray = InsertionSort.Sort(_data.MultiTypeNullList);
		
		// Assert
		Assert.AreEqual(expectedSortedArray, sortedArray);
	}
}