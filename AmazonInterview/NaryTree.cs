using System.Collections.Generic;

namespace AmazonInterview {
    public class NaryNode<T> {
        public T Value { get; private set; }

        public NaryNode<T> Parent { get; private set; }

        public ICollection<NaryNode<T>> Children { get; private set; }

        public NaryNode(T value) =>
            Value = value;

        private NaryNode(T value, NaryNode<T> parent) : this(value) =>
            Parent = parent;

        public NaryNode<T> Add(T value) {
            if (Children is null)
                Children = new List<NaryNode<T>>();

            var node = new NaryNode<T>(value, this);

            Children.Add(node);

            return node;
        }

        public NaryNode<T>[] PathToRoot() {
            var path = new List<NaryNode<T>>();
            var current = this;

            while (current.Parent != null) {
                path.Add(current);

                current = current.Parent;
            }

            return path.ToArray();
        }

        public NaryNode<T> 
    }
}
