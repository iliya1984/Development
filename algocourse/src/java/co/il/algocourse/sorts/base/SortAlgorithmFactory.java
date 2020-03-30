package co.il.algocourse.sorts.base;

import co.il.algocourse.sorts.algorithms.HeapSortAlgorithm;
import co.il.algocourse.sorts.algorithms.InsertionSortAlogrithm;
import co.il.algocourse.sorts.algorithms.MergeSortAlgorithm;
import co.il.algocourse.sorts.entities.ESortAlgorithmType;

public class SortAlgorithmFactory
{
    public static <T> ISortAlgorithm<T> createInegerAlgorithm(Class type, ESortAlgorithmType algorithmType, IComparer<T> comparer)
    {
        switch (algorithmType)
        {
            case InsertionSort:
                return new InsertionSortAlogrithm<T>(type, comparer);
            case MergeSort:
                return new MergeSortAlgorithm<T>(type, comparer);
            case HeapSort:
                return new HeapSortAlgorithm<T>(type, comparer);
            default:
                return null;
        }
    }
}
