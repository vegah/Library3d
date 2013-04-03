using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasista.Library3d;

namespace Test.TestClasses
{
    public class TestScene : IScene
    {
        public List<IModel> models;

        public TestScene()
        {
            models = new List<IModel>();
        }

        public IModel GetNewModel()
        {
            IModel model = new TestModel();
            models.Add(model);
            return model;
        }

        public Boolean TestNumberOfObjects(Int32 expected)
        {
            return expected == models.Count;
        }
    }
}
