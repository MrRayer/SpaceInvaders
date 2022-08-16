using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using SpaceInvadersFV.Objects.shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpaceInvadersFV.Objects.Behavior
{
    internal static class Player
    {
        static int moveAmmount = 10;
        static int BulletCounter = 0;
        static int ReloadTime = 500;
        static bool bulletSideFlag = true;
        static bool bulletLeftReady = true;
        static bool bulletRightReady = true;
        static int fireDelay = 10;
        public static bool fireDelayFlag = true;
        public static void MoveLeft(Canvas game)
        {            
            if (Canvas.GetLeft(MainWindow.EC.player) - moveAmmount > 0)
            {
                Canvas.SetLeft(MainWindow.EC.player, Canvas.GetLeft(MainWindow.EC.player) - moveAmmount);
                Canvas.SetLeft(MainWindow.EC.bulletPlaceholderLeft, Canvas.GetLeft(MainWindow.EC.player) + 5);
                Canvas.SetLeft(MainWindow.EC.bulletPlaceholderRight, Canvas.GetLeft(MainWindow.EC.player) + MainWindow.playerShape.GetWidth() - 15);
            }
        }
        public static void MoveRight(Canvas game)
        {
            if (Canvas.GetLeft(MainWindow.EC.player) + moveAmmount < 800 - MainWindow.playerShape.GetWidth())
            {
                Canvas.SetLeft(MainWindow.EC.player, Canvas.GetLeft(MainWindow.EC.player) + moveAmmount);
                Canvas.SetLeft(MainWindow.EC.bulletPlaceholderLeft, Canvas.GetLeft(MainWindow.EC.player) + 5);
                Canvas.SetLeft(MainWindow.EC.bulletPlaceholderRight, Canvas.GetLeft(MainWindow.EC.player) + MainWindow.playerShape.GetWidth() - 15);
            }
        }
        public async static void Fire(Canvas game)
        {
            fireDelayFlag = false;
            NamedRectangle bullet = new(40, 10, $"bullet{BulletCounter}");
            try
            {
                ImageBrush enemySkin = new ImageBrush();
                enemySkin.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(MainWindow.projectFolder, @"..\..\..\lib\img\Sidewinder.png")));
                bullet.GetShape().Fill = enemySkin;
            }
            catch { bullet.GetShape().Fill = Brushes.White; }
            Canvas.SetTop(bullet.GetShape(), Canvas.GetTop(MainWindow.EC.player));
            if (bulletSideFlag && bulletLeftReady)
            {
                bulletLeftReady = false;
                bulletSideFlag = false;
                Canvas.SetLeft(bullet.GetShape(), Canvas.GetLeft(MainWindow.EC.player)+5);
                game.Children.Remove(MainWindow.EC.bulletPlaceholderLeft);
                game.RegisterName(bullet.GetName(), bullet.GetShape());
                game.Children.Add(bullet.GetShape());
                MainWindow.EC.LoadFBullet(game, $"bullet{BulletCounter}");
                BulletCounter++;
                await Task.Delay(ReloadTime);
                game.Children.Add(MainWindow.EC.bulletPlaceholderLeft);
                bulletLeftReady = true;
            }
            else if(bulletRightReady)
            {
                bulletRightReady = false;
                bulletSideFlag = true;
                Canvas.SetLeft(bullet.GetShape(), Canvas.GetLeft(MainWindow.EC.player)+MainWindow.playerShape.GetWidth()-bullet.GetWidth()-5);
                game.Children.Remove(MainWindow.EC.bulletPlaceholderRight);
                game.RegisterName(bullet.GetName(), bullet.GetShape());
                game.Children.Add(bullet.GetShape());
                MainWindow.EC.LoadFBullet(game, $"bullet{BulletCounter}");
                BulletCounter++;
                await Task.Delay(ReloadTime);
                game.Children.Add(MainWindow.EC.bulletPlaceholderRight);
                bulletRightReady = true;
            }
            await Task.Delay(fireDelay);
            fireDelayFlag = true;
        }
    }
}
