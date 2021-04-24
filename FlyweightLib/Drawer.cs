using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightLib
{
    public static class Drawer
    {
        public static Size Size
        {
            get
            {
                return new Size(Console.WindowWidth, Console.WindowHeight);
            }
            set
            {
                Console.WindowWidth = value.Width;
                Console.WindowHeight = value.Height;
            }
        }

        public static void Draw(Shape shape)
        {
            for (int i = 0; i < shape.Image.Length; i++)
            {
                for (int j = 0; j < shape.Image[i].Length; j++)
                {
                    if (shape.Image[i][j] != ' ')
                    {
                        Console.SetCursorPosition(j + shape.Location.Width, i + shape.Location.Height);
                        Console.ForegroundColor = shape.Color;
                        Console.Write(shape.Image[i][j]);
                    }
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
