using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{

    public static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int least = i;
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[j] < arr[least])
                    least = j;
            int tmp = arr[i]; arr[i] = arr[least]; arr[least] = tmp;
        }
    }

    static void Main(string[] args)
    {

    }

}
