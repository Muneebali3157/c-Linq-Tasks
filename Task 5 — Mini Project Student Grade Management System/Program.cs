// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public int[] Marks { get; set; } = new int[5]; // Marks for 5 subjects

        // Helper properties for calculation
        public int TotalMarks => Marks.Sum();
        public double Percentage => Marks.Average();

        public char grade
        {
            get
            {
                double avg = Percentage;
                if (avg >= 80) return 'A';
                if (avg >= 70) return 'B';
                if (avg >= 60) return 'C';
                if (avg >= 50) return 'D';
                return 'F';
            }
        }

    }

    class program()
    {
        static List<Student> students = new List<Student>();
        public static void Main(string[] args)
        {

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("        STUDENT MANAGEMENT SYSTEM            ");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Topper of the Class ");
                Console.WriteLine("4. Class Average per Subject ");
                Console.WriteLine("5. Grade Distribution ");
                Console.WriteLine("6. Students Below Passing Marks ");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewAllStudents();
                        break;
                    case "3":
                        GetClassTopper();
                        break;
                    case "4":
                        GetClassAveragePerSubject();
                        break;
                    case "5":
                        GetGradeDistribution();
                        break;
                    case "6":
                        GetFailedStudents();
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("Program ended. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select a valid option.");
                        break;
                }
            }

            }
        static void AddStudent()
        {
            Student std = new Student();
            Console.WriteLine("Enter Student Name : ");
            std.Name = Console.ReadLine();
            Console.WriteLine("Enter Roll No : ");
            std.RollNo=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Marks for 5 Subjects (0-100):");
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Subject : {i+1}");
                std.Marks[i]=Convert.ToInt32( Console.ReadLine());
            }
            students.Add(std);
            Console.WriteLine("\nStudent added successfully!");


        }
        static void ViewAllStudents()
        {
            Console.WriteLine("\n List of All Students ");
            foreach(var s in students)
            {
                Console.WriteLine("\n Name : "+s.Name+" Roll No : "+s.RollNo+" Total Marks : "+s.TotalMarks+" Percentage : "+s.Percentage+" Grade : "+s.grade);
            }
        }
        static void GetClassTopper()
        {
            var topper = students.OrderByDescending(s => s.TotalMarks).FirstOrDefault();
            Console.WriteLine("\n---------Class Toper ---------");
            Console.WriteLine("\n Name : " + topper.Name + " Roll No : " + topper.RollNo + " Total Marks : " + topper.TotalMarks + " Percentage : " + topper.Percentage + " Grade : " + topper.grade);

        }
        static void GetClassAveragePerSubject()
        {
            for(int i = 0; i < 5; i++)
            {
                int subjectIndex = i; // Closure safety
                double avg = students.Average(s => s.Marks[subjectIndex]);
                Console.WriteLine($"Subject {i + 1} Average Marks: {avg}");
            }
        }
        static void GetGradeDistribution()
        {
            var gradegroupby=
                students.GroupBy(g=>g.grade).
                Select(g=>new { Grade=g.Key, Count=g.Count()}).OrderBy(g=>g.Grade);

            foreach(var g in gradegroupby)
            {
                Console.WriteLine("\n Grade : "+g.Grade+" Count : "+g.Count);
            }
        }
        static void GetFailedStudents()
        {
            var std=students.Where(s=>s.Marks.Any(m=>m<40)).ToList();
            foreach (var s in std)
            {
                Console.WriteLine("\n Name : " + s.Name + " Roll No : " + s.RollNo + " Total Marks : " + s.TotalMarks + " Percentage : " + s.Percentage + " Grade : " + s.grade);
            }

        }
    }
}


