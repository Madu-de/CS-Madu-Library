/**
* ArrayEditor
* Copyright © Madu/Marvin - 2024
*/
namespace Madu.Arrays
{
    /// <summary>
    /// A little editor to remove elements of an array
    /// </summary>
    public class ArrayEditor
    {
        /// <summary>
        /// Removes the first element which has the same value as element
        /// </summary>
        /// <returns>The modified array</returns>
        public T[] RemoveElement<T>(T[] arr, T element)
        {
            int i = FindFirstIndexOf(arr, element);
            return RemoveElementByIndex(arr, i);
        }

        /// <summary>
        /// Removes all elements which have the same value as element
        /// </summary>
        /// <returns>The modified array</returns>
        public T[] RemoveElements<T>(T[] arr, T element)
        {
            while (IsElementInArray(arr, element))
            {
                arr = RemoveElement(arr, element);
            }
            return arr;
        }

        /// <summary>
        /// Removes the element at index i
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the index is out of the array range
        /// </exception>
        /// <returns>The modified array</returns>
        public T[] RemoveElementByIndex<T>(T[] arr, int i)
        {
            if (i == -1) return arr;
            return MoveElementsUpTo(arr, i);
        }

        /// <summary>
        /// Returns -1 if element isn't in array
        /// </summary>
        /// <returns>Index of the element or -1</returns>
        int FindFirstIndexOf<T>(T[] arr, T element)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]!.Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns true if element is in array
        /// </summary>
        bool IsElementInArray<T>(T[] arr, T element)
        {
            return FindFirstIndexOf(arr, element) != -1;
        }

        /// <summary>
        /// Moves all right hand elements one index to the left
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the index is out of the array range
        /// </exception>
        /// <returns>The modified element</returns>
        T[] MoveElementsUpTo<T>(T[] arr, int index)
        {
            int newArrayLength = arr.Length - 1;
            if (index > newArrayLength || index < 0)
            {
                throw new IndexOutOfRangeException($"The index has to be in the array range (0 - {newArrayLength}) Is: {index}");
            }
            T[] outputArray = new T[newArrayLength];
            for (int i = 0; i < newArrayLength; i++)
            {
                outputArray[i] = i >= index ? arr[i + 1] : arr[i];
            }
            return outputArray;
        }
    }
}
