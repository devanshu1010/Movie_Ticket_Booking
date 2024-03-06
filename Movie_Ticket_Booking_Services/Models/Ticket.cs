using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services.Models
{
    [DataContract]
    public class Ticket
    {
        private int ticketId;
        private int userId;
        private int movieId;
        private int theaterId;
        private DateTime date;
        private decimal price;
        private DateTime time;
        private decimal seat_no;

        [DataMember]
        public int Ticket_Id
        {
            get { return ticketId; }
            set { ticketId = value; }
        }

        [DataMember]
        public int User_Id
        {
            get { return userId; }
            set { userId = value; }
        }

        [DataMember]
        public int Movie_Id
        {
            get { return movieId; }
            set { movieId = value; }
        }

        [DataMember]
        public int Theater_Id
        {
            get { return theaterId; }
            set { theaterId = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        [DataMember]
        public decimal Seat_no
        {
            get { return seat_no; }
            set { seat_no = value; }
        }
    }
}
