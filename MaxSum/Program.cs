namespace MaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = {-2, 11, -4, 13, -5, -2 };
            Console.WriteLine(MaxSumNested(a));
        }

        public static int MaxSumNested(int[] a)
        {
            int maxSum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j < a.Length; j++)
                {
                    int sum = 0;
                    for(int k = i; k < j; k++)
                    {
                        sum += a[k];
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            return maxSum;
        }
    }
}
