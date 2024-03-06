using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticket_Booking_Services.Models
{
    [DataContract]
    public class Movie
    {
        private int movieId;
        private string title;
        private string genre;
        private DateTime releaseDate;
        private TimeSpan duration;

        [DataMember]
        public int Movie_Id
        {
            get { return movieId; }
            set { movieId = value; }
        }

        [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [DataMember]
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        [DataMember]
        public DateTime Release_Date
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        [DataMember]
        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        // Navigation property for the many-to-many relationship
        public virtual ICollection<Theater> Theaters { get; set; }
    }
}
