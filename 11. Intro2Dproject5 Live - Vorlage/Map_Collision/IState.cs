using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Collision
{
    enum EState
    {
        None,
        MainMenu,
        PlayState,
        Exit
    }
    interface IState
    {
        void LoadContent(ContentManager content);
        EState Update(GameTime gTime);
        void Draw(SpriteBatch spriteBatch);

    }
}
