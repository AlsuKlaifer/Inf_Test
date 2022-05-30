using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Trees
{
    /// <summary>
    /// Вершина бинарного дерева поиска
    /// </summary>
    public class BinaryTreeNode<T>
    {
        public T Value;
        public int Key;
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;
        public BinaryTreeNode<T> Parent;

        public BinaryTreeNode(int key)
        {
            Key = key;
        }
        public BinaryTreeNode(T value, int key, BinaryTreeNode<T> parent = null)
        {
            Value = value;
            Key = key;
            Parent = parent;
        }

        public BinaryTreeNode(T value, int key, BinaryTreeNode<T> left, BinaryTreeNode<T> right, BinaryTreeNode<T> parent = null)
        {
            Value = value;
            Key = key;
            Parent = parent;
            Right = right;
            Left = left;
        }
        public int GetNodeHeight()
        {
            //return this.Parent == null ? 0 : this.Parent.GetNodeHeight() + 1;
            return this == null ? 0 : Math.Max(this.Left.GetNodeHeight(), this.Right.GetNodeHeight()) + 1;
        }
    }
}
