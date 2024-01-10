using Algorithms;
using FileReader;
using FileReader.Models;

namespace Tests.Algorithms;

[TestFixture]
public class MergeSortTests
{
	private SortingDataModel _data = null!;
	
	[SetUp]
	public async Task Setup()
	{
		var fileReader = new JsonFileReader();
		_data = await fileReader.ReadFromFileAsync<SortingDataModel>("dataset_sorteren.json");
	}
	
	[Test]
	public void MergeSort_UnsortableArray_ThrowsArgumentException()
	{
		// Act & Arrange & Assert
		Assert.Throws<ArgumentException>(() => MergeSort.Sort(_data.UnsortableList));
	}

	[Test]
	public void Test_MergeSort_EmptyArray()
	{
		// Arrange & Act
		var sortedArray = MergeSort.Sort(_data.EmptyList);
		
		// Assert
		Assert.That(sortedArray.Length, Is.EqualTo(0));
	}
	
	[Test]
	public void Test_MergeSort_ListWithNullAtBeginning()
	{
		// Arrange & Act
		var sortedArray = MergeSort.Sort(_data.NullList);
        
		// Assert
		Assert.That(sortedArray[0], Is.EqualTo(null));
	}
	
	[Test]
	public void Test_MergeSort_ListWithNullInMiddle()
	{
		// Arrange
		int?[] expectedSortedArray = { null, 1, 3 };
		
		// Act
		var sortedArray = MergeSort.Sort(_data.MultiTypeNullList);
		
		// Assert
		Assert.That(sortedArray, Is.EqualTo(expectedSortedArray));
	}
}