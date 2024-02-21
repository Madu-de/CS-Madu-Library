/**
* Printer
* Copyright © Madu/Marvin - 2024
*/
namespace Madu.Utils
{
    /// <summary>
    /// A class which includes methods to print default elements
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// Prints the separatorChar x-times (count) in one line
        /// </summary>
        public void PrintSeparator(char separatorChar = '-', int count = 50)
        {
            Console.WriteLine(new string(separatorChar, count));
        }
    }
}
