using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TP_2_XNA.Core
{
    public  abstract class ElementText2D : DrawableGameComponent
    {
        protected Vector2 position;
        protected string text;
        protected SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        public ElementText2D(Game game, string text, Vector2 position) : base(game) 
        {
            this.text = text;
            this.position = position;
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.spriteFont = this.Game.Content.Load<SpriteFont>("SpriteFont/Score");
        }

        public override void Draw(GameTime gameTime) 
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, this.text, position, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
    }
}
