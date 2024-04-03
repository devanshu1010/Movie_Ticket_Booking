using Movie_Ticket_Booking_Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Movie_Ticket_Booking_Services
{
    public class UserServices : IUserServices
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Movie_Ticket_Booking;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public User GetUser(int id)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Id = @id", cnn);
                cmd.Parameters.AddWithValue("@id", id);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                User user = new User();
                if (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["id"]);
                    user.Name = reader.GetString(2);
                    user.Email = reader.GetString(1);
                    user.Phone_no = reader.GetString(4);
                }
                reader.Close();
                return user;
            }
        }

        public DataSet GetUsers()
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User]", cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "User");
                return ds;
            }
        }

        public void SignUp(User user)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                Console.WriteLine(user);
                SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Name,Email,Password,Phone_no) VALUES (@Name , @Email, @Password, @Phone_no)", cnn);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Phone_no", user.Phone_no);
                
                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("User signed up successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to sign up user.");
                }

            }
        }

        public User Login(string email, string password)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Email = @email AND Password = @password", cnn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                User user = null;
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader.GetString(2),
                        Email = reader.GetString(1),
                        Phone_no = reader.GetString(4)
                    };
                }
                reader.Close();
                return user;
            }
        }

    }
}
