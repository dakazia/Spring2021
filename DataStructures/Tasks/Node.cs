

using System;

namespace Tasks
{
    public class Node<T>
    {
        public T data;
        public Node<T> prev;
        public Node<T> next;

        // Constructor to create a new node
        // next and prev is by default initialized as null
        public Node(T d) { data = d; }

     }
}
