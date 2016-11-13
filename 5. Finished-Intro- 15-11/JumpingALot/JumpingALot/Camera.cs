using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpingALot
{
    class Camera
    {

        public Viewport viewport { get; private set; }

        public Vector2 position;
        public Vector2 origin;

        public Rectangle view;

        public float scale { get; private set; }

        public float speed { get; private set; }

        Player player;

        public Camera(Viewport _viewport, Player player)
        {
            this.player = player;
            speed = 1;
            scale = 1;
            viewport = _viewport;
            position = new Vector2(0, 0);
            origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);

        }



        public void Reset()
        {
            position = new Vector2(0, 0);
            scale = 1;
            origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public Matrix GetViewMatrix()
        {
            position = player.position - viewport.Bounds.Size.ToVector2() / 2;

            Rectangle mapPos = GameStuff.Instance.map.Bounds;

            position.X = MathHelper.Clamp(position.X, mapPos.X, mapPos.X + mapPos.Width);
            position.Y = MathHelper.Clamp(position.Y, mapPos.Y, mapPos.Y + mapPos.Height);

            view = new Rectangle(new Point((int)position.X, (int)position.Y), new Point(viewport.Width, viewport.Height));

            return Matrix.CreateTranslation(new Vector3(-position, 1));
        }
    }
}
