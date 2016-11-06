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
        float health;

        //Human Texture
        Texture2D texture;

        //MoveVector
        Vector2 move;


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

            size = new Vector2(text.Width, text.Height);
        }

        //Handle KeyboardInput Movement Control
        void KeyboardInput(Tilemap tileMap)
        {
            //Just save our KeyboardState in Key
            KeyboardState key = Keyboard.GetState();

            //Set Move-Vector to (0,0)
            move = Vector2.Zero;

            //Check if Left Key is Down
            if (key.IsKeyDown(Keys.Left))
                move.X += -1;

            //Check if Right Key is Down
            if (key.IsKeyDown(Keys.Right))
                move.X += 1;

            //Check if Up Key is Down
            if (key.IsKeyDown(Keys.Up))
                move.Y += -1;

            //Check if Down Key is Down
            if (key.IsKeyDown(Keys.Down))
                move.Y += 1;

            if (tileMap.Walkable(position + move)
               && tileMap.Walkable(position + move + new Vector2(texture.Width, 0))
               && tileMap.Walkable(position + move + new Vector2(0, texture.Height))
               && tileMap.Walkable(position + move + new Vector2(texture.Width, texture.Height)))
                {
                    position += move;
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
                //Reset our health and position
                health = 100;
                position = new Vector2(100, 100);
            }
        }

        public void Update(GameTime gTime, Tilemap tileMap)
        {
            KeyboardInput(tileMap);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
