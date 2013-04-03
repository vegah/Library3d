/*
   Copyright 2013 Vegah

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
  
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasista.Library3d.Formats.ds3
{
    class VerticesChunk : Chunk
    {
        private struct Vector
        {
            public float x, y, z;
        }
        
        private Int16 verticeCount;
        private List<Vector> vertices= new List<Vector>();

        public VerticesChunk(BinaryReader reader, Int32 size)
            : base(reader, size)
        {

        }

        public override void FillModel(IModel model)
        {
            base.FillModel(model);
            foreach (Vector v in vertices)
                model.AddVertex(v.x, v.y, v.z);
        }

        protected override void Read()
        {
            verticeCount = reader.ReadInt16();
            for (Int32 i = 0; i < verticeCount; i++)
            {
                Vector v = new Vector();
                v.x = reader.ReadSingle();
                v.y = reader.ReadSingle();
                v.z = reader.ReadSingle();
                vertices.Add(v);
            }
        }
    }
}
