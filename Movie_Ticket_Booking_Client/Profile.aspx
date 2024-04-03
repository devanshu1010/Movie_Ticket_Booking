<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Movie_Ticket_Booking_Client.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Profile</title>
    <script type="text/javascript">
        function confirmDelete() {
            return confirm("Are you sure you want to delete this ticket?");
        }
    </script>
    <style>
        /* CSS styles for navigation bar */
        body {
            margin: 0;
            padding: 0;
        }

        .navbar {
            background-color: #333;
            overflow: hidden;
        }

        .navbar a {
            float: left;
            display: block;
            color: white;
            text-align: center;
            padding: 14px 20px;
            text-decoration: none;
        }

        .navbar a.right {
            float: right;
        }

        .container {
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            max-width: 800px;
            margin: 20px auto;
        }

        h2 {
            margin-top: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .error-message {
            color: red;
            margin-top: 5px;
        }
    </style>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="Home.aspx">Online Book Ticket</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="Home.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Profile.aspx">Profile</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Logout.aspx">Logout</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">User Profile</h2>
            <hr />

            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <div class="form-group">
                        <label for="lblName">Name:</label>
                        <asp:Label ID="lblName" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="lblEmail">Email:</label>
                        <asp:Label ID="lblEmail" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="lblPhone">Phone Number:</label>
                        <asp:Label ID="lblPhone" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>

            <h3 class="text-center">Booked Tickets</h3>
            <asp:Label ID="lblNoTickets" runat="server" CssClass="form-control" Visible="false" />
            <asp:Label ID="lblMessage" runat="server" CssClass="form-control" Visible="false" />
            <asp:GridView ID="gvBookedTickets" runat="server" AutoGenerateColumns="False" DataKeyNames="Ticket_Id" CssClass="table table-bordered" OnRowCommand="gvBookedTickets_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Ticket_Id" HeaderText="Ticket ID" ReadOnly="True" SortExpression="Ticket_Id" />
                    <asp:BoundField DataField="Movie_Id" HeaderText="Movie ID" SortExpression="Movie_Id" />
                    <asp:BoundField DataField="Theater_Id" HeaderText="Theater ID" SortExpression="Theater_Id" />
                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" SortExpression="Date" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Seat_no" HeaderText="Seat Number" SortExpression="Seat_no" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button runat="server" CommandName="DeleteTicket" CommandArgument='<%# Eval("Ticket_Id") %>' Text="Delete" CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
