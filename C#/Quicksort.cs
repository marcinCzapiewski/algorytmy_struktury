using System;
using System.Diagnostics;

namespace ASD
{
    class Program
    {
        private static int constant = 200;
        private static Random rnd = new Random();
        private static Stopwatch stopWatch = new Stopwatch();

        static void Main(string[] args)
        {
            //random numbers
            var random100 = new int[100];
            var random500 = new int[500];
            var random1000 = new int[1000];
            var random2500 = new int[2500];
            FillInRandomArrays(random100, random500, random1000, random2500);

            var random100QuickSortTime = GetSortingTime(random100, QuickSort);
            var random500QuickSortTime = GetSortingTime(random500, QuickSort);
            var random1000QuickSortTime = GetSortingTime(random1000, QuickSort);
            var random2500QuickSortTime = GetSortingTime(random2500, QuickSort);

            var random100QuickSortTimeWithBubble = GetSortingTime(random100, QuickSortWithBubble);
            var random500QuickSortTimeWithBubble = GetSortingTime(random500, QuickSortWithBubble);
            var random1000QuickSortTimeWithBubble = GetSortingTime(random1000, QuickSortWithBubble);
            var random2500QuickSortTimeWithBubble = GetSortingTime(random2500, QuickSortWithBubble);

            PrintRandomOutput(random100QuickSortTime, random500QuickSortTime, random1000QuickSortTime, random2500QuickSortTime,
                random100QuickSortTimeWithBubble, random500QuickSortTimeWithBubble, random1000QuickSortTimeWithBubble, random2500QuickSortTimeWithBubble);


            //descending numbers
            var descending100 = new int[100];
            var descending500 = new int[500];
            var descending1000 = new int[1000];
            var descending2500 = new int[2500];
            FillInDescendingArrays(descending100, descending500, descending1000, descending2500);

            var descending100QuickSortTime = GetSortingTime(descending100, QuickSort);
            var descending500QuickSortTime = GetSortingTime(descending500, QuickSort);
            var descending1000QuickSortTime = GetSortingTime(descending1000, QuickSort);
            var descending2500QuickSortTime = GetSortingTime(descending2500, QuickSort);

            var descending100QuickSortTimeWithBubble = GetSortingTime(descending100, QuickSortWithBubble);
            var descending500QuickSortTimeWithBubble = GetSortingTime(descending500, QuickSortWithBubble);
            var descending1000QuickSortTimeWithBubble = GetSortingTime(descending1000, QuickSortWithBubble);
            var descending2500QuickSortTimeWithBubble = GetSortingTime(descending2500, QuickSortWithBubble);
            PrintDescesdingOutput(descending100QuickSortTime, descending500QuickSortTime, descending1000QuickSortTime, descending2500QuickSortTime,
                descending100QuickSortTimeWithBubble, descending500QuickSortTimeWithBubble, descending1000QuickSortTimeWithBubble, descending2500QuickSortTimeWithBubble);

            //quicksort
            var quickSortArray = new int[10];
            var quickSortWithBubbleArray = new int[10];
            FillArrays(quickSortArray, quickSortWithBubbleArray);

            Console.WriteLine("PRZYKLAD Z QUICKSORTEM");
            Console.Write("1 tablica przed sortowaniem: ");
            PrintArray(quickSortArray);
            Console.WriteLine();

            QuickSort(quickSortArray, 0, quickSortArray.Length - 1);
            Console.WriteLine("\nPosortowany po sortowaniu z pivotem na koncu: ");
            PrintArray(quickSortArray);
            Console.WriteLine();

            Console.WriteLine("\nPRZYKLAD Z QS + BUB");
            Console.Write("2 tablica przed sortowaniem: ");
            PrintArray(quickSortWithBubbleArray);
            Console.WriteLine();

            QuickSortWithBubble(quickSortWithBubbleArray, 0, quickSortWithBubbleArray.Length - 1);
            Console.WriteLine();
            Console.WriteLine("Posortowany array z pivotem na koncu: ");
            PrintArray(quickSortWithBubbleArray);
            Console.ReadKey();
        }


        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(arr, left, right);

                QuickSort(arr, left, q);
                QuickSort(arr, q + 1, right);
            }
        }

        static void QuickSortWithBubble(int[] arr, int left, int right)
        {
            if (left < right)
            {
                if (right - left + 1 < constant)
                {
                    Bubble(arr, left, right);
                }
                else
                {
                    int q = Partition(arr, left, right);
                    QuickSortWithBubble(arr, left, q);
                    QuickSortWithBubble(arr, q + 1, right);
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = (left - 1);

            for (int j = left; j <= right - 1; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, right);
            if (i < right)
            {
                return i;
            }
            else
            {
                return (i + 1);
            }
        }

        private static void Bubble(int[] arr, int p, int r)
        {
            int i, j;
            for (i = p; i <= r; i++)
            {
                for (j = p; j <= r; j++)
                {
                    if (j + 1 < arr.Length && arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }

        private static void PrintArray(int[] arr)
        {
            foreach(var element in arr)
            {
                Console.Write($"{element} ");
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        private static double GetSortingTime(int[] array, Action<int [], int, int> sortingMethod)
        {
            stopWatch.Start();
            sortingMethod(array, 0, array.Length - 1);
            stopWatch.Stop();

            var time = stopWatch.Elapsed.TotalMilliseconds * 1000;
            stopWatch.Reset();

            return time;
        }

        private static void FillInDescendingArrays(int[] descending100, int[] descending500, int[] descending1000, int[] descending2500)
        {
            for (int i = 99; i >= 0; i--)
            {
                descending100[i] = i;
            }
            for (int i = 499; i >= 0; i--)
            {
                descending500[i] = i;
            }
            for (int i = 999; i >= 0; i--)
            {
                descending1000[i] = i;
            }
            for (int i = 2499; i >= 0; i--)
            {
                descending2500[i] = i;
            }
        }

        private static void FillInRandomArrays(int[] random100, int[] random500, int[] random1000, int[] random2500)
        {
            for (int i = 0; i < 100; i++)
            {
                random100[i] = rnd.Next(1, 101);
            }
            for (int i = 0; i < 500; i++)
            {
                random500[i] = rnd.Next(1, 501);
            }
            for (int i = 0; i < 1000; i++)
            {
                random1000[i] = rnd.Next(1, 1001);
            }
            for (int i = 0; i < 2500; i++)
            {
                random2500[i] = rnd.Next(1, 2501);
            }
        }

        private static void FillArrays(int[] quickSortArray, int[] quickSortWithBubbleArray)
        {
            for (int i = 0; i < 10; i++)
            {
                quickSortArray[i] = rnd.Next(1, 53);
                quickSortWithBubbleArray[i] = rnd.Next(1, 53);
            }
        }

        private static void PrintDescesdingOutput(double descending100QuickSortTime, double descending500QuickSortTime, double descending1000QuickSortTime,
        double descending2500QuickSortTime, double descending100QuickSortTimeWithBubble, double descending500QuickSortTimeWithBubble,
        double descending1000QuickSortTimeWithBubble,double descending2500QuickSortTimeWithBubble)
        {
            Console.WriteLine("NIEKORZYSTNE \n");
            Console.WriteLine("Rozmiar tablicy N     |   QuickSort        |  QuickSort+Bubble");
            Console.WriteLine("    100               |       {0:00000.0}      |		{1:00000.0}", descending100QuickSortTime, descending100QuickSortTimeWithBubble);
            Console.WriteLine("    500               |       {0:00000.0}      |		{1:00000.0}", descending500QuickSortTime, descending500QuickSortTimeWithBubble);
            Console.WriteLine("    1000              |       {0:00000.0}      |		{1:00000.0}", descending1000QuickSortTime, descending1000QuickSortTimeWithBubble);
            Console.WriteLine("    2500              |       {0:00000.0}      |		{1:00000.0}", descending2500QuickSortTime, descending2500QuickSortTimeWithBubble);
        }

        private static void PrintRandomOutput(double random100QuickSortTime, double random500QuickSortTime, double random1000QuickSortTime,
            double random2500QuickSortTime, double random100QuickSortTimeWithBubble, double random500QuickSortTimeWithBubble,
            double random1000QuickSortTimeWithBubble, double random2500QuickSortTimeWithBubble)
        {
            Console.WriteLine("DANE LOSOWE \n");
            Console.WriteLine("Rozmiar tablicy N     |   QuickSort        |  QuickSort+Bubble");
            Console.WriteLine("    100               |       {0:00000.0}      |		{1:00000.0}", random100QuickSortTime, random100QuickSortTimeWithBubble);
            Console.WriteLine("    500               |       {0:00000.0}      |		{1:00000.0}", random500QuickSortTime, random500QuickSortTimeWithBubble);
            Console.WriteLine("    1000              |       {0:00000.0}      |		{1:00000.0}", random1000QuickSortTime, random1000QuickSortTimeWithBubble);
            Console.WriteLine("    2500              |       {0:00000.0}      |		{1:00000.0}", random2500QuickSortTime, random2500QuickSortTimeWithBubble);
        }
    }
}
