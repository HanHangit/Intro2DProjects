using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpingALot
{
    class GameStuff
    {
        static GameStuff instance;
        public TileMap map;
        public Camera camera;

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
