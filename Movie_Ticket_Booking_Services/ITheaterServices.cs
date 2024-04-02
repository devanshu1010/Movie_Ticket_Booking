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
    public interface ITheaterServices
    {
        [OperationContract]
        List<Theater> GetTheaters();

        [OperationContract]
        Theater GetTheater(int id);

        [OperationContract]
        string AddTheater(Theater theater);

        [OperationContract]
        string UpdateTheater(Theater theater);

        [OperationContract]
        Movie[] GetMoviesNotInTheater(int theaterId);

        [OperationContract]
        string DeleteTheater(int id);

        [OperationContract]
        string AddMovieToTheater(int theaterId, int movieId, int totalSeats);
        
    }
}
