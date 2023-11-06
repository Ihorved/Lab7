using System;

class Calculator<T>
{
    public T Add(T a, T b)
    {
        dynamic first = a;
        dynamic second = b;
        return first + second;
    }

    public T Subtract(T a, T b)
    {
        dynamic first = a;
        dynamic second = b;
        return first - second;
    }

    public T Multiply(T a, T b)
    {
        dynamic first = a;
        dynamic second = b;
        return first * second;
    }

    public T Divide(T a, T b)
    {
        if (b.Equals((dynamic)0))
        {
            throw new DivideByZeroException("");
        }

        dynamic first = a;
        dynamic second = b;
        return first / second;
    }
}


class Program
{
    static void Main()
    {
        Calculator<int> intCalculator = new Calculator<int>();
        Console.WriteLine("Integer Calculator:");
        Console.WriteLine("Addition: " + intCalculator.Add(5, 3));
        Console.WriteLine("Subtraction: " + intCalculator.Subtract(5, 3));
        Console.WriteLine("Multiplication: " + intCalculator.Multiply(5, 3));
        Console.WriteLine("Division: " + intCalculator.Divide(5, 3));

        Calculator<double> doubleCalculator = new Calculator<double>();
        Console.WriteLine("\nDouble Calculator:");
        Console.WriteLine("Addition: " + doubleCalculator.Add(5.5, 3.2));
        Console.WriteLine("Subtraction: " + doubleCalculator.Subtract(5.5, 3.2));
        Console.WriteLine("Multiplication: " + doubleCalculator.Multiply(5.5, 3.2));
        Console.WriteLine("Division: " + doubleCalculator.Divide(5.5, 3.2));
    }
}
