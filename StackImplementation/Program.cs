namespace StackImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine("Stack size: " + stack.Size());
            Console.WriteLine("Top element: " + stack.Top());
            //while (!stack.IsEmpty())
            //{
            //    Console.WriteLine("Popped element: " + stack.Pop());
            //}
            //try
            //{
            //    stack.Pop(); // This should throw an exception since the stack is empty
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            foreach(var item in stack)
            {
                Console.WriteLine("Item in stack: " + item);
            }
        }
    }
}
