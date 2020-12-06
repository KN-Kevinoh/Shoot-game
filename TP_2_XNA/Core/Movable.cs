using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace TP_2_XNA.Core
{
    public abstract class Movable : Element2D
    {
        private List<Vector2> points = new List<Vector2>();
        protected int speed;
        private int current_index;

        protected Movable(Game game, string nameTexture, Vector2 position) : base(game, nameTexture, position)
        {
            Random rnd = new Random();

            this.speed = rnd.Next(1, 3);
           
            this.position.X = 0;
            this.position.Y = rnd.Next(0, this.Game.GraphicsDevice.PresentationParameters.BackBufferHeight);

            this.points.Add(position);
            this.current_index = 0;
        }

        public List<Vector2> Points { get { return this.points; } set { this.points = value; } }

        public void NextPosition()
        {
            ++this.current_index;

            if (this.current_index > this.points.Count-1)
            {
                this.position = this.points[0];
                this.current_index = 0;
            }
            else
            {
                this.position = this.points[current_index];
            }
        }

        public abstract void SetTrajectoire();

    }
}
