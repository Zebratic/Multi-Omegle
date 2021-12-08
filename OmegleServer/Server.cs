using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_Omegle
{
    public class Server
    {
        public static List<Client> ConnectedClients = new List<Client>();
        TcpListener server = null;
        public Server(string ip, int tcpport)
        {
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, tcpport);
            server.Start();
            new Thread(StartTCPListener).Start();
        }

        public void StartTCPListener()
        {
            Console.WriteLine("Now listening on TCP Socket");
            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    new Thread(() => HandleTCPData(client)).Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Thread.Sleep(500);
                }
            }
        }

        public void HandleTCPData(TcpClient tcpClient)
        {
            IPEndPoint endPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
            if (Program.BannedIPs.Contains(endPoint.Address.ToString()))
                return;


            ConnectedClients.Add(new Client(tcpClient));

            Console.WriteLine($"Connected from: {endPoint.Address}:{endPoint.Port}");
            
            NetworkStream stream = tcpClient.GetStream();
            Byte[] bytes = new Byte[Byte.MaxValue];
            int i;
            bool dontCloseStream = true;
            while (true)
            {
                try
                {
                    if (stream.DataAvailable)
                    {
                        string recievedData = string.Empty;
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {

                            recievedData = Encoding.UTF8.GetString(bytes, 0, i);

                            Utils.WriteGoodBad($"Received: {recievedData}", true, true);
                            if (string.IsNullOrEmpty(recievedData))
                                continue;

                            try
                            {
                                string cmd = string.Empty;
                                string param = string.Empty;
                                try
                                {
                                    cmd = recievedData.Split(new string[] { "<-->" }, StringSplitOptions.None)[0];
                                    param = recievedData.Split(new string[] { "<-->" }, StringSplitOptions.None)[1];
                                }
                                catch { }

                                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                                rgx.Replace(cmd, ""); // fix potential corrupted packet header

                                if (cmd.Contains(">")) // detected corrupted packet header
                                    cmd = cmd.Substring(cmd.IndexOf(">") + 1);

                                switch (cmd)
                                {
                                    case "ChangeClientMode":
                                        {
                                            bool ishost = Convert.ToBoolean(param);
                                            Client client = ConnectedClients.Find(x => x.TCPClient == tcpClient);
                                            if (client != null)
                                            {
                                                if (ishost)
                                                    Utils.WriteKey(">", $"{endPoint.Address} has been promoted host", true);
                                                else
                                                    Utils.WriteKey("<", $"{endPoint.Address} has been demoted host", true);

                                                client.Host = ishost;
                                            }
                                        }
                                        break;

                                    case "IDISCONNECT":
                                        {
                                            Client client = ConnectedClients.Find(x => x.TCPClient == tcpClient);
                                            if (client != null)
                                            {
                                                ConnectedClients.Remove(client);
                                                client.TCPClient.Close();
                                                return;
                                            }
                                        }
                                        break;

                                    case "GimmeInfoBitch":
                                        {
                                            Utils.WriteKey("[MULTI-OMEGLE]", $"New omegle user!", true);
                                            foreach (Client client in ConnectedClients)
                                                SendMessageToClient(client.TCPClient.GetStream(), recievedData);
                                        }
                                        break;

                                    default:
                                        Console.WriteLine($"Redirecting: \"{recievedData}\" to all clients");
                                        foreach (Client client in ConnectedClients)
                                            SendMessageToClient(client.TCPClient.GetStream(), recievedData + "<-->");
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Utils.WriteGoodBad($"Malformed request from: {endPoint.Address}:{endPoint.Port}", false, true);
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.WriteGoodBad($"[ERROR]: {ex}", false, true);
                    dontCloseStream = false;
                }

                if (!dontCloseStream)
                {
                    try { ConnectedClients.Remove(ConnectedClients.Find(x => x.TCPClient == tcpClient)); } catch { }
                    try { tcpClient.Close(); } catch { }
                    break;
                }
            }
        }

        public void SendMessageToClient(NetworkStream stream, string msg)
        {
            byte[] sentData = Encoding.UTF8.GetBytes(msg);
            stream.Write(sentData, 0, sentData.Length);
        }
    }
}