using System;
using System.Diagnostics;

public class Program
{
    static Student[] GetStudents() => new Student[]
    {
        new Student("Бойко", "КН-3/2", 95),
        new Student("Бондар", "КН-3/1", 71),
        new Student("Іванів", "КН-3/1", 48),
        new Student("Іщенко", "КН-3/1", 93),
        new Student("Коваленко", "КН-3/1", 88),
        new Student("Кравець", "КН-3/1", 76),
        new Student("Кушнір", "КН-3/2", 73),
        new Student("Мельник", "КН-3/2", 64),
        new Student("Мороз", "КН-3/2", 82),
        new Student("Савченко", "КН-3/2", 55),
        new Student("Ткачук", "КН-3/2", 90),
        new Student("Шевчук", "КН-3/1", 67)
    };

    static void Task1()
    {
        Console.WriteLine("Task 1:");
        int[] arr = Utils.GenerateRandom(7);
        Sorts.BubbleSort(arr, (x, y) => x.CompareTo(y), out int c, out int m);
        Console.WriteLine($"[{string.Join(", ", arr)}] | C: {c}, M: {m}\n");
    }

    static void Task2()
    {
        Console.WriteLine("Task 2:");
        int[] arr = Utils.GenerateRandom(14);
        Sorts.QuickSort(arr, (x, y) => x.CompareTo(y), out int c, out int m);
        Console.WriteLine($"[{string.Join(", ", arr)}] | C: {c}, M: {m}\n");
    }

    static void Task3()
    {
        Console.WriteLine("Task 3:");
        Student[] students = GetStudents();
        Sorts.BubbleSort(students, (x, y) => {
            int g = x.Group.CompareTo(y.Group);
            return g != 0 ? g : x.Score.CompareTo(y.Score);
        }, out _, out _);
        
        for (int i = 0; i < 3; i++) 
            Console.WriteLine($"{students[i].Group}, {students[i].Score}, {students[i].Name}");
        Console.WriteLine();
    }

    static void Task4()
    {
        Console.WriteLine("Task 4:");
        int[] sizes = { 100, 1000, 10000 };
        Func<int, int[]>[] gens = { Utils.GenerateRandom, Utils.GenerateSorted, Utils.GenerateReversed, Utils.GenerateAlmostSorted };
        string[] names = { "Rand", "Sort", "Rev", "Alm" };

        foreach (var s in sizes)
        {
            for (int i = 0; i < gens.Length; i++)
            {
                int[] a1 = gens[i](s), a2 = (int[])a1.Clone();
                Sorts.BubbleSort(a1, (x, y) => x.CompareTo(y), out int bc, out int bm);
                Sorts.QuickSort(a2, (x, y) => x.CompareTo(y), out int qc, out int qm);
                Console.WriteLine($"N={s} [{names[i]}]: Bubble {bc}/{bm}, Quick {qc}/{qm}");
            }
        }
        Console.WriteLine();
    }

    static void Task5()
    {
        Console.WriteLine("Task 5:");
        int[] sizes = { 1000, 10000, 100000, 1000000 };
        Stopwatch sw = new Stopwatch();

        foreach (var s in sizes)
        {
            int[] baseArr = Utils.GenerateRandom(s);
            long bTime = -1;

            if (s <= 100000)
            {
                int[] a1 = (int[])baseArr.Clone();
                sw.Restart(); Sorts.BubbleSort(a1, (x, y) => x.CompareTo(y), out _, out _); sw.Stop();
                bTime = sw.ElapsedMilliseconds;
            }

            int[] a2 = (int[])baseArr.Clone();
            sw.Restart(); Sorts.QuickSort(a2, (x, y) => x.CompareTo(y), out _, out _); sw.Stop();
            long qTime = sw.ElapsedMilliseconds;

            int[] a3 = (int[])baseArr.Clone();
            sw.Restart(); Array.Sort(a3); sw.Stop();
            long aTime = sw.ElapsedMilliseconds;

            Console.WriteLine($"N={s,-7} | Bubble: {(bTime == -1 ? "-" : bTime.ToString())} ms | Quick: {qTime} ms | Array.Sort: {aTime} ms");
        }
        Console.WriteLine();
    }

    static void CheckEdgeCases()
    {
        Console.WriteLine("Edge Cases:");
        int[][] cases = { new int[0], new int[] { 5 }, new int[] { 2, 1 }, new int[] { 7, 7, 7 } };
        foreach (var arr in cases)
        {
            int[] test = (int[])arr.Clone();
            Sorts.QuickSort(test, (x, y) => x.CompareTo(y), out _, out _);
            Console.WriteLine($"[{string.Join(",", arr)}] -> [{string.Join(",", test)}]");
        }
    }

    public static void Main()
    {
        Sorts.BubbleSort(new int[100], (x, y) => x.CompareTo(y), out _, out _);
        
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        CheckEdgeCases();
    }
}
