using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test.CustomLists
{
    public class LinkedListDeque<T>: IEnumerable<T> where T: IComparable<T>
    {
        public LinkedNode<T> head;
        public LinkedNode<T> tail;
        private int count;

        public LinkedListDeque() {}
        public IEnumerator<T> GetEnumerator()
        {
            LinkedNode<T> current = tail;
            while (current != null)
            {
                yield return current.InfField;
                current = current.PrevNode;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        public void AddLast(T data)
        {
            LinkedNode<T> node = new LinkedNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.NextNode = node;
                node.PrevNode = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            var node = new LinkedNode<T>(data);
            var temp = head;
            node.NextNode = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.PrevNode = node;
            count++;
        }
        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.InfField;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.NextNode;
                head.PrevNode = null;
            }
            count--;
            return output;
        }
        public T RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = tail.InfField;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.PrevNode;
                tail.NextNode = null;
            }
            count--;
            return output;
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
    }
}
