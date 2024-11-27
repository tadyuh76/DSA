namespace Graph;

using System;
using System.Collections.Generic;

class Graph
{
    private readonly int[,] adjacencyMatrix;
    private readonly int size;

    public Graph(int size)
    {
        this.size = size;
        adjacencyMatrix = new int[size, size];

        // Initialize adjacency matrix with 0 (no edges)
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                adjacencyMatrix[i, j] = 0;
            }
        }
    }

    public void AddEdge(int u, int v, int weight = 1)
    {
        adjacencyMatrix[u, v] = weight;
        adjacencyMatrix[v, u] = weight; // For undirected graphs
    }

    // BFS using a queue
    public void BFS(int start)
    {
        var queue = new Queue<int>();
        var visited = new bool[size];

        queue.Enqueue(start);
        visited[start] = true;

        Console.WriteLine("BFS Traversal:");
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            Console.Write(current + " ");

            for (int i = 0; i < size; i++)
            {
                if (adjacencyMatrix[current, i] != 0 && !visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                }
            }
        }
        Console.WriteLine();
    }

    // DFS using stack
    public void DFSWithStack(int start)
    {
        var stack = new Stack<int>();
        var visited = new bool[size];

        stack.Push(start);

        Console.WriteLine("DFS Traversal Using Stack:");
        while (stack.Count > 0)
        {
            int current = stack.Pop();

            if (!visited[current])
            {
                Console.Write(current + " ");
                visited[current] = true;
            }

            // Push unvisited neighbors onto the stack
            for (int i = size - 1; i >= 0; i--)
            {
                if (adjacencyMatrix[current, i] != 0 && !visited[i])
                {
                    stack.Push(i);
                }
            }
        }
        Console.WriteLine();
    }


    // DFS using recursion
    public void DFSRecursive(int start)
    {
        var visited = new bool[size];
        Console.WriteLine("DFS Recursive Traversal:");
        DFSHelper(start, visited);
        Console.WriteLine();
    }

    private void DFSHelper(int current, bool[] visited)
    {
        if (visited[current]) return;

        Console.Write(current + " ");
        visited[current] = true;

        for (int i = 0; i < size; i++)
        {
            if (adjacencyMatrix[current, i] != 0)
            {
                DFSHelper(i, visited);
            }
        }
    }

    // Dijkstra's Algorithm
    public void Dijkstra(int start)
    {
        var distances = new int[size];
        var visited = new bool[size];

        // Initialize distances to infinity and visited to false
        for (int i = 0; i < size; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }
        distances[start] = 0;

        for (int count = 0; count < size - 1; count++)
        {
            // Select the unvisited node with the smallest distance
            int u = FindMinDistance(distances, visited);
            visited[u] = true;

            // Update distances to adjacent nodes
            for (int v = 0; v < size; v++)
            {
                if (!visited[v] &&
                    adjacencyMatrix[u, v] != 0 &&
                    distances[u] != int.MaxValue &&
                    distances[u] + adjacencyMatrix[u, v] < distances[v])
                {
                    distances[v] = distances[u] + adjacencyMatrix[u, v];
                }
            }
        }

        // Print shortest distances
        Console.WriteLine($"Shortest distances from node {start}:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Node {i}: {(distances[i] == int.MaxValue ? "Infinity" : distances[i].ToString())}");
        }
    }

    private int FindMinDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int i = 0; i < size; i++)
        {
            if (!visited[i] && distances[i] <= min)
            {
                min = distances[i];
                minIndex = i;
            }
        }
        return minIndex;
    }
}

class Program
{
    static void Main()
    {
        // Create a graph with 10 nodes (0 to 9)
        Graph graph = new Graph(10);

        // Add edges
        graph.AddEdge(0, 1, 4);
        graph.AddEdge(0, 2, 1);
        graph.AddEdge(1, 3, 2);
        graph.AddEdge(1, 4, 7);
        graph.AddEdge(2, 5, 3);
        graph.AddEdge(3, 6, 6);
        graph.AddEdge(4, 7, 1);
        graph.AddEdge(5, 8, 5);
        graph.AddEdge(6, 9, 4);
        graph.AddEdge(7, 9, 2);

        // Perform BFS, DFS, and Dijkstra's algorithm
        graph.BFS(0);

        graph.DFSWithStack(0);
        graph.DFSRecursive(0);

        graph.Dijkstra(0);
    }
}
