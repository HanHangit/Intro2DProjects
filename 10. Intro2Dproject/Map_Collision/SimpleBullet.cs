using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map_Collision
{
    class SimpleBullet : Bullet
    {
        public SimpleBullet(Texture2D text, Vector2 pos, Vector2 dir, float spd, float dmg) : 
            base(text, pos, dir, spd, dmg)
        {

        }

        

        protected override void OnPlayerCollision()
        {
            base.OnPlayerCollision();
            GameStuff.Instance.player.ApplyDamage(damage);
        }

    }
}
