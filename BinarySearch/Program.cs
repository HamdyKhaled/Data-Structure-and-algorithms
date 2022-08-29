using System;

namespace BinarySearch
{
    class Program
    {
        public static int SearchInsert(int[] nums, int target)
        {

            int min = 0;
            int max = nums.Length - 1;



            while (min <= max)
            {
                int mid = min + (max - min) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                else if (target < nums[mid])
                {
                    max = mid - 1;
                }

                else
                {
                    min = mid + 1;
                }

            }
            return min;

        }

        public static object BinarySearch(int [] array, int key)
        {
            int min = 0;
            int max = array.Length - 1;
            while(min <= max)
            {
                int mid = (min + max) / 2;

                if(key == array [mid])
                {
                    return ++mid;
                }
                else if (key < array[mid])
                {
                    max = mid - 1;
                }

                else if(key > array[mid])
                {
                    min = mid + 1;
                }
            }
            return "None";
        }
        static void Main(string[] args)
        {
            int[] array = { 2, 4, 5, 6, 7, 9, 11 };
           // Console.WriteLine(BinarySearch(array, 30));
            Console.WriteLine(SearchInsert(array, 12));

        }
    }
}
