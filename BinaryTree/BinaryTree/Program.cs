namespace BinaryTree;
using System;

class TreeNode
{
    public int Value;
    public int Count; // To track occurrences
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
        Count = 1;
        Left = null;
        Right = null;
    }
}

class BinarySearchTree
{
    private TreeNode root;

    public void Insert(int value)
    {
        root = Insert(root, value);
    }

    private TreeNode Insert(TreeNode node, int value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (value == node.Value)
        {
            node.Count++; // Increment count if value already exists
        }
        else if (value < node.Value)
        {
            node.Left = Insert(node.Left, value);
        }
        else
        {
            node.Right = Insert(node.Right, value);
        }

        return node;
    }

    public int CountEdges()
    {
        int nodeCount = CountNodes(root);
        return nodeCount > 0 ? nodeCount - 1 : 0; // Edges = Nodes - 1
    }

    private int CountNodes(TreeNode node)
    {
        if (node == null)
            return 0;
        return 1 + CountNodes(node.Left) + CountNodes(node.Right); // Count current node + left + right
    }

    public void InOrderTraversal()
    {
        InOrderTraversal(root);
    }

    private void InOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        InOrderTraversal(node.Left);
        Console.WriteLine($"Value: {node.Value}, Occurrences: {node.Count}");
        InOrderTraversal(node.Right);
    }

    public void PreOrderTraversal()
    {
        PreOrderTraversal(root);
    }

    private void PreOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        Console.WriteLine($"Value: {node.Value}, Occurrences: {node.Count}");
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversal(root);
    }

    private void PostOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.WriteLine($"Value: {node.Value}, Occurrences: {node.Count}");
    }

    // Remove a node with the given value
    public Node RemoveNode(Node root, int key)
    {
        // Base case: if the tree is empty
        if (root == null)
            return root;

        // Find the node to delete
        if (key < root.Value)
        {
            root.Left = RemoveNode(root.Left, key);
        }
        else if (key > root.Value)
        {
            root.Right = RemoveNode(root.Right, key);
        }
        else
        {
            // Case 1: Node has no children (leaf node)
            if (root.Left == null && root.Right == null)
            {
                return null;
            }
            // Case 2: Node has one child
            else if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }
            // Case 3: Node has two children
            else
            {
                // Find the inorder successor (smallest in the right subtree)
                root.Value = MinValueNode(root.Right).Value;
                // Delete the inorder successor
                root.Right = RemoveNode(root.Right, root.Value);
            }
        }

        return root;
    }

    // Helper method to find the minimum value node in a subtree
    private Node MinValueNode(Node node)
    {
        Node current = node;
        while (current.Left != null)
        {
            current = current.Left;
        }
        return current;
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();
        BinarySearchTree bst = new BinarySearchTree();

        // Generate 10,000 random numbers between 0 and 9
        for (int i = 0; i < 10000; i++)
        {
            bst.Insert(random.Next(0, 10));
        }

        Console.WriteLine("In-Order Traversal:");
        bst.InOrderTraversal();

        Console.WriteLine("\nPre-Order Traversal:");
        bst.PreOrderTraversal();

        Console.WriteLine("\nPost-Order Traversal:");
        bst.PostOrderTraversal();
    }
}
