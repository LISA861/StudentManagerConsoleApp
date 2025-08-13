using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Methods
{
    internal class DeleteStudent
    {
        static string connectionString = "Data Source=DESKTOP-RFHC6TB\\MSSQLSERVER01;Initial Catalog=StudentDB;Integrated Security=True;";

        public void deleteStudent()
        {
            Console.Write("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Students WHERE StudentID = @ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                if (rows > 0)
                    Console.WriteLine("Student deleted.");
                else
                    Console.WriteLine("Student not found.");
            }
        }

    }
}
