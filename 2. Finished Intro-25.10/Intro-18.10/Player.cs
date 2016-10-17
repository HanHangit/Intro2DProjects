﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_18._10
{
    class Player
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


        /// <summary>
        /// Constructor from our Player
        /// </summary>
        /// <param name="text">The Texture which shouldt be drawn</param>
        /// <param name="pos">Start Position</param>
        /// <param name="speed">Moving Speed</param>
        public Player(Texture2D text, Vector2 pos, float speed)
        {
            //Define our ClassMember Variable
            this.speed = speed;
            position = pos;
            texture = text;
            move = Vector2.Zero;
        }

        //Handle KeyboardInput Movement Control
        void KeyboardInput()
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

            position += move;


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
