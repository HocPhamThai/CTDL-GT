namespace Graph
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IndexedGraph DFS demo");

            // Build a graph with 8 nodes (0..7). Node 7 is isolated.
            var g = new IndexedGraph(8);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(2, 5);
            g.AddEdge(5, 6);

            // DFS from 0
            var order0 = g.DfsFromZero;
            Show("DFS from 0", order0);

            // DFS from 3
            var order3 = g.Dfs(3);
            Show("DFS from 3", order3);

            // Verify isolated node (7) isn’t visited when starting from 0
            Console.WriteLine($"Contains 7 in DFS(0)? {order0.Contains(7)} (expected: False)");

            // Out-of-range DFS should throw
            try
            {
                g.Dfs(100);
                Console.WriteLine("Unexpected: no exception for out-of-range index.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Expected exception caught: {ex.Message}");
            }

            Console.WriteLine("Done.");
        }

        private static void Show(string title, List<int> order)
        {
            Console.WriteLine($"{title}: {string.Join(" -> ", order)}");
        }
    }
}
