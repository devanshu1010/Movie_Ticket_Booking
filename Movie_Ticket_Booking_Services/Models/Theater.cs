using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services.Models
{
    [DataContract]
    public class Theater
    {
        private int theaterId;
        private string name;
        private string address;

        [DataMember]
        public int Theater_Id
        {
            get { return theaterId; }
            set { theaterId = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
