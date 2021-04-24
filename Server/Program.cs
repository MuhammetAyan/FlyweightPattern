using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyweightLib;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            Console.Title = "Server";
            Drawer.Size = new System.Drawing.Size(100, 30);
            var server = new TCPServer(1234);
            server.ReceivePacket += Server_ReceivePacket;
            server.Start();
        }

        private static void Server_ReceivePacket(Socket sender, StreamWriter writer, Packet packet)
        {
            Shape shape = packet.ToShape();
            Drawer.Draw(shape);

        }
    }
}
