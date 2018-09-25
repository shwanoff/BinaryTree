using System;

namespace Shvanov.TreeCompare
{
    /// <summary>
    /// Binary Tree. You can add only unique value.
    /// </summary>
    public class BinaryTree 
        : IComparable, 
          IComparable<BinaryTree>
    {
        private readonly int _value;

        public int Value => _value;

        public BinaryTree Left { get; private set; }
        public BinaryTree Right { get; private set; }

        public BinaryTree(int value)
        {
            _value = value;
        }

        public void Add(int value)
        {
            var newTreeNode = new BinaryTree(value);
            Add(newTreeNode);
        }

        public int CompareTo(object obj)
        {
            var binaryTree = obj as BinaryTree;
            if (binaryTree == null)
            {
                throw new ArgumentException($"Uncomparable argument {nameof(obj)} in CompareTo(object) method.", nameof(obj));
            }

            return CompareTo(binaryTree);
        }

        public int CompareTo(BinaryTree other)
        {
            if(other == null)
            {
                throw new ArgumentNullException($"Null argument {nameof(other)} in CompareTo(BinaryTree) method.", nameof(other));
            }

            return Value.CompareTo(other.Value);
        }

        public override bool Equals(object obj)
        {
            var binaryTree = obj as BinaryTree;
            if(binaryTree == null)
            {
                return false;
            }

            return Equals(binaryTree);
        }

        public bool Equals(BinaryTree other)
        {
            if(other == null)
            {
                return false;
            }

            if(Value != other.Value)
            {
                return false;
            }

            if((Left ?? other.Left) != null)
            {
                var leftCompare = Left?.Equals(other.Left) ?? false;
                if (!leftCompare)
                    return false;
            }

            if((Right ?? other.Right) != null)
            {
                return Right?.Equals(other.Right) ?? false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        protected void Add(BinaryTree node)
        {
            if(node.Equals(this))
            {
                return;
            }

            if(node.CompareTo(this) < 0)
            {
                if(Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(node);
                }
            }
            else if(node.CompareTo(this) > 0)
            {
                if(Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(node);
                }
            }
        }
    }
}
