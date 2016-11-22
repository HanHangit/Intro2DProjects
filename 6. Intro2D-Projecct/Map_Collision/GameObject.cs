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

        public Vector2 position { get; protected set; }
        public Point size { get; protected set; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(position.ToPoint(), size);
            }
        }

        public GameObject(Texture2D text, Vector2 pos)
        {
            position = pos;
            texture = text;
            size = text.Bounds.Size;

            Initialize();
        }

        protected abstract void Initialize();

        protected abstract void OnPlayerCollision();

        public virtual void Update(GameTime gTime)
        {

            Rectangle me = new Rectangle(position.ToPoint(), size);
                if (me.Intersects(GameStuff.Instance.player.Bounds))
                    OnPlayerCollision();

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Bounds, texture.Bounds, Color.White);
        }
    }
}
