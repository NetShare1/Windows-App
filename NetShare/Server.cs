using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetShare
{
    public class Server
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }

        public Server(string name, string ip, int port)
        {
            Name = name;
            Ip = ip;
            Port = port;
        }

    }
}
