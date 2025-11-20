using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace AdventurerGame.Manager;

public class SpriteSheetAnimationManager
{
    private Texture2D _spriteSheet;
    private IList<Rectangle> _frames = new List<Rectangle>();
    private int _currentFrame;
    private float _frameDuration;
    private float _frameTimer;
    private bool _loop;
    private bool _isPlaying = true;
    private float _scaleMultiplayer;
    private int _row;
    private int _column;
    private int _frameWidth;
    private int _frameHeight;
    private float _posX = 0f;
    private float _posY = 0f;

    public Texture2D SpriteSheet { get => _spriteSheet; set => _spriteSheet = value; }
    public IList<Rectangle> Frames { get => _frames; set => _frames = value; }
    public int CurrentFrame { get => _currentFrame; set => _currentFrame = value; }
    public float FrameDuration { get => _frameDuration; set => _frameDuration = value; }
    public float FrameTimer { get => _frameTimer; set => _frameTimer = value; }
    public bool Loop { get => _loop; set => _loop = value; }
    public bool IsPlaying { get => _isPlaying; set => _isPlaying = value; }
    public float ScaleMultiplayer { get => _scaleMultiplayer; set => _scaleMultiplayer = value; }
    public int Row { get => _row; set => _row = value; }
    public int Column { get => _column; set => _column = value; }
    public int FrameWidth { get => _frameWidth; set => _frameWidth = value; }
    public int FrameHeight { get => _frameHeight; set => _frameHeight = value; }
    public float PosX { get => _posX; set => _posX = value; }
    public float PosY { get => _posY; set => _posY = value; }

    public SpriteSheetAnimationManager()
    {
        
    }
    
}
