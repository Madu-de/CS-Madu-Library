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
        private readonly PrinterOptions _printerOptions;

        /// <summary>
        /// Create a PrinterOptionsBuilder with or without parentOptions
        /// </summary>
        /// <param name="parentOptions">If you want to base on other options, you can put it here</param>
        public PrinterOptionsBuilder(PrinterOptions? parentOptions = null)
        {
            _printerOptions = parentOptions ?? new();
        }

        /// <summary>
        /// If DebugMode is true, the Debug method will be print messages
        /// </summary>
        public PrinterOptionsBuilder DebugMode(bool debugMode = true)
        {
            _printerOptions.DebugMode = debugMode;
            return this;
        }

        /// <summary>
        /// If SaveInFile is true, all logs will be saved in writelines.log
        /// </summary>
        public PrinterOptionsBuilder SaveInFile(bool saveInFile = true)
        {
            _printerOptions.SaveInFile = saveInFile;
            return this;
        }

        /// <summary>
        /// If PrintElementsOfArray is true, elements of an array will be printed
        /// </summary>
        public PrinterOptionsBuilder PrintElementsOfArray(bool printElementsOfArray = true)
        {
            _printerOptions.PrintElementsOfArray = printElementsOfArray;
            return this;
        }

        /// <summary>
        /// If PrintFields is true, fields of an object will be printed
        /// </summary>
        public PrinterOptionsBuilder PrintFields(bool printFields = true)
        {
            _printerOptions.PrintFields = printFields;
            return this;
        }

        /// <summary>
        /// If PrintProperties is true, properties of an object will be printed
        /// </summary>
        public PrinterOptionsBuilder PrintProperties(bool printProperties = true)
        {
            _printerOptions.PrintProperties = printProperties;
            return this;
        }

        /// <summary>
        /// If PrintMethods is true, methods of an object will be printed
        /// </summary>
        public PrinterOptionsBuilder PrintMethods(bool printMethods = true)
        {
            _printerOptions.PrintMethods = printMethods;
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
