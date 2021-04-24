using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlyweightLib
{

    public class Shape
    {
        private int imageHash;
        public string[] Image
        {
            get
            {
                return ShapePooling.GetImage(imageHash);
            }
            set
            {
                imageHash = ShapePooling.SetImage(value);
            }
        }
        public ConsoleColor Color { get; set; }

        public Size Location { get; set; }
        public Size Vektor { get; set; }

        public Shape(string filename)
        {
            Image = System.IO.File.ReadAllLines(filename);
        }

        public Shape() { }

        //public static Shape Box(Size size, Size location, ConsoleColor color)
        //{
        //    List<string> buffer = new List<string>();
        //    string r = "┌";
        //    for (int i = 0; i < size.Width - 1; i++) { r += "─"; };
        //    r += "┐";
        //    buffer.Add(r);
        //    r = "│";
        //    for (int i = 0; i < size.Width - 1; i++) { r += " "; };
        //    r += "│";
        //    buffer.Add(r);
        //    r = "└";
        //    for (int i = 0; i < size.Width; i++) { r += "─"; };
        //    r = "┘";
        //    buffer.Add(r);
        //    Shape shape = new Shape();
        //    shape.Image = buffer.ToArray();
        //    shape.Color = color;
        //    shape.Location = location;
        //    return shape;
        //}

    }
}
