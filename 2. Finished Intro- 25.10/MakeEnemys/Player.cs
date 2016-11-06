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
        Texture2D texture;

        //Current Player Position
        //Public -> We need the Position in our Enemy Class
        public Vector2 position;

        //Constructor with Input Parameters
        public Player(Texture2D playerTexture, Vector2 playerPosition)
        {
            //Define CLass Member
            texture = playerTexture;
            position = playerPosition;
        }

        public void Update()
        {
            //Get Movement Control see 1. Project
            KeyboardState key = Keyboard.GetState();
            
            if (key.IsKeyDown(Keys.Left))
                position.X -= 1;

            if (key.IsKeyDown(Keys.Right))
                position.X += 1;

            if (key.IsKeyDown(Keys.Up))
                position.Y -= 1;

            if (key.IsKeyDown(Keys.Down))
                position.Y += 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Texture
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
