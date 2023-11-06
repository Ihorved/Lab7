using System;
using System.Collections.Generic;

class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

    public TResult GetOrCreate(TKey key, Func<TKey, TResult> function, TimeSpan expiration)
    {
        if (cache.TryGetValue(key, out var cacheItem) && !cacheItem.IsExpired(expiration))
        {
            Console.WriteLine($"'{key}'");
            return cacheItem.Value;
        }
        else
        {
            Console.WriteLine($"'{key}'");
            var value = function(key);
            cache[key] = new CacheItem(value, expiration);
            return value;
        }
    }

    private class CacheItem
    {
        public TResult Value { get; }
        public DateTime Expiration { get; }

        public CacheItem(TResult value, TimeSpan expiration)
        {
            Value = value;
            Expiration = DateTime.Now + expiration;
        }

        public bool IsExpired(TimeSpan expiration)
        {
            return DateTime.Now > Expiration;
        }
    }
}

class Program
{
    static void Main()
    {
        FunctionCache<string, int> cache = new FunctionCache<string, int>();

        Func<string, int> function = (str) =>
        {
            Console.WriteLine($"'{str}'");
            return str.Length;
        };

        int result1 = cache.GetOrCreate("Hello", function, TimeSpan.FromSeconds(5));
        int result2 = cache.GetOrCreate("World", function, TimeSpan.FromSeconds(5));
        int result3 = cache.GetOrCreate("Hello", function, TimeSpan.FromSeconds(5)); // Виклик з кешу

        Console.WriteLine($"Результат 1: {result1}");
        Console.WriteLine($"Результат 2: {result2}");
        Console.WriteLine($"Результат 3: {result3}");
    }
}
