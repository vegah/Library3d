3dReader
========

Read different 3d formats to an IModel/IScene in .net.
Made because I needed these files to some other stuff, so not necessarily made for exactly what you want to use it for.  Clone and fix and send a pull request, and I'll merge it in.

#Supported formats
3ds - Can read 3ds files into IScene/IModel

md2 - Can read ID Software's md2 files, but normals are not in (they are kept in a lookup table which I havent included.  Should be easy to add).  Will for now just get information about the first frame, but all frames are read - so should also be easy to fix.  Just need to add some frameinformation to the IModel interface.



#Usage is
```csharp
            IScene scene = new YourSceneImpl();
            IReader3d reader = new Reader3ds(); // To use 3ds reader.  
            using (Stream s = new FileStream("object.3ds", FileMode.Open))
            {
                reader.FillScene(s,scene);
            }
``` 
You need to implement two interfaces.  IScene and IModel.  IScene consists of one method, GetNewModel, which should return an IModel.
IModel have 5 methods: 
```csharp
        void AddVertex(float x, float y, float z);
        void AddNormal(float normalx, float normaly, float normalz);
        void Add2dTexture(float texturex, float texturey);
        void AddIndex(Int32 index);
        void SetName(String name);
```        
Please see the provided examples (TestApplication and WindowsMonoGameTest).

The added monogame example is not meant to be an example on how to really do it in monogame.  There is for example no checking if UV coords is actually defined etc, it's just a really basic example.

This is of course not finished, and it probably never will be.    

