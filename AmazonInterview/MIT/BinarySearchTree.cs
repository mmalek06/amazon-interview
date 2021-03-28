namespace AmazonInterview.MIT {
    public class BinarySearchTree {
        private Node _root;

        public void Insert(int value) {
            var node = new Node(value);

            if (_root is null)
                _root = node;
            else
                _root.Insert(value);
        }

        public int FindMin() =>
            _root.FindMin();

        public int FindMax() =>
            _root.FindMax();

        private class Node {
            public int Value { get; private set; }

            public int Rank { get; private set; }

            public Node Left { get; private set; }

            public Node Right { get; private set; }

            public Node(int value) {
                Value = value;
                Rank = 1;
            }

            public void Insert(int value) {
                if (value <= Value) {
                    if (Left is null)
                        Left = new Node(value);
                    else
                        Left.Insert(value);
                } else {
                    if (Right is null)
                        Right = new Node(value);
                    else
                        Right.Insert(value);
                }
            }

            public int FindMin() {
                if (Left is null)
                    return Value;

                return Left.FindMin();
            }

            public int FindMax() {
                if (Right is null)
                    return Value;

                return Right.FindMax();
            }
        }
    }
}
