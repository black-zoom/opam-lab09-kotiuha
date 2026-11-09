using System;

public class Student
{
    public string Name { get; }
    public string Group { get; }
    public int Score { get; }

    public Student(string name, string group, int score)
    {
        Name = name;
        Group = group;
        Score = score;
    }
}
