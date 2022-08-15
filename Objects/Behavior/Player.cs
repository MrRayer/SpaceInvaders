using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SpaceInvadersFV.Objects.Behavior
{
    internal static class Player
    {
        static int moveAmmount = 10;
        public static void MoveLeft(Canvas game)
        {            
            if (Canvas.GetLeft(MainWindow.EC.player) - moveAmmount > 0)
            {
                Canvas.SetLeft(MainWindow.EC.player, Canvas.GetLeft(MainWindow.EC.player) - moveAmmount);
            }
        }
        public static void MoveRight(Canvas game)
        {
            if (Canvas.GetLeft(MainWindow.EC.player) + moveAmmount < 800 - MainWindow.playerShape.GetWidth())
            {
                Canvas.SetLeft(MainWindow.EC.player, Canvas.GetLeft(MainWindow.EC.player) + moveAmmount);
            }
        }
    }
}
