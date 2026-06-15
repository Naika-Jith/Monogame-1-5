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


        // Dialogue boxes
        Texture2D dialogue1Texture;
        Texture2D dialogue2Texture;
        Texture2D dialogue3Texture;
        Texture2D dialogue4Texture;
        Texture2D dialogue5Texture;
        Texture2D dialogue6Texture;
        Texture2D dialogue7Texture;
        Texture2D dialogue8Texture;

        Rectangle dialogue1Rect;
        Rectangle dialogue2Rect;
        Rectangle dialogue3Rect;
        Rectangle dialogue4Rect;
        Rectangle dialogue5Rect;
        Rectangle dialogue6Rect;
        Rectangle dialogue7Rect;
        Rectangle dialogue8Rect;


        MouseState mouseState;
        MouseState previousMouse;

        float timer;

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

            timer = 0;

            //Screens

            introRect = new Rectangle(0, 0, 950, 600);
            detentionRect = new Rectangle(0, 0, 950, 600);
            hallwayRect = new Rectangle(0, 0, 950, 600);
            abandonedRect = new Rectangle(0, 0, 950, 600);
            endRect = new Rectangle(0, 0, 950, 600);

            //Characters

            malfoyRect = new Rectangle(5, 320, 310, 290);
            damonRect = new Rectangle(200, 317, 187, 290);
            snapeRect = new Rectangle(340, 320, 300, 290);
            axelRect = new Rectangle(530, 330, 250, 290);  
            romeoRect = new Rectangle(720, 330, 250, 270);


            //Buttons

            proceedRect = new Rectangle(23, 14, 325, 115);

            //Dialogues

            timer = 0;

            dialogue1Rect = new Rectangle(150, 50, 150, 150);
            dialogue2Rect = new Rectangle(150, 50, 150, 150);
            dialogue3Rect = new Rectangle(150, 50, 150, 150);
            dialogue4Rect = new Rectangle(150, 50, 150, 150);
            dialogue5Rect = new Rectangle(150, 50, 150, 150);
            dialogue6Rect = new Rectangle(150, 50, 150, 150);
            dialogue7Rect = new Rectangle(150, 50, 150, 150);
            dialogue8Rect = new Rectangle(150, 50, 150, 150);



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

            //Dialogues

            dialogue1Texture = Content.Load<Texture2D>("dialogue1");
            dialogue2Texture = Content.Load<Texture2D>("dialogue2");
            dialogue3Texture = Content.Load<Texture2D>("dialogue3");
            dialogue4Texture = Content.Load<Texture2D>("dialogue4");
            dialogue5Texture = Content.Load<Texture2D>("dialogue5");
            dialogue6Texture = Content.Load<Texture2D>("dialogue6");
            dialogue7Texture = Content.Load<Texture2D>("dialogue7");
            dialogue8Texture = Content.Load<Texture2D>("dialogue8");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            previousMouse = mouseState;
            mouseState = Mouse.GetState();

            bool clicked = mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released;

            this.Window.Title = mouseState.Position.ToString();


            if (currentScreen == Screen.Intro)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer >= 5f)
                {
                    if (clicked && proceedRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.Detention;
                        timer = 0;
                    }
                }
            }


            else if (currentScreen == Screen.Detention)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer >= 24 && clicked && proceedRect.Contains(mouseState.Position))
                {
                    currentScreen = Screen.Hallway;
                    timer = 0;
                }
            }




            else if (currentScreen == Screen.Hallway)
            {
                if (clicked && proceedRect.Contains(mouseState.Position))
                {
                    currentScreen = Screen.Abandoned;
                }
            }

            else if (currentScreen == Screen.Abandoned)
            {
                if (clicked && proceedRect.Contains(mouseState.Position))
                {
                    currentScreen = Screen.End;
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

                if (proceedRect.Contains(mouseState.Position))
                {
                    currentScreen = Screen.Detention;
                    timer = 0;
                }

            }

            else if (currentScreen == Screen.Detention)
            {

                if (timer >= 24)
                {
                    _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
                }

                _spriteBatch.Draw(detentionTexture, detentionRect, Color.White);
                _spriteBatch.Draw(malfoyTexture, malfoyRect, Color.White);
                _spriteBatch.Draw(damonTexture, damonRect, Color.White);
                _spriteBatch.Draw(snapeTexture, snapeRect, Color.White);
                _spriteBatch.Draw(axelTexture, axelRect, Color.White);
                _spriteBatch.Draw(romeoTexture, romeoRect, Color.White);

                _spriteBatch.Draw(detentionTexture, detentionRect, Color.White);

                _spriteBatch.Draw(malfoyTexture, malfoyRect, Color.White);
                _spriteBatch.Draw(damonTexture, damonRect, Color.White);
                _spriteBatch.Draw(snapeTexture, snapeRect, Color.White);
                _spriteBatch.Draw(axelTexture, axelRect, Color.White);
                _spriteBatch.Draw(romeoTexture, romeoRect, Color.White);

                if (timer < 3)
                {
                    _spriteBatch.Draw(dialogue1Texture, dialogue1Rect, Color.White);
                }
                else if (timer < 6)
                {
                    _spriteBatch.Draw(dialogue2Texture, dialogue2Rect, Color.White);
                }
                else if (timer < 9)
                {
                    _spriteBatch.Draw(dialogue3Texture, dialogue3Rect, Color.White);
                }
                else if (timer < 12)
                {
                    _spriteBatch.Draw(dialogue4Texture, dialogue4Rect, Color.White);
                }
                else if (timer < 15)
                {
                    _spriteBatch.Draw(dialogue5Texture, dialogue5Rect, Color.White);
                }
                else if (timer < 18)
                {
                    _spriteBatch.Draw(dialogue6Texture, dialogue6Rect, Color.White);
                }
                else if (timer < 21)
                {
                    _spriteBatch.Draw(dialogue7Texture, dialogue7Rect, Color.White);
                }
                else if (timer < 24)
                {
                    _spriteBatch.Draw(dialogue8Texture, dialogue8Rect, Color.White);
                }
                else
                {
                    _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
                }


            }

            else if (currentScreen == Screen.Hallway)
            {
                _spriteBatch.Draw(hallwayTexture, hallwayRect, Color.White);
                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
                _spriteBatch.Draw(malfoyTexture, malfoyRect, Color.White);
                _spriteBatch.Draw(damonTexture, damonRect, Color.White);
                _spriteBatch.Draw(snapeTexture, snapeRect, Color.White);
                _spriteBatch.Draw(axelTexture, axelRect, Color.White);
                _spriteBatch.Draw(romeoTexture, romeoRect, Color.White);
            }

            else if (currentScreen == Screen.Abandoned)
            {
                _spriteBatch.Draw(abandonedTexture, abandonedRect, Color.White);
                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
                _spriteBatch.Draw(malfoyTexture, malfoyRect, Color.White);
                _spriteBatch.Draw(damonTexture, damonRect, Color.White);
                _spriteBatch.Draw(snapeTexture, snapeRect, Color.White);
                _spriteBatch.Draw(axelTexture, axelRect, Color.White);
                _spriteBatch.Draw(romeoTexture, romeoRect, Color.White);
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
