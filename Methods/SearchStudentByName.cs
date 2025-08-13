using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Methods
{
    internal class SearchStudentByName
    {
        static string connectionString = "Data Source=DESKTOP-RFHC6TB\\MSSQLSERVER01;Initial Catalog=StudentDB;Integrated Security=True;";

        public void searchStudentByName()
        {
            Console.Write("Enter student name (partial allowed): ");
            string name = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students WHERE FirstName LIKE @Name OR LastName LIKE @Name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", "%" + name + "%");

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["StudentID"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Age: {reader["Age"]}, Gender: {reader["Gender"]}, Email: {reader["Email"]}");
                }
                con.Close();
            }
        }

    }
}
