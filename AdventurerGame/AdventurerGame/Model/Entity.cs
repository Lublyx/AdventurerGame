using System;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
    }

    public Texture2D GetTexture{get => _texture;}

    public float GetPosX{get => _posX;}
    public float GetPosY{get => _posY;}
    public int GetSizeX{get => _sizeX;}
    public int GetSizeY{get => _sizeY;}



    private Vector2 _velocity;

    public void Movement()
    {
        _velocity = Vector2.Zero;
        if (Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            _velocity.Y -= 1;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            _velocity.X += 1;
            
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Q) || Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            _velocity.X -= 1;
            
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            _velocity.Y += 1;
            
        }
        if (_velocity != Vector2.Zero)
        {
            _velocity.Normalize();
        }

        _posX += _velocity.X * _speed;
        _posY += _velocity.Y * _speed;
    }
    
}
