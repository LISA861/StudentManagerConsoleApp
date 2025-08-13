using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Methods
{
    internal class UpdateStudent
    {
        static string connectionString = "Data Source=DESKTOP-RFHC6TB\\MSSQLSERVER01;Initial Catalog=StudentDB;Integrated Security=True;";

        public void updateStudent()
        {
            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(*) FROM Students WHERE StudentID = @ID";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                int exists = (int)checkCmd.ExecuteScalar();
                if (exists == 0)
                {
                    Console.WriteLine("Student does not exist.");
                    con.Close();
                    return;
                }

                Console.Write("New First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("New Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("New Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("New Gender: ");
                string gender = Console.ReadLine();

                Console.Write("New Email: ");
                string email = Console.ReadLine();

                string updateQuery = "UPDATE Students SET FirstName=@FirstName, LastName=@LastName, Age=@Age, Gender=@Gender, Email=@Email WHERE StudentID=@ID";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@FirstName", firstName);
                updateCmd.Parameters.AddWithValue("@LastName", lastName);
                updateCmd.Parameters.AddWithValue("@Age", age);
                updateCmd.Parameters.AddWithValue("@Gender", gender);
                updateCmd.Parameters.AddWithValue("@Email", email);
                updateCmd.Parameters.AddWithValue("@ID", id);

                updateCmd.ExecuteNonQuery();
                Console.WriteLine("Student updated successfully.");
                con.Close();
            }
        }

    }
}
