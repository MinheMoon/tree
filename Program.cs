using System;

class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
    }
}

class BinaryTree
{
    public TreeNode Root { get; private set; }

    public void Insert(int value)
    {
        Root = InsertRec(Root, value);
    }

    private TreeNode InsertRec(TreeNode node, int value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (value < node.Value)
        {
            node.Left = InsertRec(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = InsertRec(node.Right, value);
        }

        return node;
    }

    public void InOrder()
    {
        InOrderRec(Root);
    }

    private void InOrderRec(TreeNode node)
    {
        if (node != null)
        {
            InOrderRec(node.Left);
            Console.Write(node.Value + " ");
            InOrderRec(node.Right);
        }
    }

    public bool Search(int value)
    {
        return SearchRec(Root, value);
    }

    private bool SearchRec(TreeNode node, int value)
    {
        if (node == null)
        {
            return false;
        }

        if (node.Value == value)
        {
            return true;
        }

        return value < node.Value ? SearchRec(node.Left, value) : SearchRec(node.Right, value);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть розмір масиву: ");
        int size = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[size];
        var random = new Random();

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(100);
        }

        Console.WriteLine("Згенерований масив: " + string.Join(" ", array));

        var binaryTree = new BinaryTree();
        foreach (var value in array)
        {
            binaryTree.Insert(value);
        }

        Console.WriteLine("Впорядковане бінарне дерево (ін-ордер обхід):");
        binaryTree.InOrder();
        Console.WriteLine();

        Console.Write("Введіть значення для пошуку: ");
        int searchValue = Convert.ToInt32(Console.ReadLine());
        bool found = binaryTree.Search(searchValue);
        Console.WriteLine(found ? $"Значення {searchValue} знайдено в бінарному дереві." : $"Значення {searchValue} не знайдено в бінарному дереві.");
    }
}
