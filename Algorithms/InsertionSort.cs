namespace Algorithms;

public class InsertionSort
{
	public static T[] Sort<T>(IEnumerable<T> array)
	{
		var sortedArray = array.ToArray();
		
		for (var i = 1; i < sortedArray.Length; i++)
		{
			var j = i;
			
			// while (j > 0 && sortedArray[j].CompareTo(sortedArray[j - 1]) < 0)
			// {
			// 	(sortedArray[j], sortedArray[j - 1]) = (sortedArray[j - 1], sortedArray[j]);
			// 	j--;
			// }
			
			while (j > 0 && Comparer<T>.Default.Compare(sortedArray[i], sortedArray[j - 1]) < 0)
			{
				(sortedArray[j], sortedArray[j - 1]) = (sortedArray[j - 1], sortedArray[j]);
				j--;
			}
		}

		return sortedArray;
	}
}