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
    class Player
    {
        //Class Member
        //Texture
        public Texture2D texture;

        //Current Player Position
        //Public -> We need the Position in our Enemy Class
        public Vector2 position;

        float gForce = 0.3f;

        bool jump;

        float speedY;

        float health;

        Vector2 move;

        //Constructor with Input Parameters
        public Player(Texture2D playerTexture, Vector2 playerPosition)
        {
            //Define CLass Member
            texture = playerTexture;
            position = playerPosition;
            health = 100;
            move = Vector2.Zero;
            jump = false;
        }

        public void ApplyDamage(float damage)
        {
            health -= damage;

            if(health <= 0)
            {
                position = new Vector2(100, 100);
                health = 100;
            }
        }

        public void Update()
        {
            //Get Movement Control see 1. Project
            KeyboardState key = Keyboard.GetState();

            move.Y += gForce;
            move.X = 0;
            
            if (key.IsKeyDown(Keys.Left))
                move.X -= 1;

            if (key.IsKeyDown(Keys.Right))
                move.X += 1;

            if (key.IsKeyDown(Keys.Space) && !jump)
            {
                jump = true;
                move.Y = -10;
                position.Y -= 1;
            }

            if (position.Y <= 400)
            {
                position.Y += move.Y;
            }
            else
                jump = false;

            position.X += move.X;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Texture
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
