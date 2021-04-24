using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace FlyweightLib
{
    public class TCPServer
    {
        private TcpListener TcpDinleyicisi;

        [Obsolete]
        public TCPServer(int port)
        {
            TcpDinleyicisi = new TcpListener(port);
        }

        public void Start()
        {
            TcpDinleyicisi.Start();
            if (ServerStarted != null)
            {
                ServerStarted();
            }
            Socket IstemciSoketi = TcpDinleyicisi.AcceptSocket();
            if (!IstemciSoketi.Connected)
            {
                if (ClientAccepted != null)
                {
                    ClientAccepted(false);
                }
            }
            else
            {
                if (ClientAccepted != null)
                {
                    ClientAccepted(true);
                }
                while (true)
                {

                    //IstemciSoketi verilerini NetworkStream sinifi türünden nesneye aktariyoruz.
                    NetworkStream AgAkimi = new NetworkStream(IstemciSoketi);

                    //Soketteki bilgilerle islem yapabilmek için StreamReader ve StreamWriter siniflarini kullaniyoruz
                    StreamWriter AkimYazici = new StreamWriter(AgAkimi);
                    StreamReader AkimOkuyucu = new StreamReader(AgAkimi);


                    //StreamReader ile String veri tipine aktarma islemi önceden bir hata olursa bunu handle etmek gerek
                    try
                    {
                        string IstemciString = AkimOkuyucu.ReadLine();
                        if (ReceivePacket != null)
                        {
                            ReceivePacket(IstemciSoketi, AkimYazici, new Packet(IstemciString));
                        }

                        //Istemciden gelen bilginin uzunlugu hesaplaniyor
                        //int uzunluk = IstemciString.Length;

                        //AgAkimina, AkimYazını ile IstemciString inin uzunluğunu yazıyoruz
                        //AkimYazici.WriteLine(uzunluk.ToString());

                        //AkimYazici.Flush();
                    }

                    catch
                    {
                        //Console.WriteLine("Sunucu kapatiliyor...");
                        return;
                    }
                }
            }

            IstemciSoketi.Close();
        }

        public delegate void packet(Socket sender, StreamWriter writer, Packet packet);
        public delegate void NoneData();
        public delegate void Success(bool IsSuccess);
        public event packet ReceivePacket;
        public event NoneData ServerStarted;
        public event Success ClientAccepted;

    }
}
