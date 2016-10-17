using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Intro_18._10
{
    class Tile
    {

        Texture2D texture;
        int id;
        Vector2 position;

        public Tile(Texture2D text,Vector2 position, int _id)
        {
            this.position = position;
            texture = text;
            id = _id;
        }

        public bool Walkable()
        {
            if (id == 0)
                return false;
            else
                return true;
        }

        public void Update(GameTime gTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
