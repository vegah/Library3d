using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasista.Library3d.Formats.md2.Exceptions
{
    public class Md2WrongHeaderException : System.Exception
    {
        public Md2WrongHeaderException(string message)
            :base(message)
        {

        }
    }
}
