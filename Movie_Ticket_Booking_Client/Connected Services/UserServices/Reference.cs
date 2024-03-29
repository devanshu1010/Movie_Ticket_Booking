﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Movie_Ticket_Booking_Client.UserServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Movie_Ticket_Booking_Services.Models")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Phone_noField;
        
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
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone_no {
            get {
                return this.Phone_noField;
            }
            set {
                if ((object.ReferenceEquals(this.Phone_noField, value) != true)) {
                    this.Phone_noField = value;
                    this.RaisePropertyChanged("Phone_no");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServices.IUserServices")]
    public interface IUserServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServices/GetUsers", ReplyAction="http://tempuri.org/IUserServices/GetUsersResponse")]
        System.Data.DataSet GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServices/GetUsers", ReplyAction="http://tempuri.org/IUserServices/GetUsersResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServices/GetUser", ReplyAction="http://tempuri.org/IUserServices/GetUserResponse")]
        Movie_Ticket_Booking_Client.UserServices.User GetUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServices/GetUser", ReplyAction="http://tempuri.org/IUserServices/GetUserResponse")]
        System.Threading.Tasks.Task<Movie_Ticket_Booking_Client.UserServices.User> GetUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServices/SignUp", ReplyAction="http://tempuri.org/IUserServices/SignUpResponse")]
        void SignUp(Movie_Ticket_Booking_Client.UserServices.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServices/SignUp", ReplyAction="http://tempuri.org/IUserServices/SignUpResponse")]
        System.Threading.Tasks.Task SignUpAsync(Movie_Ticket_Booking_Client.UserServices.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServices/Login", ReplyAction="http://tempuri.org/IUserServices/LoginResponse")]
        Movie_Ticket_Booking_Client.UserServices.User Login(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServices/Login", ReplyAction="http://tempuri.org/IUserServices/LoginResponse")]
        System.Threading.Tasks.Task<Movie_Ticket_Booking_Client.UserServices.User> LoginAsync(string email, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServicesChannel : Movie_Ticket_Booking_Client.UserServices.IUserServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServicesClient : System.ServiceModel.ClientBase<Movie_Ticket_Booking_Client.UserServices.IUserServices>, Movie_Ticket_Booking_Client.UserServices.IUserServices {
        
        public UserServicesClient() {
        }
        
        public UserServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
        
        public Movie_Ticket_Booking_Client.UserServices.User GetUser(int id) {
            return base.Channel.GetUser(id);
        }
        
        public System.Threading.Tasks.Task<Movie_Ticket_Booking_Client.UserServices.User> GetUserAsync(int id) {
            return base.Channel.GetUserAsync(id);
        }
        
        public void SignUp(Movie_Ticket_Booking_Client.UserServices.User user) {
            base.Channel.SignUp(user);
        }
        
        public System.Threading.Tasks.Task SignUpAsync(Movie_Ticket_Booking_Client.UserServices.User user) {
            return base.Channel.SignUpAsync(user);
        }
        
        public Movie_Ticket_Booking_Client.UserServices.User Login(string email, string password) {
            return base.Channel.Login(email, password);
        }
        
        public System.Threading.Tasks.Task<Movie_Ticket_Booking_Client.UserServices.User> LoginAsync(string email, string password) {
            return base.Channel.LoginAsync(email, password);
        }
    }
}
