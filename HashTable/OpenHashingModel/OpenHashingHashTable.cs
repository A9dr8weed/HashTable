using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable.OpenHashingModel
{
    /// <summary>
    /// Hash table.
    /// </summary>
    /// <remarks>
    /// The chain method (open hashing) is used.
    /// </remarks>
    public class OpenHashingHashTable<TKey, TValue>
    {
        /// <summary>
        /// Maximum length of the key field.
        /// </summary>
        private readonly byte maxSize = 255;

        /// <summary>
        /// Collection of stored data.
        /// </summary>
        /// <remarks>
        /// Is a dictionary whose key is a hash of the stored data key, and the value is a list of elements with the same key hash.
        /// </remarks>
        private readonly Dictionary<int, List<OpenHashingItem<TKey, TValue>>> items;

        /// <summary>
        /// Collection of data stored in a hash table in the form of Hash-Value pairs.
        /// </summary>
        public IReadOnlyCollection<KeyValuePair<int, List<OpenHashingItem<TKey, TValue>>>> Items => items?.ToList()?.AsReadOnly();

        /// <summary>
        /// Create a new instance of the OpenHashingHashTable class.
        /// </summary>
        public OpenHashingHashTable()
        {
            // Initialize the collection with the maximum number of elements.
            items = new Dictionary<int, List<OpenHashingItem<TKey, TValue>>>(maxSize);
        }

        /// <summary>
        /// Add data to the hash table.
        /// </summary>
        /// <param name="key"> Stored data key. </param>
        /// <param name="value"> Stored data. </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Insert(TKey key, TValue value)
        {
            // Check the input for correctness.
            if (key == null || value == null)
            {
                throw new ArgumentNullException(nameof(key), nameof(value));
            }

            if (key.ToString().Length > maxSize)
            {
                throw new ArgumentException($"The maximum key length is {maxSize} characters.", nameof(key));
            }

            // Create a new copy of the data.
            OpenHashingItem<TKey, TValue> item = new OpenHashingItem<TKey, TValue>(key, value);

            // Get a key hash.
            int hash = GetHash(item.Key);

            // Get a collection of items with the same key hash.
            List<OpenHashingItem<TKey, TValue>> hashTableItem = null;

            // If the collection is not empty, then values with such a hash already exist.
            if (items.ContainsKey(hash))
            {
                // Get a hash table element.
                hashTableItem = items[hash];

                // Check the value inside the collection with the received key.
                OpenHashingItem<TKey, TValue> oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key.Equals(item.Key));

                // If such an element is found, we report an error.
                if (oldElementWithKey != null)
                {
                    throw new ArgumentException($"The hash table already contains an element with a key {key}. The key must be unique.", nameof(key));
                }

                // Add a data item to the hash table item collection.
                items[hash].Add(item);
            }
            // Else the collection is empty, so there were no values with such a key hash before
            else
            {
                // Create a new collection.
                hashTableItem = new List<OpenHashingItem<TKey, TValue>>() { item };

                // Add data to the table.
                items.Add(hash, hashTableItem);
            }
        }

        /// <summary>
        /// Delete data from the hash table by key.
        /// </summary>
        /// <param name="key"> Key. </param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"></exception>
        public void Delete(TKey key)
        {
            // Check the input for correctness.
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.ToString().Length > maxSize)
            {
                throw new ArgumentException($"The maximum key length is {maxSize} characters.", nameof(key));
            }

            // Get a key hash.
            int hash = GetHash(key);

            // If the value with this hash is not in the table, then terminate the method.
            if (!items.ContainsKey(hash))
            {
                return;
            }

            // Get a collection of elements by key hash.
            List<OpenHashingItem<TKey, TValue>> hashTableItem = items[hash];

            // Get a collection item by key.
            OpenHashingItem<TKey, TValue> item = hashTableItem.SingleOrDefault(i => i.Key.Equals(key));

            // If a collection item is found, delete it from the collection.
            if (item != null)
            {
                hashTableItem.Remove(item);
            }
        }

        /// <summary>
        /// Search for a value by key.
        /// </summary>
        /// <param name="key"> Key. </param>
        /// <returns> Stored data found by key. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"></exception>
        public string Search(TKey key)
        {
            // Check the input for correctness.
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.ToString().Length > maxSize)
            {
                throw new ArgumentException($"The maximum key length is {maxSize} characters.", nameof(key));
            }

            // Get a key hash.
            int hash = GetHash(key);

            // If the table does not contain such hash, we finish execution of a method having returned null.
            if (!items.ContainsKey(hash))
            {
                return null;
            }

            // Get a collection of elements by key hash.
            List<OpenHashingItem<TKey, TValue>> hashTableItem = items[hash];

            // If a hash is found, then look for the value in the collection by key.
            if (hashTableItem != null)
            {
                // Get a collection item by key.
                OpenHashingItem<TKey, TValue> item = hashTableItem.SingleOrDefault(i => i.Key.Equals(key));

                // If a collection item is found, we return the stored data.
                if (item != null)
                {
                    return item.Value.ToString();
                }
            }

            // We return null if nothing is found.
            return null;
        }

        /// <summary>
        /// Hash function.
        /// </summary>
        /// <remarks>
        /// Returns the length of the string.
        /// </remarks>
        /// <param name="value"> Cached string. </param>
        /// <returns> Hash strings. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"></exception>
        private int GetHash(TKey value)
        {
            // Check the input for correctness.
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.ToString().Length > maxSize)
            {
                throw new ArgumentException($"The maximum key length is {maxSize} characters.", nameof(value));
            }

            // Get the length of the string.
            return value.ToString().Length;
        }
    }
}