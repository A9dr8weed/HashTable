using System;

namespace HashTable.OpenHashingModel
{
    /// <summary>
    /// Data hash table element.
    /// </summary>
    /// <typeparam name="TKey"> Key type. </typeparam>
    /// <typeparam name="TValue"> Value type. </typeparam>
    public class OpenHashingItem<TKey, TValue>
    {
        /// <summary>
        /// Key.
        /// </summary>
        public TKey Key { get; }

        /// <summary>
        /// Stored data.
        /// </summary>
        public TValue Value { get; }

        /// <summary>
        /// Create a new instance of the stored data Item.
        /// </summary>
        /// <param name="key"> Key. </param>
        /// <param name="value"> Value. </param>
        public OpenHashingItem(TKey key, TValue value)
        {
            // Check the input for correctness.
            if (key == null || value == null)
            {
                throw new ArgumentNullException(nameof(key), nameof(value));
            }

            // Set the value.
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Bring an object to a string.
        /// </summary>
        /// <returns> Object key. </returns>
        public override string ToString()
        {
            return Key.ToString();
        }
    }
}