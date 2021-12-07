using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Omegle
{
    public class Utils
    {
        public static string GetLocalIP()
        {
            var DnsHostName = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var IP in DnsHostName.AddressList)
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                    return IP.ToString();

            return string.Empty;
        }

        #region Console design
        public static void WritePlus(string text, int ID = 0)
        {
            if (ID == 0)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("+");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ID);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }

        }

        public static void WriteWarning(string text, int ID = 0, bool newline = true, bool box = true)
        {
            if (ID == 0)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (box)
                {
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("] ");
                }

                Console.Write(text);

                if (newline)
                    Console.Write("\n");

                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                if (box)
                {
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("] ");
                }

                Console.Write(text);

                if (newline)
                    Console.Write("\n");

                Console.ForegroundColor = color;
            }
        }

        public static void WriteMinus(string text, int ID = 0)
        {
            if (ID == 0)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("] ");
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ID);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("] ");
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }
        }

        public static void WriteSelection(string text)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.Write(text);
            Console.ForegroundColor = color;
        }

        public static void WriteLine(string text, int ID = 0)
        {
            if (ID == 0)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] ");
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ID);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] ");
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }
        }

        public static void WriteNumber(int nr, string text, bool newline = true)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(nr);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.Write(text);
            if (newline)
                Console.Write("\n");

            Console.ForegroundColor = color;
        }

        public static void WriteKey(string Key, string text, bool newline = true)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Key);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.Write(text);
            if (newline)
                Console.Write("\n");

            Console.ForegroundColor = color;
        }

        public static void WriteGoodBad(string text, bool good = true, bool newline = true)
        {
            var color = Console.ForegroundColor;
            if (good)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(text);

            if (newline)
                Console.Write("\n");

            Console.ForegroundColor = color;
        }
        #endregion
    }
}