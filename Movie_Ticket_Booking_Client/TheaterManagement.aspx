<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TheaterManagement.aspx.cs" Inherits="Movie_Ticket_Booking_Client.TheaterManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Theater Management</title>
    <script type="text/javascript">
        function showAddTheaterForm() {
            document.getElementById('addTheaterForm').style.display = 'block';
        }
        function showUpdateTheaterForm() {
            document.getElementById('updateTheaterForm').style.display = 'block';
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
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Theater Management</h2>
            <hr />

            <asp:GridView ID="gvTheaters" runat="server" AutoGenerateColumns="False" DataKeyNames="Theater_Id"
                OnSelectedIndexChanged="gvTheaters_SelectedIndexChanged" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="Theater_Id" HeaderText="Theater ID" ReadOnly="True" SortExpression="Theater_Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:ButtonField ButtonType="Button" Text="View Details" CommandName="Select" />
                </Columns>
            </asp:GridView>

            <br />

            <asp:DetailsView ID="dvTheaterDetails" runat="server" AutoGenerateRows="False" DataKeyNames="Theater_Id"
                CssClass="table table-bordered">
                <Fields>
                    <asp:BoundField DataField="Theater_Id" HeaderText="Theater ID" ReadOnly="True" SortExpression="Theater_Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                </Fields>
            </asp:DetailsView>

            <br />

            <div class="text-center">
                <asp:Button ID="btnShowAddForm" runat="server" Text="Add New Theater" OnClientClick="showAddTheaterForm(); return false;"
                    CssClass="btn btn-primary" />
                <asp:Button ID="btnShowUpdateForm" runat="server" Text="Update Theater" OnClientClick="showUpdateTheaterForm(); return false;"
                    CssClass="btn btn-secondary" Visible="false" />
                <asp:Button ID="btnDeleteTheater" runat="server" Text="Delete Theater" OnClick="btnDeleteTheater_Click"
                    CssClass="btn btn-danger" />
            </div>

            <div id="addTheaterForm" style="display: none;">
                <h3>Add New Theater</h3>
                <asp:Label ID="lblAddResult" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <div class="form-group">
                    <asp:TextBox ID="txtNewTheaterName" runat="server" placeholder="Theater Name" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtNewTheaterAddress" runat="server" placeholder="Theater Address" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnAddTheater" runat="server" Text="Add Theater" OnClick="btnAddTheater_Click"
                        CssClass="btn btn-success" />
                </div>
            </div>

            <div id="updateTheaterForm" style="display: none;">
                <h3>Update Theater</h3>
                <!-- Update form fields -->
                <!-- Replace this with the form fields for updating a theater -->
                <asp:Label ID="lblUpdateResult" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <div class="form-group">
                    <asp:TextBox ID="txtUpdateTheaterName" runat="server" placeholder="Theater Name" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtUpdateTheaterAddress" runat="server" placeholder="Theater Address" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="Button1" runat="server" Text="Update Theater" OnClick="btnUpdateTheater_Click"
                        CssClass="btn btn-warning" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
