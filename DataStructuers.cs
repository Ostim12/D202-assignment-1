using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataStructuers
{
    class Queue<T>
    {

        private T[] queue { get; set; }
        private int size { get; set; }

        public Queue(int capacity)
        {
            queue = new T[capacity];
            size = 0;
        }

        public void Enqueue(T input)
        {
            if (size == queue.Length)
                throw new InvalidOperationException("Queue is full");

            queue[size] = input;
            size++;
        }

        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException("Queue is empty");

            T return_item = queue[0];

            for (int i = 1; i < size; i++)
                queue[i - 1] = queue[i];

            size--;
            return return_item;

        }

        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException("Queue is empty");

            return queue[0];
        }


    }

    class Stack<T>
    {
        private T[] stack { get; set; }
        private int size { get; set; }

        public IntStack(int capacity)
        {
            stack = new T[capacity];
            size = 0;
        }

        public void Push(T input)
        {
            if (size == stack.Length)
                throw new InvalidOperationException("Stack is full");

            stack[size] = input;
            size++;
        }

        public T Pop()
        {
            if (size == 0)
                throw new InvalidOperationException("Stack is empty");

            T return_item = stack[size - 1];
            size--;
            return return_item;

        }

        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException("Stack is empty");

            return stack[size - 1];
        }
    }

    class SimpleHashTable<T>
    {
        private int size = 10;
        private string[] keys;
        private T[] values;

        public SimpleHashTable()
        {
            keys = new string[size];
            values = new T[size];
        }

        private int GetHash(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash += c;
            }
            return hash % size;
        }

        public void Insert(string key, T value)
        {
            int index = GetHash(key);

            if (keys[index] == key || keys[index] == null)
            {
                keys[index] = key;
                values[index] = value;
            }
            else
            {
                throw new InvalidOperationException("Hash collision occurred");
            }
        }

        public T GetValue(string key)
        {
            int index = GetHash(key);
            return values[index];
        }
    }

    class LinkList<T>
    {
        public Node<T>? head = null;

        public void AddFirst(T item)
        {
            
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previus = newNode;
                head = newNode;
            }
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
    }

    class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Previus { get; set; }

        public Node(T data, Node<T>? previus = null, Node<T>? next = null)
        {
            Data = data;
            Next = next;
            Previus = previus;
        }
    }
}
