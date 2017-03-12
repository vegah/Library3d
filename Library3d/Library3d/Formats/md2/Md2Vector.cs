using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fantasista.Library3d.Formats.md2
{
    public class Md2Vector
    {
        public Md2Vector()
        { }

        public Md2Vector(float x,float y,float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        
        internal void Read(BinaryReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Z = reader.ReadSingle();
        }
    }
}
