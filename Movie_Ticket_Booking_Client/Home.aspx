﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Movie_Ticket_Booking_Client.Home" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home</title>
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

        /* CSS styles for movie list */
        .movie-container {
            display: flex;
            flex-wrap: wrap;
        }

        .movie {
            width: 30%;
            margin: 20px;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        .movie h2 {
            margin-top: 0;
        }

        .movie p {
            margin: 5px 0;
        }

        .details-btn {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            border-radius: 5px;
            cursor: pointer;
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

        <div class="movie-container">
            <% foreach (var movie in Movies) { %>
                <div class="movie">
                    <h2><%= movie.Title %></h2>
                    <p><strong>Genre:</strong> <%= movie.Genre %></p>
                    <p><strong>Duration:</strong> <%= movie.Duration %></p>
                    <p><strong>Release Date:</strong> <%= movie.Release_Date %></p>
                    <a href="ViewMovie.aspx?Movie_Id=<%= movie.Movie_Id %>" class="details-btn">View Details</a>
                </div>
            <% } %>
        </div>

</body>
</html>

