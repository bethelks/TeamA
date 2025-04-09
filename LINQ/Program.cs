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
        }

        // Step 5: Top N Students
        public static IEnumerable<Student> GetTopNStudents(List<Student> students, int N)
        {
            return students
                .OrderByDescending(s => s.Grade)  // Sort students by grade in descending order
                .Take(N);                        // Take the top N students
        }



        using System.IO;
        using System.Text.Json;
        
        // Step 6: Save Data
        public static void SaveStudentsToFile(List<Student> students, string filePath)
    {
        // Serialize the list of students to JSON
        string jsonString = JsonSerializer.Serialize(students);

        // Write the JSON string to a file
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Student data saved to file.");
    }


    // Step 6: Load Data
    public static List<Student> LoadStudentsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            // Read the JSON string from the file
            string jsonString = File.ReadAllText(filePath);

            // Deserialize the JSON string back to a list of students
            return JsonSerializer.Deserialize<List<Student>>(jsonString);
        }
        else
        {
            Console.WriteLine("File not found.");
            return new List<Student>();  // Return an empty list if the file doesn't exist
        }
    }



    static void DisplayStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, Grade: {student.Grade}");
            }
        }
    }
}

