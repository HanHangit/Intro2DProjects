using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Collision
{
    abstract class GameObject
    {
        Texture2D texture;
        public Vector2 position;
        public Point size;

        public GameObject(Texture2D text, Vector2 pos)
        {
            texture = text;
            position = pos;
            size = text.Bounds.Size;

            Initialize();
        }

        protected abstract void Initialize();

        protected abstract void OnPlayerCollision();

        public virtual void Update(GameTime gTime)
        {
            Rectangle me = new Rectangle(position.ToPoint(), size);
            Rectangle player = new Rectangle(GameStuff.Instance.player.position.ToPoint(), GameStuff.Instance.player.size.ToPoint());

            if (me.Intersects(player))
                OnPlayerCollision();

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
