using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Intro_18._10
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Declaration of class member variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Texture of our Human
        Texture2D human;

        Enemy bernd;

        //Position of our human
        Vector2 position;

        Vector2 move;




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
            // TODO: Add your initialization logic here

            //Set our position
            position = new Vector2(0, 0);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            human = Content.Load<Texture2D>("human");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        void KeyboardInput()
        {
            //Just save our KeyboardState in Key
            KeyboardState key = Keyboard.GetState();

            //Set Move-Vector to (0,0)
            move = Vector2.Zero;

            //Check if Left Key is Down
            if (key.IsKeyDown(Keys.Left))
                move.X += -1;

            //Check if Right Key is Down
            if (key.IsKeyDown(Keys.Right))
                move.X += 1;

            //Check if Up Key is Down
            if (key.IsKeyDown(Keys.Up))
                move.Y += -1;

            //Check if Down Key is Down
            if (key.IsKeyDown(Keys.Down))
                move.Y += 1;

            position += move;


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

            // TODO: Add your update logic here

            KeyboardInput();

            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Clear and Draw new Background
            GraphicsDevice.Clear(Color.CornflowerBlue);


            //spriteBatch.Begin() Call! Dont Forget!
            spriteBatch.Begin();

            //Drawing Function spriteBatch.Draw("Our Texture", "Position", "Color Mask")
            spriteBatch.Draw(human, position, Color.White);


            //spriteBatch.End() Call! Dont Forget!
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
