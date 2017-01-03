using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Collision
{
    class EnemyOnPlattform : GameObject
    {
        float speed, damage;
        Vector2 move;


        public EnemyOnPlattform(Texture2D text, Vector2 pos, float dmg, float speed) : base(text,pos)
        {
            this.speed = speed;
            damage = dmg;
            move = new Vector2(1, 0);
        }


        protected override void Initialize()
        {
            Tilemap tileMap = GameStuff.Instance.tileMap;

            while (tileMap.Walkable(position + new Vector2(0, size.Y))
                && tileMap.Walkable(position + new Vector2(size.X, size.Y)))
                position += new Vector2(0,0.1f);
        }

        protected override void OnPlayerCollision()
        {
            GameStuff.Instance.player.ApplyDamage(damage);
        }

        public override void Update(GameTime gTime)
        {
            base.Update(gTime);
            if (speed < 0)
                if (!GameStuff.Instance.tileMap.Walkable(position + new Vector2(0, size.Y - 1) + move * speed)
                    || !GameStuff.Instance.tileMap.Walkable(position + new Vector2(0, 0) + move * speed)
                    || GameStuff.Instance.tileMap.Walkable(position + new Vector2(0,size.Y + 1) + move * speed))
                    speed *= -1;

            if (speed > 0)
                if (!GameStuff.Instance.tileMap.Walkable(position + new Vector2(
                    size.X, size.Y - 1) + move * speed)
                    || !GameStuff.Instance.tileMap.Walkable(position + new Vector2(size.X, 0) + move * speed)
                    || GameStuff.Instance.tileMap.Walkable(position + new Vector2(size.X, size.Y + 1) + move * speed))
                    speed *= -1;

            position += move * speed;
        }
    }
}
