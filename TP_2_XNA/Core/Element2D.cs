using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TP_2_XNA.Core
{
    public abstract class Element2D : DrawableGameComponent
    {
        protected Vector2 position;
        private SpriteBatch spriteBatch;
        protected Texture2D texture;
        private string nameTexture;
        protected Rectangle rectangle;
        private bool isAlive;

        protected Element2D(Game game, string nameTexture, Vector2 position) :base(game)
        {
            this.isAlive = true;
            this.position = position;
            this.nameTexture = nameTexture;
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        
        public bool IsAlive
        {
            get { return this.isAlive; }

            set { this.isAlive = value; }
        }

        public Rectangle GetRectangle 
        { 
            get 
            { 
                return this.rectangle = new Rectangle((int)position.X, (int)position.Y, this.texture.Width, this.texture.Height); 
            }
        }

       
        protected override void LoadContent() 
        {
            this.texture = this.Game.Content.Load<Texture2D>(this.nameTexture);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            base.LoadContent();
        }
        


        public override void Draw(GameTime gameTime)
        {
            if (isAlive)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(this.texture, this.position, Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

    }
}
