namespace Algorithms;

public class QuickSort
{
	public static T[] Sort<T>(IEnumerable<T> array)
	{
		var sortedArray = array.ToArray();
		Sort(sortedArray, 0, sortedArray.Length - 1);

		return sortedArray;
	}

	private static void Sort<T>(IList<T> array, int left, int right)
	{
		if (left >= right) return;

		var pivot = Partition(array, left, right);
		Sort(array, left, pivot - 1);
	}

	public static int Partition<T>(IList<T> array, int left, int right)
	{
		var pivot = array[right];
		var i = left - 1;
		
		for (var j = left; j < right; j++)
		{
			if (Comparer<T>.Default.Compare(array[j], pivot) >= 0) continue;
			
			i++;
			(array[i], array[j]) = (array[j], array[i]);
		}

		(array[i + 1], array[right]) = (array[right], array[i + 1]);
		return i + 1;
	}
}