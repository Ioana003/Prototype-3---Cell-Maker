using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prototype_3___Cell_Maker
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D cellTexture;
        private CreatureMaker creatMaker;
        private Rectangle defaultSize;
        private Rectangle[] editableBounds = new Rectangle[4];
        private MouseManager mouseManager;
        private bool usingBounds = false;
        private bool usingPart = false;
        private bool[] usingSpecificBound = new bool[4] { false, false, false, false };

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            cellTexture = Content.Load<Texture2D>("textRectangle");

            defaultSize = new Rectangle(Window.ClientBounds.Width / 2 - 25, Window.ClientBounds.Height / 2 - 25, 50, 50);

            creatMaker = new CreatureMaker(defaultSize, cellTexture);

            //Left side
            editableBounds[0] = new Rectangle(creatMaker.cellSize.X - 15 / 2, creatMaker.cellSize.Y + creatMaker.cellSize.Height / 2 - 15 / 2, 15, 15);

            //Right side
            editableBounds[1] = new Rectangle(creatMaker.cellSize.X + creatMaker.cellSize.Width - 15 / 2, creatMaker.cellSize.Y + creatMaker.cellSize.Height / 2 - 15 / 2, 15, 15);

            //Upper Side
            editableBounds[2] = new Rectangle(creatMaker.cellSize.X + creatMaker.cellSize.Width / 2 - 15 / 2, creatMaker.cellSize.Y - 15 / 2, 15, 15);

            //Lower Side
            editableBounds[3] = new Rectangle(creatMaker.cellSize.X + creatMaker.cellSize.Width / 2 - 15 / 2, creatMaker.cellSize.Y + creatMaker.cellSize.Height - 15 / 2, 15, 15);

            mouseManager = new MouseManager(false);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (usingPart == false)
            {
                int previousPositionX = creatMaker.cellSize.X;
                int previousPositionY = creatMaker.cellSize.Y;

                // Left Side
                if (usingSpecificBound[1] == false && usingSpecificBound[2] == false && usingSpecificBound[3] == false)
                {
                    if (mouseManager.IsMouseDown(editableBounds[0]))
                    {
                        usingSpecificBound[0] = true;

                        usingBounds = true;

                        editableBounds[0].X = Mouse.GetState().X - editableBounds[0].Width / 2;

                        if (Mouse.GetState().X < previousPositionX)
                        {
                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, creatMaker.cellSize.Y, creatMaker.cellSize.Width + (previousPositionX - Mouse.GetState().X), creatMaker.cellSize.Height);

                            creatMaker.cellSize = new Rectangle(editableBounds[0].X + editableBounds[0].Width / 2, creatMaker.cellSize.Y, creatMaker.cellSize.Width, creatMaker.cellSize.Height);

                            previousPositionX = creatMaker.cellSize.X;
                        }

                        else if (Mouse.GetState().X > previousPositionX)
                        {
                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, creatMaker.cellSize.Y, creatMaker.cellSize.Width - (Mouse.GetState().X - previousPositionX), creatMaker.cellSize.Height);

                            creatMaker.cellSize = new Rectangle(editableBounds[0].X + editableBounds[0].Width / 2, creatMaker.cellSize.Y, creatMaker.cellSize.Width, creatMaker.cellSize.Height);

                            previousPositionX = creatMaker.cellSize.X;
                        }

                    }
                }

                // Right Side
                if (usingSpecificBound[0] == false && usingSpecificBound[2] == false && usingSpecificBound[3] == false)
                {
                    if (mouseManager.IsMouseDown(editableBounds[1]))
                    {
                        usingSpecificBound[1] = true;

                        usingBounds = true;

                        editableBounds[1].X = Mouse.GetState().X - editableBounds[1].Width / 2;

                        if (Mouse.GetState().X > previousPositionX + creatMaker.cellSize.Width)
                        {
                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, creatMaker.cellSize.Y, creatMaker.cellSize.Width + (Mouse.GetState().X - (previousPositionX + creatMaker.cellSize.Width)), creatMaker.cellSize.Height);
                        }

                        else if(Mouse.GetState().X < previousPositionX + creatMaker.cellSize.Width)
                        {
                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, creatMaker.cellSize.Y, creatMaker.cellSize.Width - ((previousPositionX + creatMaker.cellSize.Width) - Mouse.GetState().X), creatMaker.cellSize.Height);
                        }
                    }
                }

                // Upper Side
                if (usingSpecificBound[0] == false && usingSpecificBound[1] == false && usingSpecificBound[3] == false)
                {
                    if (mouseManager.IsMouseDown(editableBounds[2]))
                    {
                        usingSpecificBound[2] = true;

                        usingBounds = true;

                        editableBounds[2].Y = Mouse.GetState().Y - editableBounds[2].Height / 2;

                        if (Mouse.GetState().Y > previousPositionY)
                        {
                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, creatMaker.cellSize.Y, creatMaker.cellSize.Width, creatMaker.cellSize.Height - (Mouse.GetState().Y - previousPositionY));

                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, editableBounds[2].Y + editableBounds[2].Height / 2, creatMaker.cellSize.Width, creatMaker.cellSize.Height);

                            previousPositionY = creatMaker.cellSize.Y;
                        }

                        else if (Mouse.GetState().Y < previousPositionY)
                        {
                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, creatMaker.cellSize.Y, creatMaker.cellSize.Width, creatMaker.cellSize.Height + (previousPositionY - Mouse.GetState().Y));

                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, editableBounds[2].Y + editableBounds[2].Height / 2, creatMaker.cellSize.Width, creatMaker.cellSize.Height);

                            previousPositionY = creatMaker.cellSize.Y;
                        }
                    }
                }

                // Lower Side
                if (usingSpecificBound[0] == false && usingSpecificBound[1] == false && usingSpecificBound[2] == false)
                {
                    if (mouseManager.IsMouseDown(editableBounds[3]))
                    {
                        usingSpecificBound[3] = true;

                        usingBounds = true;

                        editableBounds[3].Y = Mouse.GetState().Y - editableBounds[3].Height / 3;

                        if (Mouse.GetState().Y > previousPositionY + creatMaker.cellSize.Height)
                        {
                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, creatMaker.cellSize.Y, creatMaker.cellSize.Width, creatMaker.cellSize.Height + (Mouse.GetState().Y - (previousPositionY + creatMaker.cellSize.Height)));
                        }

                        else if (Mouse.GetState().Y < previousPositionY + creatMaker.cellSize.Height)
                        {
                            creatMaker.cellSize = new Rectangle(creatMaker.cellSize.X, creatMaker.cellSize.Y, creatMaker.cellSize.Width, creatMaker.cellSize.Height - ((previousPositionY + creatMaker.cellSize.Height) - Mouse.GetState().Y));
                        }
                    }
                }

                if (Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    mouseManager.mouseClicked = false;
                    usingBounds = false;
                    for(int i = 0; i < usingSpecificBound.Length; i++)
                    {
                        usingSpecificBound[i] = false;
                    }
                }


            }

            if (usingBounds == false)
            {
                if (mouseManager.IsMouseDown(creatMaker.cellSize) == true)
                {
                    usingPart = true;

                    creatMaker.cellSize = new Rectangle(Mouse.GetState().X - creatMaker.cellSize.Width / 2, Mouse.GetState().Y - creatMaker.cellSize.Height / 2, creatMaker.cellSize.Width, creatMaker.cellSize.Height);

                    if (Mouse.GetState().LeftButton == ButtonState.Released)
                    {
                        mouseManager.mouseClicked = false;
                        usingPart = false;
                    }

                }
            }

            //Left side
            editableBounds[0] = new Rectangle(creatMaker.cellSize.X - 15 / 2, creatMaker.cellSize.Y + creatMaker.cellSize.Height / 2 - 15 / 2, 15, 15);

            //Right side
            editableBounds[1] = new Rectangle(creatMaker.cellSize.X + creatMaker.cellSize.Width - 15 / 2, creatMaker.cellSize.Y + creatMaker.cellSize.Height / 2 - 15 / 2, 15, 15);

            //Upper Side
            editableBounds[2] = new Rectangle(creatMaker.cellSize.X + creatMaker.cellSize.Width / 2 - 15 / 2, creatMaker.cellSize.Y - 15 / 2, 15, 15);

            //Lower Side
            editableBounds[3] = new Rectangle(creatMaker.cellSize.X + creatMaker.cellSize.Width / 2 - 15 / 2, creatMaker.cellSize.Y + creatMaker.cellSize.Height - 15 / 2, 15, 15);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(cellTexture, creatMaker.cellSize, Color.Gray);

            foreach(Rectangle r in editableBounds)
            {
                _spriteBatch.Draw(cellTexture, r, Color.LightGreen);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
