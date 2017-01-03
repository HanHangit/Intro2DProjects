using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Collision
{
    class Player
    {
        //Class Member Declaration

        //MovingSpeed
        float speed;

        //Current Position
        public Vector2 position;

        //Size of Texture
        public Vector2 size;

        //Current LifePoints
        public float health;

        //Human Texture
        Texture2D texture;

        //MoveVector
        Vector2 move;

        float gForce = 0.5f;

        bool jump;


        /// <summary>
        /// Constructor from our Player
        /// </summary>
        /// <param name="text">The Texture which shouldt be drawn</param>
        /// <param name="pos">Start Position</param>
        /// <param name="speed">Moving Speed</param>
        public Player(Texture2D text, Vector2 pos, float speed, float health)
        {
            //Define our ClassMember Variable
            this.speed = speed;
            this.health = health;
            position = pos;
            texture = text;
            move = Vector2.Zero;
            jump = false;

            size = new Vector2(text.Width, text.Height);
        }

        //Handle KeyboardInput Movement Control
        void KeyboardInput()
        {
            //Just save our KeyboardState in Key
            KeyboardState key = Keyboard.GetState();

            //Set Move-Vector to (0,0)
            move.X = 0;

            //Check if Left Key is Down
            if (key.IsKeyDown(Keys.Left))
                move.X += -4;

            //Check if Right Key is Down
            if (key.IsKeyDown(Keys.Right))
                move.X += 4;

            if(key.IsKeyDown(Keys.Space) && jump)
            {
                move.Y = -20;
                jump = false;
            }

            Tilemap tileMap = GameStuff.Instance.tileMap;

            move.Y += gForce;

            if (tileMap.Walkable(position + new Vector2(0,texture.Height) + new Vector2(0,move.Y)) 
                && tileMap.Walkable(position + new Vector2(texture.Width, texture.Height) + new Vector2(0, move.Y)))
            {
                jump = false;
                position.Y += move.Y;
            }
            else
            {
                while (!tileMap.Walkable(position + new Vector2(0, texture.Height))
                || !tileMap.Walkable(position + new Vector2(texture.Width, texture.Height)))
                    position.Y -= 0.1f;
                jump = true;
                move.Y = 0;
            }

            if (tileMap.Walkable(position + new Vector2(move.X,0))
               && tileMap.Walkable(position + new Vector2(move.X,0)+ new Vector2(texture.Width, 0)))
                {
                    position.X += move.X;
                }

        }

        //Function for attacking Player
        public void ApplyDamage(float amount)
        {
            //Check if we survive the attack
            if (health > amount)
                health -= amount;
            else
            {
                health = 0;
            }
        }

        public void Update(GameTime gTime)
        {
            KeyboardInput();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
