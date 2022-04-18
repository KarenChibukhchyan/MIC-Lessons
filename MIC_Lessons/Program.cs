using System;
using static System.Console;

namespace MIC_Lessons
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] a = new int [3];

            #region 1D Array
            int[] arr = createArray1D(5, 0, 100);
            WriteLine("--------------- 1D case ----------------");
            WriteLine("Original array is:");
            PrintArray1D(arr);
            WriteLine("Maximal value's index:");
            PrintElement(FindMaxIndex(arr));
            WriteLine("Minimal value's index:");
            PrintElement(FindMinIndex(arr));
            WriteLine("After swapping min and max values:");
            PrintArray1D(SwapMinMax(arr));
            WriteLine();
            WriteLine();
            #endregion

            #region 2D Array
            WriteLine("--------------- 2D case ----------------");
            int rowLength = 5, columnLength = 5, minRange = 0, maxRange = 100;
            int[,] matrix = createArray2D(rowLength, columnLength, minRange, maxRange);

            WriteLine("Original matrix is:");
            PrintArray2D(matrix);
            WriteLine("Maximal value's indices:");
            PrintArray1D(FindMaxIndices2D(matrix));
            WriteLine("Minimal value's indices:");
            PrintArray1D(FindMinIndices2D(matrix));
            WriteLine("After swapping min and max values:");
            PrintArray2D(SwapMinMax2D(matrix));
            #endregion
        }

        static int[,] createArray2D(in int rowLength, in int columnLength, in int minRange, in int maxRange)
        {
            Random r = new Random();
            int[,] matrix = new int[rowLength, columnLength];
            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < columnLength; j++)
                {
                    matrix[i, j] = r.Next(minRange, maxRange);
                }
            }

            return matrix;
        }

        static int[] createArray1D(in int length, in int minRange, in int maxRange)
        {
            Random r = new Random();
            int[] arr = new int[length];
            for (var i = 0; i < length; i++)
            {
                arr[i] = r.Next(minRange, maxRange);
            }

            return arr;
        }

        public static int[] FindMinIndices2D(int[,] matrix)
        {
            var min = Int32.MaxValue;
            int[] min_index = {1, -1};
            var rowLength = matrix.GetLength(0);
            var columnLength = matrix.GetLength(1);
            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < columnLength; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min_index = new[] {i, j};
                    }
                }
            }

            return min_index;
        }

        public static int[] FindMaxIndices2D(int[,] matrix)
        {
            var max = Int32.MinValue;
            int[] max_index = {-1, -1};
            var rowLength = matrix.GetLength(0);
            var columnLength = matrix.GetLength(1);
            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < columnLength; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_index = new[] {i, j};
                    }
                }
            }

            return max_index;
        }

        public static int[,] SwapMinMax2D(int[,] matrix)
        {
            var rowLength = matrix.GetLength(0);
            var columnLength = matrix.GetLength(1);
            int[,] output_matrix = new int[rowLength, columnLength];

            int[] max_index = FindMaxIndices2D(matrix);
            int[] min_index = FindMinIndices2D(matrix);

            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < columnLength; j++)
                {
                    output_matrix[i, j] = matrix[i, j];
                }
            }


            if (!max_index.Equals(new[] {-1, -1}) && !min_index.Equals(new[] {-1, -1}))
            {
                var tmp = output_matrix[max_index[0], max_index[1]];
                output_matrix[max_index[0], max_index[1]] = output_matrix[min_index[0], min_index[1]];
                output_matrix[min_index[0], min_index[1]] = tmp;
            }

            return output_matrix;
        }

        public static int FindMaxIndex(int[] arr)
        {
            var max_ = Int32.MinValue;
            var length = arr.GetLength(0);
            int max_index = -1;
            for (int i = 0; i < length; i++)
            {
                if (arr[i] > max_)
                {
                    max_ = arr[i];
                    max_index = i;
                }
            }

            return max_index;
        }


        public static int FindMinIndex(int[] arr)
        {
            var min_ = Int32.MaxValue;
            var length = arr.GetLength(0);
            int min_index = -1;
            for (int i = 0; i < length; i++)
            {
                if (arr[i] < min_)
                {
                    min_ = arr[i];
                    min_index = i;
                }
            }

            return min_index;
        }

        public static int[] SwapMinMax(int[] arr)
        {
            int length = arr.Length;
            int[] output_arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                output_arr[i] = arr[i];
            }

            int maxIndex = FindMaxIndex(arr);
            int minIndex = FindMinIndex(arr);
            if (maxIndex != -1 && minIndex != -1)
            {
                var tmp = output_arr[minIndex];
                output_arr[minIndex] = output_arr[maxIndex];
                output_arr[maxIndex] = tmp;
            }

            return output_arr;
        }

        public static void PrintArray1D(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"{arr[i], 5}");
            }

            WriteLine();
        }

        public static void PrintElement(int element)
        {
            WriteLine(element);
        }

        public static void PrintArray2D(int[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int columnLength = arr.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    Write($"{arr[i, j]}   ");
                }

                WriteLine();
            }
        }
    }
}