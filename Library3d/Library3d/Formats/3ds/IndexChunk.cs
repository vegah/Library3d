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
    class IndexChunk : Chunk
    {
        private Int16 numberOfIndexes;
        private List<Int16> indexes;
        public IndexChunk(BinaryReader reader, Int32 size)
            : base(reader, size)
        {
            indexes = new List<Int16>();
        }

        public override void FillModel(IModel model)
        {
            base.FillModel(model);
            foreach (Int16 idx in indexes)
                model.AddIndex(idx);
        }

        protected override void Read()
        {
            numberOfIndexes = reader.ReadInt16();
            for (Int32 i = 0; i < numberOfIndexes; i++)
            {
                indexes.Add(reader.ReadInt16());
                indexes.Add(reader.ReadInt16());
                indexes.Add(reader.ReadInt16());
                // Skip the last part for now
                reader.ReadInt16();
            }
        }
    }
}
