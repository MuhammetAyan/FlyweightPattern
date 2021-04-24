using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyweightLib
{
    public static class ShapePooling
    {
        private static Dictionary<int, string[]> ShapeImages 
            = new Dictionary<int, string[]>();


        public static int SetImage(string[] image)
        {
            string s = "";
            for (int i = 0; i < image.Length; i++)
            {
                s += image[i];
            }
            int hash = s.GetHashCode();
            if (!ShapeImages.ContainsKey(hash))
            {
                ShapeImages.Add(hash, image);
            }
            return hash;
        }

        public static string[] GetImage(int hash)
        {
            if (ShapeImages.ContainsKey(hash))
            {
                return ShapeImages[hash];
            }
            else
            {
                return null;
            }
        }
    }
}