using HashTable.Model;
using HashTable.OpenHashingModel;

using System;
using System.Collections.Generic;

namespace HashTable
{
    public static class Program
    {
        private static void Main()
        {
            BadHashTable<int> badHashTable = new BadHashTable<int>(10);
            badHashTable.Add(5);
            badHashTable.Add(18);
            badHashTable.Add(777);

            Console.WriteLine(badHashTable.Search(6));
            Console.WriteLine(badHashTable.Search(18));
            Console.ReadLine();
            Console.Clear();

            HashTable<int, string> hashTable = new HashTable<int, string>(10);
            hashTable.Add(5, "Hello");
            hashTable.Add(18, "World");
            hashTable.Add(777, "!");

            Console.WriteLine(hashTable.Search(6, "Lol"));
            Console.WriteLine(hashTable.Search(18, "World"));
            Console.ReadLine();
            Console.Clear();

            SuperHashTable<Person> superHashTable = new SuperHashTable<Person>(10);
            Person person = new Person() { Name = "A", Age = 25, Gender = 0 };
            superHashTable.Add(new Person() { Name = "A", Age = 25, Gender = 0 });
            superHashTable.Add(person);
            superHashTable.Add(new Person() { Name = "C", Age = 21, Gender = 1 });

            Console.WriteLine(superHashTable.Search(new Person() { Name = "A", Age = 25, Gender = 0 }));
            Console.WriteLine(superHashTable.Search(person));
            Console.ReadLine();
            Console.Clear();

            OpenHashingHashTable<string, string> openHashingHashTable = new OpenHashingHashTable<string, string>();

            openHashingHashTable.Insert("Little Prince", "I never wished you any sort of harm; but you wanted me to tame you...");
            openHashingHashTable.Insert("Fox", "And now here is my secret, a very simple secret: It is only with the heart that one can see rightly; what is essential is invisible to the eye.");
            openHashingHashTable.Insert("Rose", "Well, I must endure the presence of two or three caterpillars if I wish to become acquainted with the butterflies.");
            openHashingHashTable.Insert("King", "He did not know how the world is simplified for kings. To them, all men are subjects.");

            ShowHashTable(openHashingHashTable, "Created hashtable.");

            openHashingHashTable.Delete("King");
            ShowHashTable(openHashingHashTable, "Delete item from hashtable.");

            Console.WriteLine($"Little Prince say: {openHashingHashTable.Search("Little Prince")}");
        }

        /// <summary>
        /// Display the hash table on the screen.
        /// </summary>
        /// <param name="hashTable"> Hash table. </param>
        /// <param name="title"> Header before table output. </param>
        /// <exception cref="ArgumentNullException"><paramref name="hashTable"/> is <c>null</c>.</exception>
        private static void ShowHashTable(OpenHashingHashTable<string, string> hashTable, string title)
        {
            // Check the input arguments.
            if (hashTable == null || string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(hashTable), nameof(title));
            }

            // Print all pairs of hash values
            Console.WriteLine(title);
            foreach (KeyValuePair<int, List<OpenHashingItem<string, string>>> item in hashTable.Items)
            {
                // Print a hash
                Console.WriteLine($"Hash = {item.Key}");

                // Print all values stored under this hash.
                foreach (OpenHashingItem<string, string> value in item.Value)
                {
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
                }
            }
            Console.WriteLine();
        }
    }
}