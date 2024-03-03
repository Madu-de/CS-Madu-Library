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

        /// <summary>
        /// If PrintElementsOfArray is true, this separator will be used to print the elements
        /// </summary>
        public string ElementsOfArraySeparator { get; set; } = ", ";

        /// <summary>
        /// If PrintFields is true, fields of an object will be printed
        /// </summary>
        public bool PrintFields { get; set; }

        /// <summary>
        /// If PrintProperties is true, properties of an object will be printed
        /// </summary>
        public bool PrintProperties { get; set; }

        /// <summary>
        /// If PrintMethods is true, methods of an object will be printed
        /// </summary>
        public bool PrintMethods { get; set; }

        /// <summary>
        /// The file in which the logs will be saved (Based on the root directory)
        /// </summary>
        public string LogFile { get; set; } = "writelines.log";

        /// <summary>
        /// If DefaultWriteLine is true, every log is a simple Console.WriteLine
        /// </summary>
        public bool DefaultWriteLine { get; set; }

        /// <summary>
        /// Returns a copy of PrinterOptions
        /// </summary>
        public PrinterOptions Clone()
        {
            PrinterOptions options = new PrinterOptions();
            foreach (var property in GetType().GetProperties().Where(p => p.GetIndexParameters().Length == 0))
            {
                property.SetValue(options, property.GetValue(this));
            }
            return options;
        }
    }
}
