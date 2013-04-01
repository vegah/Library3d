using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3d.Formats.ds3
{
    public class Reader3ds : IReader3d
    {
        public void FillScene(System.IO.Stream s, IScene scene)
        {
            using (BinaryReader reader = new BinaryReader(s))
            {
                Chunk.CreateChunk(reader);
            }
        }
    }
}
