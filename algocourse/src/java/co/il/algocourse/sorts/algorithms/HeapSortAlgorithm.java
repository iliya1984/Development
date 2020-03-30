package co.il.algocourse.sorts.algorithms;

import co.il.algocourse.datastructures.EHeapType;
import co.il.algocourse.datastructures.Heap;
import co.il.algocourse.sorts.base.AbsSortAlogirthm;
import co.il.algocourse.sorts.base.IComparer;

public class HeapSortAlgorithm<T> extends AbsSortAlogirthm<T>
{
    private Heap<T> heap;

    public HeapSortAlgorithm(Class<T> type, IComparer<T> comparer) {
        super(type, comparer);

        heap = new Heap<T>(EHeapType.MaxHeap, type, comparer);
    }

    @Override
    protected void executeSorting()
    {
        heap.buildHeap(input);

        for(int i = input.length - 1; i > 0; i--)
        {
            heap.swap(0, i);
            heap.setHeapSize(heap.getHeapSize() - 1);
            heap.heapify();
        }

        output = heap.getArray();
    }
}
