using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map_Collision
{
    public class CutsceneBeacon
    {
        Vector2 position;
        float range;
        List<CutsceneController.MoveOrder> orderQueue;
        SpriteFont font;

        public CutsceneBeacon(Vector2 _position, float _range, List<CutsceneController.MoveOrder> _orderQueue, SpriteFont _font)
        {
            position = _position;
            range = _range;
            orderQueue = _orderQueue;
            font = _font;
        }

        public void Update()
        {
            if ((GameStuff.Instance.player.position - position).Length() < range && !GameStuff.Instance.player.cutsceneController.active)
            {
                Console.WriteLine("Fuck Sleep");
                GameStuff.Instance.player.cutsceneController = new CutsceneController(new List<CutsceneController.MoveOrder>(orderQueue), font);
            }
        }
    }
}
