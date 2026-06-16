using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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

      

        // Dialogue boxes
        Texture2D dialogue1Texture;
        Texture2D dialogue2Texture;
        Texture2D dialogue3Texture;
        Texture2D dialogue4Texture;
        Texture2D dialogue5Texture;
        Texture2D dialogue6Texture;
        Texture2D dialogue7Texture;
        Texture2D dialogue8Texture;
        Texture2D dialogue9Texture;
        Texture2D dialogue10Texture;
        Texture2D dialogue11Texture;
        Texture2D dialogue12Texture;
        Texture2D dialogue13Texture;
        Texture2D dialogue14Texture;
        Texture2D dialogue15Texture;
        Texture2D dialogue16Texture;
        Texture2D dialogue17Texture;
        Texture2D dialogue18Texture;
        Texture2D dialogue19Texture;
        Texture2D dialogue20Texture;

        Rectangle dialogue1Rect;
        Rectangle dialogue2Rect;
        Rectangle dialogue3Rect;
        Rectangle dialogue4Rect;
        Rectangle dialogue5Rect;
        Rectangle dialogue6Rect;
        Rectangle dialogue7Rect;
        Rectangle dialogue8Rect;
        Rectangle dialogue9Rect;
        Rectangle dialogue10Rect;
        Rectangle dialogue11Rect;
        Rectangle dialogue12Rect;
        Rectangle dialogue13Rect;
        Rectangle dialogue14Rect;
        Rectangle dialogue15Rect;
        Rectangle dialogue16Rect;
        Rectangle dialogue17Rect;
        Rectangle dialogue18Rect;
        Rectangle dialogue19Rect;
        Rectangle dialogue20Rect;


        MouseState mouseState;
        MouseState previousMouse;

        float timer;
        bool hallwaySetup;
        bool abandonedSetup;

        SoundEffect backgroundMusic;
        SoundEffectInstance musicInstance;
        SoundEffect dunSound;



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

            //Chracters
            
            snapeRect = new Rectangle(0, 320, 300, 290);
            malfoyRect = new Rectangle(1200, 320, 310, 290);
            damonRect = new Rectangle(1200, 317, 187, 290);
            axelRect = new Rectangle(1200, 330, 250, 290);
            romeoRect = new Rectangle(1200, 330, 250, 270);

            //Dialogues

            timer = 0;

            dialogue1Rect = new Rectangle(60, 100, 170, 170);  // Snape
            dialogue2Rect = new Rectangle(291, 100, 170, 170);   // Draco
            dialogue3Rect = new Rectangle(60, 100, 170, 170);  // Snape
            dialogue4Rect = new Rectangle(451, 100, 170, 170);  // Axel
            dialogue5Rect = new Rectangle(651,100, 170, 170);  // Romeo
            dialogue6Rect = new Rectangle(60, 100, 170, 170);  // Snape
            dialogue7Rect = new Rectangle(451, 100, 170, 170);  // Axel
            dialogue8Rect = new Rectangle(60, 100, 170, 170);  // Snape

            dialogue9Rect = new Rectangle(451, 100, 170, 170);   // Axel
            dialogue10Rect = new Rectangle(60, 100, 170, 170);  // Damon
            dialogue11Rect = new Rectangle(651, 100, 170, 170);  // Romeo
            dialogue12Rect = new Rectangle(60, 100, 170, 170);  // Damon
            dialogue13Rect = new Rectangle(344, 100, 170, 170);   // Draco
            dialogue14Rect = new Rectangle(60, 100, 170, 170);  // Damon
            dialogue15Rect = new Rectangle(344, 100, 170, 170);   // Draco
            dialogue16Rect = new Rectangle(451, 100, 170, 170);  // Axel
            dialogue17Rect = new Rectangle(344, 100, 170, 170);  // Draco

            dialogue18Rect = new Rectangle(320, 100, 170, 170);  // Damon
            dialogue19Rect = new Rectangle(106, 100, 170, 170);  // Draco
            dialogue20Rect = new Rectangle(508, 100, 170, 170);  // Snape


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
            dialogue9Texture = Content.Load<Texture2D>("dialogue9");
            dialogue10Texture = Content.Load<Texture2D>("dialogue10");
            dialogue11Texture = Content.Load<Texture2D>("dialogue11");
            dialogue12Texture = Content.Load<Texture2D>("dialogue12");
            dialogue13Texture = Content.Load<Texture2D>("dialogue13");
            dialogue14Texture = Content.Load<Texture2D>("dialogue14");
            dialogue15Texture = Content.Load<Texture2D>("dialogue15");
            dialogue16Texture = Content.Load<Texture2D>("dialogue16");
            dialogue17Texture = Content.Load<Texture2D>("dialogue17");
            dialogue18Texture = Content.Load<Texture2D>("dialogue18");
            dialogue19Texture = Content.Load<Texture2D>("dialogue19");
            dialogue20Texture = Content.Load<Texture2D>("dialogue20");

            //Music

            backgroundMusic = Content.Load<SoundEffect>("soykhaler-dramatic-piano-10950");
            dunSound = Content.Load<SoundEffect>("mrdwarf92-dramatic-dun-dun-dun-460379");

            musicInstance = backgroundMusic.CreateInstance();
            musicInstance.IsLooped = true;
            musicInstance.Play();

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
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer >= 5f)
                {
                    currentScreen = Screen.Detention;
                    timer = 0;
                }
            }


            else if (currentScreen == Screen.Detention)
            {

                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Draco enters first
                if (timer > 1 && malfoyRect.X > 170)
                {
                    malfoyRect.X -= 4;
                }

                // Axel enters
                if (timer > 6 && axelRect.X > 370)
                {
                    axelRect.X -= 4;
                }

                // Romeo enters
                if (timer > 9 && romeoRect.X > 570)
                {
                    romeoRect.X -= 4;
                }

                // Damon enters
                if (timer > 14 && damonRect.X > 770)
                {
                    damonRect.X -= 4;
                }

                if (timer >= 24)
                {
                    currentScreen = Screen.Hallway;
                    timer = 0;
                    hallwaySetup = false;
                }

            }


            else if (currentScreen == Screen.Hallway)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (!hallwaySetup)
                {
                    malfoyRect.X = 170;
                    malfoyRect.Y = 320;

                    axelRect.X = 370;
                    axelRect.Y = 330;

                    romeoRect.X = 570;
                    romeoRect.Y = 330;

                    damonRect.X = -250;
                    damonRect.Y = 317;

                    hallwaySetup = true;
                }

                // Damon enters after Axel talks

                if (timer > 3 && damonRect.X < 60)
                {
                    damonRect.X += 4;
                }

                if (timer >= 27)
                {
                    currentScreen = Screen.Abandoned;
                    timer = 0;
                    abandonedSetup = false;
                }
            }

            else if (currentScreen == Screen.Abandoned)
            {

                if (!abandonedSetup)
                {
                    malfoyRect.X = 20;
                    malfoyRect.Y = 320;

                    damonRect.X = 220;
                    damonRect.Y = 317;

                    snapeRect.X = 1200;
                    snapeRect.Y = 320;

                    abandonedSetup = true;
                }

                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

               

                // Snape enters on his dialogue

                if (timer > 6 && snapeRect.X > 430)
                {
                    snapeRect.X -= 5;
                }


              if (timer >= 15)
              {
                dunSound.Play();
                currentScreen = Screen.End;
                timer = 0;
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
                _spriteBatch.DrawString(font, "Welcome to Dacelis Academy", new Vector2(6, 220), Color.Gold);
            }

            else if (currentScreen == Screen.Detention)
            {

                _spriteBatch.Draw(detentionTexture, detentionRect, Color.White);

                _spriteBatch.Draw(malfoyTexture, malfoyRect, Color.White);
                _spriteBatch.Draw(damonTexture, damonRect, Color.White);
                _spriteBatch.Draw(snapeTexture, snapeRect, Color.White);
                _spriteBatch.Draw(axelTexture, axelRect, Color.White);
                _spriteBatch.Draw(romeoTexture, romeoRect, Color.White);

                if (timer < 4)
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
               


            }

            else if (currentScreen == Screen.Hallway)
            {
                _spriteBatch.Draw(hallwayTexture, hallwayRect, Color.White);

                _spriteBatch.Draw(malfoyTexture, malfoyRect, Color.White);
                _spriteBatch.Draw(damonTexture, damonRect, Color.White);
                _spriteBatch.Draw(axelTexture, axelRect, Color.White);
                _spriteBatch.Draw(romeoTexture, romeoRect, Color.White);


                if (timer < 3)
                {
                    _spriteBatch.Draw(dialogue9Texture, dialogue9Rect, Color.White);
                }
                else if (timer < 6)
                {
                    _spriteBatch.Draw(dialogue10Texture, dialogue10Rect, Color.White);
                }
                else if (timer < 9)
                {
                    _spriteBatch.Draw(dialogue11Texture, dialogue11Rect, Color.White);
                }
                else if (timer < 12)
                {
                    _spriteBatch.Draw(dialogue12Texture, dialogue12Rect, Color.White);
                }
                else if (timer < 15)
                {
                    _spriteBatch.Draw(dialogue13Texture, dialogue13Rect, Color.White);
                }
                else if (timer < 18)
                {
                    _spriteBatch.Draw(dialogue14Texture, dialogue14Rect, Color.White);
                }
                else if (timer < 21)
                {
                    _spriteBatch.Draw(dialogue15Texture, dialogue15Rect, Color.White);
                }
                else if (timer < 24)
                {
                    _spriteBatch.Draw(dialogue16Texture, dialogue16Rect, Color.White);
                }

                else if (timer < 27)
                {
                    _spriteBatch.Draw(dialogue17Texture, dialogue17Rect, Color.White);
                }



            }

            else if (currentScreen == Screen.Abandoned)
            {
                _spriteBatch.Draw(abandonedTexture, abandonedRect, Color.White);

                _spriteBatch.Draw(malfoyTexture, malfoyRect, Color.White);
                _spriteBatch.Draw(damonTexture, damonRect, Color.White);
                _spriteBatch.Draw(snapeTexture, snapeRect, Color.White);

                
                if (timer < 3)
                {
                    _spriteBatch.Draw(dialogue18Texture, dialogue18Rect, Color.White);
                }
                else if (timer < 6)
                {
                    _spriteBatch.Draw(dialogue19Texture, dialogue19Rect, Color.White);
                }
                else if (timer < 15)
                {
                    _spriteBatch.Draw(dialogue20Texture, dialogue20Rect, Color.White);
                }
               
               
            }

            else if (currentScreen == Screen.End)
            {
                _spriteBatch.Draw(endTexture, endRect, Color.White);
                _spriteBatch.DrawString(font, "And the chaos continues...", new Vector2(6, 220), Color.Gold);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
