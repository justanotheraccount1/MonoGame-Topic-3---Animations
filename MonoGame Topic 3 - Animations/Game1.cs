using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame_Topic_3___Animations
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTribbleTexture;
        Rectangle greyTribbleRect;
        Texture2D brownTribbleTexture;
        Rectangle brownTribbleRect;
        Rectangle window;
        Random generator = new Random();

        Vector2 greyTribbleSpeed;
        Vector2 brownTribbleSpeed;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            greyTribbleRect = new Rectangle((generator.Next(700)), generator.Next(500), 100, 100);
            greyTribbleSpeed = new Vector2 (5, 5);
            brownTribbleRect = new Rectangle(600, 10, 100, 100);
            brownTribbleSpeed = new Vector2(5, 0);
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            greyTribbleTexture = Content.Load<Texture2D>("tribbleGrey");
            brownTribbleTexture = Content.Load<Texture2D>("tribbleBrown");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            greyTribbleRect.X += (int)greyTribbleSpeed.X;
            greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
            if (greyTribbleRect.Right >= window.Width || greyTribbleRect.Left <= window.Left)
                greyTribbleSpeed.X *= -1;
            if (greyTribbleRect.Top <= window.Top || greyTribbleRect.Bottom >= window.Height)
                greyTribbleSpeed.Y *= -1;


            brownTribbleRect.X += (int)brownTribbleSpeed.X;
            brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
            if (brownTribbleRect.Right >= window.Width || brownTribbleRect.Left <= window.Left)
                brownTribbleSpeed.X *= -1;
            if (brownTribbleRect.Top <= window.Top || brownTribbleRect.Bottom >= window.Height)
                brownTribbleSpeed.Y *= -1;

            if (greyTribbleRect.Intersects(brownTribbleRect))
            {
                if (greyTribbleSpeed.X == 1 && brownTribbleSpeed.X == 1)

            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);
            _spriteBatch.Begin();

            _spriteBatch.Draw(greyTribbleTexture, greyTribbleRect, Color.White);
            _spriteBatch.Draw(brownTribbleTexture, brownTribbleRect, Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
