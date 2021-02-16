using System;

namespace HashTable.Model
{
    /// <summary>
    /// Hash table with Item.
    /// </summary>
    /// <typeparam name="T"> Return type. </typeparam>
    public class SuperHashTable<T>
    {
        /// <summary>
        /// Collection of storage data.
        /// </summary>
        private readonly Item<T>[] items;

        /// <summary>
        /// Initialize hash table where at each iteration is set to key.
        /// </summary>
        /// <param name="size"> Size of array. </param>
        public SuperHashTable(int size)
        {
            items = new Item<T>[size];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item<T>(i);
            }
        }

        /// <summary>
        /// Add a new item.
        /// </summary>
        /// <param name="item"> Added element. </param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <c>null</c>.</exception>
        public void Add(T item)
        {
            // Check input data for emptiness.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Add an item to the end of the collection if the hashes match.
            items[GetHash(item)].Nodes.Add(item);
        }

        /// <summary>
        /// Check if there is an item in the array.
        /// </summary>
        /// <param name="item"> Searching element. </param>
        /// <returns> True if an item is found or a false if such an item does not exist. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <c>null</c>.</exception>
        public bool Search(T item)
        {
            // Check input data for emptiness.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return items[GetHash(item)].Nodes.Contains(item);
        }

        /// <summary>
        /// Hash function.
        /// </summary>
        /// <param name="item"> Element for hash calculation. </param>
        /// <returns> Hash the element through the base method, divided by the remainder on the size of the collection not to go beyond the limit. </returns>
        private int GetHash(T item) => item.GetHashCode() % items.Length;
    }
}