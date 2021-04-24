using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace FlyweightLib
{
    public class TCPClient
    {
        TcpClient client;
        NetworkStream AgAkimi;
        StreamReader AkimOkuyucu;
        StreamWriter AkimYazici;


        public void Connect(int port)
        {
            client = new TcpClient("localhost", port);
            AgAkimi = client.GetStream();
            AkimOkuyucu = new StreamReader(AgAkimi);
            AkimYazici = new StreamWriter(AgAkimi);
        }

        public void Send(Packet packet)
        {
            try
            {
                AkimYazici.WriteLine(packet.GetBuffer());
                AkimYazici.Flush();
            }

            catch
            {
                //Console.WriteLine("Sunucuya baglanmada hata oldu...");
            }
        }

        public string Receive()
        {
            return AkimOkuyucu.ReadLine();
        }
    }
}