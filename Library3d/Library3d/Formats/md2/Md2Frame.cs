using System;
using System.Collections.Generic;
using System.IO;

namespace Fantasista.Library3d.Formats.md2
{
    public class Md2Frame
    {
        public Md2Vector Scale { get; set; }
        public Md2Vector Translate { get; set; }
        public string Name { get; set; }
        public List<Md2Vertex> Vertices { get; set; }

        public void Read(BinaryReader reader, int noOfVertices)
        {
            Scale = new Md2Vector();
            Scale.Read(reader);
            Translate = new Md2Vector();
            Translate.Read(reader);
            Name = new String(reader.ReadChars(16));
            Vertices = new List<Md2Vertex>();
            for (var i=0;i<noOfVertices;i++)
            {
                var vertex = new Md2Vertex();
                vertex.Read(reader);
                Vertices.Add(vertex);
            }
        }

    }
}
