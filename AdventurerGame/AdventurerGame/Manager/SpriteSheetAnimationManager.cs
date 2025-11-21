using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static AdventurerGame.Model.ModelAnimationState;

namespace AdventurerGame.Manager;

public class SpriteSheetAnimationManager
{
    private Texture2D _spriteSheet;
    private List<Rectangle> _frames;
    private int _currentFrame;
    private float _frameDuration;
    private float _frameTimer;
    private bool _loop;
    private bool _isPlaying = true;
    private float _scaleMultiplicator;
    private int _row;
    private int _column;
    private int _frameWidth;
    private int _frameHeight;
    private float _posX = 0f;
    private float _posY = 0f;
    private Color _color = Color.White;
    private int _firstFrame;
    private int _lastFrame;
    private float _duration;


    public SpriteSheetAnimationManager(Texture2D spritSheet, int row, int column, float frameDuration, float scaleMultiplicator, bool loop = true)
    {
        _spriteSheet = spritSheet;
        _row = row;
        _column = column;
        _frameDuration = frameDuration;
        _loop = loop;
        _scaleMultiplicator = scaleMultiplicator;
        _frames = new List<Rectangle>();
        _frameWidth = spritSheet.Width / column;
        _frameHeight = spritSheet.Height / row;
        _currentFrame = 0;
        _posX = 0;
        _posY = 0;
        CutSpritSheet();
    }

    public void ToggleIdleAnimation(AnimationState State)
    {
        if (State == AnimationState.Idle)
        {
            _spriteSheet = TextureManager.playerSpritIdle;
        }
        else
        {
            _spriteSheet = TextureManager.playerSpritWalk;
        }
    }


    public void UpdateAnimations(GameTime gameTime)
    {
        AnimeSpritSheet(gameTime);
    }

    private void CutSpritSheet()
    {
        for (int y = 0; y < _row; y++)
        {
            for (int x = 0; x < _column; x++)
            {
                int frameX = x * _frameWidth;
                int frameY = y * _frameHeight;

                _frames.Add(new Rectangle(frameX, frameY, _frameWidth, _frameHeight));
            }
        }
    }

    public void AnimeSpritSheet(GameTime gameTime)
    {
        if (_isPlaying)
        {
            _frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_frameTimer >= _frameDuration)
            {
                _currentFrame++;

                if (_currentFrame >= _frames.Count)
                {
                    _currentFrame = 0;
                    if (!_loop)
                    {
                        _isPlaying = false;
                    }
                }
                _frameTimer = 0;
            }
        }
    }

    public void DrawAnimation(int posX, int posY)
    {
        _posX = posX;
        _posY = posY;
        if (_currentFrame >= 0 && _currentFrame < _frames.Count)
        {
            Rectangle rectangle = new Rectangle((int)_posX, (int)_posY, (int)(_frames[_currentFrame].Width * _scaleMultiplicator), (int)(_frames[_currentFrame].Height * _scaleMultiplicator));
            Globals.spriteBatch.Draw(_spriteSheet, rectangle, _frames[_currentFrame], _color);
        }
    }


    public void setAnimation(int animationStart, int animationEnd, float duration)
    {
        _firstFrame = animationStart;
        _lastFrame = animationEnd;
        _duration = duration;
    }

    public void AnimateSpecificFrame(GameTime gameTime)
    {
        if (_isPlaying)
        {
            _frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (_frameTimer >= _frameDuration)
            {

                if (_currentFrame < _firstFrame || _currentFrame > _lastFrame)
                {
                    _currentFrame = _firstFrame;
                }
                else
                {
                _currentFrame++;
                    if (_currentFrame > _lastFrame)
                    {
                        _currentFrame = _firstFrame;
                    }
                }
                _frameTimer -= _duration;
            }
        }
        else
        {
            _currentFrame = _firstFrame;
        }
    }

}
