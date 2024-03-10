using Microsoft.Xna.Framework;
using System;

namespace iso;

public static class GameHelper
{
	public static Vector2 ToScreen(Point worldPos)
	{
		return new Vector2
		(
			(Iso.Origin.X * Iso.TileSize.X) + (worldPos.X - worldPos.Y) * (Iso.TileSize.X / 2),
			(Iso.Origin.Y * Iso.TileSize.Y) + (worldPos.X + worldPos.Y) * (Iso.TileSize.Y / 2)
		);
	}

	public static Tile[,] GenerateMap()
	{
		Tile[,] map = new Tile[Iso.WorldSize.X, Iso.WorldSize.Y];

		for (int y = 0; y < Iso.WorldSize.Y; y++)
			for (int x = 0; x < Iso.WorldSize.X; x++)
				if (x >= Math.Sin(0.25 * y) + 6)
					map[x, y] = new Tile(Block.Grass, new Point(x, y));
				else if (x <= Math.Sin(0.25 * y) + 3)
					map[x, y] = new Tile(Block.Water, new Point(x, y));
				else
					map[x, y] = new Tile(Block.Sand, new Point(x, y));

		return map;
	}
}