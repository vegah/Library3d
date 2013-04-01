using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3d.Formats.ds3
{
    internal abstract class Chunk
    {
        protected BinaryReader reader;
        protected Int32 size;
        private List<Chunk> childChunks;
        protected Int64 startPos;
        public Chunk(BinaryReader reader, Int32 size)
        {
            this.reader = reader;
            this.size = size-6;  // -6 is to not count the chunk headers which is included in the size
            childChunks = new List<Chunk>();
            startPos = reader.BaseStream.Position;
        }

        protected abstract void Read();

        protected Byte[] ReadBytes(Int32 size)
        {
            Byte[] bytes = new Byte[size];
            Int32 read = 0;
            while (read < size)
            {
                read += reader.Read(bytes, read, size - read);
            }
            return bytes;
        }

        public void AddChild(Chunk chunk)
        {
            childChunks.Add(chunk);
        }

        internal static Chunk CreateChunk(BinaryReader reader)
        {
            Int16 id = reader.ReadInt16();
            Int32 chunksize = reader.ReadInt32();
            Chunk chunk;
            switch (id)
            {
                case 0x4d4d:
                    {
                        chunk = new MainChunk(reader, chunksize);
                        break;
                    }
                default:
                    {
                        chunk = new UnknownChunk(reader, chunksize);
                        break;
                    }
            }
            Console.WriteLine("Found chunk of type {0} with size {1} and id {2:X2}",chunk.GetType().ToString(), chunksize, id);
            chunk.Read();
            return chunk;
        }
    }
}
