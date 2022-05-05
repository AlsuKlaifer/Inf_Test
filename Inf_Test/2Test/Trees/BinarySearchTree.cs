using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Trees
{
    public class BinarySearchTree<T>
    {
        private BinaryTreeNode<T> root;

        /// <summary>
        /// Выводит все узлы высотой n
        /// </summary>
        public void FindAllNode(int n)
        {
            if (n < 0) throw new Exception("Элемент не может быть отрицательным.");
            if (n == root.GetNodeHeight())
            {
                Console.WriteLine($"Ключ: {root.Key}");
                return;
            }
            List<BinaryTreeNode<T>> toVisit = new List<BinaryTreeNode<T>>();
            toVisit.Add(root);
            while (toVisit.Any())
            {
                var current = toVisit[0];
                if (current.Left != null)
                    toVisit.Add(current.Left);
                if (current.Right != null)
                    toVisit.Add(current.Right);
                toVisit.RemoveAt(0);
                if (current.GetNodeHeight() == n)
                    Console.WriteLine($"Ключ: {current.Key}");
            }
        }

        /// <summary>
        /// Считает количество листов
        /// </summary>
        public int CountLeaves()
        {
            if (root == null) return 0;
            int sum = 0;
            List<BinaryTreeNode<T>> toVisit = new List<BinaryTreeNode<T>>();
            toVisit.Add(root);
            while (toVisit.Any())
            {
                var current = toVisit[0];
                if (current.Left != null)
                    toVisit.Add(current.Left);
                if (current.Right != null)
                    toVisit.Add(current.Right);
                if (current.Left == null && current.Right == null)
                    sum++;
                toVisit.RemoveAt(0);
            }
            return sum;
        }

        /// <summary>
        /// Выводит дерево в ширину, каждый уровень отличным цветом
        /// </summary>
        public void PrintColor()
        {
            List<BinaryTreeNode<T>> toVisit = new List<BinaryTreeNode<T>>();
            toVisit.Add(root);
            while (toVisit.Any())
            {
                var current = toVisit[0];
                if (current.Left != null) toVisit.Add(current.Left);
                if (current.Right != null) toVisit.Add(current.Right);
                toVisit.RemoveAt(0);
                Console.ForegroundColor = (ConsoleColor) current.GetNodeHeight() + 1; // устанавливаем цвет
                Console.WriteLine($"Ключ: {current.Key}");
                Console.ResetColor(); // сбрасываем в стандартный
            }
        }


        public void Add(int key, T value)
        {
            if (root == null)
                root = new BinaryTreeNode<T>(value, key);
            else
            {
                var rootCopy = root;
                bool isFind = false;
                while (isFind == false)
                {
                    if (key == rootCopy.Key)
                    {
                        rootCopy.Value = value;
                        isFind = true;
                    }
                    else if (key < rootCopy.Key)
                    {
                        if (rootCopy.Left == null)
                        {
                            rootCopy.Left = new BinaryTreeNode<T>(value, key, rootCopy);
                            isFind = true;
                        }
                        else rootCopy = rootCopy.Left;
                    }
                    else
                    {
                        if (rootCopy.Right == null)
                        {
                            rootCopy.Right = new BinaryTreeNode<T>(value, key, rootCopy);
                            isFind = true;
                        }
                        else rootCopy = rootCopy.Right;
                    }

                }
            }
        }
    }
}