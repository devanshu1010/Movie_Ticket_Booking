using Movie_Ticket_Booking_Services.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services
{
    public class TheaterServices :ITheaterServices
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Movie_Ticket_Booking;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public string AddTheater(Theater theater)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Theater] (Name, Address) VALUES (@Name, @Address)", cnn);
                cmd.Parameters.AddWithValue("@Name", theater.Name);
                cmd.Parameters.AddWithValue("@Address", theater.Address);
                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Theater added successfully.";
                }
                else
                {
                    return "Failed to add theater.";
                }
            }
        }

        public List<Theater> GetTheaters()
        {
            List<Theater> theaters = new List<Theater>();
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Theater]", cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int theaterId = Convert.ToInt32(reader["Theater_Id"]);

                    // Create a new Theater object
                    Theater theater = new Theater
                    {
                        Theater_Id = theaterId,
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Movies = GetMoviesForTheater(theaterId)
                    };
                    theaters.Add(theater);
                }
                reader.Close();
            }
            return theaters;
        }


        public Theater GetTheater(int id)
        {
            Theater theater = new Theater();
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Theater] WHERE Theater_Id = @id", cnn);
                cmd.Parameters.AddWithValue("@id", id);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    theater.Theater_Id = Convert.ToInt32(reader["Theater_Id"]);
                    theater.Name = reader.GetString(1);
                    theater.Address = reader.GetString(2);
                }
                reader.Close();
            }
            // Populate movies associated with this theater
            theater.Movies = GetMoviesForTheater(id);
            return theater;
        }

        private List<TheaterMovie> GetMoviesForTheater(int theaterId)
        {
            List<TheaterMovie> theaterMovies = new List<TheaterMovie>();
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(@"SELECT m.*, tm.Total_Seats, t.*
                                          FROM [Movie] m
                                          JOIN [TheaterMovie] tm ON m.Movie_Id = tm.Movie_Id
                                          JOIN [Theater] t ON tm.Theater_Id = t.Theater_Id
                                          WHERE t.Theater_Id = @theaterId", cnn);
                cmd.Parameters.AddWithValue("@theaterId", theaterId);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int movieId = Convert.ToInt32(reader["Movie_Id"]);

                    // Create a TheaterMovie object
                    TheaterMovie theaterMovie = new TheaterMovie
                    {
                        Theater_Id = Convert.ToInt32(reader["Theater_Id"]),
                        Movie_Id = movieId,
                        Total_Seats = Convert.ToInt32(reader["Total_Seats"]),
                        Movie = new Movie
                        {
                            Movie_Id = movieId,
                            Title = reader.GetString(1),
                            Genre = reader.GetString(2),
                            Release_Date = reader.GetDateTime(3),
                            Duration = reader.GetTimeSpan(4)
                        }
                    };
                    theaterMovies.Add(theaterMovie);
                }
                reader.Close();
            }
            return theaterMovies;
        }

        /*
        public Theater GetTheater(int id)
        {
            Theater theater = new Theater();
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Theater] WHERE Theater_Id = @id", cnn);
                cmd.Parameters.AddWithValue("@id", id);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    theater.Theater_Id = Convert.ToInt32(reader["Theater_Id"]);
                    theater.Name = reader.GetString(1);
                    theater.Address = reader.GetString(2);
                }
                reader.Close();
            }
            return theater;
        }

        */

        public string UpdateTheater(Theater theater)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                cnn.Open();
                using (SqlTransaction transaction = cnn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE [Theater] SET Name = @Name, Address = @Address WHERE Theater_Id = @Theater_Id", cnn, transaction);
                        cmd.Parameters.AddWithValue("@Name", theater.Name);
                        cmd.Parameters.AddWithValue("@Address", theater.Address);
                        cmd.Parameters.AddWithValue("@Theater_Id", theater.Theater_Id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected <= 0)
                        {
                            transaction.Rollback();
                            return "Failed to update theater.";
                        }

                        // Commit the transaction if everything succeeded
                        transaction.Commit();
                        return "Theater updated successfully.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Failed to update theater: " + ex.Message;
                    }
                }
            }
        }

        public string DeleteTheater(int id)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                cnn.Open();
                using (SqlTransaction transaction = cnn.BeginTransaction())
                {
                    try
                    {
                        // Delete theater from Theater table
                        SqlCommand cmdDeleteTheater = new SqlCommand("DELETE FROM [Theater] WHERE Theater_Id = @Theater_Id", cnn, transaction);
                        cmdDeleteTheater.Parameters.AddWithValue("@Theater_Id", id);
                        int rowsAffected = cmdDeleteTheater.ExecuteNonQuery();

                        // Check if the theater was successfully deleted
                        if (rowsAffected <= 0)
                        {
                            transaction.Rollback();
                            return "Failed to delete theater.";
                        }

                        // Delete associated records from TheaterMovie table
                        SqlCommand cmdDeleteTheaterMovies = new SqlCommand("DELETE FROM [TheaterMovie] WHERE Theater_Id = @Theater_Id", cnn, transaction);
                        cmdDeleteTheaterMovies.Parameters.AddWithValue("@Theater_Id", id);
                        cmdDeleteTheaterMovies.ExecuteNonQuery();

                        // Commit the transaction if everything succeeded
                        transaction.Commit();
                        return "Theater deleted successfully.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Failed to delete theater: " + ex.Message;
                    }
                }
            }
        }


        public string AddMovieToTheater(int theaterId, int movieId, int totalSeats)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                // Check if the theater and movie exist
                if (!TheaterExists(theaterId))
                    return "Theater does not exist.";

                if (!MovieExists(movieId))
                    return "Movie does not exist.";

                // Check if the movie is already associated with the theater
                if (MovieAlreadyAddedToTheater(theaterId, movieId))
                    return "Movie is already associated with the theater.";

                // Add movie to theater
                SqlCommand cmd = new SqlCommand("INSERT INTO [TheaterMovie] (Theater_Id, Movie_Id, Total_Seats) VALUES (@Theater_Id, @Movie_Id, @Total_Seats)", cnn);
                cmd.Parameters.AddWithValue("@Theater_Id", theaterId);
                cmd.Parameters.AddWithValue("@Movie_Id", movieId);
                cmd.Parameters.AddWithValue("@Total_Seats", totalSeats);

                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Movie added to theater successfully.";
                }
                else
                {
                    return "Failed to add movie to theater.";
                }
            }
        }

        // Helper methods
        public bool TheaterExists(int theaterId)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Theater] WHERE Theater_Id = @Theater_Id", cnn);
                cmd.Parameters.AddWithValue("@Theater_Id", theaterId);
                cnn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool MovieExists(int movieId)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Movie] WHERE Movie_Id = @Movie_Id", cnn);
                cmd.Parameters.AddWithValue("@Movie_Id", movieId);
                cnn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool MovieAlreadyAddedToTheater(int theaterId, int movieId)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [TheaterMovie] WHERE Theater_Id = @Theater_Id AND Movie_Id = @Movie_Id", cnn);
                cmd.Parameters.AddWithValue("@Theater_Id", theaterId);
                cmd.Parameters.AddWithValue("@Movie_Id", movieId);
                cnn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
