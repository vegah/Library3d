using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasista.Library3d.Formats.ds3
{
    internal class Version3dsChunk : Chunk
    {
        private Int32 version;

        public Version3dsChunk(BinaryReader reader, Int32 size)
            : base(reader, size)
        {

        }

        protected override void Read()
        {
            this.version = reader.ReadInt32();
        }
    }
}
