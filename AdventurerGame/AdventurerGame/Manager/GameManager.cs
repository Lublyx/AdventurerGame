using AdventurerGame.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AdventurerGame;

public class GameManager : Game
{
    private GraphicsDeviceManager _graphics;
    private CameraManager _camera;

    public GameManager()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

    }

    protected override void Initialize()
    {

        base.Initialize();
        Globals.Player = new(100, (float)1.3, 0, 10, 0, 0, 384, 384, TextureManager.playerSpritWalk);
        _camera = new();

    }

    protected override void LoadContent()
    {
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.WindowHeight = _graphics.GraphicsDevice.DisplayMode.Height;
        Globals.WindowWidth = _graphics.GraphicsDevice.DisplayMode.Width;
        Globals.CurrentWindowWidth = _graphics.PreferredBackBufferWidth;
        Globals.CurrentWindowHeight = _graphics.PreferredBackBufferHeight;
        TextureManager.LoadTexture(Content);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape)) { }
        //Exit();
        if (Keyboard.GetState().IsKeyDown(Keys.F11))
        {
            _graphics.ToggleFullScreen();
            if (_graphics.IsFullScreen)
            {
                Globals.CurrentWindowWidth = Globals.WindowWidth;
                Globals.CurrentWindowHeight = Globals.WindowHeight;
            }
            else
            {
                Globals.CurrentWindowWidth = _graphics.PreferredBackBufferWidth;
                Globals.CurrentWindowHeight = _graphics.PreferredBackBufferHeight;
            }
        }
        Globals.Player.ToggleOpenInventory();

        



        Globals.Player.UpdatePlayer(gameTime);
        _camera.Follow(Globals.Player);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        Globals.spriteBatch.Begin(transformMatrix: _camera.Transform, samplerState: SamplerState.PointWrap);
        GraphicsDevice.Clear(Color.CornflowerBlue);
        Globals.spriteBatch.Draw(TextureManager.map, new Vector2(0, 0), Color.White);
        Globals.Player.DrawPlayer();
        Globals.Player.DrawnPlayerUtilities();

        Globals.spriteBatch.End();
        base.Draw(gameTime);
    }
}