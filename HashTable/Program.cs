using System;
using HashTable;

namespace HashTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            var table = new SeperateChaningHashTable<int, string>();

            Console.WriteLine("== Insert (new keys) ==");
            Console.WriteLine($"Insert 50 => {Format(table.Insert(50, "A"))}"); // expect default(null/empty)
            Console.WriteLine($"Insert 30 => {Format(table.Insert(30, "B"))}");
            Console.WriteLine($"Insert 20 => {Format(table.Insert(20, "C"))}");
            Console.WriteLine($"Insert 40 => {Format(table.Insert(40, "D"))}");
            Console.WriteLine($"Insert 70 => {Format(table.Insert(70, "E"))}");
            Console.WriteLine($"Insert 60 => {Format(table.Insert(60, "F"))}"); // should trigger resize after threshold crossed
            Console.WriteLine($"Size: {table.Size()}  IsEmpty: {table.IsEmpty()}");

            Console.WriteLine("\n== Update existing key ==");
            Console.WriteLine($"Insert 30 (update) old value => {Format(table.Insert(30, "B2"))}");
            Console.WriteLine($"Get 30 => {Format(table.Get(30))}");

            Console.WriteLine("\n== Collision test (keys 1,11,21 map to same bucket initially) ==");
            table.Insert(1, "K1");
            table.Insert(11, "K11");
            table.Insert(21, "K21");
            Console.WriteLine($"Get 1 => {Format(table.Get(1))}");
            Console.WriteLine($"Get 11 => {Format(table.Get(11))}");
            Console.WriteLine($"Get 21 => {Format(table.Get(21))}");

            Console.WriteLine("\n== Has / Get tests ==");
            Console.WriteLine($"Has 50: {table.Has(50)}  Value: {Format(table.Get(50))}");
            Console.WriteLine($"Has 999: {table.Has(999)}  Value: {Format(table.Get(999))}");

            Console.WriteLine("\n== Iterate keys ==");
            foreach (var k in table)
            {
                Console.Write($"{k} ");
            }
            Console.WriteLine();

            Console.WriteLine("\n== Remove tests ==");
            Console.WriteLine($"Remove 11 => {Format(table.Remove(11))}");
            Console.WriteLine($"Remove 11 again => {Format(table.Remove(11))}");
            Console.WriteLine($"Remove 50 => {Format(table.Remove(50))}");
            Console.WriteLine($"Size after removes: {table.Size()}");

            Console.WriteLine("\n== Final iteration ==");
            foreach (var k in table)
            {
                Console.Write($"{k}:{Format(table.Get(k))} ");
            }
            Console.WriteLine();

            Console.WriteLine("\n== Clear ==");
            table.Clear();
            Console.WriteLine($"Size: {table.Size()} IsEmpty: {table.IsEmpty()}");
        }

        private static string Format(string value) => value ?? "<null>";
    }
}
