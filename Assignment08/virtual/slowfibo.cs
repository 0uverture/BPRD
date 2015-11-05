using System;

/// <summary>
/// Fibonucci pasta
/// </summary>
public class Fibonacci
{
    public static int getFibo(int n)
    {
        int a = 0;
        int b = 1;
        // In N steps compute Fibonacci sequence iteratively.
        for (int i = 0; i < n; i++)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return a;
    }

    static void Main()
    {
        Console.WriteLine("Lel");
        Console.In.Read();

        for (int i = 0; i < 100000; i++)
        {
            getFibo(100000);    
        }
        
     
    }
}
