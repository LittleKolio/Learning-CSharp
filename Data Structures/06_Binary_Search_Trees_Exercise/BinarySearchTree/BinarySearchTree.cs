﻿using System;
using System.Collections.Generic;

public class BinarySearchTree<T> 
    : IBinarySearchTree<T> 
    where T : IComparable
{
    private Node root;

    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        //WTF
        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }
    
    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }


    
    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }
    
    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        //Node current = this.root;
        //Node parent = null;
        //while (current.Left != null)
        //{
        //    parent = current;
        //    current = current.Left;
        //}

        //if (parent == null)
        //{
        //    this.root = this.root.Right;
        //}
        //else
        //{
        //    parent.Left = current.Right;
        //}

        this.root = this.DeleteMin(this.root);

    }

    private Node DeleteMin(Node node)
    {
        if (node.Left == null)
        {
            return node.Right;
        }

        node.Left = this.DeleteMin(node.Left);

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
        if (this.root == null || !this.Contains(element))
        {
            throw new InvalidOperationException();
        }

        this.root = this.Delete(this.root, element);
    }

    private Node Delete(Node node, T element)
    {
        if (node == null)
        {
            return null;
        }

        int compare = node.Value.CompareTo(element);

        if (compare > 0)
        {
            node.Left = this.Delete(node.Left, element);
        }
        else if (compare < 0)
        {
            node.Right = this.Delete(node.Right, element);
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            if (node.Right == null)
            {
                return node.Left;
            }

            Node leftLeaf = this.LeftLeaf(node.Right);
            node.Value = leftLeaf.Value;
            node.Right = this.Delete(node.Right, leftLeaf.Value);
        }
        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
        return node;
    }

    private Node LeftLeaf(Node node)
    {
        Node current = node;
        while (current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }

    public void DeleteMax()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }
        this.root = this.DeleteMax(this.root);
    }

    private Node DeleteMax(Node node)
    {
        if (node.Right == null)
        {
            return node.Left;
        }

        node.Right = this.DeleteMax(node.Right);

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    public int Count()
    {
        return this.Count(this.root);
    }

    public int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        return node.Count;
    }

    public int Rank(T element)
    {
        return this.Rank(this.root, element);
    }

    private int Rank(Node node, T element)
    {
        if (node == null)
        {
            return 0;
        }

        int compare = node.Value.CompareTo(element);

        if (compare > 0)
        {
            return this.Rank(node.Left, element);
        }
        else if (compare < 0)
        {
            return 1 + 
                this.Count(node.Left) + 
                this.Rank(node.Right, element);
        }
        else
        {
            return this.Count(node.Left);
        }

    }

    public T Select(int rank)
    {
        Node node = this.Select(this.root, rank);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Select(Node node, int rank)
    {
        if (node == null)
        {
            return null;
        }

        int leftCount = this.Count(node.Left);

        if (leftCount > rank)
        {
            return this.Select(node.Left, rank);
        }
        else if (leftCount < rank)
        {
            return this.Select(node.Right, rank - (leftCount + 1));
        }

        return node;
    }

    public T Ceiling(T element)
    {
        int count = this.Rank(element);
        return this.Select(count + 1);
    }

    public T Floor(T element)
    {
        int count = this.Rank(element);
        return this.Select(count -1);
    }

    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }


        public int Count { get; set; }
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);


        bst.Delete(5);

        bst.EachInOrder(Console.WriteLine);
        
    }
}