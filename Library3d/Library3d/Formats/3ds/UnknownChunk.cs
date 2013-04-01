using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3d.Formats.ds3
{
    internal class UnknownChunk : Chunk
    {
        internal UnknownChunk(BinaryReader reader, Int32 size)
            : base(reader, size)
        {

        }

        protected override void Read()
        {
            this.ReadBytes(size);
        }
    }
}
