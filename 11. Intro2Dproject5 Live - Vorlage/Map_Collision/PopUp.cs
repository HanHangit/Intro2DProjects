using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Collision
{
    class PopUp
    {
        Rectangle window;
        string text;
        Texture2D texture;
        SpriteFont font;

        public PopUp(SpriteFont _font, Rectangle _window, string _text, Texture2D _texture)
        {
            font = _font;
            window = _window;
            text = _text;
            texture = _texture;
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 camPosition = GameStuff.Instance.camera.position;
            spriteBatch.Draw(texture, new Rectangle(camPosition.ToPoint(),window.Size), Color.White);
            spriteBatch.DrawString(font, text, camPosition, Color.White);
        }

    }
}
