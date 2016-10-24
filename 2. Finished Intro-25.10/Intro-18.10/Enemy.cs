using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Intro_18._10
{
    class Enemy
    {
        //Class Member Declaration

        //MovingSpeed
        float speed;

        //Current Position
        public Vector2 position;

        //Size of Texture
        public Vector2 size;

        //Current LifePoints
        float health;

        //Attack Damage
        float damage;

        //Human Texture
        Texture2D texture;

        //MoveVector
        Vector2 move;

        //The Target we want to follow
        Player target;

        public Enemy(Texture2D text, Vector2 pos, float speed, float _health, float _damage, Player tar)
        {
            this.speed = speed;
            health = _health;
            damage = _damage;
            position = pos;
            texture = text;
            target = tar;

            size = new Vector2(text.Width, text.Height);
        }

        void FollowTarget()
        {
            //Calculate Direction Vector to Player
            move = target.position - position;

            //Normalize to set Length to 1
            move.Normalize();

            //Set our speed
            move *= speed;

            //Simple Collision
            /*
            //AttackRange
            int r = 50;
            if((position - target.position).Length() > r)
                position += move;
            */

            //Check Collision for two Rectangles
            if (position.X < target.position.X + target.size.X
                && position.X + size.X > target.position.X
                && position.Y < target.position.Y + target.size.Y
                && position.Y + size.Y > target.position.Y)
                target.ApplyDamage(damage);
            else
                position += move;


        }

        public void Update(GameTime gTime)
        {
            //Call Moving Function
            FollowTarget();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
