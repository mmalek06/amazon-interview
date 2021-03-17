using System.Collections.Generic;

namespace AmazonInterview.Hackerrank {
    public class Node {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val) {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class CopyListWithRandomPointer {
        public Node Execute(Node head) {
            if (head is null)
                return head;

            var cache = new Dictionary<Node, Node>();

            Node newHead = null;
            Node currentNew = null;

            do {
                var newNode = new Node(head.val);

                newNode.random = head.random;

                if (currentNew != null)
                    currentNew.next = newNode;
                else
                    newHead = newNode;

                currentNew = newNode;
                cache[head] = currentNew;
                head = head.next;
            } while (head != null);

            var current = newHead;

            while (current != null) {
                if (current.random != null && cache.ContainsKey(current.random))
                    current.random = cache[current.random];

                current = current.next;
            }

            return newHead;
        }
    }
}
