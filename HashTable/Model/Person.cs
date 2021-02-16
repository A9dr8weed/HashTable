namespace HashTable.Model
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString() => Name;

        public override int GetHashCode()
        {
            return Name.Length + Age + Gender + Name[0];
        }
    }
}