namespace AmazonInterview.MIT {
    public class Heap {
        private int[] _heap;

        public Heap(int[] arr) =>
            _heap = arr;

        public void BuildMaxHeap() {
            for (var i = _heap.Length / 2; i >= 0; i--)
                MaxHeapify(i);
        }

        private void MaxHeapify(int i) {
            var left = 2 * i;
            var right = 2 * i + 1;
            var largest = -1;

            if (left < _heap.Length && _heap[left] > _heap[i])
                largest = left;
            else
                largest = i;

            if (right < _heap.Length && _heap[right] > _heap[largest])
                largest = right;

            if (largest != i) {
                Swap(i, largest);
                MaxHeapify(largest);
            }
        }

        private void Swap(int i, int j) {
            var tmp = _heap[i];

            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }
    }
}
