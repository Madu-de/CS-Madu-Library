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
        /// The name of the printer is shown at the logs
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// If DebugMode is true, the Debug method will be print messages
        /// </summary>
        public static bool DebugMode { get; set; }

        /// <summary>
        /// A class which includes methods to print default elements
        /// </summary>
        public Printer(string name, bool debugMode)
        {
            Name = name;
            DebugMode = debugMode;
        }

        /// <summary>
        /// Prints message as log
        /// </summary>
        public void Log(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Log);
        }

        /// <summary>
        /// Prints message to console, if DebugMode is true
        /// </summary>
        public void Debug(string message,
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
        public void Info(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Info);
        }

        /// <summary>
        /// Prints message as warn
        /// </summary>
        public void Warn(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Warn);
        }

        /// <summary>
        /// Prints message as error
        /// </summary>
        public void Error(string message,
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
            Console.WriteLine(new string(separatorChar, count));
        }

        void Print(string message, string memberName, string sourceFilePath, int sourceLineNumber, PrinterMethod printerMethod)
        {
            string[] messages = message.Split('\n');
            foreach(string msg in messages)
            {
                PrintPrefix(memberName, sourceFilePath, sourceLineNumber, printerMethod);
                Console.Write($"{msg}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Prints the prefix of every print
        /// </summary>
        void PrintPrefix(string memberName, string sourceFilePath, int sourceLineNumber, PrinterMethod printerMethod)
        {
            string method = printerMethod.ToString().ToUpper().PadLeft(5);
            string path = $"{sourceFilePath.Split('\\').Last()}>{memberName}:{sourceLineNumber}".PadRight(20);
            ConsoleColor methodColor = GetPrinterMethodColor(printerMethod);
            Console.ForegroundColor = methodColor;
            Console.Write($"[Madu] {path} - ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{DateTime.Now} ");
            Console.ForegroundColor = methodColor;
            Console.Write($"{method} ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"[{Name}] ");
            Console.ForegroundColor = methodColor;
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
    }
}
