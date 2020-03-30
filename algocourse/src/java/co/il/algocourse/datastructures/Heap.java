package co.il.algocourse.datastructures;

import co.il.algocourse.sorts.base.IComparer;

import java.lang.reflect.Array;

public class Heap<T>
{
    private final IComparer<T> comaprer;
    private Class<T> type;
    private T[] array;

    private int heapSize;
    private EHeapType heapType;

    public Heap(EHeapType heapType, Class<T> type, IComparer<T> comparer)
    {
        this.type = type;
        this.heapType = heapType;
        this.comaprer = comparer;
    }

    public T[] getArray() {
        return array;
    }

    public EHeapType getHeapType() {
        return heapType;
    }

    public int getHeapSize() {
        return heapSize;
    }

    public void setHeapSize(int heapSize) {
        this.heapSize = heapSize;
    }

    public void buildHeap(T[] input)
    {
        this.heapSize = input.length;
        this.array = (T[])Array.newInstance(type, input.length);
        if(input.length <= array.length)
        {
            for(int k = 0; k < input.length; k++)
            {
                array[k] = input[k];
            }
        }

        switch (heapType)
        {
            case MaxHeap:
                for(int j = array.length/2; j >= 0; j--)
                {
                    maxHeapify(j);
                }
                break;
            case MinHeap:
                for(int j = array.length/2; j >= 0; j--)
                {
                    minHeapify(j);
                }
                break;
        }
    }

    public void heapify()
    {
        switch (heapType)
        {
            case MaxHeap:
                for(int j = array.length/2; j >= 0; j--)
                {
                    maxHeapify(j);
                }
                break;
            case MinHeap:
                for(int j = array.length/2; j >= 0; j--)
                {
                    minHeapify(j);
                }
                break;
        }
    }

    public void swap(int i, int j)
    {
        T temp = array[j];
        array[j] = array[i];
        array[i] = temp;
    }

    private void maxHeapify(int i)
    {
        int l = left(i);
        int r = right(i);
        int largest;

        if(l < heapSize && comaprer.isGreater(array[l], array[i]))
        {
            largest = l;
        }
        else
        {
            largest = i;
        }

        if(r <  heapSize && comaprer.isGreater(array[r], array[largest]))
        {
            largest = r;
        }

        if(largest != i)
        {
            swap(largest, i);
            maxHeapify(largest);
        }
    }

    private void minHeapify(int i)
    {
        int l = left(i);
        int r = right(i);
        int smallest;

        if(l < heapSize && comaprer.isGreater(array[i], array[l]))
        {
            smallest = l;
        }
        else
        {
            smallest = i;
        }

        if(r <  heapSize && comaprer.isGreater(array[smallest], array[r]))
        {
            smallest = r;
        }

        if(smallest != i)
        {
            swap(smallest, i);
            minHeapify(smallest);
        }
    }

    private int left(int i)
    {
        return 2*i + 1;
    }

    private  int right(int i)
    {
        return 2*i + 2;

    }
}
