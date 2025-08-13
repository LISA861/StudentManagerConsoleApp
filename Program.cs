using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Methods;

namespace StudentManager
{
    internal class Program
    {
        static string connectionString = "Data Source=DESKTOP-RFHC6TB\\MSSQLSERVER01;Initial Catalog=StudentDB;Integrated Security=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Search Student by ID");
                Console.WriteLine("4. Search Student by Name");
                Console.WriteLine("5. Update Student");
                Console.WriteLine("6. Delete Student");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                AddStudent ad = new AddStudent();
                ViewAllStudents vas = new ViewAllStudents();
                SearchStudentByID sid = new SearchStudentByID();
                SearchStudentByName sname = new SearchStudentByName();
                UpdateStudent us = new UpdateStudent();
                DeleteStudent ds = new DeleteStudent();


                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ad.addStudent();
                        break;
                    case "2":
                        vas.viewAllStudents();
                        break;
                    case "3":
                        sid.searchStudentByID();
                        break;
                    case "4":
                        sname.searchStudentByName();
                        break;
                    case "5":
                        us.updateStudent();
                        break;
                    case "6":
                        ds.deleteStudent();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
