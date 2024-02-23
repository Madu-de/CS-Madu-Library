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
        /// The name of the printer is shown at the prints
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// If DebugMode is true, the Debug method will be print messages
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// If SaveInFile is true, all logs will be saved in writelines.log
        /// </summary>
        public bool SaveInFile { get; set; }

        /// <summary>
        /// A class which includes methods to print default elements
        /// </summary>
        public Printer(string name, bool debugMode = true, bool saveInFile = true)
        {
            Name = name;
            DebugMode = debugMode;
            SaveInFile = saveInFile;
        }

        /// <summary>
        /// Prints message as log
        /// </summary>
        public void Log<T>(T message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Log);
        }

        /// <summary>
        /// Prints message to console, if DebugMode is true
        /// </summary>
        public void Debug<T>(T message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!DebugMode) return;
            Print(message, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Debug);
        }

        /// <summary>
        /// Prints message as info
        /// </summary>
        public void Info<T>(T message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Info);
        }

        /// <summary>
        /// Prints message as warn
        /// </summary>
        public void Warn<T>(T message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Warn);
        }

        /// <summary>
        /// Prints message as error
        /// </summary>
        public void Error<T>(T message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Error);
        }

        /// <summary>
        /// Prints the separatorChar x-times (count) in one line
        /// </summary>
        public void PrintSeparator(char separatorChar = '-', int count = 50)
        {
            string message = new string(separatorChar, count);
            Console.WriteLine(message);
            if (SaveInFile) WriteInFile(message);
        }

        /// <summary>
        /// Prints message
        /// </summary>
        void Print<T>(T message, string memberName, string sourceFilePath, int sourceLineNumber, PrinterMethod printerMethod)
        {
            string messageAsString = message?.ToString() ?? "null";
            string?[] messages = messageAsString.Split('\n');
            foreach(string? msg in messages)
            {
                string prefix = PrintPrefix(memberName, sourceFilePath, sourceLineNumber, printerMethod);
                Console.Write(msg + '\n');
                Console.ForegroundColor = ConsoleColor.White;
                if (SaveInFile) WriteInFile(prefix + msg);
            }
        }

        /// <summary>
        /// Prints the prefix of every print
        /// </summary>
        /// <returns>
        /// The printed prefix
        /// </returns>
        string PrintPrefix(string memberName, string sourceFilePath, int sourceLineNumber, PrinterMethod printerMethod)
        {
            string method = printerMethod.ToString().ToUpper().PadLeft(5);
            string path = $"{sourceFilePath.Split('\\').Last()}>{memberName}:{sourceLineNumber}".PadRight(20);
            string prefixPart1 = $"[Madu] {path} - ";
            string prefixPart2 = $"{DateTime.Now} ";
            string prefixPart3 = $"{method} ";
            string prefixPart4 = $"[{Name}] ";

            ConsoleColor methodColor = GetPrinterMethodColor(printerMethod);
            Console.ForegroundColor = methodColor;
            Console.Write(prefixPart1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(prefixPart2);
            Console.ForegroundColor = methodColor;
            Console.Write(prefixPart3);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(prefixPart4);
            Console.ForegroundColor = methodColor;
            return prefixPart1 + prefixPart2 + prefixPart3 + prefixPart4;
        }

        /// <summary>
        /// Returns the ConsoleColor of the PrinterMethod
        /// </summary>
        ConsoleColor GetPrinterMethodColor(PrinterMethod method)
        {
            Dictionary<PrinterMethod, ConsoleColor> dict = new Dictionary<PrinterMethod, ConsoleColor>() 
            {
                { PrinterMethod.Log, ConsoleColor.Green },
                { PrinterMethod.Debug, ConsoleColor.Magenta },
                { PrinterMethod.Info, ConsoleColor.Blue },
                { PrinterMethod.Warn, ConsoleColor.Yellow },
                { PrinterMethod.Error, ConsoleColor.Red },
            };
            return dict[method];
        }

        /// <summary>
        /// Appends one line to the writelines.log file
        /// </summary>
        void WriteInFile(string line)
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            using StreamWriter outputFile = new StreamWriter(Path.Combine(path, "writelines.log"), true, System.Text.Encoding.UTF8);
            outputFile.WriteLine(line);
        }
    }
}
