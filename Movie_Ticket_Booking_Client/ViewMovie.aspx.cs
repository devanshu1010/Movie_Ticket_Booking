using Movie_Ticket_Booking_Client.MovieServices;
using Movie_Ticket_Booking_Client.TicketServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Movie_Ticket_Booking_Client
{
    public partial class ViewMovie : System.Web.UI.Page
    {
        private readonly MovieServices.MovieServicesClient movieServices = new MovieServices.MovieServicesClient();
        private readonly TheaterServices.TheaterServicesClient theaterServices = new TheaterServices.TheaterServicesClient();
        private readonly TicketServices.TicketServicesClient ticketServices = new TicketServices.TicketServicesClient();

        Movie Movie;
        int movieId;
        int TotalSeatsAvailable;
        private int User_Id; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            User_Id = (int)Session["userId"];
            //MessageBox.Show(User_Id.ToString());
            if (!IsPostBack)
            {
                LoadMovieDetails();
            }
        }
        private void LoadMovieDetails()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Movie_Id"]))
            {
                movieId = Convert.ToInt32(Request.QueryString["Movie_Id"]);
                Movie = GetMovieDetails(movieId);
                if (Movie != null)
                {
                    BindMovieDetails(Movie);
                    BindTheaters(movieId);
                }
                else
                {
                    // Handle case where movie details are not found
                    //Response.Redirect("Home.aspx");
                }
            }
            else
            {
                // Handle case where Movie_Id is not provided
                //Response.Redirect("Home.aspx");
            }
        }

        private void BindTheaters(int movieId)
        {
            Theater[] theaters = movieServices.GetTheatersByMovieId(movieId);
            rptTheaters.DataSource = theaters;
            rptTheaters.DataBind();

            foreach (RepeaterItem item in rptTheaters.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    // Retrieve the release date of the movie
                    DateTime releaseDate = Movie.Release_Date;

                    // Find the "Book Ticket" button in the current repeater item
                    System.Web.UI.WebControls.Button btnBookTicket = (System.Web.UI.WebControls.Button)item.FindControl("btnBookTicket");

                    // Check if the release date is less than today's date
                    if (releaseDate < DateTime.Today)
                    {
                        // Disable the button
                        btnBookTicket.Visible = false;
                    }
                }
            }

        }

        private Movie GetMovieDetails(int movieId)
        {
            // Code to fetch movie details from database using MovieServices
            
            return movieServices.GetMovie(movieId);
        }

        private void BindMovieDetails(Movie movie)
        {
            //Movie = movie;
            lblTitle.Text = movie.Title;
            lblGenre.Text = movie.Genre;
            lblReleaseDate.Text = movie.Release_Date.ToShortDateString();
            lblDuration.Text = movie.Duration.TotalMinutes.ToString();
        }

        private List<Theater> GetTheatersByMovie(int movieId)
        {
            // Code to fetch theaters where the movie is available from database using MovieServices
            Theater[] theatersArray = movieServices.GetTheatersByMovieId(movieId);
            
            return theatersArray.ToList();
        }


        protected void rptTheaters_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "BookTicket")
            {
                int theaterId = Convert.ToInt32(e.CommandArgument);
                
                //label.Text = User_Id.ToString();
                // Get the movie ID from query string
                int movieId_1 = Convert.ToInt32(Request.QueryString["Movie_Id"]);
                //label.Text = movieId_1.ToString();
                // Reinitialize the Movie object
                Movie LocalMovie = GetMovieDetails(movieId_1);

                if (LocalMovie != null)
                {
                    // Now you can access Movie properties safely
                    //label.Text = LocalMovie.Release_Date.ToString();
                    //MessageBox.Show(Movie.Release_Date.ToString());
                }
                TotalSeatsAvailable = theaterServices.GetTotalSeats(theaterId, movieId_1);

                // Check if the movie is released
                //label.Text = "Not getting movie.";
                //MessageBox.Show(Movie.Release_Date.ToString());
                // Check if the movie is released
                DateTime releaseDate = LocalMovie.Release_Date;
                if (releaseDate >= DateTime.Today)
                {
                    //label.Text = "hello2";
                    // Call GetNumberOfTicketsBooked method to get the count of booked tickets for the specified movie and theater
                    int numberOfTicketsBooked = ticketServices.GetNumberOfTicketsBooked(movieId_1, theaterId);
                    //label.Text = numberOfTicketsBooked.ToString();
                    // Proceed to book ticket if the number of tickets booked is less than the total seats available
                    if (numberOfTicketsBooked < TotalSeatsAvailable)
                    {
                        int seat = numberOfTicketsBooked + 1;
                        // Create a new Ticket object with default values
                        Ticket newTicket = new Ticket
                        {

                            User_Id = User_Id, // Assuming you store the user ID in session
                            Movie_Id = movieId_1,
                            Theater_Id = theaterId,
                            Date = LocalMovie.Release_Date, // Assuming you want to book for the current date
                            Price = 100, // Assuming the price is 100 for all tickets
                            Seat_no = seat // Assuming you will set the seat number later
                        };
                        //label.Text = seat.ToString();
                        // Call the BookTicket method to insert the new ticket into the database
                        string result = ticketServices.BookTicket(newTicket);

                        // Display the result
                        // You can redirect to another page or display a message here based on the result
                        // For example:
                        if (result == "Ticket booked successfully.")
                        {
                            MessageBox.Show(result);
                            Response.Redirect("Profile.aspx");
                        }
                        else
                        {
                            Response.Write("Failed to book ticket.");
                        }
                    }
                    else
                    {
                        // Show a message indicating that all seats are booked
                        //Response.Write("All seats are booked. Cannot book ticket.");
                    }
                }
                else
                {
                    // Show a message indicating that the movie is not released yet
                    //Response.Write("Movie is not released yet. Cannot book ticket.");
                }

            }
        }

    }
}