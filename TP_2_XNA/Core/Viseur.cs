using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TP_2_XNA.Core
{
    public class Viseur : Element2D
    {

        public Viseur(Game game, string nameTexture, Vector2 position) : base(game, nameTexture, position){}

        public override void Update(GameTime gameTime)
        {
            // get screen dimension 
            int _width = this.Game.GraphicsDevice.PresentationParameters.BackBufferWidth;
            int _height = this.Game.GraphicsDevice.PresentationParameters.BackBufferHeight;

            // get mouse position 
            MouseState mouse_state = Mouse.GetState();

            // set texture position on screen limit
            if ((mouse_state.X > (- this.texture.Width) / 2 && mouse_state.X < _width - this.texture.Width / 2) && (mouse_state.Y > -this.texture.Height / 2 && mouse_state.Y < _height - this.texture.Height / 2))
            {
                this.position.X = mouse_state.X;
                this.position.Y = mouse_state.Y;
            }

            base.Update(gameTime);
        }
    }
}
