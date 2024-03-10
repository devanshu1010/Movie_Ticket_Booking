using Movie_Ticket_Booking_Services.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services
{
    public class TicketServices : ITicketServices
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Movie_Ticket_Booking;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public List<Ticket> GetTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Ticket]", cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tickets.Add(new Ticket
                    {
                        Ticket_Id = Convert.ToInt32(reader["Ticket_Id"]),
                        User_Id = Convert.ToInt32(reader["User_Id"]),
                        Movie_Id = Convert.ToInt32(reader["Movie_Id"]),
                        Theater_Id = Convert.ToInt32(reader["Theater_Id"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Time = Convert.ToDateTime(reader["Time"]),
                        Seat_no = Convert.ToDecimal(reader["Seat_no"])
                    });
                }
                reader.Close();
            }
            return tickets;
        }

        public Ticket GetTicket(int ticketId, int userId, int movieId, int theaterId)
        {
            Ticket ticket = null;
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Ticket] WHERE Ticket_Id = @Ticket_Id AND User_Id = @User_Id AND Movie_Id = @Movie_Id AND Theater_Id = @Theater_Id", cnn);
                cmd.Parameters.AddWithValue("@Ticket_Id", ticketId);
                cmd.Parameters.AddWithValue("@User_Id", userId);
                cmd.Parameters.AddWithValue("@Movie_Id", movieId);
                cmd.Parameters.AddWithValue("@Theater_Id", theaterId);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ticket = new Ticket
                    {
                        Ticket_Id = Convert.ToInt32(reader["Ticket_Id"]),
                        User_Id = Convert.ToInt32(reader["User_Id"]),
                        Movie_Id = Convert.ToInt32(reader["Movie_Id"]),
                        Theater_Id = Convert.ToInt32(reader["Theater_Id"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Time = Convert.ToDateTime(reader["Time"]),
                        Seat_no = Convert.ToDecimal(reader["Seat_no"])
                    };
                }
                reader.Close();
            }
            return ticket;
        }

        public string BookTicket(Ticket ticket)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Ticket] (User_Id, Movie_Id, Theater_Id, Date, Price, Time, Seat_no) VALUES (@User_Id, @Movie_Id, @Theater_Id, @Date, @Price, @Time, @Seat_no)", cnn);
                cmd.Parameters.AddWithValue("@User_Id", ticket.User_Id);
                cmd.Parameters.AddWithValue("@Movie_Id", ticket.Movie_Id);
                cmd.Parameters.AddWithValue("@Theater_Id", ticket.Theater_Id);
                cmd.Parameters.AddWithValue("@Date", ticket.Date);
                cmd.Parameters.AddWithValue("@Price", ticket.Price);
                cmd.Parameters.AddWithValue("@Time", ticket.Time);
                cmd.Parameters.AddWithValue("@Seat_no", ticket.Seat_no);
                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Ticket booked successfully.";
                }
                else
                {
                    return "Failed to book ticket.";
                }
            }
        }

        public string DeleteTicket(int ticketId, int userId, int movieId, int theaterId)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Ticket] WHERE Ticket_Id = @Ticket_Id AND User_Id = @User_Id AND Movie_Id = @Movie_Id AND Theater_Id = @Theater_Id", cnn);
                cmd.Parameters.AddWithValue("@Ticket_Id", ticketId);
                cmd.Parameters.AddWithValue("@User_Id", userId);
                cmd.Parameters.AddWithValue("@Movie_Id", movieId);
                cmd.Parameters.AddWithValue("@Theater_Id", theaterId);
                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Ticket deleted successfully.";
                }
                else
                {
                    return "Failed to delete ticket.";
                }
            }
        }
    }
}
