using System;
using System.Collections.Generic;
using System.Linq;
namespace StudentGrades
{
    public class Student
    { //Lynnzey
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Alice", 85),
                new Student("Bob", 76),
                new Student("Charlie", 92),
                new Student("Diana", 88),
                new Student("Evan", 65),
                new Student("Fay", 95)
            };
            Console.WriteLine("All Students:");
            DisplayStudents(students);

            // Use LINQ to filter students with grades greater than 80
            var highAchievers = students.Where(s => s.Grade > 80);
            Console.WriteLine("\nStudents with grades greater than 80:");
            DisplayStudents(highAchievers);

            // Use LINQ to sort students by grade
            var sortedStudents = students.OrderByDescending(s => s.Grade);
            Console.WriteLine("\nStudents sorted by grades (highest to lowest):");
            DisplayStudents(sortedStudents);

            // Calculate average grade
            double averageGrade = students.Average(s => s.Grade);
            Console.WriteLine($"\nAverage grade of all students: {averageGrade}");
            Console.Read();

            // Step1: Add a new student
            AddNewStudent(students, "Grace", 90);
            AddNewStudent(students, "Alice", 78);
            Console.WriteLine("\nStudents after adding new students:");
            DisplayStudents(students);
        }

        static void DisplayStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, Grade: {student.Grade}");
            }
        }

        // Step1: Add new student and validation to check if the student already exists
        static void AddNewStudent(List<Student> studentList, string name, int grade)
        {
            if (studentList.Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Student with name '{name}' already exists");
            }
            else
            {
                studentList.Add(new Student(name, grade));
                Console.WriteLine($"Student '{name}' added succesfully.");
            }
        }

    }
}

