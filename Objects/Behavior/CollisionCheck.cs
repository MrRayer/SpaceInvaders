using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SpaceInvadersFV.Objects.Entities;

namespace SpaceInvadersFV.Objects.Behavior
{
    internal static class CollisionCheck
    {
        static int explosionCounter = 0;
        static ImageBrush enemySkinB = new ImageBrush() { ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(MainWindow.projectFolder, @"..\..\..\lib\img\SaucerB.png"))) };
        static ImageBrush explosionImg = new ImageBrush() { ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(MainWindow.projectFolder, @"..\..\..\lib\img\explosion.png"))) };
        public async static void Check(Canvas game)
        {
            Rectangle explosionShape = new() { Height = 15, Width = 15, Fill = explosionImg };
            List<Rectangle> bulletToRemove = new();
            List<BasicAlien> alienToRemove = new();
            List<BasicAlien>? enemyList = MainWindow.EC.enemyList;
            List<Rectangle>? fBulletList = MainWindow.EC.fBulletList;
            List<Rectangle>? explosionList = new();
            foreach (Rectangle bullet in fBulletList)
            {
                foreach (BasicAlien alien in enemyList)
                {
                    double alienLeft = Canvas.GetLeft(alien.shape);
                    double alienRight = Canvas.GetLeft(alien.shape) + MainWindow.Lvl1.AlienWidth;
                    double bulletLeft = Canvas.GetLeft(bullet);
                    double bulletRight = Canvas.GetLeft(bullet) + MainWindow.bulletPlaceholderLeft.GetWidth();
                    if (alienLeft < bulletLeft && bulletRight < alienRight)
                    {
                        double alienTop = Canvas.GetTop(alien.shape);
                        double alienBottom = Canvas.GetTop(alien.shape) + MainWindow.Lvl1.AlienHeight;
                        double bulletTop = Canvas.GetTop(bullet);
                        double bulletBottom = Canvas.GetTop(bullet)+MainWindow.bulletPlaceholderLeft.GetWidth()*2;
                        if (alienTop < bulletTop && bulletTop < alienBottom || alienTop < bulletTop+5 && bulletTop+5 < alienBottom || alienTop < bulletTop+10 && bulletTop+10 < alienBottom)
                        {
                            bulletToRemove.Add(bullet);
                            if (alien.health > 0)
                            {
                                alien.health--;
                                alien.shape.Fill = enemySkinB;
                            }
                            else alienToRemove.Add(alien);
                        }
                    }
                }
            }
            foreach (Rectangle bullet in bulletToRemove)
            {
                Canvas.SetTop(explosionShape, Canvas.GetTop(bullet) - 2.5);
                Canvas.SetLeft(explosionShape, Canvas.GetLeft(bullet) - 2.5);
                game.Children.Remove(bullet);
                game.UnregisterName(bullet.Name);
                MainWindow.EC.fBulletList.Remove(bullet);
                explosionShape.Name = $"explosion{explosionCounter}";
                game.RegisterName(explosionShape.Name, explosionShape);
                game.Children.Add(explosionShape);
                explosionList.Add(explosionShape);
            }
            foreach (BasicAlien alien in alienToRemove)
            {
                game.Children.Remove(alien.shape);
                MainWindow.EC.enemyList.Remove(alien);
            }
            await Task.Delay(150);
            foreach (Rectangle explosion in explosionList)
            {
                game.Children.Remove(explosion);
                game.UnregisterName(explosion.Name);
            }
        }
    }
}
