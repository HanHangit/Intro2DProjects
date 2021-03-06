﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpingALot
{
    class TileMap
    {
        Tile[,] tileMap;
        int tileSize;
        public Rectangle Bounds;

        public TileMap(Texture2D[] textures, Texture2D bitMap, int _tileSize)
        {
            tileSize = _tileSize;
            tileMap = new Tile[bitMap.Width, bitMap.Height];
            Bounds = new Rectangle(0, 0, bitMap.Width * _tileSize, bitMap.Height * _tileSize);

            BuildMap(textures, bitMap);
        }

        private void BuildMap(Texture2D[] textures, Texture2D bitMap)
        {
            Color[] colores = new Color[bitMap.Width * bitMap.Height];

            bitMap.GetData(colores);

            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                for (int x = 0; x < tileMap.GetLength(0); x++)
                {
                    if (colores[y * tileMap.GetLength(0) + x] == Color.White)
                    {
                        // Grass
                        tileMap[x, y] = new Tile(textures[0], new Vector2(x * tileSize, y * tileSize), 0);
                    }
                    else
                    {
                        // Stein
                        tileMap[x, y] = new Tile(textures[1], new Vector2(x * tileSize, y * tileSize), 1);
                    }
                }
            }
        }

        public bool Walkable(Vector2 currentPosition)
        {
            return tileMap[(int)(currentPosition.X / tileSize), (int)(currentPosition.Y / tileSize)].Walkable();
        }

        public void Update(GameTime gameTime)
        {            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                for (int x = 0; x < tileMap.GetLength(0); x++)
                {
                    tileMap[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}

