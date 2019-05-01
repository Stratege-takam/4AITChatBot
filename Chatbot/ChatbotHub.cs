using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Chatbot
{
    public class ChatbotHub : Hub
    {
        public void SendClient(string question)
        {
            // Call the recieveServer method to update clients.
            Clients.Others.recieveServer(question);
        }

        public void SendServer(bool singleMessage , string response)
        {
            // Call the recieveClient method to update clients.
            Clients.All.recieveClientAndServer(singleMessage,response);
        }

        public void RoleOfComputer(bool isServer)
        {
            // Call the recieveNewMessage method to update clients.
            Clients.Others.recieveRole(isServer);
        }
    }
}