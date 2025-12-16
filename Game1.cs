using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SantaClash
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D pixel;
        Vector2 playerPosition;
        float speed = 300f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            playerPosition = new Vector2(400, 240);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //test joystick 0
            JoystickState state = Joystick.GetState(0);

            if (state.IsConnected && state.Axes.Length > 0)
            {
                float axisX = state.Axes[0]; // -1 à +1
                playerPosition.X += axisX * speed * dt;
            }

            // Limites écran
            playerPosition.X = MathHelper.Clamp(playerPosition.X, 0, 800 - 40);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //Impossible d'ouvrir le Content.mgcb Donc dessin
            //Corps
            spriteBatch.Draw(pixel,
                new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 40, 60),
                Color.Black);

            // Tête
            spriteBatch.Draw(pixel,
                new Rectangle((int)playerPosition.X + 10, (int)playerPosition.Y - 20, 20, 20),
                Color.Black);

            //Corps p2
            spriteBatch.Draw(pixel,
                new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 40, 60),
                Color.Black);

            // Tête p2
            spriteBatch.Draw(pixel,
                new Rectangle((int)playerPosition.X + 10, (int)playerPosition.Y - 20, 20, 20),
                Color.Black);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
