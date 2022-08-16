using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SpaceInvadersFV.Objects.Behavior
{
    internal class FBulletMovement
    {
        public static int moveAmmount = 20;

        public static void Move(Canvas game)
        {
            List<Rectangle> toDestroy = new();
            foreach (Rectangle bullet in MainWindow.EC.fBulletList)
            {
                try
                {
                    if (Canvas.GetTop(bullet) - moveAmmount >= 0) Canvas.SetTop(bullet, Canvas.GetTop(bullet) - moveAmmount);
                    else toDestroy.Add(bullet);
                }
                catch { }
            }
            foreach (Rectangle bullet in toDestroy)
            {
                game.Children.Remove(bullet);
                MainWindow.EC.fBulletList.Remove(bullet);
            }
        }
    }
}
