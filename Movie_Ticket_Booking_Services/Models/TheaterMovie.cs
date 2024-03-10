using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services.Models
{
    [DataContract]
    public class TheaterMovie
    {
        [DataMember]
        public int Theater_Id { get; set; }

        [DataMember]
        public int Movie_Id { get; set; }

        [DataMember]
        public int Total_Seats { get; set; }

        [DataMember]
        // Navigation properties
        public virtual Theater Theater { get; set; }

        [DataMember]
        public virtual Movie Movie { get; set; }
    }
}
