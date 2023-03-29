public class TreeNode
{
    public char Value { get; set; }
    public TreeNode? InChild { get; set; }
    public TreeNode? OutChild { get; set; }

    public TreeNode(char value)
    {
        this.Value = value;
    }
}

public class Tree
{
    private TreeNode root;

    public Tree(string input)
    {
        this.root = BuildTree(input, 0, input.Length - 1);
    }
    private TreeNode BuildTree(string input, int startIndex, int endIndex)
    {
        if (startIndex > endIndex)
        {
            //Arada daha fazla karakter yok.
            return null;
        }

        var root = new TreeNode(input[startIndex]);
        int index = startIndex + 1;


        while (index <= endIndex && input[index] != input[startIndex])
        {
            index++;
        }

        root.InChild = BuildTree(input, startIndex + 1, index - 1);
        root.OutChild = BuildTree(input, index + 1, endIndex);

        return root;
    }

    public void Print()
    {
        Print(root, 0);
    }

    private void Print(TreeNode node, int depth)
    {
        if (depth == 0)
        {
            Console.WriteLine(node.Value);
        }
        else
        {
            Console.WriteLine(new string('-', depth) + node.Value);

        }


        if (node.InChild != null)
            Print(node.InChild, depth + 1);
        if (node.OutChild != null)
            Print(node.OutChild, depth);
    }
}

public class Program
{
    public static void Main()
    {
        var input = "abccbdeeda";

        var tree = new Tree(input);
        tree.Print();

        var input2 = "abccddbeea";
        var tree2 = new Tree(input2);
        tree2.Print();

    }
}

