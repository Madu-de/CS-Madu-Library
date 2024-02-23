/**
* GetUserInput
* Copyright © Madu/Marvin - 2024
*/
namespace Madu.Utils
{
    /// <summary>
    /// A class which includes methods to get user input
    /// </summary>
    public class UserInputHandler
    {
        private readonly Printer printer = new(typeof(UserInputHandler).Name);

        private string GetInput(string question, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            printer.Log(question, memberName, sourceFilePath, sourceLineNumber);
            return Console.ReadLine();
        }

        /// <summary>
        /// Returns the default value of T if the userinput is not compatible
        /// </summary>
        public T? GetInputAs<T>(string question,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                return GetInputAsWithoutCheck<T>(question, memberName, sourceFilePath, sourceLineNumber);
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// Throws an error if the userinput is not compatible
        /// </summary>
        public T GetInputAsWithoutCheck<T>(string question,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            return (T)Convert.ChangeType(GetInput(question, memberName, sourceFilePath, sourceLineNumber), typeof(T));
        }

        /// <summary>
        /// Creates a selection list
        /// </summary>
        /// <returns>
        /// The index of the selected list element
        /// </returns>
        public int GetInputWithList(string message, string[] list)
        {
            int choise = 0;
            bool runloop = true;
            do
            {
                Console.Clear();
                Console.WriteLine(message);
                PrintList(list, choise);
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "DownArrow":
                        choise++;
                        break;
                    case "UpArrow":
                        choise--;
                        break;
                    case "Enter":
                        runloop = false;
                        break;
                }

                if (choise < 0) choise = list.Length - 1;
                if (choise >= list.Length) choise = 0;
            } while (runloop);

            return choise;
        }

        private void PrintList(string[] list, int choiseIndex)
        {
            for (int i = 0; i < list.Length; i++)
            {
                string item = list[i];
                if (i == choiseIndex) Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("> {0}", item);
                Console.ResetColor();
            }
        }
    }
}
