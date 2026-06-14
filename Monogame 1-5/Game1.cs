using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_1_5
{
    public class Game1 : Game
    {

        enum Screen
        {
            Intro,
            Detention,
            Hallway,
            Abandoned,
            End
        }

        Screen currentScreen;





        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        //Characters

        Texture2D snapeTexture;
        Rectangle snapeRect;

        Texture2D malfoyTexture;
        Rectangle malfoyRect;

        Texture2D damonTexture;
        Rectangle damonRect;

        Texture2D axelTexture;
        Rectangle axelRect;

        Texture2D romeoTexture;
        Rectangle romeoRect;

        //Screens

        Texture2D introTexture;
        Rectangle introRect;

        Texture2D detentionTexture;
        Rectangle detentionRect;

        Texture2D hallwayTexture;
        Rectangle hallwayRect;

        Texture2D abandonedTexture;
        Rectangle abandonedRect;

        Texture2D endTexture;
        Rectangle endRect;

        //font

        SpriteFont font;

        //Buttons

        Texture2D proceedTexture;
        Rectangle proceedRect;

        MouseState mouseState;
        MouseState previousMouse;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 950, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            currentScreen = Screen.Intro;

            //Screens

            introRect = new Rectangle(0, 0, 950, 600);
            detentionRect = new Rectangle(0, 0, 950, 600);
            hallwayRect = new Rectangle(0, 0, 950, 600);
            abandonedRect = new Rectangle(0, 0, 950, 600);
            endRect = new Rectangle(0, 0, 950, 600);

            //Characters

            malfoyRect = new Rectangle(30, 50, 150, 90);
            damonRect = new Rectangle(30, 50, 150, 90);
            snapeRect = new Rectangle(30, 50, 150, 90);
            romeoRect = new Rectangle(30, 50, 150, 90);
            axelRect = new Rectangle(30, 50, 150, 80);

            //Buttons

            proceedRect = new Rectangle(23, 14, 325, 115);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Screens

            introTexture = Content.Load<Texture2D>("intro");
            detentionTexture = Content.Load<Texture2D>("detention");
            hallwayTexture = Content.Load<Texture2D>("hallway");
            abandonedTexture = Content.Load<Texture2D>("abandoned");
            endTexture = Content.Load<Texture2D>("end");

            //Characters

            malfoyTexture = Content.Load<Texture2D>("malfoy");
            axelTexture = Content.Load<Texture2D>("axel");
            damonTexture = Content.Load<Texture2D>("damon");
            snapeTexture = Content.Load<Texture2D>("snape");
            romeoTexture = Content.Load<Texture2D>("romeo");

            //Buttons

            proceedTexture = Content.Load<Texture2D>("proceed");

            //Font

            font = Content.Load<SpriteFont>("font");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            previousMouse = mouseState;
            mouseState = Mouse.GetState();

            this.Window.Title = mouseState.Position.ToString();


            if (currentScreen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
                {

                    if (proceedRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.Detention;
                    }

                }

            }


            else if (currentScreen == Screen.Detention)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
                {

                    if (proceedRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.Hallway;
                    }

                }

            }


            else if (currentScreen == Screen.Hallway)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
                {

                    if (proceedRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.Abandoned;
                    }

                }

            }

            else if (currentScreen == Screen.Abandoned)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
                {

                    if (proceedRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.End;
                    }

                }

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Azure);

            // TODO: Add your drawing code here


            _spriteBatch.Begin();

            if (currentScreen == Screen.Intro)  //Intro screen
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
                _spriteBatch.DrawString(font, "Lorem Ipsum Sit Dolor", new Vector2(20, 500), Color.Gold);

            }

            else if (currentScreen == Screen.Detention)
            {
                _spriteBatch.Draw(detentionTexture, detentionRect, Color.White);
                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
            }

            else if (currentScreen == Screen.Hallway)
            {
                _spriteBatch.Draw(hallwayTexture, hallwayRect, Color.White);
                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
            }

            else if (currentScreen == Screen.Abandoned)
            {
                _spriteBatch.Draw(abandonedTexture, abandonedRect, Color.White);
                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
            }

            else if (currentScreen == Screen.End)
            {
                _spriteBatch.Draw(endTexture, endRect, Color.White);
                _spriteBatch.DrawString(font, "Lorem Ipum Sit Dolor", new Vector2(20, 500), Color.Gold);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
