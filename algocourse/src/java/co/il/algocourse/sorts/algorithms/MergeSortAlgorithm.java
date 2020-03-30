package co.il.algocourse.sorts.algorithms;

import co.il.algocourse.sorts.base.AbsSortAlogirthm;
import co.il.algocourse.sorts.base.IComparer;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.stream.Collectors;

public class MergeSortAlgorithm<T> extends AbsSortAlogirthm<T> {

    public MergeSortAlgorithm(Class<T> type, IComparer<T> comparer) {
        super(type, comparer);
    }

    @Override
    protected void executeSorting()
    {
        output = executeMergeSort(input, 0, input.length - 1);
    }

    private T[] executeMergeSort(T[] array, int startIndex, int endIndex)
    {
        try
        {

            if(endIndex > startIndex)
            {
                int length = endIndex - startIndex;

                int partitionIndex = startIndex + length / 2;

                T[] partition1 = executeMergeSort(array, startIndex, partitionIndex);

                T[] partition2 = executeMergeSort(array,  partitionIndex + 1, endIndex);

                return mergePartitions(partition1, partition2);
            }

            T[] result = (T[])Array.newInstance(type, 1);
            result[0] = array[startIndex];
            return result;
        }
        catch(Exception e)
        {
            System.out.println(e.getMessage());
            System.out.println(e.getStackTrace());
            throw e;
        }


    }

    private  T[] mergePartitions(T[] partiation1, T[] partiation2)
    {
        if(partiation1.length == 0)
        {
            return partiation2;
        }
        if(partiation2.length == 0)
        {
            return partiation1;
        }

        T[] result = (T[])Array.newInstance(type, partiation1.length + partiation2.length);

        int i = 0;
        int j = 0;
        int k = 0;

        while(i < partiation1.length && j < partiation2.length)
        {
            if(comparer.isGreater(partiation2[j], partiation1[i]))
            {
                result[k] = partiation1[i];
                i++;
            }
            else
            {
                result[k] = partiation2[j];
                j++;
            }
            k++;
        }

        if(i < partiation1.length && j == partiation2.length)
        {
            for(; i < partiation1.length; i++)
            {
                result[k] = partiation1[i];
                k++;
            }
        }
        else if(j < partiation2.length && i == partiation1.length)
        {
            for(; j < partiation2.length; j++)
            {
                result[k] = partiation2[j];
                k++;
            }
        }

        return result;
    }
}
