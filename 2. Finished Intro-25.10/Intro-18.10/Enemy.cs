using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Intro_18._10
{
    class Enemy
    {
        public float speed;
        public Vector2 position;
        Texture2D texture;

        public Enemy(Texture2D text, Vector2 pos, float speed)
        {
            this.speed = speed;
            position = pos;
            texture = text;
        }

        public void Update(GameTime gTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,Color.White);
        }
    }
}
