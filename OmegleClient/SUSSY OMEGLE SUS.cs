using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmegleSus
{
    public partial class Main : Form
    {

        public Thread currentHandler;
        public Thread listenerThread;
        public static TcpClient tcpclient = null;
        public static NetworkStream stream = null;
        public SeleniumMoment seleniumMoment = null;

        public Main()
        {
            InitializeComponent();
        }

        private void StartListener()
        {
            try
            {
                currentHandler = new Thread(() => HandleData(stream));
                currentHandler.Start();
            }
            catch
            {
                currentHandler.Abort();
                StartListener();
            }
        }

        public void HandleData(NetworkStream stream)
        {
            try
            {
                Byte[] bytes = new Byte[Byte.MaxValue];
                int i;
                string leftoverData = string.Empty;
                while (true)
                {
                    try
                    {
                        string recievedData = string.Empty;
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Recieve incoming stream data
                            recievedData = Encoding.UTF8.GetString(bytes, 0, i);

                            Console.WriteLine("DATA " + recievedData);
                            if (string.IsNullOrEmpty(recievedData))
                                continue;

                            string cmd = string.Empty;
                            string param = string.Empty;
                            try
                            {
                                cmd = recievedData.Split(new string[] { "<-->" }, StringSplitOptions.None)[0];
                                param = recievedData.Split(new string[] { "<-->" }, StringSplitOptions.None)[1];
                            }
                            catch { }
                            finally { recievedData = string.Empty; }

                            switch (cmd)
                            {
                                case "SendMessage":
                                    if (!string.IsNullOrWhiteSpace(param))
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            foreach (string msg in param.Split(new string[] { "\n" }, StringSplitOptions.None))
                                            {
                                                chatDisplay.SelectionColor = Color.White;
                                                chatDisplay.AppendText(chatDisplay.Text == "" ? $"{msg}" : $"\n{msg}");
                                            }

                                            chatDisplay.SelectionStart = chatDisplay.Text.Length;
                                            chatDisplay.ScrollToCaret();
                                        });

                                        if (cboxHost.Checked && seleniumMoment != null)
                                            seleniumMoment.SendMessage(param);
                                    }
                                    break;

                                case "GimmeInfoBitch":
                                    {
                                        if (!string.IsNullOrEmpty(param))
                                        {
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                txbInfo.Clear();
                                                chatDisplay.Clear();

                                                foreach (string msg in param.Split(new string[] { "\n" }, StringSplitOptions.None))
                                                {
                                                    txbInfo.SelectionColor = Color.White;
                                                    txbInfo.AppendText(txbInfo.Text == "" ? $"{msg}" : $"\n{msg}");
                                                }

                                                txbInfo.SelectionStart = txbInfo.Text.Length;
                                                txbInfo.ScrollToCaret();
                                            });
                                        }
                                    }
                                    break;

                                case "Skip":
                                    {
                                        if (!string.IsNullOrEmpty(param))
                                        {
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                txbInfo.Clear();
                                                chatDisplay.Clear();

                                                foreach (string msg in param.Split(new string[] { "\n" }, StringSplitOptions.None))
                                                {
                                                    txbInfo.SelectionColor = Color.White;
                                                    txbInfo.AppendText(txbInfo.Text == "" ? $"{msg}" : $"\n{msg}");
                                                }

                                                txbInfo.SelectionStart = txbInfo.Text.Length;
                                                txbInfo.ScrollToCaret();
                                            });
                                        }
                                    }
                                    break;


                                default:
                                    break;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch {  }
        }

        #region Establishing Connection
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbIpAddress.Text) && !string.IsNullOrEmpty(txbPort.Text))
            {
                if (!int.TryParse(txbPort.Text, out int lol))
                    return;

                new Thread(() =>
                {
                    EstablishConnection(txbIpAddress.Text, Convert.ToInt32(txbPort.Text));
                }).Start();
            }
        }

        private void EstablishConnection(string ip, int port)
        {
            int connectionAttempts = 0;
            Console.WriteLine("Done setting up form");
            while (!tcpclient.Connected)
            {
                Thread.Sleep(50);
                try
                {
                    tcpclient.Connect(ip, port);
                }
                catch
                {
                    connectionAttempts++;

                    if (connectionAttempts == 5)
                    {
                        if (MessageBox.Show("Failed to establish a connection with the server. \n Would you like to retry?", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) != DialogResult.Retry)
                        {
                            Environment.Exit(0);
                            Application.Exit();
                        }
                        connectionAttempts = 0;
                    }
                }
            }

            stream = tcpclient.GetStream();

            listenerThread = new Thread(() => StartListener());
            listenerThread.Start();
        }

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            btnSendMessage.FlatStyle = FlatStyle.Flat;
            btnSendMessage.FlatAppearance.BorderSize = 0;
            btnSkip.FlatStyle = FlatStyle.Flat;
            btnSkip.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnOpenBrowser.FlatStyle = FlatStyle.Flat;
            btnOpenBrowser.FlatAppearance.BorderSize = 0;

            btnOpenBrowser.Visible = false;
            cboxYeetIndians.Visible = false;
            tcpclient = new TcpClient();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbMessage.Text) && txbMessage.Text != " ")
            {
                string msg = txbMessage.Text;
                new Thread(() =>
                {
                    ServerCommands.BuildCommand(ServerCommands.SendMessage, msg);

                    txbMessage.Invoke((MethodInvoker)delegate { txbMessage.Text = ""; });
                }).Start();
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                ServerCommands.BuildCommand(ServerCommands.Skip);
            }).Start();
        }

        private void cboxHost_CheckedChanged(object sender, EventArgs e)
        {
            cboxYeetIndians.Visible = cboxHost.Checked;
            btnOpenBrowser.Visible = cboxHost.Checked;
            new Thread(() =>
            {
                ServerCommands.BuildCommand(ServerCommands.ChangeClientMode, cboxHost.Checked.ToString());
            }).Start();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (seleniumMoment != null)
                seleniumMoment.Shutdown();

            ServerCommands.BuildCommand(ServerCommands.IDISCONNECT);
            Application.Exit();
            Environment.Exit(69);
        }

        private void btnOpenBrowser_Click(object sender, EventArgs e)
        {
            if (seleniumMoment != null)
                seleniumMoment.Shutdown();

            seleniumMoment = new SeleniumMoment();
        }
    }
}