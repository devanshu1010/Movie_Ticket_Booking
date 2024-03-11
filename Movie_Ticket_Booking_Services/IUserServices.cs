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
    public interface IUserServices
    {
        [OperationContract]
        DataSet GetUsers();

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        void SignUp(User user);

        [OperationContract]
        User Login(string email, string password);

    }
}
