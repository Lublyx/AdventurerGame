using System;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using Microsoft.Xna.Framework.Graphics;

namespace AdventurerGame;

public class TextureManager
{
    public Texture2D playerSprit;

    public void LoadTexture(Microsoft.Xna.Framework.Content.ContentManager content)
    {
        playerSprit = content.Load<Texture2D>("Player/Sprite/Soldier-Idle");
    }
}
