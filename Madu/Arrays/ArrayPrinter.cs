/**
* ArrayPrinter
* Copyright © Madu/Marvin - 2024
*/
namespace Madu.Arrays
{
    /// <summary>
    /// A class which includes methods to print an array
    /// </summary>
    public class ArrayPrinter
    {
        /// <summary>
        /// Prints every element in its own line
        /// </summary>
        public void Print<T>(T[] arr)
        {
            foreach (T item in arr)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Prints every element in one line
        /// </summary>
        public void OneLinePrint<T>(T[] arr, string separator = ", ")
        {
            Console.WriteLine(string.Join(separator, arr));
        }
    }
}
