using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Booking_Client
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                UserServices.UserServicesClient service1Client = new UserServices.UserServicesClient();

                UserServices.User user = service1Client.Login(email, password);
                Console.WriteLine(user);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Password);
                if (user != null)
                {
                    Session["userId"] = user.Id;
                    Session["userName"] = user.Name;
                    Console.WriteLine(Session["userId"]);

                    Console.WriteLine(Session["userName"]);
                    if (user.Email == "admin@gmail.com" && user.Name == "admin")
                    {
                        Response.Redirect("TheaterManagement.aspx");
                    }
                    Response.Redirect("TheaterManagement.aspx");
                }
                else
                {
                    Response.Write(email);

                }
            }
        }

    }
}