<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieManagement.aspx.cs" Inherits="Movie_Ticket_Booking_Client.MovieManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Management</title>
    <script type="text/javascript">
        function showAddMovieForm() {
            document.getElementById('btnShowAddForm').style.display = 'none';
            document.getElementById('addMovieForm').style.display = 'block';
            document.getElementById('updateMovieForm').style.display = 'none';
        }
        function showUpdateMovieForm() {
            document.getElementById('addMovieForm').style.display = 'none';
            document.getElementById('btnShowUpdateForm').style.display = 'none'; // Hide add form
            document.getElementById('updateMovieForm').style.display = 'block';
        }
    </script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Add your additional CSS code here */
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
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="TheaterManagement.aspx">Online Book Ticket</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="Logout.aspx">Logout</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Movie Management</h2>
            <hr />

            <div class="text-center mb-3">
                <asp:Button ID="btnGoToTheaterManagement" runat="server" Text="Go to Theater Management" OnClick="btnGoToTheaterManagement_Click"
                    CssClass="btn btn-primary" />
            </div>
            <asp:Label ID="message" runat="server" CssClass="text-success" />
            <asp:Label ID="message2" runat="server" CssClass="text-success" />
            <asp:GridView ID="gvMovies" runat="server" AutoGenerateColumns="False" DataKeyNames="Movie_Id"
                OnSelectedIndexChanged="gvMovies_SelectedIndexChanged" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="Movie_Id" HeaderText="Movie ID" ReadOnly="True" SortExpression="Movie_Id" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                    <asp:BoundField DataField="Release_Date" HeaderText="Release Date" DataFormatString="{0:yyyy-MM-dd}" SortExpression="Release_Date" />
                    <asp:BoundField DataField="Duration" HeaderText="Duration (minutes)" SortExpression="Duration" />
                    <asp:ButtonField ButtonType="Button" Text="View Details" CommandName="Select" />
                </Columns>
            </asp:GridView>


            <br />

            <asp:DetailsView ID="dvMovieDetails" runat="server" AutoGenerateRows="False" DataKeyNames="Movie_Id"
                CssClass="table table-bordered">
                <Fields>
                    <asp:BoundField DataField="Movie_Id" HeaderText="Movie ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" />
                    <asp:BoundField DataField="Release_Date" HeaderText="Release Date" />
                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                    
                </Fields>
            </asp:DetailsView>


            <br />

            <div class="text-center">
                <asp:Button ID="btnShowAddForm" runat="server" Text="Add New Movie" OnClientClick="showAddMovieForm(); return false;" CssClass="btn btn-primary"/>
                <asp:Button ID="btnShowUpdateForm" runat="server" Text="Update Movie" OnClientClick="showUpdateMovieForm(); return false;" CssClass="btn btn-secondary" Visible="false" />
                <asp:Button ID="btnDeleteMovie" runat="server" Text="Delete Movie" OnClick="btnDeleteMovie_Click" CssClass="btn btn-danger" Visible="false"/>
            </div>

      
            <div id="addMovieForm" style="display: none;">
                <h3>Add New Movie</h3>
                <asp:Label ID="lblAddResult" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <div class="form-group">
                    <asp:TextBox ID="txtNewMovieTitle" runat="server" placeholder="Movie Title" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtNewMovieGenre" runat="server" placeholder="Movie Genre" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtNewMovieReleaseDate" runat="server" placeholder="Release Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtNewMovieDuration" runat="server" placeholder="Duration" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnAddMovie" runat="server" Text="Add Movie" OnClick="btnAddMovie_Click"
                        CssClass="btn btn-success" />
                </div>
            </div>


            <div id="updateMovieForm" style="display: none;">
                <h3>Update Movie</h3>
                <!-- Update form fields -->
                <!-- Replace this with the form fields for updating a theater -->
                <asp:Label ID="lblUpdateResult" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <div class="form-group">
                    <asp:TextBox ID="txtUpdateMovieTitle" runat="server" placeholder="Movie Title" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtUpdateMovieGenre" runat="server" placeholder="Movie Genre" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtUpdateMovieReleaseDate" runat="server" placeholder="Movie Release" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtUpdateMovieDuration" runat="server" placeholder="Movie Duration" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnUpdateMovie" runat="server" Text="Update Movie" OnClick="btnUpdateMovie_Click"
                        CssClass="btn btn-warning" />
                </div>
            </div>

            

            <!-- Labels to display add/update/delete results -->
            <asp:Label ID="Label1" runat="server" CssClass="text-success" Visible="false"></asp:Label>
            <asp:Label ID="Label2" runat="server" CssClass="text-success" Visible="false"></asp:Label>
            <asp:Label ID="lblDeleteResult" runat="server" CssClass="text-success" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
