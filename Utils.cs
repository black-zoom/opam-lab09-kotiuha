using System;
using System.Collections.Generic;

public static class Utils
{
    public static int[] GenerateRandom(int size)
    {
        Random rnd = new Random(14);
        int[] arr = new int[size];
        for (int i = 0; i < size; i++) arr[i] = rnd.Next(0, 21);
        return arr;
    }

    public static int[] GenerateSorted(int size)
    {
        int[] arr = GenerateRandom(size);
        Array.Sort(arr);
        return arr;
    }

    public static int[] GenerateReversed(int size)
    {
        int[] arr = GenerateSorted(size);
        Array.Reverse(arr);
        return arr;
    }

    public static int[] GenerateAlmostSorted(int size)
    {
        int[] arr = GenerateSorted(size);
        Random rnd = new Random(14);
        if (size >= 2)
        {
            int idx1 = rnd.Next(0, size);
            int idx2 = rnd.Next(0, size);
            int temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }
        return arr;
    }

    public static bool IsSorted<T>(T[] a, Func<T, T, int> cmp)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            if (cmp(a[i], a[i + 1]) > 0) return false;
        }
        return true;
    }

    public static bool IsPermutationOf<T>(T[] a, T[] b) where T : notnull
    {
        if (a.Length != b.Length) return false;
        Dictionary<T, int> counts = new Dictionary<T, int>();
        foreach (var item in a)
        {
            if (counts.ContainsKey(item)) counts[item]++;
            else counts[item] = 1;
        }
        foreach (var item in b)
        {
            if (!counts.ContainsKey(item) || counts[item] == 0) return false;
            counts[item]--;
        }
        return true;
    }
}
