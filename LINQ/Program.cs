using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

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

            // Get Top N Student - Albert added by Lynnzey 4/11/25
            var v=GetTopNStudents(students, 2);
            Console.WriteLine("The top two students: " + v.ToList());

            // Calculate average grade
            double averageGrade = students.Average(s => s.Grade);
            Console.WriteLine($"\nAverage grade of all students: {averageGrade}");

            //List Students Below Average - Lynnzey Young 4/11/25
            ListStudentBelowAverage(students);
            Console.Read();

            // Step 1a: Add new student
            AddNewStudent(students, "Grace", 90);
            AddNewStudent(students, "Alice", 78);
            Console.WriteLine("\nStudents after adding new students:");
            DisplayStudents(students);
        }

        // Step 1b: Add new student and validation to check if student already exists
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

        /// <summary>
        /// Step 5: Top N Students
        /// This method takes a list of students and a number N,
        /// and returns the top N students based on their grade, in descending order.
        /// </summary>
        /// <param name="students">A list of Student objects</param>
        /// <param name="N">The number of top students to return</param>
        /// <returns>An IEnumerable of the top N students by grade</returns>
        public static IEnumerable<Student> GetTopNStudents(List<Student> students, int N)
        {
            if (students == null || students.Count == 0 || N <= 0)
            {
                return new List<Student>();
            }

            return students
                .OrderByDescending(s => s.Grade)  // Sort by grade descending
                .Take(N);                         // Take the top N
        }


        // Step 6: Save Data
        public static void SaveStudentsToFile(List<Student> students, string filePath)
    {
            // Serialize the list of students to JSON
            string jsonString = JsonConvert.SerializeObject(students, Formatting.Indented);

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
            return JsonConvert.DeserializeObject<List<Student>>(jsonString);
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
        public static void ListStudentBelowAverage(List<Student> students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }
            double average = students.Average(s => s.Grade);
            Console.WriteLine($"Class Average: {average:F2}");

            var belowAverageStudents = students.Where(s => s.Grade < average).ToList();
            if (belowAverageStudents.Count != 0)
            {
                Console.WriteLine("Students below average:");
                foreach (var student in belowAverageStudents)
                {
                    Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
                }
            }
            else
            {
                Console.WriteLine("All students are at or above average.");
                return;
            }
        }
    }
}
