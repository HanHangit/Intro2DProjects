using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JumpingALot
{
    class Enemy
    {
        //Class Member
        //Our Texture
        Texture2D texture;

        //Current Position
        Vector2 position;

        //Moving Speed
        float speed;

        //Reference to Player
        Player target;     

        //Constructor with Input Parameters
        public Enemy(Texture2D enemyTexture, Vector2 enemyPosition, float speed, Player target)
        {
            //Define our Class Members
            texture = enemyTexture;
            position = enemyPosition;
            this.speed = speed;
            this.target = target;
        }

        //Update() Function
        public void Update()
        {
            //Setting Move Direction
            Vector2 move = target.position - position;
            //Normalize to get Length == 1
            move.Normalize();

            //Set our length = Speed
            move *= speed;

            /*
            Vector2 distance = target.position - position;

            if(distance.Length() <= 30)
            {
                target.ApplyDamage(1);
            }
            */
            Rectangle rectE = new Rectangle(position.ToPoint(), new Point(texture.Width, texture.Height));

            Rectangle rectP = new Rectangle(target.position.ToPoint(), new Point(target.texture.Width, target.texture.Height));

            if(rectE.X < rectP.X + rectP.Size.X 
                && rectE.X + rectE.Size.X > rectP.X
                && rectE.Y < rectP.Y + rectP.Size.Y
                && rectE.Y + rectE.Size.Y > rectP.Y)
            {
                target.ApplyDamage(1f);
            }
            else
            {
                //Change Position
                position += move;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //This draws our Texture
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
