using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fantasista.Library3d.Formats.md2
{
    public class Md2Reader : IReader3d
    {
        List<Md2Skin> skins;
        List<Md2TextureCoords> textureCoords;
        List<Md2Vertex> vertices;
        List<Md2Triangle> triangles;
        List<Md2Frame> frames;

        public Md2Reader()
        {
            skins = new List<Md2Skin>();
            textureCoords = new List<Md2TextureCoords>();
            vertices = new List<Md2Vertex>();
            triangles = new List<Md2Triangle>();
            frames = new List<Md2Frame>();
        }

        public void FillScene(Stream stream, IScene scene)
        {
            ReadMd2File(stream);
            var model = scene.GetNewModel();
            foreach (var vertex in frames[0].Vertices)
                model.AddVertex((vertex.X*frames[0].Scale.X)+frames[0].Translate.X,
                    (vertex.Y * frames[0].Scale.Y) + frames[0].Translate.Y,
                    (vertex.Z * frames[0].Scale.Z) + frames[0].Translate.Z);
            foreach (var uv in textureCoords)
                model.Add2dTexture(uv.u, uv.v);
            foreach (var triangles in triangles)
            {
                model.AddIndex(triangles.VertexIndexes[0]);
                model.AddIndex(triangles.VertexIndexes[1]);
                model.AddIndex(triangles.VertexIndexes[2]);
            }
        }



        private void ReadMd2File(Stream stream)
        {
            var reader = new BinaryReader(stream);
            var header = new Md2Header(reader);
            header.ReadHeader();
            ReadPart<Md2Skin>(header.Ofs_skins, header.Num_skins, skins, reader);
            ReadPart<Md2TextureCoords>(header.Ofs_st, header.Num_st, textureCoords, reader);
            ReadPart<Md2Triangle>(header.Ofs_tris, header.Num_tris, triangles, reader);
            ReadFrames(header, reader);
        }

        private void ReadFrames(Md2Header header, BinaryReader reader)
        {
            reader.BaseStream.Seek(header.Ofs_frames, SeekOrigin.Begin);
            for (var i=0;i<header.Num_frames;i++)
            {
                var frame = new Md2Frame();
                frame.Read(reader, header.Num_vertices);
                frames.Add(frame);
            }
        }

        private void ReadPart<T>(int offset, int num, List<T> list, BinaryReader reader) where T : IMd2Part,new()
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            for (var i = 0; i < num; i++)
            {
                var part = new T();
                part.Read(reader);
                list.Add(part);
            }
        }

    }
}
