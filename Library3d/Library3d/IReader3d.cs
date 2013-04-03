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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasista.Library3d
{
    public interface IReader3d
    {
        /// <summary>
        /// Takes a scene and fills it with 3d models
        /// </summary>
        /// <param name="stream">The stream which contains the raw data</param>
        /// <param name="scene">The scene to be filled</param>
        void FillScene(System.IO.Stream stream, IScene scene);
    }
}
