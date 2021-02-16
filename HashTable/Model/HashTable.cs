using System;
using System.Collections.Generic;

namespace HashTable.Model
{
    /// <summary>
    /// A hash table with keys and values, based on a list.
    /// </summary>
    /// <typeparam name="TKey"> Key type. </typeparam>
    /// <typeparam name="TValue"> Value type. </typeparam>
    public class HashTable<TKey, TValue>
    {
        /// <summary>
        /// An array of lists with a TValue.
        /// </summary>
        private readonly List<TValue>[] items;

        /// <summary>
        /// Constructor with setting the size of the array.
        /// </summary>
        /// <param name="size"> Array size. </param>
        public HashTable(int size) => items = new List<TValue>[size];

        /// <summary>
        /// Add a new item.
        /// </summary>
        /// <param name="key"> Adding a key. </param>
        /// <param name="value"> Adding a value. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(TKey key, TValue value)
        {
            // Check input data for emptiness.
            if (key == null || value == null)
            {
                throw new ArgumentNullException(nameof(key), nameof(value));
            }

            // If the key is empty then add a list with the element.
            if (items[GetHash(key)] == null)
            {
                items[GetHash(key)] = new List<TValue>() { value };
            }
            // otherwise add to the end of the list item.
            else
            {
                items[GetHash(key)].Add(value);
            }
        }

        /// <summary>
        /// Check if there is an item in the array.
        /// </summary>
        /// <param name="key"> Searching key. </param>
        /// <param name="item"> Searching value. </param>
        /// <returns> True if an item is found or a false if such an item does not exist. </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Search(TKey key, TValue item)
        {
            // Check input data for emptiness.
            if (key == null || item == null)
            {
                throw new ArgumentNullException(nameof(key), nameof(item));
            }

            // If the list contains an element, then we return true, if not, then a false.
            // Zero lable check.
            return items[GetHash(key)]?.Contains(item) ?? false;
        }

        /// <summary>
        /// Hash function.
        /// </summary>
        /// <param name="key"> Element for hash calculation. </param>
        /// <returns> Convert the key to the string, and take the first element of the string. </returns>
        private int GetHash(TKey key) => Convert.ToInt32(key.ToString().Substring(0, 1));
    }
}