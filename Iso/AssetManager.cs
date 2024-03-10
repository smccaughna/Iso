using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace iso;

public static class AssetManager
{
	public static Texture2D TileEmpty { get; set; }
	public static Texture2D TileGrass { get; set; }
	public static Texture2D TileDirt { get; set; }
	public static Texture2D TileSand { get; set; }
	public static Texture2D TileWater { get; set; }
	public static Texture2D TileSelect { get; set; }

	public static Texture2D RoadNS { get; set; }
	public static Texture2D RoadEW { get; set; }
	public static Texture2D RoadIntersection { get; set; }
	public static Texture2D RoadTNorth { get; set; }
	public static Texture2D RoadTSouth { get; set; }
	public static Texture2D RoadTEast { get; set; }
	public static Texture2D RoadTWest { get; set; }
	public static Texture2D RoadLNE { get; set; }
	public static Texture2D RoadLNW { get; set; }
	public static Texture2D RoadLSE { get; set; }
	public static Texture2D RoadLSW { get; set; }

	public static Texture2D RoadIcon { get; set; }
	public static Texture2D NoneIcon { get; set; }
	public static Texture2D EraseIcon { get; set; }
	public static Texture2D BuildingIcon { get; set; }
	public static Texture2D RoadIconPressed { get; set; }
	public static Texture2D NoneIconPressed { get; set; }
	public static Texture2D EraseIconPressed { get; set; }
	public static Texture2D BuildingIconPressed { get; set; }

	public static Texture2D House { get; set; }

	public static SpriteFont Font { get; set; }

	public static void LoadContent(ContentManager content)
	{
		TileEmpty = content.Load<Texture2D>("sprites/tileEmpty");
		TileGrass = content.Load<Texture2D>("sprites/tileGrass");
		TileDirt = content.Load<Texture2D>("sprites/tileDirt");
		TileSand = content.Load<Texture2D>("sprites/tileSand");
		TileWater = content.Load<Texture2D>("sprites/tileWater");
		TileSelect = content.Load<Texture2D>("sprites/tileSelect");

		RoadNS = content.Load<Texture2D>("sprites/road/roadNS");
		RoadEW = content.Load<Texture2D>("sprites/road/roadEW");
		RoadIntersection = content.Load<Texture2D>("sprites/road/roadIntersection");
		RoadTNorth = content.Load<Texture2D>("sprites/road/roadTNorth");
		RoadTSouth = content.Load<Texture2D>("sprites/road/roadTSouth");
		RoadTEast = content.Load<Texture2D>("sprites/road/roadTEast");
		RoadTWest = content.Load<Texture2D>("sprites/road/roadTWest");
		RoadLNE = content.Load<Texture2D>("sprites/road/roadLNE");
		RoadLNW = content.Load<Texture2D>("sprites/road/roadLNW");
		RoadLSE = content.Load<Texture2D>("sprites/road/roadLSE");
		RoadLSW = content.Load<Texture2D>("sprites/road/roadLSW");

		RoadIcon = content.Load<Texture2D>("sprites/icons/roadIcon");
		NoneIcon = content.Load<Texture2D>("sprites/icons/noneIcon");
		EraseIcon = content.Load<Texture2D>("sprites/icons/eraseIcon");
		BuildingIcon = content.Load<Texture2D>("sprites/icons/buildingIcon");
		RoadIconPressed = content.Load<Texture2D>("sprites/icons/roadIcon_pressed");
		NoneIconPressed = content.Load<Texture2D>("sprites/icons/noneIcon_pressed");
		EraseIconPressed = content.Load<Texture2D>("sprites/icons/eraseIcon_pressed");
		BuildingIconPressed = content.Load<Texture2D>("sprites/icons/buildingIcon_pressed");

		House = content.Load<Texture2D>("sprites/buildings/house");

		Font = content.Load<SpriteFont>("fonts/openSansPX");
	}
}
