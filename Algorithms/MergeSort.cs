namespace Algorithms;

public class MergeSort
{
	public static T[] Sort<T>(T[] array)
	{
		var sortedArray = new T[array.Length];
		Sort(array, sortedArray, 0, array.Length - 1);
		return sortedArray;
	}
	
	private static void Sort<T>(T[] array, T[] sortedArray, int left, int right)
	{
		if (left >= right) return;
		
		var middle = (left + right) / 2;
		Sort(array, sortedArray, left, middle);
		Sort(array, sortedArray, middle + 1, right);
		Merge(array, sortedArray, left, middle, right);
	}
	
	private static void Merge<T>(T[] array, T[] sortedArray, int left, int middle, int right)
	{
		var leftIndex = left;
		var rightIndex = middle + 1;
		var sortedIndex = left;
		
		while (leftIndex <= middle && rightIndex <= right)
		{
			if (Comparer<T>.Default.Compare(array[leftIndex], array[rightIndex]) <= 0)
			{
				sortedArray[sortedIndex] = array[leftIndex];
				leftIndex++;
			}
			else
			{
				sortedArray[sortedIndex] = array[rightIndex];
				rightIndex++;
			}

			sortedIndex++;
		}

		while (leftIndex <= middle)
		{
			sortedArray[sortedIndex] = array[leftIndex];
			leftIndex++;
			sortedIndex++;
		}

		while (rightIndex <= right)
		{
			sortedArray[sortedIndex] = array[rightIndex];
			rightIndex++;
			sortedIndex++;
		}

		for (var i = left; i <= right; i++)
		{
			array[i] = sortedArray[i];
		}
	}
}