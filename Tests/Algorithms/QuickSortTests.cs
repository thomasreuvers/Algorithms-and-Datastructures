using Algorithms;
using FileReader;
using FileReader.Models;

namespace Tests.Algorithms;

[TestFixture]
public class QuickSortTests
{
	private SortingDataModel _data = null!;
	
	[SetUp]
	public async Task Setup()
	{
		var fileReader = new JsonFileReader();
		_data = await fileReader.ReadFromFileAsync<SortingDataModel>("data_sorteren.json");
	}
	
	[Test]
	public void QuickSort_UnsortableArray_ThrowsArgumentException()
	{
		// Act & Arrange & Assert
		Assert.Throws<ArgumentException>(() => QuickSort.Sort(_data.UnsortableList));
	}

	[Test]
	public void Test_QuickSort_EmptyArray()
	{
		// Arrange & Act
		var sortedArray = QuickSort.Sort(_data.EmptyList);
		
		// Assert
		Assert.AreEqual(0, sortedArray.Length);
	}
	
	[Test]
	public void Test_QuickSort_ListWithNullAtBeginning()
	{
		// Arrange & Act
		var sortedArray = QuickSort.Sort(_data.NullList);
        
		// Assert
		Assert.AreEqual(null, sortedArray[0]);
	}
	
	[Test]
	public void Test_QuickSort_ListWithNullInMiddle()
	{
		// Arrange
		int?[] expectedSortedArray = { null, 1, 3 };
		
		// Act
		var sortedArray = QuickSort.Sort(_data.MultiTypeNullList);
		
		// Assert
		Assert.AreEqual(expectedSortedArray, sortedArray);
	}
}