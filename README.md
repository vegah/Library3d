3dReader
========

Read different 3d formats to an IModel/IScene.
For now it just supports 3ds.  

Usage is
'''csharp
            IScene scene = new YourSceneImpl();
            IReader3d reader = new Reader3ds(); // To use 3ds reader.  
            using (Stream s = new FileStream("object.3ds", FileMode.Open))
            {
                reader.FillScene(s,scene);
            }
'''
You need to implement two interfaces.  IScene and IModel.  IScene consists of one method, GetNewModel, which should return an IModel.
IModel have 5 methods: 
        void AddVertex(float x, float y, float z);
        void AddNormal(float normalx, float normaly, float normalz);
        void Add2dTexture(float texturex, float texturey);
        void AddIndex(Int32 index);
        void SetName(String name);
They should explain themselves.

The added monogame example is not meant to be an example on how to really do it in monogame.  There is for example no checking if UV coords is actually defined etc, it's just a really basic example.

This is nowhere near finished, and I am not sure if it ever will be.  
