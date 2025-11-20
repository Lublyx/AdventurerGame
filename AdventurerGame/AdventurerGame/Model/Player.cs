using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace AdventurerGame.Model;

public class Player : Entity
{
    protected int _experience;
    private IList<int> _inventory = new List<int>();

    public Player(int Health, float Speed, int Experience, int Domage, int PosX, int PosY, int SizeX, int SizeY, Texture2D texture) : base(Health, Speed, Experience, Domage, PosX, PosY, SizeX, SizeY, texture)
    {
        this._experience = Experience;
        
    }
}
