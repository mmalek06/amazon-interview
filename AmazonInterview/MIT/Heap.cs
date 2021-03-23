namespace AmazonInterview.MIT {
    /// <summary>
    /// var h = new Heap(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 });
    ///            
    /// h.BuildMaxHeap();
    /// h.HeapSort();
    /// </summary>
    public class Heap {
        private int[] _heap;
        private int _heapSize;

        public Heap(int[] arr) {
            _heap = arr;
            _heapSize = arr.Length;
        }

        public void BuildMaxHeap() {
            for (var i = _heapSize / 2; i >= 0; i--)
                MaxHeapify(i);
        }

        public int[] HeapSort() {
            var arr = new int[_heap.Length];
            var idx = _heap.Length - 1;

            while (_heapSize > 0) {
                arr[idx] = ExtractMax();
                idx--;
            }

            return arr;
        }

        public int ExtractMax() {
            var max = _heap[0];

            _heap[0] = _heap[_heapSize - 1];
            _heapSize--;

            MaxHeapify(0);

            return max;
        }

        private void MaxHeapify(int i) {
            var left = 2 * i;
            var right = 2 * i + 1;
            int largest;

            if (left < _heapSize && _heap[left] > _heap[i])
                largest = left;
            else
                largest = i;

            if (right < _heapSize && _heap[right] > _heap[largest])
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
