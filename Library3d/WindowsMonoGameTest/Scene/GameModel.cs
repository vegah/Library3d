using Fantasista.Library3d;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
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
        private Texture2D texture;

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
            using (Stream s = new FileStream("Textures/cloud1.png", FileMode.Open))
            {
                texture = Texture2D.FromStream(Game.GraphicsDevice, s);
            }
            worldMatrix = Matrix.Identity;
            effect = new BasicEffect(Game.GraphicsDevice);
            effect.World = worldMatrix;
            effect.View = viewMatrix;
            effect.Projection = projectionMatrix;
            effect.TextureEnabled = true;
            effect.Texture = texture;
            
        }

        public void SetupBuffers()
        {
            // No checking if uvcoordinates at all is defined etc.
            for (Int32 i = 0; i < vertices.Count;i++ )
            {
                mapvertex.Add(new VertexPositionNormalTexture() { Position = vertices[i], TextureCoordinate=uvCoords[i] });
            }
            vertexBuffer = new VertexBuffer(Game.GraphicsDevice, VertexPositionNormalTexture.VertexDeclaration, mapvertex.Count, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionNormalTexture>(mapvertex.ToArray());
            indexBuffer = new IndexBuffer(Game.GraphicsDevice, IndexElementSize.ThirtyTwoBits, indexes.Count, BufferUsage.WriteOnly);
            indexBuffer.SetData<UInt32>(indexes.ToArray());
            vertexCount = mapvertex.Count;
            indexCount = indexes.Count;
        }

        public void Draw()
        {
            if (vertexBuffer == null)
                SetupBuffers();
            Game.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Game.GraphicsDevice.Indices = indexBuffer;
            effect.World = worldMatrix;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                Game.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0,
                    vertexCount, 0, indexCount / 3);
            }

        }

        public void Rotate()
        {
            worldMatrix *= Matrix.CreateRotationZ(0.05f);
            worldMatrix *= Matrix.CreateRotationY(0.05f);
            
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
