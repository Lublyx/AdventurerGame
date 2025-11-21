using System;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static AdventurerGame.Model.ModelAnimationState;

namespace AdventurerGame.Model;

public class Entity
{

    protected int _health;
    protected float _speed;
    protected int _domage;
    protected float _posX;
    protected float _posY;
    protected int _sizeX;
    protected int _sizeY;
    protected Texture2D _texture;    
    public AnimationState _state;
    protected float _animationSpeed = 0.2f;

    public Entity(int Health, float Speed, int Experience, int Domage, float PosX, float PosY, int SizeX, int SizeY, Texture2D texture)
    {
        this._health = Health;
        this._speed = Speed;
        this._domage = Domage;
        this._posX = PosX;
        this._posY = PosY;
        this._sizeX = SizeX;
        this._sizeY = SizeY;
        this._texture = texture;
        this._state =AnimationState.Down;
    }

    public Texture2D GetTexture { get => _texture; }

    public float GetPosX { get => _posX; }
    public float GetPosY { get => _posY; }
    public int GetSizeX { get => _sizeX; }
    public int GetSizeY { get => _sizeY; }
    public AnimationState GetAnimationState { get => _state; }



    

}
