using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Map_Collision
{
    class AnimatedSprite
    {
        Texture2D spriteSheet;
        Vector2 frameSize;
        public Vector2 position;
        int numberOfFrames;
        int currentFrame;
        float frameTime;        // in ms
        float currentFrameTime; // in ms
        AnimationStates currentAnimation;
        List<Animation> animations;


        public enum AnimationStates
        {
            Idle, 
            Walking,
            Jumping
        }

        public struct Animation
        {
            public Animation(AnimationStates _animState, int _startFrame, int _endFrame)
            {
                animState = _animState;
                startFrame = _startFrame;
                endFrame = _endFrame;
            }

            public AnimationStates animState;
            public int startFrame;
            public int endFrame;
        }

        public AnimatedSprite(Texture2D _spriteSheet, Vector2 _frameSize, int _numberOfFrames, float _frameTime, List<Animation> _animations)
        {
            spriteSheet = _spriteSheet;
            frameSize = _frameSize;
            numberOfFrames = _numberOfFrames;
            frameTime = _frameTime;
            currentFrame = 0;
            currentFrameTime = frameTime;
            animations = _animations;
            currentAnimation = AnimationStates.Idle;
        }

        public void Update(GameTime gameTime, AnimationStates _currentAnimation)
        {
            currentFrameTime -= gameTime.ElapsedGameTime.Milliseconds;
            if(currentFrameTime <= 0)
            {
                if(currentAnimation == _currentAnimation)
                {
                    if(animations.Find(p => p.animState == currentAnimation).endFrame <= currentFrame)
                    {
                        currentFrame = animations.Find(p => p.animState == currentAnimation).startFrame;
                    }
                    else
                    {
                        currentFrame++;
                    }
                }
                else
                {
                    currentAnimation = _currentAnimation;
                    currentFrame = animations.Find(p => p.animState == currentAnimation).startFrame;
                }
                currentFrameTime += frameTime;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 _position)
        {
            position = _position;
            spriteBatch.Draw(spriteSheet, new Rectangle(position.ToPoint(), frameSize.ToPoint()), new Rectangle(currentFrame * (int)frameSize.X, 0, (int)frameSize.X, (int)frameSize.Y), Color.White);
        }
    }
}
