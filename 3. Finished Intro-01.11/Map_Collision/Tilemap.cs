using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Map_Collision
{
    class TileMap
    {
        Tile[,] tileMap;

        int tilesize;

        public TileMap(Texture2D[] textures, Texture2D bitMap, int _tilesize)
        {
            tilesize = _tilesize;

            tileMap = new Tile[bitMap.Width, bitMap.Height];

            BuildMap(textures, bitMap);
        }

        private void BuildMap(Texture2D[] textures, Texture2D bitMap)
        {
            Color[] colors = new Color[bitMap.Width * bitMap.Height];

            bitMap.GetData(colors);

            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                for( int x= 0; x < tileMap.GetLength(0); x++)
                {
                    if(colors[y * bitMap.Width + x] == Color.White)
                    {
                        tileMap[x, y] = new Tile(textures[0], new Vector2(x * tilesize, y * tilesize), 0);
                    }
                    else
                    {
                        tileMap[x, y] = new Tile(textures[1], new Vector2(x * tilesize, y * tilesize), 1);
                    }
                }
            }
        }

        public bool Walkable(Vector2 currentPosition)
        {
            return tileMap[(int)currentPosition.X / tilesize, (int)currentPosition.Y / tilesize].Walkable();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int y = 0; y < tileMap.GetLength(1); y++)
            {
                for (int x = 0; x < tileMap.GetLength(0); x++)
                {
                    tileMap[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}
