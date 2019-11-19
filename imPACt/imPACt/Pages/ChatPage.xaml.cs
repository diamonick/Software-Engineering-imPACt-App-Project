
using imPACt.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace imPACt.Pages
{
    public partial class ChatPage : ContentPage
    {
        private string _name;
        private int _id;
        private string _message;
        private ObservableCollection<Message> _messages;
        private bool _isConnected;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        //public int IdNum
        //{
        //    get
        //    {
        //        return _id;
        //    }
        //    set
        //    {
        //        _id = value;
        //        OnPropertyChanged();
        //    }
        //}

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Message> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }

        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                OnPropertyChanged();
            }
        }

        private HubConnection hubConnection;
        public Command SendMessageCommand { get; }
        public Command ConnectCommand { get; }
        public Command DisconnectCommand { get; }

        


        public ChatPage()
        {
            InitializeComponent();

            Messages = new ObservableCollection<Message>();
            SendMessageCommand = new Command(async () => { await SendMessage(Name, Message); });
            ConnectCommand = new Command(async () => await Connect());
            DisconnectCommand = new Command(async () => await Disconnect());

            IsConnected = false;

            hubConnection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:44304")
                .Build();

            hubConnection.On<string>("JoinChat", (user) =>
            {
                Messages.Add(new Message() { User = Name, MessageContent = $"{user} has joined the chat", IsSystemMessage = true });
            });

            hubConnection.On<string>("LeaveChat", (user) =>
            {
                Messages.Add(new Message() { User = Name, MessageContent = $"{user} has left the chat", IsSystemMessage = true });
            });

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Messages.Add(new Message() { User = user, MessageContent = message, IsSystemMessage = false, IsOwnMessage = Name == user });
            });
        }

        async Task Connect()
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("JoinChat", Name);

            IsConnected = true;
        }

        async Task SendMessage(string user, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", user, message);
        }

        async Task Disconnect()
        {
            await hubConnection.InvokeAsync("LeaveChat", Name);
            await hubConnection.StopAsync();

            IsConnected = false;
        }

        //protected override void OnPropertyChanged(
        //[System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        //{
            //OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        //}
    }
}