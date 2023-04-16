using System;
using System.Collections.Generic;
using System.Linq;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxLinkedStack<T>
    {
        private readonly LinkedList<T> _linkedList = new LinkedList<T>();

        public bool IsEmpty => _linkedList.Count == 0;

        public int Count => _linkedList.Count;

        public void Push(T t)
        {
            _linkedList.AddFirst(t);
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The stack is empty.");
            var item = _linkedList.First.Value;
            _linkedList.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The stack is empty.");
            return _linkedList.First.Value;
        }

        public List<T> FindAll(Predicate<T> match)
        {
            return _linkedList.Where(item => match(item)).ToList();
        }

        public int FindIndex(Predicate<T> match)
        {
            var index = 0;
            foreach (var item in _linkedList)
            {
                if (match(item))
                    return index;
                ++index;
            }

            return -1;
        }

        public void RemoveAll(Predicate<T> match)
        {
            var nodesToRemove = _linkedList.Where(item => match(item)).ToList();
            foreach (var node in nodesToRemove)
            {
                _linkedList.Remove(node);
            }
        }

        public void RemoveAt(int index)
        {
            var nodeToRemove = GetNode(index);
            _linkedList.Remove(nodeToRemove);
        }

        public void Swap(int leftIndex, int rightIndex)
        {
            if (!IsValidIndex(leftIndex) || !IsValidIndex(rightIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(leftIndex), "Index out of range.");
            }

            if (leftIndex == rightIndex)
            {
                return;
            }

            var leftNode = GetNode(leftIndex);
            var rightNode = GetNode(rightIndex);
            (leftNode.Value, rightNode.Value) = (rightNode.Value, leftNode.Value);
        }

        private LinkedListNode<T> GetNode(int index)
        {
            if (IsEmpty)
                throw new InvalidOperationException("The stack is empty.");

            var node = _linkedList.First;
            for (var i = 0; i < index; i++)
            {
                node = node?.Next;
            }

            return node;
        }

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < Count;
        }
    }
}