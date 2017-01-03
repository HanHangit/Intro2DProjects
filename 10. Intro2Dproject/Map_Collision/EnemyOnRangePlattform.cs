using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map_Collision
{
    class EnemyOnRangePlattform : EnemyOnPlattform
    {

        float timer, attackSpeed;

        public EnemyOnRangePlattform(Texture2D text, Vector2 pos, float dmg, float speed, float atkSpeed) : base(text, pos, dmg, speed)
        {
            timer = atkSpeed;
            attackSpeed = atkSpeed;
        }

        public override void Update(GameTime gTime)
        {
            base.Update(gTime);
            timer -= (float)gTime.ElapsedGameTime.TotalSeconds;

            if(timer <= 0)
            {
                timer += attackSpeed;

                Vector2 dir = GameStuff.Instance.player.position - position;

                GameStuff.Instance.bullet.Add(new RocketBullet(GameStuff.Instance.bulletTexture[0], position, dir, 2, 5,1));
            }
        }
    }
}
