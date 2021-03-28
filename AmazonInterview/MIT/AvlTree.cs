using System;
using System.Collections.Generic;

namespace AmazonInterview.MIT {
    public class AvlTree {
        private Node _root;

        public void Insert(int value) {
            var node = new Node(null, value);

            if (_root is null)
                _root = node;
            else
                _root = _root.Insert(value);
        }

        public int FindMin() =>
            _root.FindMin().Value;

        public int FindMax() =>
            _root.FindMax().Value;

        public IEnumerable<int> InOrder() {
            var result = new List<int>();
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();
            var node = _root;

            while (node != null) {
                if (node.Left != null && !visited.Contains(node.Left)) {
                    stack.Push(node);

                    node = node.Left;
                } else if (node.Right != null && !visited.Contains(node.Right)) {
                    stack.Push(node);

                    node = node.Right;
                } else if (node.Left is null && node.Right is null) {
                    visited.Add(node);

                    var parent = stack.Pop();

                    if (node.Value <= parent.Value) {
                        result.Add(node.Value);
                        result.Add(parent.Value);
                    }
                    else {
                        if (!visited.Contains(parent))
                            result.Add(parent.Value);

                        result.Add(node.Value);
                    }

                    visited.Add(parent);

                    node = parent;
                }
                else if (stack.Count == 0)
                    break;
                else {
                    node = stack.Pop();

                    if (!visited.Contains(node)) {
                        result.Add(node.Value);
                        visited.Add(node);
                    }
                }
            }

            return result;
        }

        private class Node {
            public int Value { get; private set; }

            public int Height { get; private set; }

            public Node Parent { get; private set; }

            public Node Left { get; private set; }

            public Node Right { get; private set; }

            public Node(Node parent, int value) {
                Parent = parent;
                Value = value;
                Height = 1;
            }

            public Node Insert(int value) {
                var node = BinaryInsert(value);
                var newRoot = Rebalance(node);

                return newRoot;
            }

            public Node FindMin() {
                if (Left is null)
                    return this;

                return Left.FindMin();
            }

            public Node FindMax() {
                if (Right is null)
                    return this;

                return Right.FindMax();
            }

            private Node BinaryInsert(int value) {
                Node node;

                if (value <= Value) {
                    if (Left is null)
                        node = Left = new Node(this, value);
                    else
                        node = Left.BinaryInsert(value);
                } else {
                    if (Right is null)
                        node = Right = new Node(this, value);
                    else
                        node = Right.BinaryInsert(value);
                }

                return node;
            }

            private Node Rebalance(Node node) {
                Node lastRoot = null;

                while (node != null) {
                    node.UpdateHeight();

                    if ((node.Left?.Height ?? -1) >= 2 + (node.Right?.Height ?? -1)) {
                        if ((node.Left.Left?.Height ?? -1) >= (node.Left.Right?.Height ?? -1))
                            node.RightRotate();
                        else {
                            node.Left.LeftRotate();
                            node.RightRotate();
                        }
                    } else if ((node.Right?.Height ?? -1) >= 2 + (node.Left?.Height ?? -1)) {
                        if ((node.Right.Right?.Height ?? -1) >= (node.Right.Left?.Height ?? -1))
                            node.LeftRotate();
                        else {
                            node.Right.RightRotate();
                            node.LeftRotate();
                        }
                    }

                    node = node.Parent;

                    if (node != null)
                        lastRoot = node;
                }

                return lastRoot;
            }

            /// <summary>
            ///         x                       y
            ///     ---- ----               ---- ----
            ///     A       y      ==>      x       C
            ///         ---- ----       ---- ----
            ///         B       C       A       B
            /// </summary>
            private void LeftRotate() {
                var x = this;
                var y = x.Right;
                var bSubtree = y?.Left;

                y.Parent = x.Parent;
                x.Parent = y;
                y.Left = x;
                x.Right = bSubtree;

                if (y.Parent?.Right == x)
                    y.Parent.Right = y;
                else if (y.Parent?.Left == x)
                    y.Parent.Left = y;
                
                if (bSubtree != null)
                    bSubtree.Parent = x;

                x.UpdateHeight();
                y.UpdateHeight();
            }

            /// <summary>
            ///         x               y
            ///     ---- ----       ---- ----
            ///     y       C  ==>  A       x
            /// ---- ----               ---- ----
            /// A       B               B       C
            /// </summary>
            private void RightRotate() {
                var x = this;
                var y = x.Left;
                var bSubtree = y?.Right;

                y.Parent = x.Parent;
                x.Parent = y;
                y.Right = x;
                x.Left = bSubtree;

                if (y.Parent?.Right == x)
                    y.Parent.Right = y;
                else if (y.Parent?.Left == x)
                    y.Parent.Left = y;

                if (bSubtree != null)
                    bSubtree.Parent = x;

                x.UpdateHeight();
                y.UpdateHeight();
            }

            private void UpdateHeight() =>
                Height = Math.Max(Left?.Height ?? -1, Right?.Height ?? -1) + 1;
        }
    }
}
