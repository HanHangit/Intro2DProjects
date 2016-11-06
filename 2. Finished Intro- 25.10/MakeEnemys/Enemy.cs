using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MakeEnemys
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

            //Change Position
            position += move;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //This draws our Texture
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
