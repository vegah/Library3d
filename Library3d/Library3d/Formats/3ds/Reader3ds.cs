using Fantasista.Library3d.Formats.ds3.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasista.Library3d.Formats.ds3
{
    public class Reader3ds : IReader3d
    {
        public void FillScene(System.IO.Stream s, IScene scene)
        {
            Chunk main;
            using (BinaryReader reader = new BinaryReader(s))
            {
                main = Chunk.CreateChunk(reader);
            }
            if (main is MainChunk)
                main.FillScene(scene);
            else
                throw new MissingChunkException(String.Format("The main chunk of the 3ds file is missing."));
                    
        }
    }
}
