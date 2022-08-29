using System;
using System.Text;

namespace TwoPointersProblems
{
    class Program
    {
        public static int GetMaxSumOfSubArray(int[] array, int noElements)
        {
            int start = 0, end = 0;
            int widowSum = 0, maxSum = 0;

            while(end < noElements)
            {
                widowSum += array[end++];
            }

            while (end < array.Length)
            {
                widowSum += array[end++] - array[start++];
                maxSum = Math.Max(widowSum, maxSum);

            }

            return maxSum;

        }

        public static int[] GetTwoSum(int[] array, int targetNumber)
        {
            int start = 0, end = array.Length - 1;
            int[] result = new int[2];

            while(start < end)
            {
                int sum = array[start] + array[end];
                if(sum == targetNumber)
                {
                    result[0] = start + 1;
                    result[1] = end + 1;
                    break;
                }
                else if(sum < targetNumber)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
            return result;
        }

        public static void ReverseArray(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            while(left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                left++;
                right--;
            }

        }

        public static void RotateArray(int[] arr, int k)
        {
            k %= arr.Length;

            Reverse(arr, 0, arr.Length - 1);
            Reverse(arr, 0, k - 1);
            Reverse(arr, k, arr.Length - 1);
        }
        public static void Reverse(int[] arr, int left, int right)
        {
            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                left++;
                right--;
            }

        }

        public static int GetLongestMountain(int[] array)
        {
            int n = array.Length;
            int res = 0;
            for(int i =1; i<= n; i++)
            {
                bool flag = false;

                int counter = 1;
                int j = i;
                // increasing sequense
                while(j< n && array[j] > array[j - 1]) 
                {
                    counter++;
                    j++;
                }
                //decreasing
                while (j!=i && j < n && array[j] < array[j - 1])
                {
                    counter++;
                    j++;
                    flag = true;

                }

                if (j != i && flag && counter > 2)
                {
                    res = Math.Max(res, counter);
                    j--;
                }
                i = j;
            }
            return res;
        }

        public static void MoveZeroes(int[] nums)
        {
            int end = 0;
            int start = 0;

            while (end < nums.Length)
            {

                if (nums[end] == 0)
                {
                    end++;

                }
                else 
                {
                    int temp = nums[end];
                    nums[end] = nums[start];
                    nums[start] = temp;
                    end++;
                    start++;
                }


            }

        }

        public static string ReverseWords(string s)
        {
            char[] chars = s.ToCharArray();
            int anchor = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if(chars[i]== ' ')
                {
                    ReverseChars(chars, anchor, i - 1);
                    anchor = i + 1;
                }
                else if(i == chars.Length - 1)
                {
                    ReverseChars(chars, anchor, i);
                }
            }
            return new string(chars);

        }

        public static void ReverseChars(char[] chars, int left, int right)
        {

            while (left < right)
            {
                Char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                left++;
                right--;
            }
        }
        static void Main(string[] args)
        {
            // Get Max sum of subarray of K elements (equi direction two pointers)

            int[] array = { 1, 9, -1, -2, 7, 3, -1, 2 };

            //Console.WriteLine(GetMaxSumOfSubArray(array, 4));

            // Given and ascending sorted array, find two numbers which should added to get the target number
            // opposite direction two pointers

            int[] nums = { -3, 2, 3, 3, 6, 8, 15 };

            int[] result = GetTwoSum(nums, 6);

            int[] mountainArray = { 2, 1, 4, 7, 6,3,2, 5 };
            int[] mountainArray1 = { 1, 4, 7, 8, 10, 12, 15 };
            int[] zerosArray = { 0,1, 0,3,12 };
            Console.WriteLine(GetLongestMountain(mountainArray));
            int[] rotateArray = { 1,2 };

            string s = "Let's take LeetCode contest";
            Console.WriteLine(ReverseWords(s));
            //RotateArray(mountainArray1, 3);
            MoveZeroes(zerosArray);

            Console.ReadLine();



        }
    }
}
