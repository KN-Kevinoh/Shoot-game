using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace TP_2_XNA.Core
{
    public class GestionCibles : GameComponent
    {
        private int niveau;
        private int nb_cibles;
        private List<Cible> list_cibles;

        public GestionCibles(Game game, int niveau) : base(game)
        {
            this.niveau = niveau;
            this.nb_cibles = niveau;

            this.list_cibles = new List<Cible>();

            for (int i = 0; i < this.niveau; i++)
            {
                this.list_cibles.Add(new Cible(this.Game, nameTexture: "Textures/YellowStar", position: new Vector2(0, 0)));
            }
        }

        public int Nb_Cibles { get { return this.nb_cibles; } set { this.nb_cibles = value; } }


        public List<Cible> List_Cibles { get { return list_cibles; } }


        public override void Initialize()
        {
            base.Initialize();
        }

        public void incrementeLevel()
        {
            this.niveau++;
        }

        public override void Update(GameTime gameTime)
        {
           
            if (nb_cibles == 0)
            {
                incrementeLevel();
                nb_cibles = niveau;
            }
           
            base.Update(gameTime);
        }

    }
}
