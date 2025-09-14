namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDynamicArray<int> ints = new MyDynamicArray<int>();
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            ints.Add(4);
            Console.WriteLine(ints.ToString());
            Console.WriteLine("Set value at index 0 to 4: ");
            ints.SetValue(0, 4);
            Console.WriteLine(ints.ToString());
            Console.WriteLine("Get value at index 0: " + ints.GetValue(0));
            ints.Remove(3);
            Console.WriteLine("Remove 3: ");
            //ints.RemoveAtNotMinusSize(1);
            Console.WriteLine(ints.ToString());
            Console.WriteLine("Get size of Array: " + ints.Size());
            Console.WriteLine(ints.ToString());
            Console.WriteLine("Is Array Empty: " + ints.IsEmpty());
            Console.WriteLine("Array Contains 9: " + ints.Contain(9));
            Console.WriteLine("Index of 4: " + ints.IndexOf(4));
            ints.Clear();
            Console.WriteLine("Clear: ");
            Console.WriteLine(ints.ToString());
        }
    }
}
