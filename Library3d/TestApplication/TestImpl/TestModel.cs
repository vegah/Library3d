using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasista.Library3d;

namespace Test.TestClasses
{
    /// <summary>
    /// Just used to test the implementation of IModel.  
    /// Not intended to be used to anything other than testing.
    /// </summary>
    public class TestModel : IModel
    {
        /// <summary>
        /// Just a struct defining a 3d Vector.  
        /// </summary>
        private class Vector3
        {
            private Vector2 xy;
            private float z;

            public Vector3(float x, float y, float z)
            {
                this.xy = new Vector2(x, y);
                this.z = z;
            }

            public Boolean Test(float x, float y, float z)
            {
                if (this.z != z)
                    return false;
                return xy.Test(x, y);
            }

            public override string ToString()
            {
                return String.Format("{0},z: {1}", xy.ToString(), z);
            }
        }

        private class Vector2
        {
            private float x;
            private float y;
            public Vector2(float x, float y)
            {
                this.x = x;
                this.y = y;
            }

            public Boolean Test(float x, float y)
            {
                if (this.x == x && this.y == y)
                    return true;
                return false;
            }

            public override string ToString()
            {
                return String.Format("x:{0},y: {1}", x, y);
            }
        }

        private List<Vector3> vertices = new List<Vector3>();
        private List<Vector2> texturecoordinates = new List<Vector2>();
        private List<Vector3> normals = new List<Vector3>();
        private List<Int32> index = new List<Int32>();
        private String name = null;


        public void AddIndex(int index)
        {
            this.index.Add(index);
        }

        public void AddVertex(float x, float y, float z)
        {
            vertices.Add(new Vector3(x, y, z));
        }

        public void AddNormal( float normalx, float normaly, float normalz)
        {
            normals.Add(new Vector3(normalx, normaly, normalz));
        }

        public void Add2dTexture(float texturex, float texturey)
        {
            texturecoordinates.Add(new Vector2(texturex, texturey));
        }
        public void SetName(String name)
        {
            this.name = name;
        }

        public Boolean TestVertex(Int32 index, float x, float y, float z)
        {
            return vertices[index].Test(x, y, z);
        }

        public Boolean TestName(String name)
        {
            return this.name == name;
        }
    }
}
