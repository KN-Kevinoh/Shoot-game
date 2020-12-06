using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TP_2_XNA.Core;

namespace TP_2_XNA
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
       

        private int niveau;
        private int score;

        private Viseur viseur;
        private GestionCibles gestionCibles;
        private Hud hud;

        private const int SCREEN_WIDTH = 800;
        private const int SCREEN_HEIGHT = 600;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // initial level
            this.niveau = 1;

            // initial score 
            this.score = 0;

            // set screen dimension
            this._graphics.IsFullScreen = false;
            this._graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            this._graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

            this._graphics.ApplyChanges();

            // add compenents cibles
            addCibles(niveau);

            // add component viseur
            this.viseur = new Viseur( this, nameTexture: "Textures/crosshair", position: new Vector2(SCREEN_WIDTH/2, SCREEN_HEIGHT/2));
            this.Components.Add(this.viseur);

            // add component hud
            string txt = "Level: " + niveau + "    Score: " + score;
            this.hud = new Hud(this, txt, new Vector2(txt.Length + 10, 20));
            this.Components.Add(hud);
            base.Initialize();
        }

        private void addCibles(int niveau)
        {
            this.gestionCibles = new GestionCibles(this, niveau: this.niveau);
            foreach (Cible cible in gestionCibles.List_Cibles.ToArray())
            {
                this.Components.Add(cible);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed || Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                foreach (var cible in gestionCibles.List_Cibles)
                {
                    if (this.viseur.GetRectangle.Intersects(cible.GetRectangle))
                    {
                        cible.IsAlive = false;
                        this.gestionCibles.Nb_Cibles = this.gestionCibles.Nb_Cibles - 1;
                        this.score++;
                    }
                }
            }

            if(this.gestionCibles.Nb_Cibles == 0)
            {
                this.niveau ++;
                this.gestionCibles.Nb_Cibles = niveau;
                this.gestionCibles.List_Cibles.RemoveAll(x => x.IsAlive == false);
                addCibles(this.niveau);
                this.
                //recréer viseur
                viseur = null;
                this.viseur = new Viseur(this, nameTexture: "Textures/crosshair", position: new Vector2(SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2));
                this.Components.Add(this.viseur);
            }

            string txt = "Level: " + niveau + "    Score: " + score;
            this.hud.SetText(txt);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
