using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Chatbot
{
    public class ChatbotHub : Hub
    {
        public void Send(string search)
        {
            // Call the recieveNewMessage method to update clients.
            Clients.Others.recieveNewResponse(search);
        }

        public void RoleOfComputer(bool isServer)
        {
            // Call the recieveNewMessage method to update clients.
            Clients.Others.recieveRole(isServer);
        }
    }
}