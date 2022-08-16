using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SpaceInvadersFV.Objects.Behavior;
using System.Diagnostics;
using System.Windows.Shapes;

namespace SpaceInvadersFV
{
    internal static class Mainloop
    {
        static int timeBetweenLoops = 17;
        public static async void Loop(Canvas game)
        {
            if (MainWindow.leftFlag) Player.MoveLeft(game);
            if (MainWindow.rightFlag) Player.MoveRight(game);
            if (MainWindow.fireFlag && Player.fireDelayFlag) Player.Fire(game);
            if (EnemyMovement.readyToMove)
            {
                MainWindow.Lvl1.Load(game);
                EnemyMovement.move(game);
            }
            FBulletMovement.Move(game);
            Objects.Behavior.CollisionCheck.Check(game);
            await Task.Delay(timeBetweenLoops);
            Loop(game);
        }
    }
}
