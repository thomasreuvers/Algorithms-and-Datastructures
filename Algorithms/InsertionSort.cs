namespace Algorithms;

public class InsertionSort
{
	public static void Sort<T>(IEnumerable<T> array) where T: IComparable<T>
	{
		var sortedArray = array.ToArray();
		
		for (var i = 1; i < sortedArray.Length; i++)
		{
			var j = i;
			
			while (j > 0 && sortedArray[j].CompareTo(sortedArray[j - 1]) < 0)
			{
				(sortedArray[j], sortedArray[j - 1]) = (sortedArray[j - 1], sortedArray[j]);
				j--;
			}
		}
	}
}