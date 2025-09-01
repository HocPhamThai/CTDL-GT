namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeADT<int> binarySearchTree = new BinarySearchTree<int>();
            
            // Kiểm tra tree rỗng
            Console.WriteLine("=== KIỂM TRA TREE RỖNG ===");
            Console.WriteLine("Is Empty: " + (binarySearchTree.IsEmpty() ? "Empty" : "Not Empty"));
            Console.WriteLine($"Size: {binarySearchTree.Size()}");
            Console.WriteLine($"Height: {binarySearchTree.Height()}");
            
            // Thêm các phần tử
            Console.WriteLine("\n=== THÊM CÁC PHẦN TỬ ===");
            Console.WriteLine("Processing Add..");
            binarySearchTree.Add(50);
            binarySearchTree.Add(30);
            binarySearchTree.Add(20);
            binarySearchTree.Add(40);
            binarySearchTree.Add(70);
            binarySearchTree.Add(60);
            binarySearchTree.Add(80);
            
            Console.WriteLine("Is Empty: " + (binarySearchTree.IsEmpty() ? "Empty" : "Not Empty"));
            Console.WriteLine($"Size: {binarySearchTree.Size()}");
            Console.WriteLine($"Height: {binarySearchTree.Height()}");
            
            // Kiểm tra traverse
            Console.WriteLine("\n=== CÁC CÁCH DUYỆT CÂY ===");
            Console.Write("PreOrder: ");
            foreach (var item in binarySearchTree.Traverse(TraverseOrder.PreOrder))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
            Console.Write("InOrder: ");
            foreach (var item in binarySearchTree.Traverse(TraverseOrder.InOrder))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
            Console.Write("PostOrder: ");
            foreach (var item in binarySearchTree.Traverse(TraverseOrder.PostOrder))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
            // Kiểm tra Contains
            Console.WriteLine("\n=== KIỂM TRA CONTAINS ===");
            Console.WriteLine($"Contains 30: {binarySearchTree.Contains(30)}");
            Console.WriteLine($"Contains 100: {binarySearchTree.Contains(100)}");
            Console.WriteLine($"Contains 20: {binarySearchTree.Contains(20)}");
            
            // Kiểm tra Remove
            Console.WriteLine("\n=== KIỂM TRA REMOVE ===");
            Console.WriteLine($"Remove 30: {binarySearchTree.Remove(30)}");
            Console.WriteLine($"Size after remove: {binarySearchTree.Size()}");
            
            Console.Write("InOrder after remove 30: ");
            foreach (var item in binarySearchTree.Traverse(TraverseOrder.InOrder))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
            // Remove root
            Console.WriteLine($"Remove root (20): {binarySearchTree.Remove(20)}");
            Console.WriteLine($"Size after remove root: {binarySearchTree.Size()}");
            
            Console.Write("InOrder after remove root: ");
            foreach (var item in binarySearchTree.Traverse(TraverseOrder.InOrder))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine($"Final Height: {binarySearchTree.Height()}");
        }
    }
}
