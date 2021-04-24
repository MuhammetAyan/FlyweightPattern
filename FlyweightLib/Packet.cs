using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightLib
{
    public class Packet
    {
        private string buffer;

        public Packet(string buffer)
        {
            this.buffer = buffer;
        }

        public Packet(Shape shape)
        {
            buffer = "";
            buffer += shape.Color.GetHashCode().ToString() + "\t";
            buffer += shape.Location.Width.ToString() + "\t";
            buffer += shape.Location.Height.ToString() + "\t";
            buffer += shape.Vektor.Width.ToString() + "\t";
            buffer += shape.Vektor.Height.ToString() + "\t";
            foreach (var row in shape.Image)
            {
                buffer += row + "\t";
            }
            buffer = buffer.Substring(0, buffer.Length - 1);
            buffer += "\n";
        }

        public Shape ToShape()
        {
            Shape shape = new Shape();
            string[] segments = buffer.Split('\t');
            shape.Color = (ConsoleColor)Convert.ToInt32(segments[0]);
            shape.Location = new System.Drawing.Size(
                Convert.ToInt32(segments[1]),
                Convert.ToInt32(segments[2])
                );
            shape.Vektor = new System.Drawing.Size(
                Convert.ToInt32(segments[3]),
                Convert.ToInt32(segments[4])
                );
            List<string> img = new List<string>();
            for (int i = 5; i < segments.Length; i++)
            {
                img.Add(segments[i]);
            }
            shape.Image = img.ToArray();
            return shape;
        }

        public string GetBuffer()
        {
            return buffer;
        }
    }
}
