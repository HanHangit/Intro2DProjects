using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Collision
{
    abstract class Bullet
    {
        float speed;
        protected float damage;
        protected Vector2 position, direction;
        Texture2D texture;
        public bool alive;

        public Bullet(Texture2D text, Vector2 pos, Vector2 dir, float spd, float dmg)
        {
            texture = text;
            position = pos;
            direction = Vector2.Normalize(dir);
            speed = spd;
            damage = dmg;
            alive = true;
        }

        protected virtual void OnPlayerCollision()
        {
            alive = false;
        }

        public virtual void Update(GameTime gTime)
        {
            Rectangle me = new Rectangle(position.ToPoint(), texture.Bounds.Size);
            Rectangle player = new Rectangle(GameStuff.Instance.player.position.ToPoint(), 
                GameStuff.Instance.player.size.ToPoint());

            if (me.Intersects(player) && alive)
                OnPlayerCollision();

            position += direction * speed;

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
