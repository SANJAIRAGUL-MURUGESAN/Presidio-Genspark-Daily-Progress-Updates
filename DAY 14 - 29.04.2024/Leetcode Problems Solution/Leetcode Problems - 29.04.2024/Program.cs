namespace Leetcode_Problems___29._04._2024
{
    public class Program
    {
        public class TreeNode
        {
            public int val;

            public TreeNode left;

            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class BinaryTree
        {
            public async Task<int> MinDepthAsync(TreeNode root)
            {
                if (root == null)
                    return 0;

                if (root.left == null && root.right == null)
                    return 1;

                if (root.left == null)
                    return await MinDepthAsync(root.right) + 1;

                if (root.right == null)
                    return await MinDepthAsync(root.left) + 1;

                int leftDepth = await MinDepthAsync(root.left);
                int rightDepth = await MinDepthAsync(root.right);

                return Math.Min(leftDepth, rightDepth) + 1;
            }
        }

        // Creating List Node 
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
        public async Task<bool> HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                {
                    return true;
                }

                slow = slow.next;
                fast = fast.next.next;

                // Introducing a small delay to simulate an asynchronous operation
                await Task.Delay(10);
            }

            return false;
        }
        static async Task Main(string[] args)
        {
            //-------------------First Questions Starts--------------

            BinaryTree tree = new BinaryTree();

            // Code for constructing a binary tree
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            // Code for finding the minimum depth
            int MinimumDepth = await tree.MinDepthAsync(root); // Function Call
            Console.WriteLine("Minimum depth of the binary tree: " + MinimumDepth);

            //-----------First Question Over--------------------

            //-----------Second Question starts-----------------

            ExcelSheetColumn Excelsheet = new ExcelSheetColumn();
            Console.WriteLine("Enter the Column Number : ");
            int ColumnNumber = Convert.ToInt32(Console.ReadLine()); // Example column number(Assigning)

            string ColumnTitle = await Excelsheet.GetExcelColumnTitle(ColumnNumber); // Function Call
            Console.WriteLine($"Column title for column number {ColumnNumber}: {ColumnTitle}");

            //-----------Second Quesition Ends------------------

            //-----------Third Question Starts------------------

            ListNode head = new ListNode(3);
            head.next = new ListNode(2);
            head.next.next = new ListNode(0);
            head.next.next.next = new ListNode(-4);
            head.next.next.next.next = head.next; // Code for creating a cycle

            LinkedList Solution = new LinkedList();
            bool HasCycle = await Solution.HasCycle(head); // Function Call
            Console.WriteLine("Is Linked list has cycle: " + HasCycle);

            //-----------Third Question Ends--------------------
        }
    }
}
