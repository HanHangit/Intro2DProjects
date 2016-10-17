using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Intro_18._10
{
    class TileMap
    {
        //Size of each Tile
        int tileSize = 16;

        //Tile Array
        Tile[,] tileMap;

        public TileMap(Texture2D[] tileText, Texture2D bitMap)
        {
            //IntMap Size = Size of bitMap
            tileMap = new Tile[bitMap.Width, bitMap.Height];

            BuildMap(tileText, bitMap);
        }

        void BuildMap(Texture2D[] tileText, Texture2D bitMap)
        {
            //We create a Color Array, where we save each PixelColor
            Color[] colorMap = new Color[bitMap.Height * bitMap.Width];

            //Get ColorData from BitMap
            bitMap.GetData(colorMap);

            //Check each PixelColor
            for (int i = 0; i < bitMap.Width; ++i)
                for (int j = 0; j < bitMap.Height; ++j)
                {
                    //If Color == Black create Wall-Tile
                    if (colorMap[i % bitMap.Width + j * bitMap.Width].Equals(Color.Black))
                        tileMap[i, j] = new Tile(tileText[0], new Vector2(tileSize * i, tileSize * j), 0);
                    //If Color == White create Floor-Tile
                    else if (colorMap[i % bitMap.Width + j * bitMap.Width].Equals(Color.White))
                        tileMap[i, j] = new Tile(tileText[1], new Vector2(tileSize * i, tileSize * j), 1);
                    else
                        tileMap[i, j] = new Tile(tileText[1], new Vector2(tileSize * i, tileSize * j), 1);
                }


        }

        public bool Walkable(Vector2 position)
        {
            return tileMap[(int)position.X / tileSize, (int)position.Y / tileSize].Walkable();
        }

        public void Update(GameTime gTime)
        {
            //Iterate over tileMap and call .Update()
            for (int i = 0; i < tileMap.GetLength(0); ++i)
                for (int j = 0; j < tileMap.GetLength(1); ++j)
                {
                    tileMap[i, j].Update(gTime);
                }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //Iterate over tileMap and call .Draw()
            for (int i = 0; i < tileMap.GetLength(0); ++i)
                for (int j = 0; j < tileMap.GetLength(1); ++j)
                {
                    tileMap[i, j].Draw(spriteBatch);
                }
        }
    }
}
