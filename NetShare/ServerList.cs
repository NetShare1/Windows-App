using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShare
{
    class ServerList
    {
        List<Server> servers = new List<Server>();

        void addServer(string name, string ip, int port)
        {
            servers.Add(new Server(name, ip, port));
        }

        void deleteServer(Server server)
        {
            servers.Remove(server);
        }


    }
}
