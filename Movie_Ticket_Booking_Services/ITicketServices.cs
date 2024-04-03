using Movie_Ticket_Booking_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services
{
    [ServiceContract]
    public interface ITicketServices
    {

        [OperationContract]
        List<Ticket> GetTickets();

        [OperationContract]
        Ticket GetTicket(int ticketId, int userId);

        [OperationContract]
        string BookTicket(Ticket ticket);

        [OperationContract]
        string DeleteTicket(int ticketId, int userId, int movieId, int theaterId);

        [OperationContract]
        int GetNumberOfTicketsBooked(int movieId, int theaterId);

        [OperationContract]
        List<Ticket> GetTicketsForUser(int userId);
    }
}
