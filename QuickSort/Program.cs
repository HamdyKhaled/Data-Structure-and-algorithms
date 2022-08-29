using System;

namespace QuickSort
{
    class Program
    {
        static public void quickSort(int[] arr, int leftIndex, int rightIndex)
        {
            int pivot;
            if (leftIndex < rightIndex)
            {
                pivot = Partition(arr, leftIndex, rightIndex);
                if (pivot > 1)
                {
                    quickSort(arr, leftIndex, pivot - 1);
                }
                if (pivot + 1 < rightIndex)
                {
                    quickSort(arr, pivot + 1, rightIndex);
                }
            }
        }

        static public int Partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 };
            quickSort(arr, 0, 9);
            Console.Write("\nSorted Array is: ");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
