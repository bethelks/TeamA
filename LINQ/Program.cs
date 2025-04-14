using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGrades
{
    public class Student
    {
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

            // Prompt to find a student by their name
            Console.WriteLine("\nEnter the name of the student you want to find:");
            string studentNameToFind = Console.ReadLine();
            var foundStudent = FindStudentByName(students, studentNameToFind);
            if (foundStudent != null)
            {
                Console.WriteLine($"Found: {foundStudent.Name}, Grade: {foundStudent.Grade}");
            }
            else
            {
                Console.WriteLine($"Student {studentNameToFind} not found.");
            }

            // Prompt to remove a student by their name
            Console.WriteLine("\nEnter the name of the student you want to remove:");
            string studentNameToRemove = Console.ReadLine();
            if (RemoveStudentByName(students, studentNameToRemove))
            {
                Console.WriteLine($"Successfully removed {studentNameToRemove}.");
            }
            else
            {
                Console.WriteLine($"Student {studentNameToRemove} not found.");
            }

            // Display students after removal
            Console.WriteLine("\nAll Students after removal:");
            DisplayStudents(students);

            Console.ReadLine(); // Keep console open
        }

        static void DisplayStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, Grade: {student.Grade}");
            }
        }

        // Method to find a student by name
        static Student FindStudentByName(List<Student> students, string name)
        {
            return students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Method to remove a student by name
        static bool RemoveStudentByName(List<Student> students, string name)
        {
            var studentToRemove = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                return true; // Successfully removed
            }
            return false; // Student not found
        }
    }
}