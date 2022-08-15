using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace SpaceInvadersFV
{
    internal class ShapesList
    {
        public List<Rectangle> enemyList = new();
        public List<Rectangle> fBulletList = new();
        public Rectangle? player;
        public Rectangle? goal;
        public void Load(Canvas game)
        {
            foreach (Rectangle thing in game.Children.OfType<Rectangle>())
            {
                switch (Convert.ToString(thing.Tag))
                {
                    case ("enemy"):
                        enemyList.Add(thing);
                        break;
                    case ("player"):
                        player = thing;
                        break;
                    case ("goal"):
                        goal = thing;
                        break;
                }
            }
        }
    }
}
