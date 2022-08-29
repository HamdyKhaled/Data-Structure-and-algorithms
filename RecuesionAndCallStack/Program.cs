using System;

namespace RecuesionAndCallStack
{
    class Program
    {
        static int[] arr = {4,2,60};

        // Return sum of elements in
        // A[0..N-1] using recursion.
        static int findSum(int[] A, int N)
        {
            if (N <= 0)
                return 0;
            return (findSum(A, N - 1) + A[N - 1]);
        }

        public static int findMaxRec(int[] A,
                             int n)
        {
            // if size = 0 means whole array
            // has been traversed
            if (n == 1)
                return A[0];
            if (n == 0)
                return 0;

            return Math.Max(A[n - 1],
                            findMaxRec(A, n - 1));
        }
        public static int FindCount(int [] a, int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {
                return (FindCount(a, n - 1) + 1);
            }

        }
        public static void greeting(string name)
        {
            Console.WriteLine("Hello" + name);
            Welcoming(name);
            SayBye(name);
        }
        public static void Welcoming (string name)
        {
            Console.WriteLine("You are welcome" + name);

        }

        public static void SayBye(string name)
        {
            Console.WriteLine("Bye" + name);

        }
        static void Main(string[] args)
        {
            greeting("Hamdy");
            Console.WriteLine(findSum(arr, arr.Length));
            Console.WriteLine(findMaxRec(arr, arr.Length));
            Console.WriteLine(FindCount(arr, arr.Length));



        }
    }
}
