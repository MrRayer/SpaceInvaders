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
        }
        public static void LoadGoal(Canvas game, NamedRectangle goal)
        {
            goal.GetShape().Fill = Brushes.White;
            Canvas.SetTop(goal.GetShape(), Canvas.GetTop(MainWindow.EC.player) - 5 );
            Canvas.SetLeft(goal.GetShape(), 0);
            game.RegisterName(goal.GetName(), goal.GetShape());
            game.Children.Add(goal.GetShape());
        }
            /*
            while(placedEnemies < levelEnemies)
            {
                Trace.WriteLine($"DEBUG --- Placing enemies {placedEnemies}, enemies to place {levelEnemies}");
                int height;
                if (heightFlag) height = 15 + shape.GetHeight() * placedInColumn + 10 * placedInColumn;
                else height = 15 + shape.GetHeight()/2 + shape.GetHeight()*placedInColumn + 10*placedInColumn;
                SpawnEnemy(game, shape, height, 785-shape.GetWidth());
                MainWindow.EC.LoadEnemy(game, $"alien_{placedEnemies}");
                placedInColumn++;
                placedEnemies++;
                if (placedInColumn == rows)
                {
                    await Task.Delay(34);
                    if (heightFlag) { placedInColumn = 0; heightFlag = false; }
                    else { placedInColumn = 1; heightFlag = true; }
                }
            }
            */
    }
}
