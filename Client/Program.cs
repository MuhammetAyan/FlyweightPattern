using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyweightLib;

namespace Client
{
    class Program
    {
        static List<string[]> images;
        static void Main(string[] args)
        {
            TCPClient client = new TCPClient();
            client.Connect(1234);
            while (true)
            {
                try
                {
                    Shape shape = GenerateShape();
                    client.Send(new Packet(shape));
                    Console.Clear();
                    Console.WriteLine("Şekil gönderildi.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata:" + ex.Message);
                    Console.WriteLine("Devam etmek için bir tuşa basınız...");
                    Console.ReadKey();
                    Console.Clear();
                }


            }

        }

        private static void LoadImages()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..";
            images = new List<string[]>();
            Random random = new Random();
            foreach (var file in System.IO.Directory.GetFiles(path))
            {
                if (file.ToLower().EndsWith(".txt"))
                {
                    Shape shape = new Shape(file);
                    images.Add(shape.Image);
                }
            }
        }

        private static Shape GenerateShape()
        {
            if (images == null) LoadImages();
            Drawer.Size = new System.Drawing.Size(40, 20);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Yukarı Aşağı yön tuşlarını ve Enter tuşunu kullanınız.\n");

            Shape shape = new Shape();
            int x = inpRange("Konum için x değeri", range(0, 30));
            int y = inpRange("Konum için y değeri", range(0, 20));
            shape.Location = new System.Drawing.Size(x, y);
            //x = inpRange("Vektör için x değeri", range(-3, 3));
            //y = inpRange("Vektör için y değeri", range(-3, 3));
            //shape.Vektor = new System.Drawing.Size(x, y);
            string[] colors = new string[] { "Siyah", "Koyu Mavi", "Koyu Yeşil", "Koyu turkuaz", "Koyu Kırmızı", "Koyu Magenta", "Koyu Sarı", "Gri", "Koyu Gri", "Mavi", "Yeşil", "Turkuaz", "Kırmızı", "Magenta", "Sarı", "Beyaz" };
            x = inpRange("Renk seçiniz", colors);
            shape.Color = (ConsoleColor)x;
            x = inpRange("Resim seçiniz", range(0, images.Count - 1));
            shape.Image = images[x];
            return shape;
        }

        private static string[] range(int min, int max)
        {
            List<string> s = new List<string>();
            for (int i = min; i <= max; i++)
            {
                s.Add(i.ToString());
            }
            return s.ToArray();
        }

        //private static int inputInt(string message)
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            Console.Write(message);
        //            int x = Convert.ToInt32(Console.ReadLine());
        //            return x;
        //        }
        //        catch (Exception)
        //        {
        //            Console.Write("Hatalı giriş oldu! ");
        //        }
        //    }

        //}

        //private static int inputRange(string message, int min, int max)
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            Console.WriteLine(message + "(" + min + " - " + max + ")");
        //            int x = Convert.ToInt32(Console.ReadLine());
        //            if (x >= min && x <= max)
        //            {
        //                return x;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.Write("Hatalı giriş oldu! ");
        //        }
        //    }
        //}

        private static int inpRange(string message, string[] list)
        {
            int loc = Console.CursorTop;
            int index = 0;

            Console.WriteLine(message);
            int inputloc = Console.CursorTop;
            Console.SetCursorPosition(0, inputloc);
            Console.Write(list[index].PadRight(Drawer.Size.Width - 2, ' '));
            Console.SetCursorPosition(0, inputloc);
            while (true)
            {
                var inp = Console.ReadKey();
                Console.SetCursorPosition(0, inputloc);
                if (inp.Key == ConsoleKey.UpArrow)
                {
                    if (index < list.Length - 1)  index++;
                    Console.SetCursorPosition(0, inputloc);
                    Console.Write(list[index].PadRight(Drawer.Size.Width - 2, ' '));
                }
                else if (inp.Key == ConsoleKey.DownArrow)
                {
                    if (index > 0) index--;
                    Console.SetCursorPosition(0, inputloc);
                    Console.Write(list[index].PadRight(Drawer.Size.Width - 2, ' '));
                }
                else if (inp.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, inputloc + 2);
                    break;
                }
            }
            return index;
        }
    }
}
