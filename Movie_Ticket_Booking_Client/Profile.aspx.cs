using Movie_Ticket_Booking_Client.TicketServices;
using Movie_Ticket_Booking_Client.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Movie_Ticket_Booking_Client
{
    public partial class Profile : System.Web.UI.Page
    {
        private int User_Id;
        private readonly TicketServices.TicketServicesClient ticketServices = new TicketServices.TicketServicesClient();
        private readonly UserServices.UserServicesClient userServices = new UserServices.UserServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["userName"] == "admin")
            {
                Response.Redirect("~/TheaterManagement.aspx");
            }
            User_Id = (int)Session["userId"];
            if (!IsPostBack)
            {
                // Populate user details
                PopulateUserDetails();

                // Populate booked tickets
                PopulateBookedTickets();
            }
        }
        private void PopulateUserDetails()
        {
            // Assuming you have a way to retrieve the logged-in user's ID
            int userId = User_Id; // Replace with actual user ID

            // Fetch user details from the database
            
            User user = userServices.GetUser(userId);

            // Display user details
            lblName.Text = user.Name;
            lblEmail.Text = user.Email;
            lblPhone.Text = user.Phone_no;
        }

        private void PopulateBookedTickets()
        {
            // Assuming you have a way to retrieve the logged-in user's ID
            int userId = User_Id; // Replace with actual user ID

            // Fetch booked tickets for the user from the database

            Ticket[] tickets = ticketServices.GetTicketsForUser(userId);
            if (tickets.Length == 0)
            {
                // If no tickets are booked, display a message
                lblNoTickets.Text = "No tickets booked.";
                lblNoTickets.Visible = true;
                gvBookedTickets.Visible = false; // Hide the GridView
            }
            else
            {
                // If tickets are booked, convert the array to a list
                List<Ticket> bookedTickets = tickets.ToList();

                // Bind the booked tickets to the GridView
                gvBookedTickets.DataSource = bookedTickets;
                gvBookedTickets.DataBind();

                // Show the GridView
                gvBookedTickets.Visible = true;
            }
        }


        protected void gvBookedTickets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessage.Text = "called ";
            // Extract the ticket ID from the command argument
            int ticketId;
            if (e.CommandName == "DeleteTicket")
            {
                
                ticketId = Convert.ToInt32(e.CommandArgument);
                MessageBox.Show(ticketId.ToString());
                // Assuming you have a way to retrieve the logged-in user's ID
                int userId = User_Id; // Replace with actual user ID

                Ticket ticket = ticketServices.GetTicket(ticketId, userId);
                // Delete the ticket
                if (ticket != null)
                {
                    int movieId = ticket.Movie_Id;
                    int theaterId = ticket.Theater_Id;

                    // Delete the ticket
                    string result = ticketServices.DeleteTicket(ticketId, userId, movieId, theaterId);

                    // Refresh the booked tickets list
                    PopulateBookedTickets();
                    MessageBox.Show(result);
                    // Display the result of ticket deletion
                    Console.WriteLine(result);
                    lblMessage.Text = result;
                }
                else
                {
                    lblMessage.Text = "Ticket not found.";
                    Console.WriteLine("Ticket not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ticket ID format.");
                MessageBox.Show(e.CommandArgument.ToString());
                lblMessage.Text = "Invalid ticket ID format.";
                Console.WriteLine("Invalid ticket ID format.");
            }
        }

    }
}