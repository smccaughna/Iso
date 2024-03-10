using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iso;

public enum Block
{
	Empty,
	Grass,
	Dirt,
	Sand,
	Water
};

public class Tile
{
	public Block Texture { get; set; }


	private Point _position;

	public Tile(Block texture, Point position)
	{
		Texture = texture;
		_position = position;
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Begin();
		{
			switch (Texture)
			{
				case Block.Empty:
					spriteBatch.Draw(AssetManager.TileEmpty, GameHelper.ToScreen(_position), Color.White);
					break;
				case Block.Grass:
					spriteBatch.Draw(AssetManager.TileGrass, GameHelper.ToScreen(_position), Color.White);
					break;
				case Block.Dirt:
					spriteBatch.Draw(AssetManager.TileDirt, GameHelper.ToScreen(_position), Color.White);
					break;
				case Block.Sand:
					spriteBatch.Draw(AssetManager.TileSand, GameHelper.ToScreen(_position), Color.White);
					break;
				case Block.Water:
					spriteBatch.Draw(AssetManager.TileWater, GameHelper.ToScreen(_position), Color.White);
					break;
			}
		}
		spriteBatch.End();
	}
}