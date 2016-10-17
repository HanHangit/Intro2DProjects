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
        //Class Member Declaration

        //MovingSpeed
        public float speed;

        //Current Position
        public Vector2 position;

        //Human Texture
        Texture2D texture;

        //MoveVector
        Vector2 move;

        //The Target we want to follow
        Player target;

        public Enemy(Texture2D text, Vector2 pos, float speed, Player tar)
        {
            this.speed = speed;
            position = pos;
            texture = text;
            target = tar;
        }

        public void Update(GameTime gTime)
        {
            //Calculate Direction Vector to Player
            move = target.position - position;

            //Normalize to set Length to 1
            move.Normalize();

            //Set our speed
            move *= speed;

            position += move;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,Color.White);
        }
    }
}
