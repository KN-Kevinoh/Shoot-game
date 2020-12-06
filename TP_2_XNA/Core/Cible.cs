using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace TP_2_XNA.Core
{
    

    public class Cible : Movable
    {
        public Cible(Game game, string nameTexture, Vector2 position)
                    : base(game, nameTexture, position)
        {}


        public override void Initialize()
        {
            SetTrajectoire();
            base.Initialize();
        }

        public override void SetTrajectoire()
        {
            // get list points
            List<Vector2> points = this.Points;
            Vector2 pos = this.position;

            int parcours = this.Game.GraphicsDevice.PresentationParameters.BackBufferWidth;
            
             while( pos.X < parcours + this.speed)
             {
                 pos.X += this.speed;
                 points.Add(pos);
             }
            // set list points
            this.Points = points;
        }

        public override void Update(GameTime gameTime)
        {
            this.NextPosition();
            base.Update(gameTime);
        }

       
    }
}
