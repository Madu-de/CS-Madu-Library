/**
* NumberUtils
* Copyright © Madu/Marvin - 2024
*/
namespace Madu.Utils
{
    /// <summary>
    /// A class which includes utility methods for numbers
    /// </summary>
    public class NumberUtils
    {
        /// <summary>
        /// Returns true if number is prime
        /// </summary>
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (IsEven(number)) return false;

            int maxIndex = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= maxIndex; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        /// <summary>
        /// Returns true if number is even
        /// </summary>
        public bool IsEven(int number) => number % 2 == 0;

        /// <summary>
        /// Returns true if number is odd
        /// </summary>
        public bool IsOdd(int number) => number % 2 != 0;

        /// <summary>
        /// Returns true if number is pi (3.14159265358979323846)
        /// </summary>
        public bool IsPi(double number) => number == Math.PI;

        /// <summary>
        /// Returns true if number is e (2.7182818284590452354)
        /// </summary>
        public bool IsE(double number) => number == Math.E;
    }
}
