using LinkedList;

class Program
{
    static void Main()
    {
        var list = new MyDoublyLinkedList<int?>();

        // Test AddLast và AddFirst
        list.Add(1);
        list.Add(2);
        list.Add(null);
        list.Add(1);
        list.Add(0);

        Console.WriteLine("Danh sách sau khi thêm:" + list.ToString());

        // Test Size
        Console.WriteLine("Số phần tử: " + list.Size()); // 3

        // Test PeekFirst và PeekLast
        Console.WriteLine("Phần tử đầu: " + list.PeekFirst()); // 0
        Console.WriteLine("Phần tử cuối: " + list.PeekLast()); // 2

        // Test RemoveFirst
        int? removedFirst = list.RemoveFirst();
        Console.WriteLine("Đã xóa đầu: " + removedFirst); // 0

        // Test RemoveLast
        int? removedLast = list.RemoveLast();
        Console.WriteLine("Đã xóa cuối: " + removedLast); // 2

        // Test còn lại
        Console.WriteLine("Còn lại: " + list.ToString());

        // Test IsEmpty và Clear
        list.Clear();
        Console.WriteLine("Sau khi clear, rỗng không? " + list.IsEmpty()); // True
    }
}
