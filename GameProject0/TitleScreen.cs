using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq.Expressions;

namespace GameProject0
{
    public class TitleScreen : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _paddle;
        private Vector2 _paddlePlacement;
        private Texture2D _brick;
        private Vector2 _brickPlacement;
        private Texture2D _ball;
        private Vector2 _ballPlacement;
        private Texture2D _breakBall;
        private Vector2 _breakBallPlacement;
        private SpriteFont spriteFont;
        private StarSprite[] stars;
        

        public TitleScreen()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _paddlePlacement = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - 66, _graphics.GraphicsDevice.Viewport.Height - 100);
            _brickPlacement = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - 16, 0);
            _ballPlacement = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + 36, _graphics.GraphicsDevice.Viewport.Height - 135);
            _breakBallPlacement = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - 66, _graphics.GraphicsDevice.Viewport.Height - 135);
            System.Random rand = new System.Random();
            stars = new StarSprite[]
            {
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32)),
                new StarSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width - 32, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height - 32))
            };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _paddle = Content.Load<Texture2D>("Paddle");
            _brick = Content.Load<Texture2D>("Brick");
            _ball = Content.Load<Texture2D>("HitTest");
            _breakBall = Content.Load<Texture2D>("BreakBall.png");
            spriteFont = Content.Load<SpriteFont>("PublicPixel");
            foreach(var star in stars)
            {
                star.LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_paddle, _paddlePlacement, Color.White);
            _spriteBatch.Draw(_brick, _brickPlacement, Color.White);
            _spriteBatch.Draw(_ball, _ballPlacement, Color.White);
            _spriteBatch.Draw(_breakBall, _breakBallPlacement, Color.White);

            _spriteBatch.DrawString(spriteFont, "Breakdown", new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - 127, 100), Color.Gold);
            _spriteBatch.DrawString(spriteFont, "Press 'Esc' to exit the game", new Vector2(25, 200), Color.Gold);
            foreach(var star in stars)
            {
                star.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
