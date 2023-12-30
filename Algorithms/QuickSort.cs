namespace Algorithms;

public class QuickSort
{
	public static void Sort<T>(IEnumerable<T> array) where T : IComparable<T>
	{
		var sortedArray = array.ToArray();
		Sort(sortedArray, 0, sortedArray.Length - 1);
	}

	private static void Sort<T>(IList<T> array, int left, int right) where T : IComparable<T>
	{
		while (true)
		{
			if (left >= right) return;

			var pivot = Partition(array, left, right);
			Sort(array, left, pivot - 1);
			left = pivot + 1;
		}
	}

	private static int Partition<T>(IList<T> array, int left, int right) where T : IComparable<T>
	{
		var pivot = array[right];
		var i = left - 1;
		
		for (var j = left; j < right; j++)
		{
			if (array[j].CompareTo(pivot) >= 0) continue;
			
			i++;
			(array[i], array[j]) = (array[j], array[i]);
		}

		(array[i + 1], array[right]) = (array[right], array[i + 1]);
		return i + 1;
	}
}