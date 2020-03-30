package co.il.algocourse.sorts.base;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

public abstract class AbsSortAlogirthm<T> implements  ISortAlgorithm<T>
{
    protected T[] input;
    protected T[] output;
    protected IComparer<T> comparer;
    protected Class<T> type;

    protected AbsSortAlogirthm(Class<T> type , IComparer<T> comparer)
    {
        this.comparer = comparer;
        this.type = type;
    }

    @Override
    public T[] sort(T[] input)
    {
        this.output =  (T[])Array.newInstance(type, input.length);
        try
        {
            this.input = input;

            executeSorting();

            return this.output;
        }
        catch(Exception ex)
        {
            System.out.println(ex.getMessage());
            System.out.println(ex.getStackTrace());
        }

        return this.output;
    }

    protected abstract void executeSorting();
}
