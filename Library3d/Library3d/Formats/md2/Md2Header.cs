using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Fantasista.Library3d.Formats.md2.Exceptions;
namespace Fantasista.Library3d.Formats.md2
{
    public class Md2Header 
    {

        private BinaryReader binaryReader;


        public Md2Header(BinaryReader reader)
        {
            binaryReader = reader; 
        }

        public void ReadHeader()
        {
            ReadIdentAndVersion();
            ReadSkinSizeInformation();
            Framesize = binaryReader.ReadInt32();
            ReadNumberOfDifferentElements();
            ReadOffsets();
        }

        private void ReadNumberOfDifferentElements()
        {
            Num_skins = binaryReader.ReadInt32();
            Num_vertices = binaryReader.ReadInt32();
            Num_st = binaryReader.ReadInt32();
            Num_tris = binaryReader.ReadInt32();
            Num_glcmds = binaryReader.ReadInt32();
            Num_frames = binaryReader.ReadInt32();
        }

        private void ReadOffsets()
        {
            Ofs_skins = binaryReader.ReadInt32();
            Ofs_st = binaryReader.ReadInt32();
            Ofs_tris = binaryReader.ReadInt32();
            Ofs_frames = binaryReader.ReadInt32();
            Ofs_glcmds = binaryReader.ReadInt32();
            Ofs_end = binaryReader.ReadInt32();
        }

        private void ReadSkinSizeInformation()
        {
            Skinwidth = binaryReader.ReadInt32();
            Skinheight = binaryReader.ReadInt32();

        }

        private void ReadIdentAndVersion()
        {
            Ident = binaryReader.ReadInt32();
            if (Ident != 844121161)
                throw new Md2WrongHeaderException($"Wrong ident - was {Ident}");
            Version = binaryReader.ReadInt32();
        }

        public int Ident { get; set; }

        public int Version { get; set; }

        public int Skinwidth { get; set; }

        public int Skinheight { get; set; }

        public int Framesize { get; set; }

        public int Num_skins { get; set; }

        public int Num_vertices { get; set; }

        public int Num_st { get; set; }

        public int Num_tris { get; set; }

        public int Num_glcmds { get; set; }

        public int Num_frames { get; set; }

        public int Ofs_skins { get; set; }

        public int Ofs_st { get; set; }

        public int Ofs_tris { get; set; }

        public int Ofs_frames { get; set; }

        public int Ofs_glcmds { get; set; }

        public int Ofs_end { get; set; }

    }
}
