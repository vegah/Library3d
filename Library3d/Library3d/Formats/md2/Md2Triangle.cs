using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fantasista.Library3d.Formats.md2
{
    public class Md2Triangle : IMd2Part
    {
        public short[] VertexIndexes {get;set;}
        public short[] TextureCoordinateIndexes { get; set; }
        public void Read(BinaryReader reader)
        {
            VertexIndexes = new short[3];
            TextureCoordinateIndexes = new short[3];
            for (var i = 0; i < 3; i++)
                VertexIndexes[i] = reader.ReadInt16();
            for (var i = 0; i < 3; i++)
                TextureCoordinateIndexes[i] = reader.ReadInt16();
        }
    }
}
