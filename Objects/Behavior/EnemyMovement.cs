using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SpaceInvadersFV.Objects.Entities;
using System.Diagnostics;

namespace SpaceInvadersFV.Objects.Behavior
{
    internal static class EnemyMovement
    {
        public static int moveAmmount = 20;
        static bool horizontalFlag = false;
        public static bool readyToMove = true;
        public static int timeBetweenMoves = 300;

        public async static void move(Canvas game)
        {
            readyToMove = false;
            bool changeHFlag = false;
            foreach (BasicAlien enemy in MainWindow.EC.enemyList)
            {
                try
                {
                    if (horizontalFlag)
                    {
                        if (Canvas.GetLeft(enemy.shape) + moveAmmount < 785) Canvas.SetLeft(enemy.shape, Canvas.GetLeft(enemy.shape) + moveAmmount);
                        if (Canvas.GetLeft(enemy.shape) + moveAmmount >= 785) changeHFlag = true;
                    }
                    else
                    {
                        if (Canvas.GetLeft(enemy.shape) - moveAmmount > 0) Canvas.SetLeft(enemy.shape, Canvas.GetLeft(enemy.shape) - moveAmmount);
                        if (Canvas.GetLeft(enemy.shape) - moveAmmount <= 0) changeHFlag = true;
                    }
                }
                catch { }
            }
            if (changeHFlag)
            {
                if (horizontalFlag) horizontalFlag = false;
                else horizontalFlag = true;
            }
            await Task.Delay(timeBetweenMoves);
            readyToMove = true;
        }
    }
}
