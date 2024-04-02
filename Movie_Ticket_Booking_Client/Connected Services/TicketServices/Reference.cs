﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Movie_Ticket_Booking_Client.TicketServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ticket", Namespace="http://schemas.datacontract.org/2004/07/Movie_Ticket_Booking_Services.Models")]
    [System.SerializableAttribute()]
    public partial class Ticket : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Movie_IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal Seat_noField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Theater_IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Ticket_IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int User_IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Movie_Id {
            get {
                return this.Movie_IdField;
            }
            set {
                if ((this.Movie_IdField.Equals(value) != true)) {
                    this.Movie_IdField = value;
                    this.RaisePropertyChanged("Movie_Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Seat_no {
            get {
                return this.Seat_noField;
            }
            set {
                if ((this.Seat_noField.Equals(value) != true)) {
                    this.Seat_noField = value;
                    this.RaisePropertyChanged("Seat_no");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Theater_Id {
            get {
                return this.Theater_IdField;
            }
            set {
                if ((this.Theater_IdField.Equals(value) != true)) {
                    this.Theater_IdField = value;
                    this.RaisePropertyChanged("Theater_Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Ticket_Id {
            get {
                return this.Ticket_IdField;
            }
            set {
                if ((this.Ticket_IdField.Equals(value) != true)) {
                    this.Ticket_IdField = value;
                    this.RaisePropertyChanged("Ticket_Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int User_Id {
            get {
                return this.User_IdField;
            }
            set {
                if ((this.User_IdField.Equals(value) != true)) {
                    this.User_IdField = value;
                    this.RaisePropertyChanged("User_Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TicketServices.ITicketServices")]
    public interface ITicketServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketServices/GetTickets", ReplyAction="http://tempuri.org/ITicketServices/GetTicketsResponse")]
        Movie_Ticket_Booking_Client.TicketServices.Ticket[] GetTickets();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketServices/GetTickets", ReplyAction="http://tempuri.org/ITicketServices/GetTicketsResponse")]
        System.Threading.Tasks.Task<Movie_Ticket_Booking_Client.TicketServices.Ticket[]> GetTicketsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketServices/GetTicket", ReplyAction="http://tempuri.org/ITicketServices/GetTicketResponse")]
        Movie_Ticket_Booking_Client.TicketServices.Ticket GetTicket(int ticketId, int userId, int movieId, int theaterId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketServices/GetTicket", ReplyAction="http://tempuri.org/ITicketServices/GetTicketResponse")]
        System.Threading.Tasks.Task<Movie_Ticket_Booking_Client.TicketServices.Ticket> GetTicketAsync(int ticketId, int userId, int movieId, int theaterId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketServices/BookTicket", ReplyAction="http://tempuri.org/ITicketServices/BookTicketResponse")]
        string BookTicket(Movie_Ticket_Booking_Client.TicketServices.Ticket ticket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketServices/BookTicket", ReplyAction="http://tempuri.org/ITicketServices/BookTicketResponse")]
        System.Threading.Tasks.Task<string> BookTicketAsync(Movie_Ticket_Booking_Client.TicketServices.Ticket ticket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketServices/DeleteTicket", ReplyAction="http://tempuri.org/ITicketServices/DeleteTicketResponse")]
        string DeleteTicket(int ticketId, int userId, int movieId, int theaterId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketServices/DeleteTicket", ReplyAction="http://tempuri.org/ITicketServices/DeleteTicketResponse")]
        System.Threading.Tasks.Task<string> DeleteTicketAsync(int ticketId, int userId, int movieId, int theaterId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITicketServicesChannel : Movie_Ticket_Booking_Client.TicketServices.ITicketServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TicketServicesClient : System.ServiceModel.ClientBase<Movie_Ticket_Booking_Client.TicketServices.ITicketServices>, Movie_Ticket_Booking_Client.TicketServices.ITicketServices {
        
        public TicketServicesClient() {
        }
        
        public TicketServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TicketServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Movie_Ticket_Booking_Client.TicketServices.Ticket[] GetTickets() {
            return base.Channel.GetTickets();
        }
        
        public System.Threading.Tasks.Task<Movie_Ticket_Booking_Client.TicketServices.Ticket[]> GetTicketsAsync() {
            return base.Channel.GetTicketsAsync();
        }
        
        public Movie_Ticket_Booking_Client.TicketServices.Ticket GetTicket(int ticketId, int userId, int movieId, int theaterId) {
            return base.Channel.GetTicket(ticketId, userId, movieId, theaterId);
        }
        
        public System.Threading.Tasks.Task<Movie_Ticket_Booking_Client.TicketServices.Ticket> GetTicketAsync(int ticketId, int userId, int movieId, int theaterId) {
            return base.Channel.GetTicketAsync(ticketId, userId, movieId, theaterId);
        }
        
        public string BookTicket(Movie_Ticket_Booking_Client.TicketServices.Ticket ticket) {
            return base.Channel.BookTicket(ticket);
        }
        
        public System.Threading.Tasks.Task<string> BookTicketAsync(Movie_Ticket_Booking_Client.TicketServices.Ticket ticket) {
            return base.Channel.BookTicketAsync(ticket);
        }
        
        public string DeleteTicket(int ticketId, int userId, int movieId, int theaterId) {
            return base.Channel.DeleteTicket(ticketId, userId, movieId, theaterId);
        }
        
        public System.Threading.Tasks.Task<string> DeleteTicketAsync(int ticketId, int userId, int movieId, int theaterId) {
            return base.Channel.DeleteTicketAsync(ticketId, userId, movieId, theaterId);
        }
    }
}
