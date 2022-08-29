using System;

namespace SelectionSort
{
    class Program
    {
        public static void SelectionSort(int[] ArrayOfNumbers, int noElements)
        {
            for (int i = 0; i < noElements - 1; i++)
            {
                int Imin = i;
                for (int j = i + 1; j < noElements; j++)
                {
                    if (ArrayOfNumbers[j] < ArrayOfNumbers[Imin])
                    {
                        Imin = j;
                    }
                }
                int temp = ArrayOfNumbers[i];
                ArrayOfNumbers[i] = ArrayOfNumbers[Imin];
                ArrayOfNumbers[Imin] = temp;
            }
        }

        public static int[] SquareArray(int[] nums)
        {
            //int[] result = new int[nums.Length];

            //for (int i = 0; i <= nums.Length - 1; i++)
            //{

            //    int iMin = i;

            //    for (int j = i + 1; j <= nums.Length - 1; j++)
            //    {
            //        if ((int)Math.Pow(nums[j], 2) < (int)Math.Pow(nums[iMin], 2))
            //        {
            //            iMin = j;
            //        }

            //    }

            //    int temp = nums[i];
            //    result[i] = (int)Math.Pow(nums[iMin], 2);
            //    nums[i] = (int)Math.Pow(nums[iMin], 2);
            //    nums[iMin] = temp;

            //}
            //return result;
            int n = nums.Length;
            int[] ans = new int[n];
            int i = n - 1;

            for (int l = 0, r = n - 1; l <= r;)
                if (Math.Pow(nums[l], 2) > Math.Pow(nums[r], 2))
                    ans[i--] = nums[l] * nums[l++];
                else
                    ans[i--] = nums[r] * nums[r--];

            return ans;

        
    }
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = { 3, 2, 4, 1, 7, 6 };

            SelectionSort(arrayOfNumbers, 6);

            foreach (int element in arrayOfNumbers)
            {
                Console.WriteLine(element);
            }

            int[] squareArray = {-4, -1, 0, 3, 10};
            SquareArray(squareArray);
        }
    }
}
