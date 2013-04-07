using Fantasista.Library3d;
using Fantasista.Library3d.Formats.ds3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.TestClasses;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader3d reader = new Reader3ds();
            IScene scene = new TestScene();
            using (Stream s = new FileStream("3dObjects/cube.3ds", FileMode.Open))
            {
                reader.FillScene(s, scene);
            }

            IScene scene2 = new TestScene();
            using (Stream s = new FileStream("3dObjects/donutcube.3ds", FileMode.Open))
            {
                reader.FillScene(s, scene2);
            }

            Console.ReadLine();
        }
    }
}
