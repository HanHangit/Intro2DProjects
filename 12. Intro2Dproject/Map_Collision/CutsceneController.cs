using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Map_Collision
{
    
    public class CutsceneController
    {
        public enum MoveControlls
        {
            Left, 
            Right,
            Jump
        }

        String messageString;
        String currentString;
        float updateTime;
        float currentTime;
        Vector2 textPosition;

        List<MoveOrder> moveQueue;
        public bool active;
        SpriteFont font;

        public struct MoveOrder
        {   
            public MoveOrder(MoveControlls _order, float _xPos)
            {
                order = _order;
                xPos = _xPos;
            }

            public MoveControlls order;
            public float xPos;
        }


        public CutsceneController(List<MoveOrder> _moveQueue, SpriteFont _font)
        {
            moveQueue = _moveQueue;
            active = true;
            font = _font;

            messageString = "some random funny message...";
            currentString = "";
            updateTime = 60;
            currentTime = updateTime;
            textPosition = new Vector2(0, 200);
        }

        public void Update(GameTime gameTime)
        {
            currentTime -= gameTime.ElapsedGameTime.Milliseconds;
            if(currentTime < 0)
            {
                currentTime = updateTime;
                if (currentString.Length < messageString.Length)
                {
                    currentString += messageString[currentString.Length];
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, currentString, GameStuff.Instance.camera.position + textPosition, Color.White);
        }

        public bool GetMove(MoveControlls move)
        {
            if (moveQueue == null || moveQueue.Count == 0)
            {
                active = false;
                return false;
            }

            if(move == moveQueue[0].order)
            {
                if (moveQueue[0].order == MoveControlls.Left)
                {
                    if (GameStuff.Instance.player.position.X < moveQueue[0].xPos)
                        moveQueue.RemoveAt(0);
                }
                else if (moveQueue[0].order == MoveControlls.Right)
                {
                    if (GameStuff.Instance.player.position.X > moveQueue[0].xPos)
                        moveQueue.RemoveAt(0);
                }
                else
                {
                    if (moveQueue[0].order == MoveControlls.Jump)
                        moveQueue.RemoveAt(0);
                }
                return true;
            }
            return false;
        }
    }
}
