using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fantasista.Library3d.Formats.md2
{
    public class Md2Skin : IMd2Part
    {
        public string Name { get; set; }

        public void Read(BinaryReader reader)
        {
            Name = new String(reader.ReadChars(64));
        }
    }
}
