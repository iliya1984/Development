import co.il.algocourse.sorts.base.ISortAlgorithm;
import co.il.algocourse.sorts.base.IntergerComparer;
import co.il.algocourse.sorts.base.SortAlgorithmFactory;
import co.il.algocourse.sorts.entities.ESortAlgorithmType;

import java.awt.*;
import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collectors;

import static java.lang.Thread.sleep;

public class AlgoCourseApplication
{
    public static void main(String[] args)
    {
        Scanner scanner  = new Scanner(System.in);
        String inputLine = scanner.nextLine();

        String[] inputStrings = inputLine.split(",");
        Integer[] input =new Integer[inputStrings.length];

        for(int i =0; i< inputStrings.length; i++)
        {
            input[i] = tryParseInt(inputStrings[i], 0);
        }

        IntergerComparer comparer = new IntergerComparer();

        ESortAlgorithmType[] algorithms = new ESortAlgorithmType[]
                {
                        ESortAlgorithmType.InsertionSort,
                        ESortAlgorithmType.MergeSort,
                        ESortAlgorithmType.HeapSort
                };

        for(ESortAlgorithmType algorithm : algorithms)
        {
            ISortAlgorithm<Integer> sortAlgorithm = SortAlgorithmFactory.createInegerAlgorithm(Integer.class, algorithm, comparer);

            Integer[] output = sortAlgorithm.sort(input);

            if(output != null)
            {
                String outputLine = Arrays
                        .stream(output)
                        .mapToInt(i -> i)
                        .mapToObj(String::valueOf)
                        .collect(Collectors.joining(","));

                System.out.println("Sorting Algorithm: ," + algorithm.name() + " Sorted sequence is : " + outputLine);
            }
            else
            {
                System.out.println("Error: output array is NULL");
            }
        }

        String exitLine = "";
        System.out.println("Press 'c' for exit");

        while (false == exitLine.equals("c") && false == exitLine.equals("e"))
        {
            try
            {
                Thread.sleep(1000);
                exitLine = scanner.nextLine();
            }
            catch(Exception e)
            {
                System.out.println(e.getMessage());
                exitLine = "e";
            }
            exitLine = exitLine.replace(" ", "");
            exitLine = exitLine.toLowerCase();
        }

    }

    private  static int tryParseInt(String value, int defaultValue)
    {
        try
        {
            Integer result = defaultValue;
            result = Integer.parseInt(value);
            return result;
        }
        catch(Exception e)
        {
            System.out.println(e.getMessage());
            return defaultValue;
        }
    }

}
