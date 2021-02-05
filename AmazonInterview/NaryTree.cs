using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview {
    public class NaryNode<T> {
        public T Value { get; private set; }

        public NaryNode<T> Parent { get; private set; }

        public List<NaryNode<T>> Leafs { get; private set; }

        public NaryNode(T value) =>
            Value = value;

        private NaryNode(T value, NaryNode<T> parent) : this(value) =>
            Parent = parent;

        public NaryNode<T> Add(T value) {
            if (Leafs is null)
                Leafs = new List<NaryNode<T>>();

            var node = new NaryNode<T>(value, this);

            Leafs.Add(node);

            return node;
        }

        public IReadOnlyList<NaryNode<T>> ToRoot() {
            var path = new Stack<NaryNode<T>>();
            var current = this;

            path.Push(this);

            while (current.Parent != null) {
                current = current.Parent;

                if (current != null)
                    path.Push(current);
            }

            return path.ToList();
        }

        public List<T> ToRootValuesOnly() {
            var path = new List<T>();
            var current = this;

            path.Add(Value);

            while (current.Parent != null) {
                current = current.Parent;

                if (current != null)
                    path.Add(Value);
            }

            return path;
        }

        public IReadOnlyList<IReadOnlyList<NaryNode<T>>> InOrder() {
            var result = new List<List<NaryNode<T>>>();

            GetNodesInOrder(new List<NaryNode<T>>(), result);

            return result;
        }

        public IReadOnlyList<IReadOnlyList<T>> InOrderValuesOnly() {
            var result = new List<List<T>>();

            GetNodesInOrderValuesOnly(new List<T>(), result);

            return result;
        }

        /// <summary>
        /// This overload is more performant, because it does less alocations for new Lists instead relying on
        /// modifying existing ones.
        /// </summary>
        private void GetNodesInOrder(List<NaryNode<T>> parentPath, List<List<NaryNode<T>>> result) {
            if (!HasLeafs()) {
                result.Add(parentPath.ToList());
                result.Last().Add(this);
            } else {
                foreach (var leaf in Leafs) {
                    var index = parentPath.Count;

                    parentPath.Add(this);
                    leaf.GetNodesInOrder(parentPath, result);
                    parentPath.RemoveRange(index, parentPath.Count - index);
                }
            }
        }

        private void GetNodesInOrderValuesOnly(List<T> parentPath, List<List<T>> result) {
            if (!HasLeafs()) {
                result.Add(parentPath.ToList());
                result.Last().Add(Value);
            } else {
                foreach (var leaf in Leafs) {
                    var index = parentPath.Count;

                    parentPath.Add(Value);
                    leaf.GetNodesInOrderValuesOnly(parentPath, result);
                    parentPath.RemoveRange(index, parentPath.Count - index);
                }
            }
        }

        /// <summary>
        /// This overload on the other hand is simpler.
        /// </summary>
        private List<List<NaryNode<T>>> GetNodesInOrder() {
            if (!HasLeafs())
                return new List<List<NaryNode<T>>> { new List<NaryNode<T>> { this } };

            var paths = new List<List<NaryNode<T>>>();

            foreach (var leaf in Leafs) {
                foreach (var path in leaf.GetNodesInOrder()) {
                    var newPath = new List<NaryNode<T>> { this };

                    newPath.AddRange(path);
                    paths.Add(newPath);
                }
            }

            return paths;
        }

        private bool HasLeafs() =>
            Leafs?.Any() == true;
    }
}
