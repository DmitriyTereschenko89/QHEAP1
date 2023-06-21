namespace QHEAP1
{
	internal class Program
	{
		private class MinHeap
		{
			private readonly List<int> heap;
			private readonly Dictionary<int, int> mapIndex;

			private void Swap(int i, int j)
			{
				mapIndex[heap[i]] = j;
				mapIndex[heap[j]] = i;
				(heap[i], heap[j]) = (heap[j], heap[i]);
			}

			private void SiftUp(int curIdx)
			{
				int parentIdx = (curIdx - 1) / 2;
				while (parentIdx >= 0 && heap[parentIdx] > heap[curIdx])
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
				mapIndex = new Dictionary<int, int>();
			}

			public void Add(int val)
			{
				if(!mapIndex.ContainsKey(val))
				{
					heap.Add(val);
					mapIndex.Add(val, heap.Count - 1);
					SiftUp(heap.Count - 1);
				}
			}

			public void Remove(int val)
			{
				if (mapIndex.ContainsKey(val))
				{
					int removeIdx = mapIndex[val];
					Swap(removeIdx, heap.Count - 1);
					heap.RemoveAt(heap.Count - 1);
					mapIndex.Remove(val);
					SiftDown(removeIdx, heap.Count - 1);
				}
			}

			public int GetMinimum()
			{
				return heap[0];
			}
		}

		static void Main(string[] args)
		{
			List<int> minimumHeap = new();
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
						minHeap.Remove(Convert.ToInt32(data[1]));
						break;
					default:
						minimumHeap.Add(minHeap.GetMinimum());
						break;
				}
			}
			Console.Clear();
			Console.WriteLine(string.Join('\n', minimumHeap));
		}
	}
}