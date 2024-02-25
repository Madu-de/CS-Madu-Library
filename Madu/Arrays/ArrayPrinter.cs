﻿
using Madu.Utils;
/**
* ArrayPrinter
* Copyright © Madu/Marvin - 2024
*/
namespace Madu.Arrays
{
    /// <summary>
    /// A class which includes methods to print an array
    /// </summary>
    public class ArrayPrinter : Printer
    {
        /// <summary>
        /// A class which includes methods to print an array
        /// </summary>
        public ArrayPrinter(string name) : base(name)
        { }

        /// <summary>
        /// A class which includes methods to print an array
        /// </summary>
        public ArrayPrinter(string name, PrinterOptions printerOptions) : base(name, printerOptions)
        {}

        /// <summary>
        /// Prints every element in its own line
        /// </summary>
        public void Print<T>(T[] arr,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            foreach (T item in arr)
            {
                Log(item.ToString(), memberName, sourceFilePath, sourceLineNumber);
            }
        }

        /// <summary>
        /// Prints every element in one line
        /// </summary>
        public void OneLinePrint<T>(T[] arr, string separator = ", ",
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(string.Join(separator, arr), memberName, sourceFilePath, sourceLineNumber);
        }
    }
}
