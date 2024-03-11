using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceHost sh1 = new ServiceHost(typeof(Movie_Ticket_Booking_Services.UserServices));
            ServiceHost sh2 = new ServiceHost(typeof(Movie_Ticket_Booking_Services.MovieServices));
            ServiceHost sh3 = new ServiceHost(typeof(Movie_Ticket_Booking_Services.TheaterServices));
            ServiceHost sh4 = new ServiceHost(typeof(Movie_Ticket_Booking_Services.TicketServices));
            sh1.Open();
            sh2.Open();
            sh3.Open();
            sh4.Open();
            label1.Text = "Server Running.";

        }
    }
}
