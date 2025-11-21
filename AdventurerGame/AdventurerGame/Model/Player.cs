using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AdventurerGame.Manager;
using static AdventurerGame.Model.ModelAnimationState;

namespace AdventurerGame.Model;

public class Player : Entity
{
    private Vector2 _velocity;
    protected int _experience;
    private IList<int> _inventory = new List<int>();
    private SpriteSheetAnimationManager _playerAnimation;
    private AnimationState _previousState;
    private Color _color = Color.White;

    public Player(int Health, float Speed, int Experience, int Domage, int PosX, int PosY, int SizeX, int SizeY, Texture2D texture) : base(Health, Speed, Experience, Domage, PosX, PosY, SizeX, SizeY, texture)
    {
        this._experience = Experience;
        this._playerAnimation = new SpriteSheetAnimationManager(_texture, 6, 8, _animationSpeed, 3, true);
        this._previousState = AnimationState.Down;

    }

    public void UpdatePlayer(GameTime gameTime)
    {
        Movement();
        AnimationManager();
        _playerAnimation.AnimateSpecificFrame(gameTime);
    }

    private void Movement()
    {
        _velocity = Vector2.Zero;

        if (Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            _velocity.Y -= 1;
            _state = AnimationState.Top;
            _previousState = _state;
            _texture = TextureManager.playerSpritWalk;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            _velocity.X += 1;
            _state = AnimationState.Right;
            _previousState = _state;
            _texture = TextureManager.playerSpritWalk;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Q) || Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            _velocity.X -= 1;
            _state = AnimationState.Left;
            _previousState = _state;
            _texture = TextureManager.playerSpritWalk;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            _velocity.Y += 1;
            _state = AnimationState.Down;
            _previousState = _state;
            _texture = TextureManager.playerSpritWalk;
        }
        if (_velocity != Vector2.Zero)
        {
            _velocity.Normalize();
        }
        else
        {
            _state = AnimationState.Idle;
            _texture = TextureManager.playerSpritIdle;
        }

        _posX += _velocity.X * _speed;
        _posY += _velocity.Y * _speed;
    }


    private void AnimationManager()
    {
        switch (_state)
        {
            case AnimationState.Top:
                _playerAnimation.ToggleIdleAnimation(_state);
                _playerAnimation.setAnimation(24, 31, _animationSpeed);
                break;
            case AnimationState.Right:
                _playerAnimation.ToggleIdleAnimation(_state);
                _playerAnimation.setAnimation(40, 47, _animationSpeed);
                break;
            case AnimationState.Left:
                _playerAnimation.ToggleIdleAnimation(_state);
                _playerAnimation.setAnimation(8, 15, _animationSpeed);
                break;
            case AnimationState.Down:
                _playerAnimation.ToggleIdleAnimation(_state);
                _playerAnimation.setAnimation(0, 7, _animationSpeed);
                break;
            case AnimationState.Idle:
                _playerAnimation.ToggleIdleAnimation(_state);
                if (_previousState == AnimationState.Top)
                {
                    _playerAnimation.setAnimation(24, 31, _animationSpeed);
                }
                if (_previousState == AnimationState.Right)
                {
                    _playerAnimation.setAnimation(40, 47, _animationSpeed);
                }
                if (_previousState == AnimationState.Left)
                {
                    _playerAnimation.setAnimation(8, 15, _animationSpeed);
                }
                if (_previousState == AnimationState.Down)
                {
                    _playerAnimation.setAnimation(0, 7, _animationSpeed);
                }

                break;
        }
    }

    public void DrawPlayer()
    {
        _playerAnimation.DrawAnimation((int)_posX, (int)_posY);
    }
}
