using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Methods
{
    internal class SearchStudentByID
    {
        static string connectionString = "Data Source=DESKTOP-RFHC6TB\\MSSQLSERVER01;Initial Catalog=StudentDB;Integrated Security=True;";

        public void searchStudentByID()
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students WHERE StudentID = @ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["StudentID"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Age: {reader["Age"]}, Gender: {reader["Gender"]}, Email: {reader["Email"]}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
                con.Close();
            }
        }

    }
}
