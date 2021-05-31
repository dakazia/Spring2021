using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public int Length { get => count; }

       public void Add(T e)
        {
            if (count == 0)
            {
                head = tail = new Node<T>(e);
            }
            else if (count == 1)
            {
                tail = new Node<T>(e);
                head.next = tail;
                tail.prev = head;
            }
            else
            {
                var temp = tail;
                tail = new Node<T>(e);
                temp.next = tail;
                tail.prev = temp;
            }
            count++;
        }

        public void AddAt(int index, T e)
        {
            VerifyValidationIndex(index);

            if (index == count)
            {
                var temp = tail;
                tail = new Node<T>(e);
                temp.next = tail;
                tail.prev = temp;
            }
            else
            {
                var addedNode = GetNodeAt(index);
                addedNode.data = e;
            }

            count++;
        }
        private Node<T> GetNodeAt(int index)
        {
            var node = head;
            for (int i = 0; i < index; i++)
            {
                node = node.next;
            }

            return node;
        }

        public T ElementAt(int index)
        {
            VerifyValidationIndex(index);

            VerifyIndexEqualsLength(index);

            return GetNodeAt(index).data;
        }

        public void Remove(T item)
        {
            var node = head;
            while (node != null)
            {
                if (node.data.Equals(item))
                {
                    ChangeLinksWhenRemove(node);
                    count--;
                    return;
                }

                node = node.next;
            }
        }

        public T RemoveAt(int index)
        {
            VerifyValidationIndex(index);

            VerifyIndexEqualsLength(index);

            var node = GetNodeAt(index);
            
            ChangeLinksWhenRemove(node);

            count--;
            return node.data;
        }

        private void VerifyValidationIndex(int index)
        {
            if (count == 0 || index > count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void VerifyIndexEqualsLength(int index)
        {
            if (index == count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ChangeLinksWhenRemove(Node<T> node)
        {
            if (node == head)
            {
                head = head.next;
                head.prev = null;
            }
            else if (node == tail)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        private class Enumerator : IEnumerator<T>
        {
            private readonly DoublyLinkedList<T> _list;
            private Node<T> _node;
            private T _current;

            public Enumerator(DoublyLinkedList<T> list)
            {
                _list = list;
                _node = list.head;
                _current = default;
            }

            public bool MoveNext()
            {
                if (_node == null)
                {
                    return false;
                }

                _current = _node.data;
                _node = _node.next;

                if (_node == _list.head)
                {
                    _node = null;
                }

                return true;
            }

            public void Reset()
            {
                _node = _list.head;
                _current = default;

            }

            public T Current
            {
                get => _current;
            }

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}
