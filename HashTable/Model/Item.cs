using System.Collections.Generic;

namespace HashTable.Model
{
    /// <summary>
    /// Hash table data element.
    /// </summary>
    /// <typeparam name="T"> Type of data. </typeparam>
    public class Item<T>
    {
        /// <summary>
        /// Key.
        /// </summary>
        public int Key { get; }

        /// <summary>
        /// Cell.
        /// </summary>
        public List<T> Nodes { get; set; }

        /// <summary>
        /// Create a new instance of the stored data.
        /// </summary>
        /// <param name="key"> Key. </param>
        public Item(int key)
        {
            Nodes = new List<T>();
            Key = key;
        }
    }
}