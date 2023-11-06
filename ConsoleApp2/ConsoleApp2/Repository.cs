using System;
using System.Collections.Generic;

class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> Find(Func<T, bool> criteria)
    {
        List<T> results = new List<T>();

        foreach (var item in items)
        {
            if (criteria(item))
            {
                results.Add(item);
            }
        }

        return results;
    }
}

class Program
{
    static void Main()
    {
        Repository<int> intRepository = new Repository<int>();
        intRepository.Add(1);
        intRepository.Add(2);
        intRepository.Add(3);
        intRepository.Add(4);

    
        List<int> result = intRepository.Find(x => x > 2);

        Console.WriteLine("Елементи більше 2:");
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        Repository<string> stringRepository = new Repository<string>();
        stringRepository.Add("apple");
        stringRepository.Add("banana");
        stringRepository.Add("cherry");
        stringRepository.Add("date");

        List<string> stringResult = stringRepository.Find(x => x.Length > 5);

        Console.WriteLine("\nРядки з більшою довжиною за 5 символів:");
        foreach (var item in stringResult)
        {
            Console.WriteLine(item);
        }
    }
}
