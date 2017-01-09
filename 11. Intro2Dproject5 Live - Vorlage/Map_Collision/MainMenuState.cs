using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Map_Collision
{
    class MainMenuState : IState
    {
        SpriteFont text;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(text, "Druecken Sie 'B' um das Spiel zu starten",new Vector2(100,200), Color.Red);

            spriteBatch.End();
        }

        public void LoadContent(ContentManager content)
        {
            text = content.Load<SpriteFont>("SimpleText");
        }

        public EState Update(GameTime gTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.B))
                return EState.PlayState;

            return EState.MainMenu;
        }
    }
}
