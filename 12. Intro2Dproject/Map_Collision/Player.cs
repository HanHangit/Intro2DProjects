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

        AnimatedSprite animatedSprite;
        AnimatedSprite.AnimationStates animationState;

        public CutsceneController cutsceneController;

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
        public Player(Texture2D text, Vector2 pos, float speed, float health, AnimatedSprite _animatedSprite)
        {
            //Define our ClassMember Variable
            this.speed = speed;
            this.health = health;
            position = pos;
            animatedSprite = _animatedSprite;
            texture = text;
            move = Vector2.Zero;
            jump = false;
            animationState = AnimatedSprite.AnimationStates.Idle;
            size = new Vector2(text.Width, text.Height);
            cutsceneController = new CutsceneController(null, null);
            cutsceneController.active = false;
        }

        //Handle KeyboardInput Movement Control
        void KeyboardInput()
        {
            Console.WriteLine("position: " + position);
            //Just save our KeyboardState in Key
            KeyboardState key = Keyboard.GetState();

            //Set Move-Vector to (0,0)
            move.X = 0;

            //Check if Left Key is Down
            if ((!cutsceneController.active) ? key.IsKeyDown(Keys.Left) : cutsceneController.GetMove(CutsceneController.MoveControlls.Left))
                move.X += -4;

            //Check if Right Key is Down
            if ((!cutsceneController.active) ? key.IsKeyDown(Keys.Right) : cutsceneController.GetMove(CutsceneController.MoveControlls.Right))
                move.X += 4;

            if (jump && (!cutsceneController.active) ? key.IsKeyDown(Keys.Space): cutsceneController.GetMove(CutsceneController.MoveControlls.Jump))
            {
                move.Y = -20;
                jump = false;
                animationState = AnimatedSprite.AnimationStates.Jumping;
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

            if (jump == true)
            {
                if (move.Length() > 0)
                    animationState = AnimatedSprite.AnimationStates.Walking;
                else
                    animationState = AnimatedSprite.AnimationStates.Idle;
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

        public void Update(GameTime gTime)
        {
            if(cutsceneController.active)
            {
                cutsceneController.Update(gTime);
            }
            KeyboardInput();
            animatedSprite.Update(gTime, animationState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (cutsceneController.active)
            {
                cutsceneController.Draw(spriteBatch);
            }
            //spriteBatch.Draw(texture, position, Color.White);
            animatedSprite.Draw(spriteBatch, position);
        }
    }
}
