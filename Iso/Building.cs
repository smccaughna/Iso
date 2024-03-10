using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iso;

public enum BuildingType
{
	House
}

public class Building
{
	public Point Position { get; set; }
	public BuildingType Type { get; set; }

	private Texture2D Texture;

	public Building(Point position, BuildingType type)
	{
		Position = position;
		Type = type;

		switch (type)
		{
			case BuildingType.House:
				Texture = AssetManager.House;
				break;
			default:
				Texture = AssetManager.House;
				break;
		}
	}

	public void Draw(SpriteBatch _spriteBatch)
	{
		_spriteBatch.Begin();
		{
			_spriteBatch.Draw(Texture, new Vector2(GameHelper.ToScreen(Position).X - 20, GameHelper.ToScreen(Position).Y - 80), Color.White);
		}
		_spriteBatch.End();
	}
}
