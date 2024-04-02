using Movie_Ticket_Booking_Client.MovieServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Booking_Client
{
    public partial class ViewMovie : System.Web.UI.Page
    {
        private readonly MovieServices.MovieServicesClient movieServices = new MovieServices.MovieServicesClient();

        Movie Movie;
        int movieId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMovieDetails();
            }
        }
        private void LoadMovieDetails()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Movie_Id"]))
            {
                int movieId = Convert.ToInt32(Request.QueryString["Movie_Id"]);
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
        }

        private Movie GetMovieDetails(int movieId)
        {
            // Code to fetch movie details from database using MovieServices
            
            return movieServices.GetMovie(movieId);
        }

        private void BindMovieDetails(Movie movie)
        {
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
            // Handle button click event here
            if (e.CommandName == "BookTicket")
            {
                // Retrieve Theater_Id and Movie_Id from the command argument
                string[] args = e.CommandArgument.ToString().Split(',');
                int theaterId = Convert.ToInt32(args[0]);
                //int movieId = Convert.ToInt32(movieId);
                // Redirect to booking page with Theater_Id and Movie_Id
                Response.Redirect($"BookTicket.aspx?Theater_Id={theaterId}&Movie_Id={movieId}");
            }
        }

    }
}