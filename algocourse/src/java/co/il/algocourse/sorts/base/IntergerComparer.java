package co.il.algocourse.sorts.base;

public class IntergerComparer implements  IComparer<Integer> {

    @Override
    public Boolean isGreater(Integer first, Integer second) {
        return first > second;
    }
}
