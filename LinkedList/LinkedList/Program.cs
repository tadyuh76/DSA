using System;

// Node for Singly Linked List
public class SinglyLinkedListNode
{
    public object Data;
    public SinglyLinkedListNode Next;

    public SinglyLinkedListNode(object data)
    {
        Data = data;
        Next = null;
    }
}

// Singly Linked List
public class SinglyLinkedList
{
    private SinglyLinkedListNode head;

    public SinglyLinkedList()
    {
        head = null;
    }

    // Add to the end of the list
    public void Add(object data)
    {
        SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            SinglyLinkedListNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // Insert after a specific element
    public void InsertAfter(object target, object data)
    {
        SinglyLinkedListNode current = head;
        while (current != null && !current.Data.Equals(target))
        {
            current = current.Next;
        }

        if (current != null)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
            newNode.Next = current.Next;
            current.Next = newNode;
        }
    }

    // Remove a node by value
    public void Remove(object data)
    {
        if (head == null) return;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            return;
        }

        SinglyLinkedListNode current = head;
        while (current.Next != null && !current.Next.Data.Equals(data))
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    // Search for a value
    public bool Contains(object data)
    {
        SinglyLinkedListNode current = head;
        while (current != null)
        {
            if (current.Data.Equals(data)) return true;
            current = current.Next;
        }
        return false;
    }

    // Swap two elements
    public void Swap(object data1, object data2)
    {
        if (head == null || data1.Equals(data2))
            return;

        SinglyLinkedListNode prev1 = null, prev2 = null;
        SinglyLinkedListNode node1 = head, node2 = head;

        // Find node1 and node2
        while (node1 != null && !node1.Data.Equals(data1))
        {
            prev1 = node1;
            node1 = node1.Next;
        }

        while (node2 != null && !node2.Data.Equals(data2))
        {
            prev2 = node2;
            node2 = node2.Next;
        }

        if (node1 == null || node2 == null)
            return;  // One of the elements not found

        // If node1 is not the head, update the previous node's next pointer
        if (prev1 != null)
            prev1.Next = node2;
        else
            head = node2;  // If node1 is the head, set node2 as the new head

        // If node2 is not the head, update the previous node's next pointer
        if (prev2 != null)
            prev2.Next = node1;
        else
            head = node1;  // If node2 is the head, set node1 as the new head

        // Swap the next pointers
        SinglyLinkedListNode temp = node1.Next;
        node1.Next = node2.Next;
        node2.Next = temp;
    }

    // Print all elements
    public void PrintAll()
    {
        SinglyLinkedListNode current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

// Node for Doubly Linked List
public class DoublyLinkedListNode
{
    public object Data;
    public DoublyLinkedListNode Next;
    public DoublyLinkedListNode Prev;

    public DoublyLinkedListNode(object data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

// Doubly Linked List
public class DoublyLinkedList
{
    private DoublyLinkedListNode head;

    public DoublyLinkedList()
    {
        head = null;
    }

    // Add to the end of the list
    public void Add(object data)
    {
        DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            DoublyLinkedListNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Prev = current;
        }
    }

    // Insert after a specific element
    public void InsertAfter(object target, object data)
    {
        DoublyLinkedListNode current = head;
        while (current != null && !current.Data.Equals(target))
        {
            current = current.Next;
        }

        if (current != null)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
            newNode.Next = current.Next;
            newNode.Prev = current;
            if (current.Next != null)
            {
                current.Next.Prev = newNode;
            }
            current.Next = newNode;
        }
    }

    // Remove a node by value
    public void Remove(object data)
    {
        if (head == null) return;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            if (head != null)
            {
                head.Prev = null;
            }
            return;
        }

        DoublyLinkedListNode current = head;
        while (current != null && !current.Data.Equals(data))
        {
            current = current.Next;
        }

        if (current != null)
        {
            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
        }
    }

    // Search for a value
    public bool Contains(object data)
    {
        DoublyLinkedListNode current = head;
        while (current != null)
        {
            if (current.Data.Equals(data)) return true;
            current = current.Next;
        }
        return false;
    }

    // Swap two elements
    public void Swap(object data1, object data2)
    {
        if (head == null || data1.Equals(data2))
            return;

        DoublyLinkedListNode node1 = head, node2 = head;

        // Find node1 and node2
        while (node1 != null && !node1.Data.Equals(data1))
        {
            node1 = node1.Next;
        }

        while (node2 != null && !node2.Data.Equals(data2))
        {
            node2 = node2.Next;
        }

        if (node1 == null || node2 == null)
            return;  // One of the elements not found

        // Swap previous and next pointers of node1 and node2
        if (node1.Prev != null)
            node1.Prev.Next = node2;
        if (node2.Prev != null)
            node2.Prev.Next = node1;

        // Swap head if necessary
        if (node1 == head)
            head = node2;
        else if (node2 == head)
            head = node1;

        // Swap the previous pointers
        DoublyLinkedListNode tempPrev = node1.Prev;
        node1.Prev = node2.Prev;
        node2.Prev = tempPrev;

        // Swap the next pointers
        DoublyLinkedListNode tempNext = node1.Next;
        node1.Next = node2.Next;
        node2.Next = tempNext;

        // Update the next nodes' prev pointers if necessary
        if (node1.Next != null)
            node1.Next.Prev = node1;
        if (node2.Next != null)
            node2.Next.Prev = node2;
    }

    // Print all elements
    public void PrintAll()
    {
        DoublyLinkedListNode current = head;
        while (current != null)
        {
            Console.Write(current.Data + " <-> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

// Test Program
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Singly Linked List:");
        SinglyLinkedList singlyList = new SinglyLinkedList();
        singlyList.Add(10);
        singlyList.Add(20);
        singlyList.Add(30);
        singlyList.PrintAll();
        singlyList.InsertAfter(20, 25);
        singlyList.PrintAll();
        singlyList.Remove(20);
        singlyList.PrintAll();
        singlyList.Swap(10, 25);
        singlyList.PrintAll();
        Console.WriteLine("Contains 30: " + singlyList.Contains(30));

        Console.WriteLine("\nDoubly Linked List:");
        DoublyLinkedList doublyList = new DoublyLinkedList();
        doublyList.Add(40);
        doublyList.Add(50);
        doublyList.Add(60);
        doublyList.PrintAll();
        doublyList.InsertAfter(50, 55);
        doublyList.PrintAll();
        doublyList.Remove(50);
        doublyList.PrintAll();
        doublyList.Swap(60, 40);
        doublyList.PrintAll();
        Console.WriteLine("Contains 60: " + doublyList.Contains(60));
    }
}