using Algorithms;
using FileReader;
using FileReader.Models;

namespace Tests.Algorithms;

[TestFixture]
public class SelectionSortTests
{
	private SortingDataModel _data = null!;
	
	[SetUp]
	public async Task Setup()
	{
		var fileReader = new JsonFileReader();
		_data = await fileReader.ReadFromFileAsync<SortingDataModel>("dataset_sorteren.json");
	}
	
	[Test]
	public void SelectionSort_UnsortableArray_ThrowsArgumentException()
	{
		// Act & Arrange & Assert
		Assert.Throws<ArgumentException>(() => SelectionSort.Sort(_data.UnsortableList));
	}

	[Test]
	public void Test_SelectionSort_EmptyArray()
	{
		// Arrange & Act
		var sortedArray = SelectionSort.Sort(_data.EmptyList);
		
		// Assert
		Assert.AreEqual(0, sortedArray.Length);
	}
	
	[Test]
	public void Test_SelectionSort_ListWithNullAtBeginning()
	{
		// Arrange & Act
		var sortedArray = SelectionSort.Sort(_data.NullList);
        
		// Assert
		Assert.AreEqual(null, sortedArray[0]);
	}
	
	[Test]
	public void Test_SelectionSort_ListWithNullInMiddle()
	{
		// Arrange
		int?[] expectedSortedArray = { null, 1, 3 };
		
		// Act
		var sortedArray = SelectionSort.Sort(_data.MultiTypeNullList);
		
		// Assert
		Assert.AreEqual(expectedSortedArray, sortedArray);
	}
}