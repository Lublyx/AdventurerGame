using System;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using Microsoft.Xna.Framework.Graphics;

namespace AdventurerGame;

public static class TextureManager
{
    public static Texture2D playerSpritIdle;
    public static Texture2D playerSpritWalk;
    public static Texture2D map;
    public static Texture2D inventory;

    public static void LoadTexture(Microsoft.Xna.Framework.Content.ContentManager content)
    {
        playerSpritIdle = content.Load<Texture2D>("Player/Sprite/idle");
        playerSpritWalk = content.Load<Texture2D>("Player/Sprite/walk");
        map = content.Load<Texture2D>("Map/map");
        inventory = content.Load<Texture2D>("Player/Inventory/Inventory");
    }
}
