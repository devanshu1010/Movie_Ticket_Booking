using Movie_Ticket_Booking_Client.TheaterServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Movie_Ticket_Booking_Client
{
    public partial class TheaterManagement : System.Web.UI.Page
    {
        private readonly TheaterServices.TheaterServicesClient theaterServices = new TheaterServices.TheaterServicesClient();
        private int update_id = -1; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["userName"].ToString() != "admin")
            {
                Response.Redirect("~/Logout.aspx");
            }
            //MessageBox.Show(Session["userName"].ToString());
            if (!IsPostBack)
            {
                
                BindTheaters();
                /*if (ddlAvailableMovies.Items.Count == 0) // Check if movies are already populated to avoid duplication
                {
                    PopulateAvailableMovies();
                }*/
            }

        }

        protected void PopulateAvailableMovies()
        {
            // Get the ID of the selected theater
            int selectedTheaterId = Convert.ToInt32(gvTheaters.SelectedDataKey.Value);

            // Call the service method to get movies that are not associated with the selected theater
            Movie[] availableMoviesArray = theaterServices.GetMoviesNotInTheater(selectedTheaterId);

            // Convert the array to a list
            List<Movie> availableMovies = availableMoviesArray.ToList();

            // Bind the available movies to the dropdown list
            ddlAvailableMovies.DataSource = availableMovies;
            ddlAvailableMovies.DataTextField = "Title"; // Assuming Title is the property of Movie class representing movie title
            ddlAvailableMovies.DataValueField = "Movie_Id"; // Assuming Movie_Id is the property of Movie class representing movie ID
            ddlAvailableMovies.DataBind();
        }


        protected void BindTheaters()
        {
            gvTheaters.DataSource = theaterServices.GetTheaters();
            gvTheaters.DataBind();
        }

        protected void gvTheaters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTheaterId = Convert.ToInt32(gvTheaters.SelectedDataKey.Value);
            Theater selectedTheater = theaterServices.GetTheater(selectedTheaterId);

            update_id = selectedTheaterId;
            dvTheaterDetails.DataSource = new[] { selectedTheater };
            dvTheaterDetails.DataBind();

            PopulateAvailableMovies();

            txtUpdateTheaterName.Text = selectedTheater.Name;
            txtUpdateTheaterAddress.Text = selectedTheater.Address;

            // Show the Update Theater button
            btnShowUpdateForm.Visible = true;
            btnAddMovieForm.Visible = true;
            btnDeleteTheater.Visible = true;
        }

        protected void btnAddTheater_Click(object sender, EventArgs e)
        {
            // Retrieve new theater details from input fields
            string name = txtNewTheaterName.Text;
            string address = txtNewTheaterAddress.Text;

            // Create a new Theater object
            Theater newTheater = new Theater
            {
                Name = name,
                Address = address
            };

            // Add the new theater
            string result = theaterServices.AddTheater(newTheater);

            // Refresh the grid view
            BindTheaters();

            // Display result to the user
            lblAddResult.Text = result;
            lblAddResult.Visible = true;

            // Clear input fields
            txtNewTheaterName.Text = string.Empty;
            txtNewTheaterAddress.Text = string.Empty;

        }

        protected void btnUpdateTheater_Click(object sender, EventArgs e)
        {
            string name = txtUpdateTheaterName.Text;
            string address = txtUpdateTheaterAddress.Text;
            int selectedTheaterId = Convert.ToInt32(gvTheaters.SelectedDataKey.Value);
            // Create a new Theater object
            Theater updateTheater = new Theater
            {

                Theater_Id = selectedTheaterId,
                Name = name,
                Address = address
            };

            // Implement the logic to update the selected theater here
            //int selectedTheaterId = Convert.ToInt32(gvTheaters.SelectedDataKey.Value);
            //Theater selectedTheater = theaterServices.GetTheater(selectedTheaterId);

            //selectedTheater.Name = "Updated Name";
            //selectedTheater.Address = "Updated Address";

            string result = theaterServices.UpdateTheater(updateTheater);
            BindTheaters(); // Refresh the gridview

            // Display result to the user
            lblUpdateResult.Text = result;
            lblUpdateResult.Visible = true;

            // Clear input fields
            txtUpdateTheaterName.Text = string.Empty;
            txtUpdateTheaterAddress.Text = string.Empty;

            btnShowUpdateForm.Visible = false;
            
           
        }

        protected void btnDeleteTheater_Click(object sender, EventArgs e)
        {
            // Implement the logic to delete the selected theater here
            int selectedTheaterId = Convert.ToInt32(gvTheaters.SelectedDataKey.Value);

            string result = theaterServices.DeleteTheater(selectedTheaterId);
            BindTheaters(); // Refresh the gridview
            // Display result to the user
        }

        protected void btnAddMovieToTheater_Click(object sender, EventArgs e)
        {
            int theaterId = Convert.ToInt32(gvTheaters.SelectedDataKey.Value);
            int movieId = Convert.ToInt32(ddlAvailableMovies.SelectedValue);
            int totalSeats = Convert.ToInt32(txtTotalSeats.Text);

            // Call the service method to add the movie to the theater
            string result = theaterServices.AddMovieToTheater(theaterId, movieId, totalSeats);

            // Display result to the user
            lblAddMovieResult.Text = result;
            lblAddMovieResult.Visible = true;

            // Clear input fields
            txtTotalSeats.Text = string.Empty;

            // If the result is successful, trigger the event handler to show the updated theater details
            if (result == "Movie added to theater successfully.")
            {
                gvTheaters_SelectedIndexChanged(sender, e);
            }
        }


        protected void btnGoToMovieManagement_Click(object sender, EventArgs e)
        {
            // Redirect to the Movie Management page
            Response.Redirect("MovieManagement.aspx");
        }
    }
}
