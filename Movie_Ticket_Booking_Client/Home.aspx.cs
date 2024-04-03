using Movie_Ticket_Booking_Client.MovieServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Booking_Client
{
    public partial class Home : System.Web.UI.Page
    {
        private readonly MovieServices.MovieServicesClient movieServices = new MovieServices.MovieServicesClient();

        protected List<Movie> Movies { get; set; }

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
            //User_Id = (int)Session["userId"];
            if (!IsPostBack)
            {
                // Fetch movie data from the database
                Movie[] moviesArray = movieServices.GetMovies();
                Movies = moviesArray.ToList();
               
            }
        }
    }
}