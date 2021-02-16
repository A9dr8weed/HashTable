using System;

namespace HashTable.Model
{
    /// <summary>
    /// Hash table without resolving collisions.
    /// </summary>
    /// <typeparam name="T"> The type of data. </typeparam>
    public class BadHashTable<T>
    {
        /// <summary>
        /// The collection of stored data.
        /// </summary>
        private readonly T[] items;

        /// <summary>
        /// Constructor with setting the size of the array.
        /// </summary>
        /// <param name="size"> Array size. </param>
        public BadHashTable(int size) => items = new T[size];

        /// <summary>
        /// Add an element to the array.
        /// </summary>
        /// <param name="item"> Adding element. </param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <c>null</c>.</exception>
        public void Add(T item)
        {
            // Check input data for emptiness.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Insert the item into the index derived from the hash function.
            items[GetHash(item)] = item;
        }

        /// <summary>
        /// Check if there is an item in the array.
        /// </summary>
        /// <param name="item"> Searching element. </param>
        /// <returns> True if an item is found or a false if such an item does not exist. </returns>
        public bool Search(T item)
        {
            // Check input data for emptiness.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Return true, if desired element corresponds to the index, else return false.
            return items[GetHash(item)].Equals(item);
        }

        /// <summary>
        /// Hash function.
        /// </summary>
        /// <param name="item"> Element for hash calculation. </param>
        /// <returns> The value of the number of elements divided by the remainder on the size of the array not to go beyond the limit. </returns>
        private int GetHash(T item) => item.ToString().Length % items.Length;
    }
}