// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Person {
    class Employee {
        public string Name { get; set; }
        public string Department { get; set; }
        public long Salary { get; set; }
        public int Age { get; set; }
        public int JoiningYear { get; set; }

        public Employee(string name, string dep, long sal, int age, int jyear) {
            Name = name;
            Department = dep;
            Salary = sal;
            Age = age;
            JoiningYear = jyear;
        }

    }
    class program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee> {

            new Employee("Ali", "IT", 85000, 28, 2021),
                new Employee("Sara", "Finance", 65000, 32, 2019),
                new Employee("Usman", "HR", 52000, 35, 2018),
                new Employee("Bilal", "IT", 72000, 26, 2022),
                new Employee("Zainab", "Finance", 65400, 30, 2021),
                new Employee("Hamza", "IT", 105000, 34, 2017),
                new Employee("Ayesha", "HR", 48000, 24, 2023),
                new Employee("Omer", "Marketing", 55000, 29, 2020),
                new Employee("Sana", "IT", 90000, 31, 2019),
                new Employee("Tariq", "Finance", 45000, 27, 2022)
                };
            Console.WriteLine("------------Employees with salary greater than 50000-----------");

            highestsalariesemployee(emp);

            Console.WriteLine("\n------------Department-wise average salary-------------");

            departmentwiseavgsalary(emp);

            Console.WriteLine("\n----------------Highest paid employee -----------------");
            highestpaidemp(emp);

            Console.WriteLine("\n----------Employeessort according to descending order --------------");
            employsalarysort(emp);

            Console.WriteLine("\n --------- just  Name and Department list ---------------");
            namedeplist(emp);

            Console.WriteLine("\n--------employee join after 2020------------");
            empjoinafter2020(emp);
            Console.WriteLine("\n--------Any employee  taking more than 100000 ammount------------");
            emplsal(emp);
            Console.WriteLine("\n--------. Total salary expense of the company------------");
            companexp(emp);

        }


        public static void highestsalariesemployee(List<Employee> empl)
        {
            var result = empl.Where(e => e.Salary > 50000).ToList();
            foreach (var employee in result)
            {
                Console.WriteLine("Name: " + employee.Name + " , Department: " + employee.Department + " , Salary: " + employee.Salary + " , Age: " + employee.Age + " , Joining year: " + employee.JoiningYear);

            }
        }
        public static void departmentwiseavgsalary(List<Employee> empl)
        {
            var result = empl.GroupBy(e => e.Department)
                    .Select(g => new
                    { Department = g.Key, AverageSalary = g.Average(e => e.Salary) });
            foreach (var employee in result)
            {
                Console.WriteLine("Employee Department : " + employee.Department + " | " +
                    "Employee Average salary : " + employee.AverageSalary);

            }
        }

        public static void highestpaidemp(List<Employee> empl)
        {
            var salary = empl.OrderByDescending(e => e.Salary).FirstOrDefault();
            if (salary != null)
            {
                Console.WriteLine("Name: " + salary.Name + " , Department: " + salary.Department + " , Salary: " + salary.Salary + " , Age: " + salary.Age + " , Joining Year: " + salary.JoiningYear);
            }
        }
        public static void employsalarysort(List<Employee> empl)
        {
            var result = empl.OrderByDescending(e => e.Salary).ToList();
            foreach (var employee in result)
            {
                Console.WriteLine("Name: " + employee.Name + " , Department: " + employee.Department + " , Salary: " + employee.Salary + " , Age: " + employee.Age + " , Joining Year: " + employee.JoiningYear);
            }
        }
        public static void namedeplist(List<Employee> empl) { 
        var result = empl.Select(e => new { e.Name, e.Department });
            foreach (var employee in result) { 
            Console.WriteLine("Name : "+employee.Name + " , Department : " + employee.Department);
            }
        }
        public static void empjoinafter2020(List<Employee> empl)
        {
            var result = empl.Where(e => e.JoiningYear > 2020);
            foreach(var emp in result)
            {
                Console.WriteLine("Name: " + emp.Name + " , Department: " + emp.Department + " , Salary: " + emp.Salary + " , Age: " + emp.Age + " , Joining Year: " + emp.JoiningYear);
            }
        }
        public static void emplsal(List<Employee> empl)
        {
            var result = empl.Any(e => e.Salary > 100000);
            if (result)
            {   Console.WriteLine("Yes, there is an employee taking more than 100000 ammount");
            }
            else
                {
                Console.WriteLine("No employee is taking more than 100000 ammount");
            }
        }
        public static void companexp(List<Employee> empl)
        {
            var result=empl.Sum(e=>e.Salary);
            Console.WriteLine("Total salary expense of the company : "+result);
        }

        }
}
    
    


