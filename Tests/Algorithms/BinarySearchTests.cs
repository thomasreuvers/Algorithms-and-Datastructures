using Algorithms;
using FileReader;
using FileReader.Models;

namespace Tests.Algorithms;

[TestFixture]
public class BinarySearchTests
{
	private SortingDataModel _data = null!;
	
	[SetUp]
	public async Task Setup()
	{
		var fileReader = new JsonFileReader();
		_data = await fileReader.ReadFromFileAsync<SortingDataModel>("data_sorteren.json");
	}
	
	[Test]
	public void Search_EmptyList_ReturnsMinusOne()
	{
		var result = BinarySearch.Search(_data.EmptyList, 10);
		Assert.That(result, Is.EqualTo(-1));
	}

	[Test]
	public void Search_NullElementInList_ReturnsIndex()
	{
		var result = BinarySearch.Search(_data.NullList, null);
		Assert.That(result, Is.EqualTo(0));
	}
	
	[Test]
	public void Search_NullElementInListWithMultipleItems_ReturnsIndex()
	{
		var result = BinarySearch.Search(_data.MultiTypeNullList, null);
		Assert.That(result, Is.EqualTo(1));
	}
	
	[Test]
	public void Search_UnsortableList_ReturnMinusOne()
	{
		Assert.Throws<ArgumentException>(() => BinarySearch.Search(_data.UnsortableList, "string"));
	}
	
	[Test]
	public void Search_DecreasingOrderList_ReturnsIndex()
	{
		// Reverse the list to make it descending
		_data.DescendingList = _data.DescendingList.Reverse().ToArray();
		
		var result = BinarySearch.Search(_data.DescendingList, -10033224);
		Assert.That(result, Is.EqualTo(0));
	}
	
	[Test]
	public void Search_IncreasingOrderList_ReturnsIndex()
	{
		var result = BinarySearch.Search(_data.AscendingList, -100324);
		Assert.That(result, Is.EqualTo(0));
	}
}