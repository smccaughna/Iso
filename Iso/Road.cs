using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iso;

public enum RoadOrientation
{
	NorthSouth,
	EastWest,
	Intersection,
	TNorth,
	TSouth,
	TEast,
	TWest,
	LNorthEast,
	LNorthWest,
	LSouthEast,
	LSouthWest
}

public class Road
{
	public Point Position { get; set; }
	public RoadOrientation Orientation { get; set; }

	private Texture2D _texture;

	public Road(Point position)
	{
		Position = position;
		_texture = AssetManager.RoadNS;
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Begin();
		{
			spriteBatch.Draw(_texture, GameHelper.ToScreen(Position), Color.White);
		}
		spriteBatch.End();
	}

	public void Update()
	{
		Road north = null, south = null, east = null, west = null;

		if (Position.X != Iso.WorldSize.X - 1 && Position.Y != Iso.WorldSize.Y - 1 && Position.X != 0 && Position.Y != 0)
		{
			north = Iso.Roads[Position.X, Position.Y - 1];
			south = Iso.Roads[Position.X, Position.Y + 1];
			east = Iso.Roads[Position.X + 1, Position.Y];
			west = Iso.Roads[Position.X - 1, Position.Y];
		}

		if (north != null || south != null)
			Orientation = RoadOrientation.NorthSouth;
		if (east != null || west != null)
			Orientation = RoadOrientation.EastWest;

		if (north != null && west != null && south == null && east == null)
			Orientation = RoadOrientation.LNorthWest;
		if (north != null && east != null && south == null && west == null)
			Orientation = RoadOrientation.LNorthEast;
		if (south != null && west != null && north == null && east == null)
			Orientation = RoadOrientation.LSouthWest;
		if (south != null && east != null && north == null && west == null)
			Orientation = RoadOrientation.LSouthEast;

		if (west != null && north != null && east != null && south == null)
			Orientation = RoadOrientation.TNorth;
		if (west != null && south != null && east != null && north == null)
			Orientation = RoadOrientation.TSouth;
		if (north != null && east != null && south != null && west == null)
			Orientation = RoadOrientation.TEast;
		if (north != null && west != null && south != null && east == null)
			Orientation = RoadOrientation.TWest;

		if (north != null && south != null && east != null && west != null)
			Orientation = RoadOrientation.Intersection;

		if (north == null && south == null && east == null && west == null)
			Orientation = RoadOrientation.Intersection;

		switch (Orientation)
		{
			case RoadOrientation.NorthSouth:
				_texture = AssetManager.RoadNS;
				break;
			case RoadOrientation.EastWest:
				_texture = AssetManager.RoadEW;
				break;
			case RoadOrientation.Intersection:
				_texture = AssetManager.RoadIntersection;
				break;
			case RoadOrientation.TNorth:
				_texture = AssetManager.RoadTNorth;
				break;
			case RoadOrientation.TSouth:
				_texture = AssetManager.RoadTSouth;
				break;
			case RoadOrientation.TEast:
				_texture = AssetManager.RoadTEast;
				break;
			case RoadOrientation.TWest:
				_texture = AssetManager.RoadTWest;
				break;
			case RoadOrientation.LNorthEast:
				_texture = AssetManager.RoadLNE;
				break;
			case RoadOrientation.LNorthWest:
				_texture = AssetManager.RoadLNW;
				break;
			case RoadOrientation.LSouthEast:
				_texture = AssetManager.RoadLSE;
				break;
			case RoadOrientation.LSouthWest:
				_texture = AssetManager.RoadLSW;
				break;
		}
	}
}
