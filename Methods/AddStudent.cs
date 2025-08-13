using System;
using System.Data.SqlClient;


namespace StudentManager.Methods
{
    internal class AddStudent
    {
        static string connectionString = "Data Source=DESKTOP-RFHC6TB\\MSSQLSERVER01;Initial Catalog=StudentDB;Integrated Security=True;";

        public void addStudent()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (FirstName, LastName, Age, Gender, Email) VALUES (@FirstName, @LastName, @Age, @Gender, @Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Email", email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Student added successfully.");
            }
        }

    }
}
