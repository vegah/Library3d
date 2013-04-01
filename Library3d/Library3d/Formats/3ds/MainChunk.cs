﻿/*
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

namespace Library3d.Formats.ds3
{
    class MainChunk : Chunk
    {
        public MainChunk(BinaryReader reader, Int32 size)
            : base(reader, size)
        {

        }

        protected override void Read()
        {
            while (this.reader.BaseStream.Position < (startPos + size))
            {
                this.AddChild(Chunk.CreateChunk(this.reader));
            }
        }
    }
}
