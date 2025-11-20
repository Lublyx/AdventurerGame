using System;
using System.Diagnostics;
using AdventurerGame.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventurerGame.Manager;

public class CameraManager
{

    public Matrix Transform;

    public void Follow(Player player)
    {
        Matrix Position = Matrix.CreateTranslation(-player.GetPosX - (player.GetSizeX/2), -player.GetPosY - (player.GetSizeY/2), 0);

        Matrix Offset = Matrix.CreateTranslation(Globals.CurrentWindowWidth/2, Globals.CurrentWindowHeight/2, 0);

        Transform = Position * Offset;
    }
}
