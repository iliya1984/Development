package co.il.algocourse.sorts.algorithms;

import co.il.algocourse.sorts.base.AbsSortAlogirthm;
import co.il.algocourse.sorts.base.IComparer;

public class InsertionSortAlogrithm<T> extends AbsSortAlogirthm<T>
{
    public InsertionSortAlogrithm(Class<T> type, IComparer<T> comparer) {
        super(type, comparer);
    }

    @Override
    protected void executeSorting()
    {
        for(int i = 0; i < input.length; i++)
        {
            output[i] = input[i];
        }

        for(int j = 1; j < output.length; j++)
        {
            T key = output[j];
            int k = j;
            while (k > 0 && comparer.isGreater(output[k - 1], key))
            {
                output[k] = output[k - 1];
                k--;
            }
            output[k] = key;
        }
    }
}
