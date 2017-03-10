using Fantasista.Library3d;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsMonoGameTest.Scene
{
    public class GameScene : GameComponent, IScene
    {
        private String name;
        private List<UInt32> index;
        private Matrix viewMatrix, projectionMatrix;
        private List<GameModel> models;

        public GameScene(Game g)
            : base(g)            
        {
            models = new List<GameModel>();
            Setup();
        }

        public void Setup()
        {
            viewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, -10), Vector3.Zero, Vector3.Up);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Game.GraphicsDevice.Viewport.AspectRatio, 1, 200);
        }

        public void Update()
        {
            foreach (GameModel model in models)
                model.Rotate();
        }

        public void Draw()
        {
            foreach (GameModel model in models)
                model.Draw();
        }

        public IModel GetNewModel()
        {
            GameModel model = new GameModel(Game, viewMatrix, projectionMatrix);
            models.Add(model);
            return model;
        }
    }
}
