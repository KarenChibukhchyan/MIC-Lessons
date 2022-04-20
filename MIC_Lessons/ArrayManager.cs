using System;
using static System.Console;

namespace MIC_Lessons
{
    public class ArrayManager
    {
        public int[,] createArray(Size size, Range range)
        {
            Random r = new Random();
            int[,] matrix = new int[size.row_size, size.column_size];
            for (var i = 0; i < size.row_size; i++)
            {
                for (var j = 0; j < size.column_size; j++)
                {
                    matrix[i, j] = r.Next(range.min_value, range.max_value);
                }
            }

            return matrix;
        }

        public int[] createArray(int length, Range range)
        {
            Random r = new Random();
            int[] arr = new int[length];
            for (var i = 0; i < length; i++)
            {
                arr[i] = r.Next(range.min_value, range.max_value);
            }

            return arr;
        }

        public Index GetMin(int[,] matrix)
        {
            var min = Int32.MaxValue;
            Index min_index = new Index() {row_index = -1, column_index = -1};
            var rowLength = matrix.GetLength(0);
            var columnLength = matrix.GetLength(1);
            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < columnLength; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min_index.row_index = i;
                        min_index.column_index = j;
                    }
                }
            }

            return min_index;
        }

        public Index GetMax(int[,] matrix)
        {
            var max = Int32.MinValue;
            Index max_index = new Index() {row_index = -1, column_index = -1};
            var rowLength = matrix.GetLength(0);
            var columnLength = matrix.GetLength(1);
            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < columnLength; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_index.row_index = i;
                        max_index.column_index = j;
                    }
                }
            }

            return max_index;
        }

        public int[,] SwapMinMax(int[,] matrix)
        {
            var rowLength = matrix.GetLength(0);
            var columnLength = matrix.GetLength(1);
            int[,] output_matrix = new int[rowLength, columnLength];

            Index max_index = GetMax(matrix);
            Index min_index = GetMin(matrix);

            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < columnLength; j++)
                {
                    output_matrix[i, j] = matrix[i, j];
                }
            }


            if (max_index.row_index !=-1 && max_index.column_index !=-1 &&
                min_index.row_index != -1 && min_index.column_index != -1)
            {
                var tmp = output_matrix[max_index.row_index, max_index.column_index];
                output_matrix[max_index.row_index, max_index.column_index] = output_matrix[min_index.row_index, min_index.column_index];
                output_matrix[min_index.row_index, min_index.column_index] = tmp;
            }

            return output_matrix;
        }

        public int GetMax(int[] arr)
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


        public int GetMin(int[] arr)
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

        public int[] SwapMinMax(int[] arr)
        {
            int length = arr.Length;
            int[] output_arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                output_arr[i] = arr[i];
            }

            int maxIndex = GetMax(arr);
            int minIndex = GetMin(arr);
            if (maxIndex != -1 && minIndex != -1)
            {
                var tmp = output_arr[minIndex];
                output_arr[minIndex] = output_arr[maxIndex];
                output_arr[maxIndex] = tmp;
            }

            return output_arr;
        }

        public void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"{arr[i],5}");
            }

            WriteLine();
        }

        public void Print(int element)
        {
            WriteLine(element);
        }
        public void Print(Index index)
        {
            WriteLine($"Row index: {index.row_index}; Column index: {index.column_index}");
        }
        public void Print(int[,] arr)
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