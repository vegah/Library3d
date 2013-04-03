using Fantasista.Library3d;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsMonoGameTest.Scene
{
    class GameModel : GameComponent, IModel
    {
        private List<Vector2> uvCoords;
        private List<Vector3> normals;
        private List<Vector3> vertices;
        private List<UInt32> indexes;
        private VertexBuffer vertexBuffer;
        private IndexBuffer indexBuffer;
        private BasicEffect effect;
        private Matrix worldMatrix;
        private String name;
        private int vertexCount;
        private int indexCount;
        private List<VertexPositionNormalTexture> mapvertex;


        public GameModel(Game g, Matrix viewMatrix, Matrix projectionMatrix)
            : base(g)
        {
            uvCoords = new List<Vector2>();
            normals = new List<Vector3>();
            vertices = new List<Vector3>();
            indexes = new List<UInt32>();
            mapvertex = new List<VertexPositionNormalTexture>();
            Setup(viewMatrix, projectionMatrix);
        }

        private void Setup(Matrix viewMatrix, Matrix projectionMatrix)
        {
            worldMatrix = Matrix.Identity;
            effect = new BasicEffect(GraphicsDevice);
            effect.World = worldMatrix;
            effect.View = viewMatrix;
            effect.Projection = projectionMatrix;
            effect.TextureEnabled = true;
        }

        public void SetupBuffers()
        {
            foreach (Vector3 ver in vertices)
            {
                mapvertex.Add(new VertexPositionNormalTexture() { Position = ver });
            }
            vertexBuffer = new VertexBuffer(GraphicsDevice, VertexPositionNormalTexture.VertexDeclaration, mapvertex.Count, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionNormalTexture>(mapvertex.ToArray());
            indexBuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.ThirtyTwoBits, indexes.Count, BufferUsage.WriteOnly);
            indexBuffer.SetData<UInt32>(indexes.ToArray());
            vertexCount = mapvertex.Count;
            indexCount = indexes.Count;
        }

        public void Draw()
        {
            if (vertexBuffer == null)
                SetupBuffers();
            GraphicsDevice.SetVertexBuffer(vertexBuffer);
            GraphicsDevice.Indices = indexBuffer;
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0,
                    vertexCount, 0, indexCount / 3);
            }

        }

        public void AddVertex(float x, float y, float z)
        {
            vertices.Add(new Vector3(x, y, z));
        }

        public void AddNormal(float normalx, float normaly, float normalz)
        {
            normals.Add(new Vector3(normalx, normaly, normalz));
        }

        public void Add2dTexture(float texturex, float texturey)
        {
            uvCoords.Add(new Vector2(texturex, texturey));
        }

        public void AddIndex(int index)
        {
            indexes.Add((UInt32)index);
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
