<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Movie_Ticket_Booking_Client.Register" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title>Register</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Add your additional CSS code here */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f8f9fa; /* Light gray background */
        }

        .container {
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #fff; /* White background */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Shadow effect */
            max-width: 500px;
            margin: 20px auto;
        }

        .form-group {
            margin-bottom: 20px;
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
        <h1>Online Movie Ticket Booking</h1>
        <p>Create an account to access our services!</p>
    </div>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-group text-center">
                <h2>Register</h2>
            </div>
            <div class="form-group">
                <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required" CssClass="error-message"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" CssClass="error-message"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format" CssClass="error-message"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPhoneNumber" runat="server" AssociatedControlID="txtPhoneNumber" Text="Phone Number"></asp:Label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone number is required" CssClass="error-message"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid phone number format" CssClass="error-message"
                    ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" CssClass="error-message"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmPassword" Text="Confirm Password"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required" CssClass="error-message"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPasswordMatch" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                    ErrorMessage="Passwords do not match" CssClass="error-message"></asp:CompareValidator>
            </div>
            <div class="form-group text-center">
                <div class="d-grid gap-2">
                    <!-- Register Button -->
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="text-center">
                <p>Already have an account? <a href="Login.aspx">LOGIN</a></p>
            </div>
        </div>
    </form>
</body>
</html>
