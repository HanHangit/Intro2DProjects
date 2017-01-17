using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Collision
{
    class GameStuff
    {
        static GameStuff instance;
        public Tilemap tileMap;
        public Player player;
        public Camera camera;
        public CutsceneBeacon cutsceneBeacon;
        public List<GameObject> enemyList = new List<GameObject>();
        public List<Bullet> bullet = new List<Bullet>();
        public Texture2D[] bulletTexture = new Texture2D[1];

        private GameStuff()
        {

        }

        public static GameStuff Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameStuff();

                return instance;
            }
        }
    }
}
