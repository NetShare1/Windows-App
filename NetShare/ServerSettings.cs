using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * name: Manuel Lind
 * class: 5AHIF
 * number: i16022
*/

namespace NetShare
{
    public class ServerObject
    {
        public string name { get; set; }
        public string ip { get; set; }
        public int port { get; set; }
    }

    public class ServerSettings
    {
        public List<ServerObject> serverList { get; set; }

        public ServerSettings()
        {
            serverList = new List<ServerObject>();
        }
    }
}
