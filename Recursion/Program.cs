namespace Recursion
{
    public class Program
    {
        static void Main(string[] args)
        {
            // test Fibonacci
            // [0,1,1,2,3,5,8,12,]
            // [0,1,2,3,4,5,6,7]
            Console.WriteLine(Fibonacci(6));
            Console.WriteLine(Fibonacci_Loop(6));

            Console.WriteLine(Factorial_Recursion(3));
            Console.WriteLine(SumToN(3));
        }

        public static int Fibonacci(int n)
        {
            if (n < 2) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static int Fibonacci_Loop(int n)
        {
            if (n < 2) return n;
            int fib0 = 0;
            int fib1 = 1;
            int result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = fib0 + fib1;
                fib0 = fib1;
                fib1 = result;
            }
            return result;
            // Fib(n) = Fib(n-1) + Fib(n-2)
        }

        // factorial(n) = factorial(n) * factorial(n - 1) *...* 1
        public static int Factorial_Recursion(int n)
        {
            if (n == 1) return 1;
            return n * Factorial_Recursion(n - 1);
        }

        public static int SumToN(int n)
        {
            if (n == 1) return 1;
            return n + SumToN(n - 1);
        }

    }
}
