using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Methods
{
    internal class ViewAllStudents
    {
        static string connectionString = "Data Source=DESKTOP-RFHC6TB\\MSSQLSERVER01;Initial Catalog=StudentDB;Integrated Security=True;";

        public void viewAllStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("ID\tFirst Name\tLast Name\tAge\tGender\tEmail");
                Console.WriteLine("-------------------------------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["StudentID"]}\t{reader["FirstName"]}\t{reader["LastName"]}\t{reader["Age"]}\t{reader["Gender"]}\t{reader["Email"]}");
                }
                con.Close();
            }
        }

    }
}
