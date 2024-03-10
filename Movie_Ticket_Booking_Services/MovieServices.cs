using Movie_Ticket_Booking_Services.Models;
using static Movie_Ticket_Booking_Services.TheaterServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services
{
    public class MovieServices : IMovieServices
    {
        TheaterServices theaterServices = new TheaterServices();

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Movie_Ticket_Booking;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public Movie GetMovie(int movie_id)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(@"SELECT m.*, tm.Total_Seats, t.*
                                          FROM [Movie] m
                                          JOIN [TheaterMovie] tm ON m.Movie_Id = tm.Movie_Id
                                          JOIN [Theater] t ON tm.Theater_Id = t.Theater_Id
                                          WHERE m.Movie_Id = @movie_id", cnn);
                cmd.Parameters.AddWithValue("@movie_id", movie_id);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Movie movie = null;
                while (reader.Read())
                {
                    if (movie == null)
                    {
                        movie = new Movie
                        {
                            Movie_Id = Convert.ToInt32(reader["Movie_Id"]),
                            Title = reader.GetString(1),
                            Genre = reader.GetString(2),
                            Release_Date = reader.GetDateTime(3),
                            Duration = reader.GetTimeSpan(4),
                            Theaters = new List<TheaterMovie>()
                        };
                    }
                    // Add TheaterMovie for the movie
                    TheaterMovie theaterMovie = new TheaterMovie
                    {
                        Theater_Id = Convert.ToInt32(reader["Theater_Id"]),
                        Movie_Id = Convert.ToInt32(reader["Movie_Id"]),
                        Total_Seats = Convert.ToInt32(reader["Total_Seats"]),
                        Theater = new Theater
                        {
                            Theater_Id = Convert.ToInt32(reader["Theater_Id"]),
                            Name = reader.GetString(7),
                            Address = reader.GetString(8)
                        }
                    };
                    movie.Theaters.Add(theaterMovie);
                }
                reader.Close();
                return movie;
            }
        }
        /*
        public string AddMovie(Movie movie)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Movie] (Title, Genre, Release_Date, Duration) VALUES (@Title, @Genre, @Release_Date, @Duration); SELECT SCOPE_IDENTITY()", cnn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Release_Date", movie.Release_Date);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);

                cnn.Open();
                int movieId = Convert.ToInt32(cmd.ExecuteScalar());

                if (movieId > 0)
                {
                    foreach (var theaterMovie in movie.Theaters)
                    {
                        AddTheaterMovie(theaterMovie.Theater_Id, movieId, theaterMovie.Total_Seats);
                    }
                    return "Movie added successfully.";
                }
                else
                {
                    return "Failed to add movie.";
                }
            }
        }
        */

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(@"SELECT m.*, tm.Total_Seats, t.*
                                          FROM [Movie] m
                                          JOIN [TheaterMovie] tm ON m.Movie_Id = tm.Movie_Id
                                          JOIN [Theater] t ON tm.Theater_Id = t.Theater_Id", cnn);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int movieId = Convert.ToInt32(reader["Movie_Id"]);
                    // Check if the movie already exists in the list
                    Movie movie = movies.FirstOrDefault(m => m.Movie_Id == movieId);
                    if (movie == null)
                    {
                        movie = new Movie
                        {
                            Movie_Id = movieId,
                            Title = reader.GetString(1),
                            Genre = reader.GetString(2),
                            Release_Date = reader.GetDateTime(3),
                            Duration = reader.GetTimeSpan(4),
                            Theaters = new List<TheaterMovie>()
                        };
                        movies.Add(movie);
                    }

                    // Add TheaterMovie for the movie
                    TheaterMovie theaterMovie = new TheaterMovie
                    {
                        Theater_Id = Convert.ToInt32(reader["Theater_Id"]),
                        Movie_Id = movieId,
                        Total_Seats = Convert.ToInt32(reader["Total_Seats"]),
                        Theater = new Theater
                        {
                            Theater_Id = Convert.ToInt32(reader["Theater_Id"]),
                            Name = reader.GetString(7),
                            Address = reader.GetString(8)
                        }
                    };
                    movie.Theaters.Add(theaterMovie);
                }
                reader.Close();
            }
            return movies;
        }


        public string AddMovie(Movie movie)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Movie] (Title,Genre,Release_Date,Duration) VALUES (@Title , @Genre, @Release_Date, @Duration)", cnn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Release_Date", movie.Release_Date);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                
                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("User signed up successfully.");
                    return "Movie added succesfully.";
                }
                else
                {
                    Console.WriteLine("Failed to sign up user.");
                    return "Error in adding.";
                }

            }
        }

        public string UpdateMovie(Movie movie)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Movie] SET Title = @Title, Genre = @Genre, Release_Date = @Release_Date, Duration = @Duration WHERE Movie_Id = @Movie_Id", cnn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Release_Date", movie.Release_Date);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                cmd.Parameters.AddWithValue("@Movie_Id", movie.Movie_Id);

                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Delete existing theater movie associations
                    DeleteTheaterMovieByMovieId(movie.Movie_Id);

                    // Add updated theater movie associations
                    foreach (var theaterMovie in movie.Theaters)
                    {
                        AddTheaterMovie(theaterMovie.Theater_Id, movie.Movie_Id, theaterMovie.Total_Seats);
                    }
                    return "Movie updated successfully.";
                }
                else
                {
                    return "Failed to update movie.";
                }
            }
        }

        public string DeleteMovie(int id)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                // Delete movie from TheaterMovie
                DeleteTheaterMovieByMovieId(id);

                // Delete movie from Movie table
                SqlCommand cmd = new SqlCommand("DELETE FROM [Movie] WHERE Movie_Id = @Movie_Id", cnn);
                cmd.Parameters.AddWithValue("@Movie_Id", id);

                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Movie deleted successfully.";
                }
                else
                {
                    return "Failed to delete movie.";
                }
            }
        }

        public string AddMovieToTheater(int theaterId, Movie movie, int totalSeats)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                // Check if the theater exists
                if (!theaterServices.TheaterExists(theaterId))
                    return "Theater does not exist.";

                // Check if the movie already exists
                int movieId = GetMovieIdByTitle(movie.Title);
                if (movieId == -1)
                {
                    // If the movie doesn't exist, add it to the Movie table
                    return "No movie exist like that.";
                }

                // Check if the movie is already associated with the theater
                if (theaterServices.MovieAlreadyAddedToTheater(theaterId, movieId))
                    return "Movie is already associated with the theater.";

                // Add movie to theater
                AddTheaterMovie(theaterId, movieId, totalSeats);
                return "Movie added to theater successfully.";
            }
        }

        // Helper method to get movie ID by title
        private int GetMovieIdByTitle(string title)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT Movie_Id FROM [Movie] WHERE Title = @Title", cnn);
                cmd.Parameters.AddWithValue("@Title", title);

                cnn.Open();
                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        // Helper method to add theater movie association
        private void AddTheaterMovie(int theaterId, int movieId, int totalSeats)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [TheaterMovie] (Theater_Id, Movie_Id, Total_Seats) VALUES (@Theater_Id, @Movie_Id, @Total_Seats)", cnn);
                cmd.Parameters.AddWithValue("@Theater_Id", theaterId);
                cmd.Parameters.AddWithValue("@Movie_Id", movieId);
                cmd.Parameters.AddWithValue("@Total_Seats", totalSeats);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Helper method to delete theater movie associations by movie ID
        private void DeleteTheaterMovieByMovieId(int movieId)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [TheaterMovie] WHERE Movie_Id = @Movie_Id", cnn);
                cmd.Parameters.AddWithValue("@Movie_Id", movieId);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
