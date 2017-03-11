using System.IO;

namespace Fantasista.Library3d.Formats.md2
{
    public class Md2TextureCoords : IMd2Part
    {
        public short u;
        public short v;

        public void Read(BinaryReader reader)
        {
            u = reader.ReadInt16();
            v = reader.ReadInt16();
        }
    }
}
