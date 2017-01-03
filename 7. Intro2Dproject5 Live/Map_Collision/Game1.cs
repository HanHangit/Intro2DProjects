﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Map_Collision
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Stopwatch stop;
        PopUp deadPopup;
        bool pause;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            pause = false;
            // TODO: Add your initialization logic here
            GameStuff.Instance.player = new Player(Content.Load<Texture2D>("human"), new Vector2(100, 100), 1f, 100f);

            GameStuff.Instance.tileMap = new Tilemap(new Texture2D[] { Content.Load<Texture2D>("grass"), Content.Load<Texture2D>("rock") }, Content.Load<Texture2D>("NewTower"), 16);
            base.Initialize();

            GameStuff.Instance.bulletTexture[0] = Content.Load<Texture2D>("Bullet");

            stop = new System.Diagnostics.Stopwatch();

            GameStuff.Instance.camera = new Camera(graphics.GraphicsDevice.Viewport);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GameStuff.Instance.enemyList.Add(new EnemyOnPlattform(Content.Load<Texture2D>("Hunter"), new Vector2(260, 500), 1, 1));

            GameStuff.Instance.enemyList.Add(new EnemyOnRangePlattform(Content.Load<Texture2D>("Hunter"), new Vector2(1000, 500), 1, 1f, 3));

            deadPopup = new PopUp(Content.Load<SpriteFont>("SimpleText"),
                new Rectangle(200, 200, 100, 100), "Game Over!!!", Content.Load<Texture2D>("rock"));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (pause)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    pause = false;
                return;
            }

            if (GameStuff.Instance.player.health <= 0)
                pause = true;

            // TODO: Add your update logic here
            GameStuff.Instance.tileMap.Update(gameTime);
            GameStuff.Instance.player.Update(gameTime);

            foreach (GameObject g in GameStuff.Instance.enemyList)
                g.Update(gameTime);

            for(int i = 0; i < GameStuff.Instance.bullet.Count; ++i)
            {
                if (GameStuff.Instance.bullet[i].alive)
                    GameStuff.Instance.bullet[i].Update(gameTime);
                else
                {
                    GameStuff.Instance.bullet.RemoveAt(i--);
                }
            }
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(transformMatrix: GameStuff.Instance.camera.GetViewMatrix());
            // TODO: Add your drawing code here
            GameStuff.Instance.tileMap.Draw(spriteBatch);
            GameStuff.Instance.player.Draw(spriteBatch);

            foreach (GameObject g in GameStuff.Instance.enemyList)
                g.Draw(spriteBatch);

            foreach (Bullet b in GameStuff.Instance.bullet)
                b.Draw(spriteBatch);

            if (pause)
                deadPopup.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
