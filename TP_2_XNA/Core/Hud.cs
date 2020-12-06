using Microsoft.Xna.Framework;

namespace TP_2_XNA.Core
{
    class Hud : ElementText2D
    {
        public Hud(Game game, string text, Vector2 position) : base(game, text, position)
        {}

        public void SetText(string text)
        {
            this.text = text;
        }

        public override void Update(GameTime gameTime)
        {
            SetText(this.text);

            base.Update(gameTime);
        }
    }
}
