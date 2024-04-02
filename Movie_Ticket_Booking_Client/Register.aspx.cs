using Movie_Ticket_Booking_Client.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Booking_Client
{
    public partial class Register : System.Web.UI.Page
    {
        private IUserServices userServices = new UserServicesClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string phoneNumber = txtPhoneNumber.Text;

            // Create a new user object
            User newUser = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Phone_no = phoneNumber // Set the phone number
            };

            // Call the SignUp method of User Services
            userServices.SignUp(newUser);

            // Redirect to login page after successful registration
            Response.Redirect("Login.aspx");
        }

    }
}