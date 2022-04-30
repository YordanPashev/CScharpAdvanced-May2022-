using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.AverageStudentGrades
{
        class Program
        {
            class Student
            {
                public Student(string name, decimal grade)
                {
                    this.Name = name;
                    this.Grade = new List<decimal>();
                }
                public string Name { get; set; }

                public List<decimal> Grade { get; set; }
            }
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
                int studentsCount = int.Parse(Console.ReadLine());

                for (int stud = 0; stud < studentsCount; stud++)
                {
                    string[] currStudentsInfo = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    string studentName = currStudentsInfo[0];
                    decimal grade = decimal.Parse(currStudentsInfo[1]);

                    if (!students.Any(s => s.Name == studentName))
                    {
                        Student newStudent = new Student(studentName, grade);
                        students.Add(newStudent);
                    }

                    var currStudent = students.Find(s => s.Name == studentName);
                    currStudent.Grade.Add(grade);
                }

                foreach (Student stud in students)
                {
                    decimal averageGrade = CalculateAverageGrade(stud);
                    Console.Write($"{stud.Name} -> ");
                    foreach (double digit in stud.Grade)
                    {
                        Console.Write($"{digit:F2} ");
                    }
                    Console.Write($"(avg: {averageGrade:F2})");
                    Console.WriteLine();
                }
            }

            static decimal CalculateAverageGrade(Student stud)
            {
                decimal averageGrade = 0;
                foreach (decimal grade in stud.Grade)
                {
                    averageGrade += grade;
                }

                return averageGrade / stud.Grade.Count;
            }
        }
    }

