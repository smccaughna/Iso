using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace iso;

public class Iso : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;
	private UserInterface _userInterface;

	public static Point WorldSize { get; } = new Point(30, 30);
	public static Point TileSize { get; } = new Point(40, 20);
	public static Point Origin { get; } = new Point(15, 2);

	public static Tile[,] Map { get; set; }
	public static Road[,] Roads { get; set; }
	public static Building[,] Buildings { get; set; }

	public static Point MouseCell { get; set; }
	public static Point SelectedCell { get; set; }

	public static Point MousePos { get; set; }
	public static Point MouseOffset { get; set; }

	public Iso()
	{
		_graphics = new GraphicsDeviceManager(this)
		{
			PreferredBackBufferWidth = 1240,
			PreferredBackBufferHeight = 720
		};

		Content.RootDirectory = "Content";
		IsMouseVisible = true;
	}

	protected override void Initialize()
	{
		Map = GameHelper.GenerateMap();
		Roads = new Road[WorldSize.X, WorldSize.Y];
        Buildings = new Building[WorldSize.X, WorldSize.Y];

        _userInterface = new UserInterface();

		base.Initialize();
	}

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		AssetManager.LoadContent(Content);
	}

	protected override void Update(GameTime gameTime)
	{
		MouseState mouseState = Mouse.GetState();
		KeyboardState keyboardState = Keyboard.GetState();

		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
			Exit();

		MousePos = new Point(mouseState.Position.X, mouseState.Position.Y);
		MouseCell = new Point(MousePos.X / TileSize.X, MousePos.Y / TileSize.Y);
		MouseOffset = new Point(MousePos.X % TileSize.X, MousePos.Y % TileSize.Y);

		SelectedCell = new Point((MouseCell.Y - Origin.Y) + (MouseCell.X - Origin.X), (MouseCell.Y - Origin.Y) - (MouseCell.X - Origin.X));

		if (MouseOffset.Y > 0.5 * MouseOffset.X + 10)
			SelectedCell += new Point(0, 1); // bottom left
		else if (MouseOffset.Y > -0.5 * MouseOffset.X + 30)
			SelectedCell += new Point(1, 0); // bottom right
		else if (MouseOffset.Y < 0.5 * MouseOffset.X - 10)
			SelectedCell += new Point(0, -1); // top right
		else if (MouseOffset.Y < -0.5 * MouseOffset.X + 10)
			SelectedCell += new Point(-1, 0); // top left

		foreach (Road road in Roads)
			road?.Update();

		_userInterface.Update(mouseState, keyboardState);
		
		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.LightSkyBlue);

		foreach (Tile tile in Map)
			tile.Draw(_spriteBatch);

		foreach (Road road in Roads)
			road?.Draw(_spriteBatch);

		foreach (Building building in Buildings)
			building?.Draw(_spriteBatch);

		_userInterface.Draw(_spriteBatch);

		base.Draw(gameTime);
	}
}
