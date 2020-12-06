using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TP_2_XNA.Core
{
    public class SpriteObject
    {
        private Texture2D texture;
        private Vector2 position;
        private float speed;
        private Rectangle _rectangle;

        public SpriteObject(Texture2D texture)
        {
            this.texture = texture;
        }

        public Texture2D Texture { get { return this.texture; } set { this.texture = value; } }
        public Vector2 Position { get { return this.position; } set { this.position = value; } }
        public float Speed { get { return this.speed; } set { this.speed = value; } }
        public Rectangle _Rectangle { get { return this._rectangle; } set { this._rectangle = value; } }


        public void Update() 
        {
            this.position.X += this.speed;
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);
        }


    }
}
