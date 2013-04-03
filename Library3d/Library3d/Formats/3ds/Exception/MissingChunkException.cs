using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasista.Library3d.Formats.ds3.Exception
{
    internal class MissingChunkException : System.Exception
    {
        public MissingChunkException(String message)
            : base(message)
        {
        }
    }
}
