using System;
using System.Data.SqlClient;

namespace Lab_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=MAXACER\\SQLEXPRESS;Initial Catalog=sportComplex;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Clients";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["client_id"]}, Name: {reader["client_full_name"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }
    }
}
