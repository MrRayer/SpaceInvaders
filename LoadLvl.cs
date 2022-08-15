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
using System.Diagnostics;

namespace SpaceInvadersFV
{
    public class LoadLvl
    {
        int placedEnemies = 0;
        int placedInColumn = 0;
        bool heightFlag = false;
        int levelEnemies;
        int rows;
        int AlienHeight;
        int AlienWidth;
        public LoadLvl(int _levelEnemies, int _rows, int EHeight, int EWidth)
        {
            levelEnemies = _levelEnemies;
            rows = _rows;
            AlienHeight = EHeight;
            AlienWidth = EWidth;
        }
        public void Load(Canvas game)
        {
            Trace.WriteLine($"DEBUG --- PlacedEnemies:{placedEnemies} vs LevelEnemies:{levelEnemies}");
            while (placedInColumn < rows && placedEnemies < levelEnemies)
            {
                NamedRectangle shape = new(AlienHeight, AlienWidth, $"Alien{placedEnemies}");
                int height;
                if (heightFlag) height = 15 + shape.GetHeight() * placedInColumn + 10 * placedInColumn;
                else height = 15 + shape.GetHeight() / 2 + shape.GetHeight() * placedInColumn + 10 * placedInColumn;
                SpawnEnemy(game, shape, height, 785 - shape.GetWidth());
                MainWindow.EC.LoadEnemy(game, $"Alien{placedEnemies}");
                placedInColumn++;
                placedEnemies++;
            }
            if (placedInColumn == rows)
            {
                if (heightFlag) { placedInColumn = 0; heightFlag = false; }
                else { placedInColumn = 1; heightFlag = true; }
            }
        }
        public static void SpawnEnemy(Canvas game, NamedRectangle enemy, int top, int left)
        {
            try
            {
                ImageBrush enemySkin = new ImageBrush();
                enemySkin.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(MainWindow.projectFolder, @"..\..\..\lib\img\alien1.png")));
                enemy.GetShape().Fill = enemySkin;
            }
            catch { enemy.GetShape().Fill = Brushes.Blue; }
            Canvas.SetTop(enemy.GetShape(), top);
            Canvas.SetLeft(enemy.GetShape(), left);
            game.RegisterName(enemy.GetName(), enemy.GetShape());
            game.Children.Add(enemy.GetShape());
        }
    }
}
