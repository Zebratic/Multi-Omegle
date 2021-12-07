using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OmegleSus
{
    public class ServerCommands
    {

        public const string ChangeClientMode    = "ChangeClientMode",
                            SendMessage         = "SendMessage",
                            Skip                = "Skip",
                            IDISCONNECT         = "IDISCONNECT";

        public static void BuildCommand(string commandtype, params string[] commandParameters)
        {
            string builtCommand = $"{commandtype}<-->";
            foreach (string param in commandParameters)
                builtCommand += param == commandParameters.Last() ? $"{param}" : $"{param}>--<";

            SendCommandToServer(builtCommand);
        }

        public static void SendCommandToServer(string msg)
        {
            try
            {
                byte[] sentData = new byte[Byte.MaxValue];
                sentData = Encoding.UTF8.GetBytes(msg);
                Main.stream.Write(sentData, 0, sentData.Length);
            }
            catch { }
        }
    }
}