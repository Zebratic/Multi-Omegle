using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text; 
using System.Threading.Tasks;

namespace Multi_Omegle
{
    public class Client
    {
        public TcpClient TCPClient { get; set; }
        public bool Host { get; set; } = false;
        public Client(TcpClient tcpclient)
        {
            TCPClient = tcpclient;
        }
    }
}