using Movie_Ticket_Booking_Client.MovieServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Booking_Client
{
    public partial class MovieManagement : System.Web.UI.Page
    {
        private readonly MovieServices.MovieServicesClient movieServices = new MovieServices.MovieServicesClient();
        private int update_id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMovies();
            }
        }

        protected void BindMovies()
        {
            // Retrieve the movies
            Movie[] theatersArray = movieServices.GetMovies();
            List<Movie> movies = theatersArray.ToList();

            // Bind the data to the GridView
            gvMovies.DataSource = movies;
            gvMovies.DataBind();

        }

        protected void gvMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedMovieId = Convert.ToInt32(gvMovies.SelectedDataKey.Value);
            Movie selectedMovie = movieServices.GetMovie(selectedMovieId);

            update_id = selectedMovieId;
            //TheaterMovie[] theatersArray = selectedMovie.Theaters;

            //message.Text = selectedMovie.Theaters.ToString();
            //message2.Text = theatersArray.ToString();// selectedMovie.Theaters.ToString();
            //message.Text = selectedMovieId.ToString();

            // Convert the array to a list
            //List<TheaterMovie> theaters = selectedMovie.Theaters.ToList();

            // Bind the selected movie details to the DetailsView
            dvMovieDetails.DataSource = new[] { selectedMovie };
            dvMovieDetails.DataBind();

            // Show the Update Theater button
            btnShowUpdateForm.Visible = true;
            // Show the Update Movie button
            /*btnShowAddForm.Visible = false;
            btnUpdateMovie.Visible = true;*/
            btnDeleteMovie.Visible = true;

            // Populate update movie form fields
            txtUpdateMovieTitle.Text = selectedMovie.Title;
            txtUpdateMovieGenre.Text = selectedMovie.Genre;
            txtUpdateMovieReleaseDate.Text = selectedMovie.Release_Date.ToString("yyyy-MM-dd");
            txtUpdateMovieDuration.Text = selectedMovie.Duration.TotalMinutes.ToString();
                
        }

        protected void btnAddMovie_Click(object sender, EventArgs e)
        {
            // Retrieve movie details from input fields
            string title = txtNewMovieTitle.Text;
            Console.WriteLine(title);
            string genre = txtNewMovieGenre.Text;
            Console.WriteLine(genre);
            DateTime releaseDate = Convert.ToDateTime(txtNewMovieReleaseDate.Text);
            Console.WriteLine(releaseDate); 
            TimeSpan duration = TimeSpan.FromMinutes(Convert.ToDouble(txtNewMovieDuration.Text));
            Console.WriteLine(duration);

            // Create a new Movie object
            Movie newMovie = new Movie
            {
                Title = title,
                Genre = genre,
                Release_Date = releaseDate,
                Duration = duration
            };

            // Add the new movie
            string result = movieServices.AddMovie(newMovie);

            // Refresh the GridView
            BindMovies();

            // Display result to the user
            lblAddResult.Text = result;
            lblAddResult.Visible = true;

            // Clear input fields
            txtNewMovieTitle.Text = string.Empty;
            txtNewMovieGenre.Text = string.Empty;
            txtNewMovieReleaseDate.Text = string.Empty;
            txtNewMovieDuration.Text = string.Empty;
        }

        protected void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            int selectedMovieId = Convert.ToInt32(gvMovies.SelectedDataKey.Value);
            // Retrieve updated movie details from input fields
            string title = txtUpdateMovieTitle.Text;
            string genre = txtUpdateMovieGenre.Text;
            DateTime releaseDate = Convert.ToDateTime(txtUpdateMovieReleaseDate.Text);
            TimeSpan duration = TimeSpan.FromMinutes(Convert.ToDouble(txtUpdateMovieDuration.Text));

            // Create a new Movie object
            Movie updatedMovie = new Movie
            {
                Movie_Id = selectedMovieId,
                Title = title,
                Genre = genre,
                Release_Date = releaseDate,
                Duration = duration
            };

            // Update the selected movie
            string result = movieServices.UpdateMovie(updatedMovie);

            // Refresh the GridView
            BindMovies();

            // Display result to the user
            lblUpdateResult.Text = result;
            lblUpdateResult.Visible = true;

            // Clear input fields
            txtUpdateMovieTitle.Text = string.Empty;
            txtUpdateMovieGenre.Text = string.Empty;
            txtUpdateMovieReleaseDate.Text = string.Empty;
            txtUpdateMovieDuration.Text = string.Empty;

            // Hide the Update Movie button
            //btnShowAddForm.Visible = true;
            btnUpdateMovie.Visible = false;
            //btnDeleteMovie.Visible = false;
        }

        protected void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            int selectedMovieId = Convert.ToInt32(gvMovies.SelectedDataKey.Value);

            // Delete the selected movie
            string result = movieServices.DeleteMovie(selectedMovieId);

            // Refresh the GridView
            BindMovies();

            // Display result to the user
            lblDeleteResult.Text = result;
            lblDeleteResult.Visible = true;
        }

        protected void btnGoToTheaterManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("TheaterManagement.aspx");
        }

    }
}
