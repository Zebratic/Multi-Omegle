using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Omegle
{
    public class Program
    {
        public static Server server { get; set; }
        public static List<string> BannedIPs = new List<string>();
        public static string IP { get; set; } = string.Empty;
        public static int Port { get; set; } = 6969;
        static void Main(string[] args)
        {
            try
            {
                if (!string.IsNullOrEmpty(args[0]))
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        try
                        {
                            if (args[i].ToLower() == "-ip")
                            {
                                IP = args[i + 1];
                                Utils.WriteGoodBad($"Loaded Argument: {args[i]} {args[i + 1]}", true, true);
                            }
                            else if (args[i].ToLower() == "-port")
                            {
                                Port = Convert.ToInt32(args[i + 1]);
                                Utils.WriteGoodBad($"Loaded Argument: {args[i]} {args[i + 1]}", true, true);
                            }
                            else if (args[i].ToLower() == "-banip")
                            {
                                BannedIPs.Add(args[i + 1]);
                                Utils.WriteGoodBad($"Loaded Argument: {args[i]} {args[i + 1]}", true, true);
                            }
                        }
                        catch
                        {
                            Utils.WriteGoodBad($"Bad argument : {args[i]} {args[i + 1]}", false, true);
                        }
                    }
                }
            }
            catch { }

            if (IP == string.Empty)
                IP = Utils.GetLocalIP();
            if (IP == string.Empty)
            {
                Utils.WriteGoodBad("[!] LOCAL IP NOT FOUND! [!]", false, true);
                Utils.WriteKey(">", "Please manually enter IP: ", false);
                IP = Console.ReadLine();
            }

            try
            {
                server = new Server(IP, Port);
                Utils.WriteGoodBad($"Server started on {IP}:{Port}", true, true);
            }
            catch (Exception ex)
            {
                Utils.WriteGoodBad($"[ERROR]: {ex.Message}", false, true);
            }
        }
    }
}