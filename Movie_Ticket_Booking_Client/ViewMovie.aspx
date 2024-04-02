<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMovie.aspx.cs" Inherits="Movie_Ticket_Booking_Client.ViewMovie" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Movie Details</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Navbar -->
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <a class="navbar-brand" href="#">Book Ticket</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Profile</a>
                        </li>
                    </ul>
                </div>
            </nav>

            <!-- Movie Details -->
            <div class="card mt-4">
                <div class="card-body">
                    <h5 class="card-title">Movie Details</h5>
                    <ul>
                        <li><strong>Title:</strong> <asp:Label ID="lblTitle" runat="server" /></li>
                        <li><strong>Genre:</strong> <asp:Label ID="lblGenre" runat="server" /></li>
                        <li><strong>Release Date:</strong> <asp:Label ID="lblReleaseDate" runat="server" /></li>
                        <li><strong>Duration:</strong> <asp:Label ID="lblDuration" runat="server" /></li>
                    </ul>
                </div>
            </div>

            <!-- List of Theaters -->
            <div class="card mt-4">
                <div class="card-body">
                    <h5 class="card-title">Theaters</h5>
                    <asp:Repeater ID="rptTheaters" runat="server">
                        <ItemTemplate>
                            <div class="card mt-2">
                                <div class="card-body">
                                    <h6 class="card-title">Theater: <%# Eval("Name") %></h6>
                                    <p class="card-text"><strong>Address:</strong> <%# Eval("Address") %></p>
                                    
                                    <asp:Button runat="server" Text="Book Ticket" CssClass="btn btn-primary" CommandName="BookTicket" CommandArgument='<%# Eval("Theater_Id") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>