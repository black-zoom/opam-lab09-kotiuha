using System;

public static class Sorts
{
    public static void BubbleSort<T>(T[] a, Func<T, T, int> cmp, out int comparisons, out int moves)
    {
        comparisons = 0;
        moves = 0;
        int n = a.Length;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                comparisons++;
                if (cmp(a[j], a[j + 1]) > 0)
                {
                    T temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                    moves += 2;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    public static void QuickSort<T>(T[] a, Func<T, T, int> cmp, out int comparisons, out int moves)
    {
        comparisons = 0;
        moves = 0;
        if (a.Length > 0)
        {
            QuickSortRec(a, 0, a.Length - 1, cmp, ref comparisons, ref moves);
        }
    }

    private static void QuickSortRec<T>(T[] a, int left, int right, Func<T, T, int> cmp, ref int comparisons, ref int moves)
    {
        int i = left;
        int j = right;
        T pivot = a[left + (right - left) / 2];

        while (i <= j)
        {
            while (true)
            {
                comparisons++;
                if (cmp(a[i], pivot) < 0) i++; else break;
            }
            while (true)
            {
                comparisons++;
                if (cmp(a[j], pivot) > 0) j--; else break;
            }

            if (i <= j)
            {
                if (i != j)
                {
                    T temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    moves += 2;
                }
                i++;
                j--;
            }
        }

        if (left < j) QuickSortRec(a, left, j, cmp, ref comparisons, ref moves);
        if (i < right) QuickSortRec(a, i, right, cmp, ref comparisons, ref moves);
    }
}
