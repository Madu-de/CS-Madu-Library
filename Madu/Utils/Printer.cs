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

        public PrinterOptions Options { get; set; }

        /// <summary>
        /// Create a Printer with default options
        /// </summary>
        public Printer(string name)
        {
            Name = name;
            Options = new PrinterOptions();
            Options.DebugMode = true;
            Options.SaveInFile = true;
            Options.PrintElementsOfArray = true;
        }

        /// <summary>
        /// Create a Printer with custom options
        /// </summary>
        public Printer(string name, PrinterOptions printerOptions)
        {
            Name = name;
            Options = printerOptions;
        }

        /// <summary>
        /// Prints message as log
        /// </summary>
        public void Log<T>(T message, PrinterOptions? options = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, options, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Log);
        }

        /// <summary>
        /// Prints message to console, if DebugMode is true
        /// </summary>
        public void Debug<T>(T message, PrinterOptions? options = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!Options.DebugMode) return;
            Print(message, options, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Debug);
        }

        /// <summary>
        /// Prints message as info
        /// </summary>
        public void Info<T>(T message, PrinterOptions? options = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, options, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Info);
        }

        /// <summary>
        /// Prints message as warn
        /// </summary>
        public void Warn<T>(T message, PrinterOptions? options = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, options, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Warn);
        }

        /// <summary>
        /// Prints message as error
        /// </summary>
        public void Error<T>(T message, PrinterOptions? options = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(message, options, memberName, sourceFilePath, sourceLineNumber, PrinterMethod.Error);
        }

        /// <summary>
        /// Prints the separatorChar x-times (count) in one line
        /// </summary>
        public void PrintSeparator(char separatorChar = '-', int count = 50)
        {
            string message = new string(separatorChar, count);
            Console.WriteLine(message);
            if (Options.SaveInFile) WriteInFile(message);
        }

        /// <summary>
        /// Prints message
        /// </summary>
        void Print<T>(T message, PrinterOptions? options, string memberName, string sourceFilePath, int sourceLineNumber, PrinterMethod printerMethod)
        {
            options ??= Options;
            string messageAsString = GetMessageAsString(message, options);
            string[] messages = messageAsString.Split('\n');
            foreach(string msg in messages)
            {
                string prefix = PrintPrefix(memberName, sourceFilePath, sourceLineNumber, printerMethod);
                Console.Write(msg + '\n');
                Console.ForegroundColor = ConsoleColor.White;
                if (options.SaveInFile) WriteInFile(prefix + msg);
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

        string GetMessageAsString<T>(T message, PrinterOptions options)
        {
            string messageAsString = message?.ToString() ?? "null";
            var messageAsArray = message as Array;
            if (options.PrintElementsOfArray && message != null && messageAsArray != null)
            {
                List<string> list = new();
                foreach (var item in messageAsArray)
                {
                    list.Add(GetMessageAsString(item, options));
                }
                messageAsString = $"{message.GetType()} {{ ";
                messageAsString += string.Join(", ", list);
                messageAsString += " }";
            }
            var properties = message?.GetType().GetProperties().Where(p => p.GetIndexParameters().Length == 0);
            var fields = message?.GetType().GetFields();
            var methods = message?.GetType().GetMethods();

            if (properties != null && properties.Any() && options.PrintProperties)
            {
                messageAsString += " -> ";
                foreach (var prop in properties)
                {
                    messageAsString += $"{prop.Name}: {prop.GetValue(message)}; ";
                }
            }
            if (fields != null && fields.Length > 0 && options.PrintFields)
            {
                messageAsString += " -> ";
                foreach (var field in message.GetType().GetFields())
                {
                    messageAsString += $"{field.Name}: {field.GetValue(message)}; ";
                }
            }
            if (methods != null && methods.Length > 0 && options.PrintMethods)
            {
                messageAsString += " -> ";
                foreach (var method in message.GetType().GetMethods())
                {
                    messageAsString += $"public {method.ReturnType} {method.Name}(";
                    foreach (var parameter in method.GetParameters())
                    {
                        messageAsString += $"{parameter.ParameterType} {parameter.Name},";
                    }
                    messageAsString += "); ";
                }
            }
            return messageAsString;
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
