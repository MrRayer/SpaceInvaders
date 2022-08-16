using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Media;
using SpaceInvadersFV.Objects.shapes;
using System.Windows.Media.Imaging;
using System.IO;

namespace SpaceInvadersFV
{
    internal static class Setup
    {
        public static void LoadPlayer(Canvas game, NamedRectangle player)
        {
            try
            {
                ImageBrush playerSkin = new ImageBrush();
                playerSkin.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(MainWindow.projectFolder, @"..\..\..\lib\img\pship.png")));
                player.GetShape().Fill = playerSkin;
            }
            catch { player.GetShape().Fill = Brushes.Blue; }
            Canvas.SetTop(player.GetShape(), 585 - player.GetHeight());
            Canvas.SetLeft(player.GetShape(), 400 - player.GetWidth() / 2);
            game.RegisterName(player.GetName(), player.GetShape());
            game.Children.Add(player.GetShape());
            MainWindow.EC.LoadPlayer(game);
            LoadBPH(game, false);
            LoadBPH(game, true);
        }
        public static void LoadBPH(Canvas game, bool side)
        {
            try
            {
                ImageBrush bulletOffSkin = new ImageBrush();
                bulletOffSkin.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(MainWindow.projectFolder, @"..\..\..\lib\img\SidewinderOff.png")));
                MainWindow.bulletPlaceholderLeft.GetShape().Fill = bulletOffSkin;
                MainWindow.bulletPlaceholderRight.GetShape().Fill = bulletOffSkin;
            }
            catch { MainWindow.bulletPlaceholderLeft.GetShape().Fill = Brushes.White; MainWindow.bulletPlaceholderRight.GetShape().Fill = Brushes.White; }
            if (side)
            {
                Canvas.SetTop(MainWindow.bulletPlaceholderLeft.GetShape(), Canvas.GetTop(MainWindow.EC.player));
                Canvas.SetLeft(MainWindow.bulletPlaceholderLeft.GetShape(), Canvas.GetLeft(MainWindow.EC.player) + 5);
                game.RegisterName(MainWindow.bulletPlaceholderLeft.GetName(), MainWindow.bulletPlaceholderLeft.GetShape());
                game.Children.Add(MainWindow.bulletPlaceholderLeft.GetShape());
            }
            else
            {
                Canvas.SetTop(MainWindow.bulletPlaceholderRight.GetShape(), Canvas.GetTop(MainWindow.EC.player));
                Canvas.SetLeft(MainWindow.bulletPlaceholderRight.GetShape(), Canvas.GetLeft(MainWindow.EC.player) + MainWindow.playerShape.GetWidth() - 15);
                game.RegisterName(MainWindow.bulletPlaceholderRight.GetName(), MainWindow.bulletPlaceholderRight.GetShape());
                game.Children.Add(MainWindow.bulletPlaceholderRight.GetShape());
            }
            MainWindow.EC.LoadPlaceholder(game, side);
        }
        public static void LoadGoal(Canvas game, NamedRectangle goal)
        {
            goal.GetShape().Fill = Brushes.White;
            Canvas.SetTop(goal.GetShape(), Canvas.GetTop(MainWindow.EC.player) - 5 );
            Canvas.SetLeft(goal.GetShape(), 0);
            game.RegisterName(goal.GetName(), goal.GetShape());
            game.Children.Add(goal.GetShape());
            MainWindow.EC.LoadGoal(game);
        }
    }
}
