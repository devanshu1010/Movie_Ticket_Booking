using Movie_Ticket_Booking_Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services
{
    [ServiceContract]
    public interface IMovieServices
    {
        [OperationContract]
        List<Movie> GetMovies();

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        string AddMovie(Movie movie);

        [OperationContract]
        string UpdateMovie(Movie movie);

        [OperationContract]
        string DeleteMovie(int id);

        [OperationContract]
        string AddMovieToTheater(int theaterId, Movie movie, int totalSeats);
    }
}
