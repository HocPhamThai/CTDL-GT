namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> ints = new DynamicArray<int>();
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            ints.Add(4);
            ints.SetValue(0, 4);
            ints.Remove(3);
            //Console.WriteLine(ints.Size());
            //Console.WriteLine(ints.ToString());
            //Console.WriteLine(ints.IsEmpty());
            //Console.WriteLine(ints.Contain(9));
            //Console.WriteLine(ints.IndexOf(4));
            //ints.Clear();
            foreach (int i in ints) {
                Console.WriteLine(i);
            }
        }
    }
}
