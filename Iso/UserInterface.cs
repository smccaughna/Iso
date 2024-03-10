using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace iso;

public enum BuildType
{
	Road,
	Erase,
	Building,
	None
}

public class UserInterface
{
	public BuildType SelectedBuildType { get; set; } = BuildType.None;

	private Rectangle _noneButton = new Rectangle(540, 680, 40, 40);
	private Rectangle _roadButton = new Rectangle(580, 680, 40, 40);
	private Rectangle _buildingButton = new Rectangle(620, 680, 40, 40);
    private Rectangle _eraseButton = new Rectangle(660, 680, 40, 40);

	public void Update(MouseState mouseState, KeyboardState keyboardState)
	{
		Keys[] pressedKeys = keyboardState.GetPressedKeys();

		if (pressedKeys.Length != 0)
		{
			if (pressedKeys.Contains(Keys.D1))
				SelectedBuildType = BuildType.None;
			if (pressedKeys.Contains(Keys.D2))
				SelectedBuildType = BuildType.Road;
			if (pressedKeys.Contains(Keys.D3))
				SelectedBuildType = BuildType.Building;
			if (pressedKeys.Contains(Keys.D4))
				SelectedBuildType = BuildType.Erase;
		}

		if (mouseState.LeftButton == ButtonState.Pressed)
		{
			if (_roadButton.Contains(mouseState.Position.X, mouseState.Position.Y))
				SelectedBuildType = BuildType.Road;
			else if (_noneButton.Contains(mouseState.Position.X, mouseState.Position.Y))
				SelectedBuildType = BuildType.None;
			else if (_buildingButton.Contains(mouseState.Position.X, mouseState.Position.Y))
				SelectedBuildType = BuildType.Building;
			else if (_eraseButton.Contains(mouseState.Position.X, mouseState.Position.Y))
				SelectedBuildType = BuildType.Erase;
		}

		if (mouseState.LeftButton == ButtonState.Pressed && SelectedBuildType == BuildType.Road)
			if (Iso.SelectedCell.X >= 0 && Iso.SelectedCell.X < Iso.WorldSize.X && Iso.SelectedCell.Y >= 0 && Iso.SelectedCell.Y < Iso.WorldSize.Y)
				Iso.Roads[Iso.SelectedCell.X, Iso.SelectedCell.Y] = new Road(Iso.SelectedCell);

		if (mouseState.LeftButton == ButtonState.Pressed && SelectedBuildType == BuildType.Erase)
			if (Iso.SelectedCell.X >= 0 && Iso.SelectedCell.X < Iso.WorldSize.X && Iso.SelectedCell.Y >= 0 && Iso.SelectedCell.Y < Iso.WorldSize.Y)
			{
				Iso.Roads[Iso.SelectedCell.X, Iso.SelectedCell.Y] = null;
				Iso.Buildings[Iso.SelectedCell.X, Iso.SelectedCell.Y] = null;
			}

		if (mouseState.LeftButton == ButtonState.Pressed && SelectedBuildType == BuildType.Building)
			if (Iso.SelectedCell.X >= 0 && Iso.SelectedCell.X < Iso.WorldSize.X && Iso.SelectedCell.Y >= 0 && Iso.SelectedCell.Y < Iso.WorldSize.Y)
				if (Iso.Buildings[Iso.SelectedCell.X, Iso.SelectedCell.Y] == null && Iso.Buildings[Iso.SelectedCell.X, Iso.SelectedCell.Y - 1] == null && Iso.Buildings[Iso.SelectedCell.X - 1, Iso.SelectedCell.Y] == null && Iso.Buildings[Iso.SelectedCell.X - 1, Iso.SelectedCell.Y - 1] == null)
					Iso.Buildings[Iso.SelectedCell.X, Iso.SelectedCell.Y] = new Building(Iso.SelectedCell, BuildingType.House);
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Begin();
		{
			spriteBatch.Draw(SelectedBuildType == BuildType.None ? AssetManager.NoneIconPressed : AssetManager.NoneIcon, new Vector2(540, 680), Color.White);
			spriteBatch.Draw(SelectedBuildType == BuildType.Road ? AssetManager.RoadIconPressed : AssetManager.RoadIcon, new Vector2(580, 680), Color.White);
			spriteBatch.Draw(SelectedBuildType == BuildType.Building ? AssetManager.BuildingIconPressed : AssetManager.BuildingIcon, new Vector2(620, 680), Color.White);
			spriteBatch.Draw(SelectedBuildType == BuildType.Erase ? AssetManager.EraseIconPressed : AssetManager.EraseIcon, new Vector2(660, 680), Color.White);

			spriteBatch.DrawString(AssetManager.Font, "1", new Vector2(559, 660), Color.Black);
			spriteBatch.DrawString(AssetManager.Font, "2", new Vector2(599, 660), Color.Black);
			spriteBatch.DrawString(AssetManager.Font, "3", new Vector2(639, 660), Color.Black);
			spriteBatch.DrawString(AssetManager.Font, "4", new Vector2(679, 660), Color.Black);
		}
		spriteBatch.End();
	}
}
