using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map_Collision
{
    class RocketBullet : SimpleBullet
    {
        float atkSpeed;
        float timer;

        public RocketBullet(Texture2D text, Vector2 pos, Vector2 dir, float spd, float dmg, float attackSpeed) : base(text, pos, dir, spd, dmg)
        {
            atkSpeed = attackSpeed;
            timer = atkSpeed;
        }

        Vector2 rotate(Vector2 vec, float angle)
        {
            angle = MathHelper.ToRadians(angle);
            return new Vector2(vec.X * (float)Math.Cos(angle) - vec.Y * (float)Math.Sin(angle),
                vec.X * (float)Math.Sin(angle) + vec.Y * (float)Math.Cos(angle));            
        }
        
        public override void Update(GameTime gTime)
        {
            base.Update(gTime);

            timer -= (float)gTime.ElapsedGameTime.TotalSeconds;

            if(timer <= 0)
            {
                timer += atkSpeed;

//                Vector2 dir1 = rotate(direction, 10);
//                Vector2 dir2 = rotate(direction, -10);
//
//                GameStuff.Instance.bullet.Add(new RocketBullet(GameStuff.Instance.bulletTexture[0], position, dir1, 2, 1,2f));
//                GameStuff.Instance.bullet.Add(new RocketBullet(GameStuff.Instance.bulletTexture[0], position, dir2, 2, 1,2f));
            }

        }
    }
}
