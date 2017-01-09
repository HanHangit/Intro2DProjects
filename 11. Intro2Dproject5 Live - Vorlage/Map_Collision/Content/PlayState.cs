using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Map_Collision
{
    class PlayState : IState
    {
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin(transformMatrix: GameStuff.Instance.camera.GetViewMatrix());
            // TODO: Add your drawing code here
            GameStuff.Instance.tileMap.Draw(spriteBatch);
            GameStuff.Instance.player.Draw(spriteBatch);

            foreach (GameObject g in GameStuff.Instance.enemyList)
                g.Draw(spriteBatch);

            foreach (Bullet b in GameStuff.Instance.bullet)
                b.Draw(spriteBatch);


            spriteBatch.End();
        }

        public void LoadContent(ContentManager Content)
        {
            // TODO: Add your initialization logic here
            GameStuff.Instance.player = new Player(Content.Load<Texture2D>("human"), new Vector2(100, 100), 1f, 100f);

            GameStuff.Instance.tileMap = new Tilemap(new Texture2D[] { Content.Load<Texture2D>("grass"), Content.Load<Texture2D>("rock") }, Content.Load<Texture2D>("NewTower"), 16);

            GameStuff.Instance.bulletTexture[0] = Content.Load<Texture2D>("Bullet");


            GameStuff.Instance.enemyList.Add(new EnemyOnPlattform(Content.Load<Texture2D>("Hunter"), new Vector2(260, 500), 1, 1));

            GameStuff.Instance.enemyList.Add(new EnemyOnRangePlattform(Content.Load<Texture2D>("Hunter"), new Vector2(1000, 500), 1, 1f, 3));
        }

        public EState Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                return EState.MainMenu;

            // TODO: Add your update logic here
            GameStuff.Instance.tileMap.Update(gameTime);
            GameStuff.Instance.player.Update(gameTime);

            foreach (GameObject g in GameStuff.Instance.enemyList)
                g.Update(gameTime);

            for (int i = 0; i < GameStuff.Instance.bullet.Count; ++i)
            {
                if (GameStuff.Instance.bullet[i].alive)
                    GameStuff.Instance.bullet[i].Update(gameTime);
                else
                {
                    GameStuff.Instance.bullet.RemoveAt(i--);
                }
            }

            return EState.PlayState;

        }
    }
}
