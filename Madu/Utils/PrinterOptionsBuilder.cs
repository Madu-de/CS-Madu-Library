/**
* PrinterOptionsBuilder
* Copyright © Madu/Marvin - 2024
*/
namespace Madu.Utils
{
    /// <summary>
    /// A class to create PrinterOptions easily
    /// </summary>
    public class PrinterOptionsBuilder
    {
        private readonly PrinterOptions _printerOptions = new();

        /// <summary>
        /// If DebugMode is true, the Debug method will be print messages
        /// </summary>
        public PrinterOptionsBuilder DebugMode(bool debugMode)
        {
            _printerOptions.DebugMode = debugMode;
            return this;
        }

        /// <summary>
        /// If SaveInFile is true, all logs will be saved in writelines.log
        /// </summary>
        public PrinterOptionsBuilder SaveInFile(bool saveInFile)
        {
            _printerOptions.SaveInFile = saveInFile;
            return this;
        }

        /// <summary>
        /// If PrintElementsOfArray is true, elements of an array will be printed
        /// </summary>
        public PrinterOptionsBuilder PrintElementsOfArray(bool printElementsOfArray)
        {
            _printerOptions.PrintElementsOfArray = printElementsOfArray;
            return this;
        }

        /// <summary>
        /// Returns custom options
        /// </summary>
        public PrinterOptions Build()
        {
            return _printerOptions;
        }
    }
}
