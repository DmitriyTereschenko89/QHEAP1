namespace QHEAP1
{
	internal class Program
	{
		private class MinHeap
		{
			private readonly List<int> heap;

			private void Swap(int i, int j)
			{
				(heap[i], heap[j]) = (heap[j], heap[i]);
			}

			private void SiftUp(int curIdx)
			{
				int parentIdx = (curIdx - 1) / 2;
				while (parentIdx >= 0 && heap[parentIdx] < heap[curIdx])
				{
					Swap(parentIdx, curIdx);
					curIdx = parentIdx;
					parentIdx = (curIdx - 1) / 2;
				}
			}

			private void SiftDown(int curIdx, int endIdx)
			{
				int childOneIdx = curIdx * 2 + 1;
				while (childOneIdx <= endIdx)
				{
					int swapIdx = childOneIdx;
					int childTwoIdx = curIdx * 2 + 2;
					if (childTwoIdx <= endIdx && heap[childTwoIdx] < heap[childOneIdx])
					{
						swapIdx = childTwoIdx;
					}
					if (heap[swapIdx] < heap[curIdx])
					{
						Swap(swapIdx, curIdx);
						curIdx = swapIdx;
						childOneIdx = curIdx * 2 + 1;
					}
					else
					{
						return;
					}
				}
			}

			public MinHeap()
			{
				heap = new List<int>();
			}

			public void Add(int val)
			{
				heap.Add(val);
				SiftUp(heap.Count - 1);
			}

			public int Remove()
			{
				Swap(0, heap.Count - 1);
				int removed = heap[^1];
				heap.RemoveAt(heap.Count - 1);
				SiftDown(0, heap.Count - 1);
				return removed;
			}

			public int GetMinimum()
			{
				return heap[0];
			}
		}
		static void Main(string[] args)
		{
			MinHeap minHeap = new MinHeap();
			int queries = Convert.ToInt32(Console.ReadLine().TrimEnd());
			for (int query = 1; query <= queries; ++query)
			{
				string[] data = Console.ReadLine().TrimEnd().Split(' ');
				switch (data[0])
				{
					case "1":
						minHeap.Add(Convert.ToInt32(data[1]));
						break;
					case "2":
						minHeap.Remove();
						break;
					default:
						Console.WriteLine(minHeap.GetMinimum());
						break;
				}
			}
		}
	}
}