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
        public List<GameObject> enemyList = new List<GameObject>();

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
