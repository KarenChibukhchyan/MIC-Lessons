using System;
using System.Text;
using static System.Console;

namespace MIC_Lessons
{
    class Program
    {
        public static void Main(string[] args)
        {
            ArrayManager manager = new ArrayManager();

            #region 1D Array
            int[] arr = manager.createArray(5, new Range(){min_value = 0, max_value = 100});
            WriteLine("--------------- 1D case ----------------");
            WriteLine("Original array is:");
            manager.Print(arr);
            WriteLine("Maximal value's index:");
            manager.Print(manager.GetMax(arr));
            WriteLine("Minimal value's index:");
            manager.Print(manager.GetMin(arr));
            WriteLine("After swapping min and max values:");
            manager.Print(manager.SwapMinMax(arr));
            WriteLine();
            WriteLine();
            #endregion

            #region 2D Array
            WriteLine("--------------- 2D case ----------------");
            Size size = new Size() {row_size = 5, column_size = 6};
            Range range = new Range() {min_value = 0, max_value = 100};
            int[,] matrix = manager.createArray(size, range);
            WriteLine("Original matrix is:");
            manager.Print(matrix);
            WriteLine("Maximal value's indices:");
            manager.Print(manager.GetMax(matrix));
            WriteLine("Minimal value's indices:");
            manager.Print(manager.GetMin(matrix));
            WriteLine("After swapping min and max values:");
            manager.Print(manager.SwapMinMax(matrix));
            #endregion
        }


    }
}