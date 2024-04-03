<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Movie_Ticket_Booking_Client.Login" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title>Login</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Add your CSS code here */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f8f9fa; /* Light gray background */
        }

        .container {
            /* Adjusted width */
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #fff; /* White background */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Shadow effect */
            max-width: 500px;
        }

        .form-group {
            margin-bottom: 0.5rem;
        }

        .form-group label {
            font-weight: bold;
        }

        .error-message {
            color: red;
            margin-top: 5px;
        }

        .heading {
            text-align: center;
            margin-bottom: 20px;
        }

        .heading h1 {
            font-size: 36px;
            color: #007bff; /* Blue color */
            margin-bottom: 10px;
        }

        .heading p {
            font-size: 18px;
            color: #6c757d; /* Gray color */
        }
    </style>
</head>
<body>
    <div class="heading">
        </br></br></br></br>
        <h1>Online Movie Ticket Booking</h1>
        <p>Purchase your movie tickets now and explore a wide selection of films!!</p>
    </div>
    <form id="form1" runat="server">
        <div class="container">
            <!-- <asp:Label ID="Label1" runat="server" ></asp:Label> -->
            <div class="form-group text-center">
                <h2>Login</h2>
            </div>
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" CssClass="error-message"></asp:RequiredFieldValidator>
                
            </div>
            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" CssClass="error-message"></asp:RequiredFieldValidator>
                
            </div>
            <div class="form-group text-center">
                <div class="d-grid gap-2">
                    <!-- Login Button -->
                    
              

     <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
 </div>
             
            </div>
            <div class="text-center">
                <p>Not a user yet? <a href="Register.aspx">REGISTER</a></p>
            </div>
        </div>
    </form>
</body>
</html>
