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
using System.Linq;
using System.Text;

namespace Fantasista.Library3d
{
    public interface IModel
    {
        void AddVertex(float x, float y, float z);
        void AddNormal(float normalx, float normaly, float normalz);
        void Add2dTexture(float texturex, float texturey);
        void AddIndex(Int32 index);
        void SetName(String name);

    }
}
