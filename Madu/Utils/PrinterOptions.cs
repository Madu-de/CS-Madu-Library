/**
* PrinterOptions
* Copyright © Madu/Marvin - 2024
*/
namespace Madu.Utils
{
    /// <summary>
    /// A class to create PrinterOptions
    /// </summary>
    public class PrinterOptions
    {
        /// <summary>
        /// If DebugMode is true, the Debug method will be print messages
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// If SaveInFile is true, all logs will be saved in writelines.log
        /// </summary>
        public bool SaveInFile { get; set; }

        /// <summary>
        /// If PrintElementsOfArray is true, elements of an array will be printed
        /// </summary>
        public bool PrintElementsOfArray { get; set; }
    }
}
