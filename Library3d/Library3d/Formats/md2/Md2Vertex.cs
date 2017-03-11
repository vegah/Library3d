using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fantasista.Library3d.Formats.md2
{
    public class Md2Vertex : IMd2Part
    {
        public byte X { get; set; }
        public byte Y { get; set; }
        public byte Z { get; set; }
        public byte NormalIndex { get; set; }

        public void Read(BinaryReader reader)
        {
            X = reader.ReadByte();
            Y = reader.ReadByte();
            Z = reader.ReadByte();
            NormalIndex = reader.ReadByte();
        }
    }
}
