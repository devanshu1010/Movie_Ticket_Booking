using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services.Models
{
    [DataContract]
    public class User
    {
        private int userId;
        private string name;
        private string email;
        private string password;
        private string phone_no;

        [DataMember]
        public int Id
        {
            get { return userId; }
            set { userId = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public string PhoneNo
        {
            get { return phone_no; }
            set { phone_no = value; }
        }
    }
}
