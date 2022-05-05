using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test.CustomLists
{
    /// <summary>
    /// Линейный список на основе двунаправленного списка
    /// </summary>
    public class CustomLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private LinkedNode<T> head;
        public CustomLinkedList() { }
        public CustomLinkedList(T elem)
        {
            head = new LinkedNode<T>(elem);
        }
        public CustomLinkedList(T[] array)
        {
            if (array == null && array.Length == 0)
                return;
            head = new LinkedNode<T>(array[0]);
            if (array.Length > 1)
            {
                var headCopy = head;
                for (int i = 1; i < array.Length; i++)
                {
                    var node = new LinkedNode<T>(array[i]);
                    node.PrevNode = headCopy;
                    headCopy.NextNode = node;
                    headCopy = headCopy.NextNode;
                }
            }
        }
        public bool isEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }
        public void RemoveTheThirdFromEnd()
        {
            int ind = Size() - 2;
            RemoveAt(ind);
        }
        public void RemoveAt(int index)
        {
            if (index <= 0)
                throw new Exception("Позиция должна быть больше единицы");

            if (head == null || Size() < index)
                throw new Exception("Нет данной позиции в списке");

            if (index == 1)
                head = head.NextNode;

            var headCopy = head;
            for (int i = 1; i <= index - 1; i++)
            {
                headCopy = headCopy.NextNode;
            }

            if (headCopy.NextNode == null)
            {
                headCopy.PrevNode.NextNode = null;
            }
            else
            {
                headCopy.PrevNode.NextNode = headCopy.NextNode;
                headCopy.NextNode.PrevNode = headCopy.PrevNode;
            }
        }
        public int Size()
        {
            if (head == null)
                return 0;
            var headcopy = head;
            int length = 1;
            while (headcopy.NextNode != null)
            {
                length++;
                headcopy = headcopy.NextNode;
            }
            return length;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(head);
        }
        public override string ToString()
        {
            if (head == null)
                return "Список пуст";
            var sb = new StringBuilder();
            var headCopy = head;
            while (headCopy != null)
            {
                sb.Append(headCopy.InfField.ToString());
                if (headCopy.NextNode != null)
                    sb.Append(" ");
                headCopy = headCopy.NextNode;
            }
            return sb.ToString();
        }
        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
    public class LinkedListEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private LinkedNode<T> _head;
        private int number = 0;

        private LinkedNode<T> currentNode;
        public T Current => currentNode.InfField;
        object IEnumerator.Current => Current;
        public LinkedListEnumerator(LinkedNode<T> head)
        {
            _head = head;
            currentNode = new LinkedNode<T>(default(T))
            {
                NextNode = head
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (number == 0)
            {
                while (currentNode.NextNode != null)
                    currentNode = currentNode.NextNode;
                number++;
                return true;
            }
            else if (currentNode.PrevNode != null)
            {
                currentNode = currentNode.PrevNode;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            currentNode = new LinkedNode<T>(default(T))
            {
                NextNode = _head
            };
        }
    }
}
